using Microsoft.AspNetCore.Mvc;
using SmartTaxAssistant.Web.Services;
using SmartTaxAssistant.Web.Data;
using SmartTaxAssistant.Web.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SmartTaxAssistant.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly IQuestionnaireService _questionnaireService;
        private readonly SmartTaxContext _context;

        public QuestionnaireController(IQuestionnaireService questionnaireService, SmartTaxContext context)
        {
            _questionnaireService = questionnaireService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Start(int id)
        {
            var taxReturn = await _context.TaxReturns.FindAsync(id);
            if (taxReturn == null) return NotFound();

            var questions = await _questionnaireService.GetQuestionsAsync(taxReturn.ReturnType);
            ViewBag.TaxReturnId = id;
            return View("Index", questions);
        }

        [HttpPost]
        public async Task<IActionResult> Start(int id, Dictionary<int, string> answers)
        {
            var answerEntities = new List<QuestionnaireAnswer>();
            foreach (var kvp in answers)
            {
                answerEntities.Add(new QuestionnaireAnswer
                {
                    QuestionnaireQuestionId = kvp.Key,
                    AnswerText = kvp.Value
                });
            }

            await _questionnaireService.SaveAnswersAsync(id, answerEntities);
            return RedirectToAction("Index", "TaxSummary", new { id = id });
        }
    }
}
