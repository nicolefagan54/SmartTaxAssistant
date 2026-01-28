using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartTaxAssistant.Web.Models
{
    public class TaxCategory
    {
        public int TaxCategoryId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Code { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        [StringLength(20)]
        public string ReturnType { get; set; } = string.Empty;

        public ICollection<ExtractedLineItem> ExtractedLineItems { get; set; } = new List<ExtractedLineItem>();
    }
}
