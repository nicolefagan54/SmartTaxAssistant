using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartTaxAssistant.Web.Models
{
    public class QuestionnaireQuestion
    {
        public int QuestionnaireQuestionId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Code { get; set; } = string.Empty;
        
        [Required]
        [StringLength(500)]
        public string Text { get; set; } = string.Empty;
        
        [Required]
        [StringLength(20)]
        public string ReturnType { get; set; } = string.Empty;
        
        public int OrderIndex { get; set; }

        public ICollection<QuestionnaireAnswer> QuestionnaireAnswers { get; set; } = new List<QuestionnaireAnswer>();
    }
}
