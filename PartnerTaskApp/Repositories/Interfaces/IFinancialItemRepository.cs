using PartnerTaskApp.Models.DatabaseModels;
using System.Collections.Generic;

namespace PartnerTaskApp.Repositories.Interfaces
{
    public interface IFinancialItemRepository
    {
        bool AddNewFinancialItem(FinancialItem financialItem);
        void DeleteAllItems();
        bool UpdateFinancialItem(FinancialItem financialItem);
        void DeleteFinancialItemById(int id);
        List<FinancialItem> GetAllFinancialItems();
        List<FinancialItem> GetAllPartnerFinancialItems(int partnerId);
        FinancialItem GetFinancialItemById(int id);
    }
}
