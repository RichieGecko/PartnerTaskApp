using System;

namespace PartnerTaskApp.Models.DatabaseModels
{
    public class FinancialItem
    {
        public int FinancialItemId { get; set; }
        public int PartnerId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
