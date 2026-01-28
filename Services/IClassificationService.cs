using SmartTaxAssistant.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartTaxAssistant.Web.Services
{
    public interface IClassificationService
    {
        Task ClassifyAsync(IEnumerable<ExtractedLineItem> items, string returnType);
    }
}
