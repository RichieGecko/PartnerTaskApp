using System.Collections.Generic;

namespace PartnerTaskApp.Models.ViewModels
{
    public class PartnerViewModel
    {
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public int ParentPartnerId { get; set; }
        public decimal FeePercent { get; set; }
    }
}
