using System;

namespace PartnerTaskApp.Models.ViewModels
{
    public class FinancialItemViewModel
    {
        public int? FinancialItemId { get; set; }
        public string PartnerName  { get; set; }
        public string PartnerId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
    }
}
