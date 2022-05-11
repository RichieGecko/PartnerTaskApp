namespace PartnerTaskApp.Models.ViewModels
{
    public class CalculationViewModel
    {
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public int ParentPartnerId { get; set; }
        public decimal FeePercent { get; set; }
        public decimal TeamShopingAmount { get; set; }
        public decimal TotalShopingAmount { get; set; }
        public decimal PartnerBonus { get; set; }
    }
}
