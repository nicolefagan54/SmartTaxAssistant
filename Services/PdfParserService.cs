using SmartTaxAssistant.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SmartTaxAssistant.Web.Services
{
    public class PdfParserService : IPdfParser
    {
        public async Task<IList<ExtractedLineItem>> ParseAsync(Stream pdfStream, int pdfDocumentId)
        {
            // Mock implementation to make the app "functional" for demonstration
            var mockItems = new List<ExtractedLineItem>
            {
                new ExtractedLineItem { PdfDocumentId = pdfDocumentId, RawText = "Employment Income (Box 14)", Amount = 65000.00m, LineNumber = 1 },
                new ExtractedLineItem { PdfDocumentId = pdfDocumentId, RawText = "CPP Contributions (Box 16)", Amount = 3500.00m, LineNumber = 2 },
                new ExtractedLineItem { PdfDocumentId = pdfDocumentId, RawText = "EI Premiums (Box 18)", Amount = 950.00m, LineNumber = 3 },
                new ExtractedLineItem { PdfDocumentId = pdfDocumentId, RawText = "Income Tax Deducted (Box 22)", Amount = 12000.00m, LineNumber = 4 }
            };

            return await Task.FromResult(mockItems);
        }
    }
}
