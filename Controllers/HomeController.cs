using Microsoft.AspNetCore.Mvc;
using SmartTaxAssistant.Web.Models;
using SmartTaxAssistant.Web.Data;
using SmartTaxAssistant.Web.Services;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace SmartTaxAssistant.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SmartTaxContext _context;
        private readonly IPdfParser _pdfParser;
        private readonly IClassificationService _classifier;

        public HomeController(ILogger<HomeController> logger, SmartTaxContext context, IPdfParser pdfParser, IClassificationService classifier)
        {
            _logger = logger;
            _context = context;
            _pdfParser = pdfParser;
            _classifier = classifier;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var questions = await _context.QuestionnaireQuestions.OrderBy(q => q.OrderIndex).ToListAsync();
            return View(questions);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int taxYear, string returnType, IFormFile pdf, Dictionary<int, string> answers)
        {
            var taxReturn = new TaxReturn
            {
                TaxYear = taxYear,
                ReturnType = returnType,
                Status = "Draft"
            };

            _context.TaxReturns.Add(taxReturn);
            await _context.SaveChangesAsync();

            // Save Answers
            if (answers != null && answers.Any())
            {
                var answerEntities = new List<QuestionnaireAnswer>();
                foreach (var kvp in answers)
                {
                    answerEntities.Add(new QuestionnaireAnswer
                    {
                        TaxReturnId = taxReturn.TaxReturnId,
                        QuestionnaireQuestionId = kvp.Key,
                        AnswerText = kvp.Value
                    });
                }
                _context.QuestionnaireAnswers.AddRange(answerEntities);
                await _context.SaveChangesAsync();
            }

            var pdfDoc = new PdfDocument
            {
                TaxReturnId = taxReturn.TaxReturnId,
                FileName = pdf.FileName,
                OriginalPath = $"uploads/{pdf.FileName}"
            };

            _context.PdfDocuments.Add(pdfDoc);
            await _context.SaveChangesAsync();

            using var stream = pdf.OpenReadStream();
            var items = await _pdfParser.ParseAsync(stream, pdfDoc.PdfDocumentId);

            _context.ExtractedLineItems.AddRange(items);
            await _context.SaveChangesAsync();

            await _classifier.ClassifyAsync(items, returnType);

            return RedirectToAction("Index", "TaxSummary", new { taxReturnId = taxReturn.TaxReturnId });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
