using SmartTaxAssistant.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartTaxAssistant.Web.Services
{
    public interface IQuestionnaireService
    {
        Task<IEnumerable<QuestionnaireQuestion>> GetQuestionsAsync(string returnType);
        Task SaveAnswersAsync(int taxReturnId, IEnumerable<QuestionnaireAnswer> answers);
    }
}
