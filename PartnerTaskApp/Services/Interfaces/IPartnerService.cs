using PartnerTaskApp.Models.DatabaseModels;
using PartnerTaskApp.Models.ViewModels;
using System.Collections.Generic;

namespace PartnerTaskApp.Services.Interfaces
{
    public interface IPartnerService
    {
        List<PartnerViewModel> GetAllPartnersAsViewModel();
        PartnerViewModel GetPartnerById(int id);
        List<Partner> GetAllPartners();
    }
}
