using System;
using System.Collections.Generic;

namespace SmartTaxAssistant.Web.Models
{
    public class Taxpayer
    {
        public int TaxpayerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SIN { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ResidencyProvince { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<TaxReturn> TaxReturns { get; set; } = new List<TaxReturn>();
    }
}
