using SmartTaxAssistant.Web.Models;
using System.Threading.Tasks;

namespace SmartTaxAssistant.Web.Services
{
    public interface ITaxComputationService
    {
        Task CalculateTaxAsync(int taxReturnId);
    }
}
