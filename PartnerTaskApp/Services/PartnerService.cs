using PartnerTaskApp.Models.DatabaseModels;
using PartnerTaskApp.Models.ViewModels;
using PartnerTaskApp.Repositories.Interfaces;
using PartnerTaskApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PartnerTaskApp.Services
{
    public class PartnerService : IPartnerService
    {
        private IPartnerRepository _partnerRepository;

        public PartnerService(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public List<Partner> GetAllPartners()
        {
            return _partnerRepository.GetAllPartners();
        }

        public List<PartnerViewModel> GetAllPartnersAsViewModel()
        {
            var partners = _partnerRepository.GetAllPartners();

            if(partners != null)
            {
                return partners.Select(x => CastToPartnerViewModel(x)).ToList();
            }

            return null;
        }

        public PartnerViewModel GetPartnerById(int id)
        {

            var partner = _partnerRepository.GetPartnerById(id);
            if (partner == null)
            {
                return null;
            }

            var response = new PartnerViewModel
            {
                PartnerId = partner.PartnerId,
                FeePercent = partner.FeePercent,
                PartnerName = partner.PartnerName,
                ParentPartnerId = partner.ParentPartnerId
            };

            return response;
        }

        private PartnerViewModel CastToPartnerViewModel(Partner partner)
        {
            return new PartnerViewModel
            {
                PartnerId = partner.PartnerId,
                FeePercent = partner.FeePercent,
                PartnerName = partner.PartnerName
            };
        }
    }
}
