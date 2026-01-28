using SmartTaxAssistant.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SmartTaxAssistant.Web.Services
{
    public interface IPdfParser
    {
        Task<IList<ExtractedLineItem>> ParseAsync(Stream pdfStream, int pdfDocumentId);
    }
}
