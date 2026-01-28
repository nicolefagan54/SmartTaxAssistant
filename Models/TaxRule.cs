using System;
using System.ComponentModel.DataAnnotations;

namespace SmartTaxAssistant.Web.Models
{
    public class TaxRule
    {
        public int TaxRuleId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Code { get; set; } = string.Empty;
        
        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        [StringLength(20)]
        public string ReturnType { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
    }
}
