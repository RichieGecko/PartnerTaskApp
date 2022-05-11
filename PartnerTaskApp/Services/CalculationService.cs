using PartnerTaskApp.Models.DatabaseModels;
using PartnerTaskApp.Models.ViewModels;
using PartnerTaskApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PartnerTaskApp.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly IPartnerService _partnerService;
        private readonly IFinancialItemService _financialItemService;

        private const int INITIAL_PARTNER = 1;
        public CalculationService(IPartnerService partnerService, IFinancialItemService financialItemService)
        {
            _partnerService = partnerService;
            _financialItemService = financialItemService;
        }

        /// <summary>
        /// This method calculate partners data
        /// </summary>
        /// <returns></returns>
        public List<CalculationViewModel> CalculatePartnerData()
        {
            var partners = _partnerService.GetAllPartners();

            var partnersViewModel = partners.Select(x => CastToCalculationViewModel(x)).ToList();

            var initialPartner = partnersViewModel.FirstOrDefault(x => x.PartnerId == INITIAL_PARTNER);

            if(initialPartner != null)
            {
                initialPartner.TotalShopingAmount = CalculateAmounts(initialPartner, partnersViewModel);
                initialPartner.PartnerBonus += initialPartner.TotalShopingAmount * GetPercentageValue(initialPartner.FeePercent);
            }

            return partnersViewModel;
        }

        /// <summary>
        /// This recursive method calculate all amounts and partner bonuses
        /// </summary>
        /// <param name="partner"></param>
        /// <param name="partnersViewModel"></param>
        /// <returns></returns>
        private decimal CalculateAmounts(CalculationViewModel partner, List<CalculationViewModel> partnersViewModel)
        {
            foreach (var childPartner in partnersViewModel)
            {
                if(partner.PartnerId == childPartner.ParentPartnerId)
                {
                    var tempTeamShopingAmount = partner.TeamShopingAmount;
                    partner.TeamShopingAmount += CalculateAmounts(childPartner, partnersViewModel);

                    //Check that the current TeamShipingAmoount is higher than the previous one to increase partner bonus
                    if (partner.TeamShopingAmount > tempTeamShopingAmount)
                    {
                        if (partner.FeePercent > childPartner.FeePercent)
                        {
                            var feePercentForChildAmounth = partner.FeePercent - childPartner.FeePercent;
                            partner.PartnerBonus += partner.TeamShopingAmount * GetPercentageValue(feePercentForChildAmounth);
                        }
                        else
                        {
                            partner.PartnerBonus += partner.TeamShopingAmount * GetPercentageValue(partner.FeePercent);
                        }
                    }
                }
            }

            var partnerTotalShopingAmounth = CalculatePartnerTotalAmount(partner.PartnerId);
            partner.TotalShopingAmount = partnerTotalShopingAmounth + partner.TeamShopingAmount;
            if (partnerTotalShopingAmounth > 0)
            {
                partner.PartnerBonus += partnerTotalShopingAmounth * GetPercentageValue(partner.FeePercent);
            }

            return partner.TotalShopingAmount;
        }

        /// <summary>
        /// Return percentage value to calculate bonus
        /// </summary>
        /// <param name="feePercent"></param>
        /// <returns></returns>
        private decimal GetPercentageValue(decimal feePercent)
        {
            return feePercent / 100;
        }

        /// <summary>
        /// This method calculate partner total amount
        /// </summary>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        private decimal CalculatePartnerTotalAmount(int partnerId)
        {
            return _financialItemService.GetPartnerTotalAmount(partnerId);
        }

        /// <summary>
        /// This method cast Parner class to CalculationViewModel
        /// </summary>
        /// <param name="partner"></param>
        /// <returns></returns>
        private CalculationViewModel CastToCalculationViewModel(Partner partner)
        {
            return new CalculationViewModel
            {
                PartnerId = partner.PartnerId,
                PartnerName = partner.PartnerName,
                FeePercent = partner.FeePercent,
                ParentPartnerId = partner.ParentPartnerId,
            };
        }
    }
}
