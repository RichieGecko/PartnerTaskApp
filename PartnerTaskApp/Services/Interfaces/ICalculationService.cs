using PartnerTaskApp.Models.ViewModels;
using System.Collections.Generic;

namespace PartnerTaskApp.Services.Interfaces
{
    public interface ICalculationService
    {
        List<CalculationViewModel> CalculatePartnerData();
    }
}
