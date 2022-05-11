using PartnerTaskApp.Models.ViewModels;
using System.Collections.Generic;

namespace PartnerTaskApp.Services.Interfaces
{
    public interface IFinancialItemService
    {
        List<FinancialItemViewModel> GetAllFinancialItems();
        bool AddNewFinancialItem(FinancialItemViewModel model);
        decimal GetPartnerTotalAmount(int partnerId);
        void DeleteAllFinancialItems();
        FinancialItemViewModel GetFinancialItemById(int id);
        void DeleteFinancialItemById(int id);
        void UpdateFinancialItem(FinancialItemViewModel model);
    }
}
