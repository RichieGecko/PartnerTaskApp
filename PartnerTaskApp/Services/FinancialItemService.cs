using PartnerTaskApp.Models.DatabaseModels;
using PartnerTaskApp.Models.ViewModels;
using PartnerTaskApp.Repositories.Interfaces;
using PartnerTaskApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PartnerTaskApp.Services
{
    public class FinancialItemService : IFinancialItemService
    {
        private readonly IFinancialItemRepository _financialItemRepository;
        private readonly IPartnerService _partnerService;
        public FinancialItemService(IFinancialItemRepository financialItemRepository, IPartnerService partnerService)
        {
            _financialItemRepository = financialItemRepository;
            _partnerService = partnerService;
        }

        public bool AddNewFinancialItem(FinancialItemViewModel model)
        {
            if(model != null)
            {
                var financialItem = CastToFinancialItem(model);
                if(financialItem != null)
                {
                    _financialItemRepository.AddNewFinancialItem(financialItem);
                    return true;
                }
            }

            return false;
        }

        private FinancialItem CastToFinancialItem(FinancialItemViewModel model)
        {
            int partnerId = 0;

            var parsed = int.TryParse(model.PartnerId, out partnerId);

            if (!parsed)
            {
                return null;
            }

            var financialItem = new FinancialItem
            {
                Amount = model.Amount,
                PartnerId = partnerId,
                Date = model.DateTime,
            };

            if(model.FinancialItemId != null && model.FinancialItemId > 0)
            {
                financialItem.FinancialItemId = model.FinancialItemId.Value;
            }

            return financialItem;
        }

        public List<FinancialItemViewModel>  GetAllFinancialItems()
        {
            var financialItems = _financialItemRepository.GetAllFinancialItems();
            if(financialItems != null)
            {
                var financialItemViewModels = financialItems.Select(x => CastToFinancialItemViewModel(x)).ToList();

                return financialItemViewModels;
            }

            return null;
        }

        public decimal GetPartnerTotalAmount(int partnerId)
        {
            var partnerFinancialItems = _financialItemRepository.GetAllPartnerFinancialItems(partnerId);

            return partnerFinancialItems.Sum(x => x.Amount);
        }

        public void DeleteAllFinancialItems()
        {
            _financialItemRepository.DeleteAllItems();
        }

        public FinancialItemViewModel GetFinancialItemById(int id)
        {
            var financialItem = _financialItemRepository.GetFinancialItemById(id);

            return CastToFinancialItemViewModel(financialItem);
        }

        public void DeleteAllFinancialItems(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteFinancialItemById(int id)
        {
            _financialItemRepository.DeleteFinancialItemById(id);
        }

        public void UpdateFinancialItem(FinancialItemViewModel model)
        {
            FinancialItem financialItem = CastToFinancialItem(model);
            _financialItemRepository.UpdateFinancialItem(financialItem);
        }

        private FinancialItemViewModel CastToFinancialItemViewModel(FinancialItem financialItem)
        {
            return new FinancialItemViewModel
            {
                Amount = financialItem.Amount,
                DateTime = financialItem.Date,
                PartnerName = _partnerService.GetPartnerById(financialItem.PartnerId).PartnerName,
                FinancialItemId = financialItem.FinancialItemId,
                PartnerId = financialItem.PartnerId.ToString()
            };
        }
    }
}
