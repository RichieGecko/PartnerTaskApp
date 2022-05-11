using System.Collections.Generic;

namespace PartnerTaskApp.Models.DatabaseModels
{
    public class Partner
    {
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public int ParentPartnerId { get; set; }
        public decimal FeePercent { get; set; }
    }
}
