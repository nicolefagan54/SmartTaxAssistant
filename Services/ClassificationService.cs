using SmartTaxAssistant.Web.Data;
using SmartTaxAssistant.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTaxAssistant.Web.Services
{
    public class ClassificationService : IClassificationService
    {
        private readonly SmartTaxContext _context;

        public ClassificationService(SmartTaxContext context)
        {
            _context = context;
        }

        public async Task ClassifyAsync(IEnumerable<ExtractedLineItem> items, string returnType)
        {
            // Pre-fetch categories for the return type (or all if needed)
            // A smarter implementation would cache this or be more selective
            var categories = await _context.TaxCategories.ToListAsync();

            foreach (var item in items)
            {
                if (string.IsNullOrWhiteSpace(item.RawText)) continue;
                
                var text = item.RawText.ToUpperInvariant();
                string? targetCode = null;

                // Simple hardcoded rules for demonstration
                if (text.Contains("T4") || text.Contains("EMPLOYMENT INCOME"))
                {
                    targetCode = "EMP_INCOME";
                }
                else if (text.Contains("RENT"))
                {
                    targetCode = "BUS_EXP_RENT";
                }
                
                // Assign category if found
                if (targetCode != null)
                {
                    var category = categories.FirstOrDefault(c => c.Code == targetCode);
                    // Match return type if strictly required, or allow cross-type for simplicity?
                    // Assuming we only assign if it matches the requested ReturnType or generic
                    if (category != null)
                    {
                        item.TaxCategoryId = category.TaxCategoryId;
                    }
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
