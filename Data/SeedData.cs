using SmartTaxAssistant.Web.Models;
using System.Linq;

namespace SmartTaxAssistant.Web.Data
{
    public static class SeedData
    {
        public static void Initialize(SmartTaxContext context)
        {
            if (!context.QuestionnaireQuestions.Any())
            {
                context.QuestionnaireQuestions.AddRange(
                    new QuestionnaireQuestion { Code="Q_PERSONAL_RESIDENT_ON", Text="Were you a resident of Ontario for the entire tax year (Ontario Tax Act)?", ReturnType="Personal", OrderIndex=1 },
                    new QuestionnaireQuestion { Code="Q_PERSONAL_EMPLOYMENT", Text="Did you earn employment income (T4)?", ReturnType="Personal", OrderIndex=2 },
                    new QuestionnaireQuestion { Code="Q_PERSONAL_SELFEMPLOYED", Text="Did you have self-employment income?", ReturnType="Personal", OrderIndex=3 },
                    new QuestionnaireQuestion { Code="Q_PERSONAL_ON_TRILLIUM", Text="Are you applying for the Ontario Trillium Benefit (Energy/Property Tax Credit)?", ReturnType="Personal", OrderIndex=4 },
                    new QuestionnaireQuestion { Code="Q_PERSONAL_INVESTMENT", Text="Did you earn investment income?", ReturnType="Personal", OrderIndex=5 },

                    new QuestionnaireQuestion { Code="Q_CORP_ACTIVE_BUSINESS", Text="Did the corporation carry on active business in Ontario?", ReturnType="Corporate", OrderIndex=1 },
                    new QuestionnaireQuestion { Code="Q_CORP_SMALL_BUS", Text="Is the corporation a CCPC eligible for the Ontario Small Business Deduction?", ReturnType="Corporate", OrderIndex=2 },
                    new QuestionnaireQuestion { Code="Q_CORP_ASSOCIATED_CORPS", Text="Is the corporation associated with any others?", ReturnType="Corporate", OrderIndex=3 }
                );

                context.SaveChanges();
            }
        }
    }
}
