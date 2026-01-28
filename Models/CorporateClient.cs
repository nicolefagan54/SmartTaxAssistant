using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTaxAssistant.Web.Models
{
    public class CorporateClient
    {
        public int CorporateClientId { get; set; }
        
        [StringLength(200)]
        public string? LegalName { get; set; }
        
        [StringLength(50)]
        public string? BusinessNumber { get; set; }
        
        [StringLength(50)]
        public string? IncorporationProvince { get; set; }
        
        [Column(TypeName = "DATE")]
        public DateTime? FiscalYearStart { get; set; }
        
        [Column(TypeName = "DATE")]
        public DateTime? FiscalYearEnd { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<TaxReturn> TaxReturns { get; set; } = new List<TaxReturn>();
    }
}
