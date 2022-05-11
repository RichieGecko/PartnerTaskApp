using PartnerTaskApp.Models.DatabaseModels;
using PartnerTaskApp.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PartnerTaskApp.Repositories
{
    public class FinancialItemRepository : IFinancialItemRepository
    {
        private List<FinancialItem> financialItems;
        private int financialItemCounter;

        public FinancialItemRepository()
        {
            financialItems = new List<FinancialItem>();
        }

        public bool AddNewFinancialItem(FinancialItem financialItem)
        {
            if(financialItem != null)
            {
                financialItemCounter++;
                financialItem.FinancialItemId = financialItemCounter;
                financialItems.Add(financialItem);
                return true;
            }

            return false;
        }

        public void DeleteFinancialItemById(int id)
        {
            if(id > 0 && financialItems != null)
            {
                var financialItemsForDelete = financialItems.FirstOrDefault(x => x.FinancialItemId == id);

                if(financialItemsForDelete != null)
                {
                    financialItems.Remove(financialItemsForDelete);
                }
            }
        }

        public List<FinancialItem> GetAllFinancialItems()
        {
            return financialItems;
        }

        public List<FinancialItem> GetAllPartnerFinancialItems(int partnerId)
        {
            return financialItems.Where(x => x.PartnerId == partnerId).ToList();
        }

        public void DeleteAllItems()
        {
            financialItems = null;
            financialItems = new List<FinancialItem>();
        }

        public bool UpdateFinancialItem(FinancialItem financialItem)
        {
            if(financialItem != null && financialItems != null && financialItems.Any())
            {
                var selectedFinancialItem = financialItems.FirstOrDefault(x => x.FinancialItemId == financialItem.FinancialItemId);
                if(selectedFinancialItem != null)
                {
                    selectedFinancialItem.Amount = financialItem.Amount;
                    selectedFinancialItem.Date = financialItem.Date;
                    selectedFinancialItem.PartnerId = financialItem.PartnerId;
                    return true;
                }
            }

            return false;
        }

        public FinancialItem GetFinancialItemById(int id)
        {
            return financialItems.FirstOrDefault(x => x.FinancialItemId == id);
        }
    }
}
