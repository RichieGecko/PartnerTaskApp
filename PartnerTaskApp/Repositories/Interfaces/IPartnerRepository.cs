using PartnerTaskApp.Models.DatabaseModels;
using System.Collections.Generic;

namespace PartnerTaskApp.Repositories.Interfaces
{
    public interface IPartnerRepository
    {
        bool AddToPartner(Partner partner);
        public List<Partner> GetAllPartners();
        public Partner GetPartnerById(int id);
    }
}
