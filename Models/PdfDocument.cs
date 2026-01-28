using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTaxAssistant.Web.Models
{
    public class PdfDocument
    {
        public int PdfDocumentId { get; set; }
        
        [Required]
        public int TaxReturnId { get; set; }
        
        [StringLength(255)]
        public string? FileName { get; set; }
        
        [StringLength(500)]
        public string? OriginalPath { get; set; }
        
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("TaxReturnId")]
        public TaxReturn? TaxReturn { get; set; }

        public ICollection<ExtractedLineItem> ExtractedLineItems { get; set; } = new List<ExtractedLineItem>();
    }
}
