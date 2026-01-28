using SmartTaxAssistant.Web.Data;
using SmartTaxAssistant.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTaxAssistant.Web.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly SmartTaxContext _context;

        public QuestionnaireService(SmartTaxContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuestionnaireQuestion>> GetQuestionsAsync(string returnType)
        {
            return await _context.QuestionnaireQuestions
                .Where(q => q.ReturnType == returnType)
                .OrderBy(q => q.OrderIndex)
                .ToListAsync();
        }

        public async Task SaveAnswersAsync(int taxReturnId, IEnumerable<QuestionnaireAnswer> answers)
        {
            foreach (var answer in answers)
            {
                answer.TaxReturnId = taxReturnId;
                _context.QuestionnaireAnswers.Add(answer);
            }
            await _context.SaveChangesAsync();
        }
    }
}
