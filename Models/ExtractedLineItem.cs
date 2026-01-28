using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTaxAssistant.Web.Models
{
    public class ExtractedLineItem
    {
        public int ExtractedLineItemId { get; set; }
        
        [Required]
        public int PdfDocumentId { get; set; }
        
        [StringLength(1000)]
        public string? RawText { get; set; }
        
        public decimal? Amount { get; set; }
        
        public int? TaxCategoryId { get; set; }
        public int? LineNumber { get; set; }

        [ForeignKey("PdfDocumentId")]
        public PdfDocument? PdfDocument { get; set; }

        [ForeignKey("TaxCategoryId")]
        public TaxCategory? TaxCategory { get; set; }
    }
}
