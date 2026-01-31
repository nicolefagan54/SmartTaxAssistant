using Microsoft.AspNetCore.Mvc;
using SmartTaxAssistant.Web.Data;
using System.Linq;

namespace SmartTaxAssistant.Web.Controllers
{
    public class TaxSummaryController : Controller
    {
        private readonly SmartTaxContext _context;

        public TaxSummaryController(SmartTaxContext context)
        {
            _context = context;
        }

        public IActionResult Index(int taxReturnId)
        {
            var items = _context.ExtractedLineItems
                .Where(i => i.PdfDocument != null && i.PdfDocument.TaxReturnId == taxReturnId)
                .ToList();

            return View(items);
        }
    }
}
