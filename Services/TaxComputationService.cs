using SmartTaxAssistant.Web.Models;
using System.Threading.Tasks;

namespace SmartTaxAssistant.Web.Services
{
    public class TaxComputationService : ITaxComputationService
    {
        public async Task CalculateTaxAsync(int taxReturnId)
        {
             // TODO: specific implementation
             await Task.CompletedTask;
        }
    }
}
