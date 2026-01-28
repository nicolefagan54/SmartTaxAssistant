using System;
using System.Collections.Generic;

namespace SmartTaxAssistant.Web.Models
{
    public class TaxReturn
    {
        public int TaxReturnId { get; set; }
        public int? TaxpayerId { get; set; }
        public int? CorporateClientId { get; set; }
        public int TaxYear { get; set; }
        public string ReturnType { get; set; } = "Personal";
        public string Status { get; set; } = "Draft";
        
        // Calculated Summary Fields
        public decimal? TotalIncome { get; set; }
        public decimal? TotalTaxPaid { get; set; }
        public decimal? EstimatedBalance { get; set; } // Positive = Refund, Negative = Owed

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Taxpayer? Taxpayer { get; set; }
        public CorporateClient? CorporateClient { get; set; }
        public ICollection<PdfDocument> PdfDocuments { get; set; } = new List<PdfDocument>();
        public ICollection<ExtractedLineItem> ExtractedLineItems { get; set; } = new List<ExtractedLineItem>();
    }
}
