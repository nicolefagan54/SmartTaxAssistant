using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTaxAssistant.Web.Models
{
    public class QuestionnaireAnswer
    {
        public int QuestionnaireAnswerId { get; set; }
        
        [Required]
        public int TaxReturnId { get; set; }
        
        [Required]
        public int QuestionnaireQuestionId { get; set; }
        
        [StringLength(1000)]
        public string? AnswerText { get; set; }

        [ForeignKey("TaxReturnId")]
        public TaxReturn? TaxReturn { get; set; }

        [ForeignKey("QuestionnaireQuestionId")]
        public QuestionnaireQuestion? QuestionnaireQuestion { get; set; }
    }
}
