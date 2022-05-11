using PartnerTaskApp.Models.DatabaseModels;
using PartnerTaskApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace PartnerTaskApp.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        private Random random = new Random();
        public PartnerRepository()
        {
            partners = new List<Partner>
            {
                new Partner
                {
                    PartnerName = "Partner1",
                    FeePercent = random.Next(1, 20),
                    PartnerId = 1,
                    ParentPartnerId = 0
                },
                new Partner
                {
                    PartnerName = "Partner2",
                    FeePercent = random.Next(1, 20),
                    PartnerId = 2,
                    ParentPartnerId = 1
                },
                new Partner
                {
                    PartnerName = "Partner3",
                    FeePercent = random.Next(1, 20),
                    PartnerId = 3,
                    ParentPartnerId = 1
                },
                new Partner
                {
                    PartnerName = "Partner4",
                    FeePercent = random.Next(1, 20),
                    PartnerId = 4,
                    ParentPartnerId = 2
                },
                new Partner
                {
                    PartnerName = "Partner5",
                    FeePercent = random.Next(1, 20),
                    PartnerId = 5,
                    ParentPartnerId = 3
                },
                new Partner
                {
                    PartnerName = "Partner6",
                    FeePercent = random.Next(1, 20),
                    PartnerId = 6,
                    ParentPartnerId = 4
                },
                new Partner
                {
                    PartnerName = "Partner7",
                    FeePercent = random.Next(1, 20),
                    PartnerId = 7,
                    ParentPartnerId = 4
                },
                new Partner
                {
                    PartnerName = "Partner8",
                    FeePercent = random.Next(1, 20),
                    PartnerId = 8,
                    ParentPartnerId = 5
                },
                new Partner
                {
                    PartnerName = "Partner9",
                    FeePercent = random.Next(1, 20),
                    PartnerId = 9,
                    ParentPartnerId = 5
                },
                new Partner
                {
                    PartnerName = "Partner10",
                    FeePercent = random.Next(1, 20),
                    PartnerId = 10,
                    ParentPartnerId = 4
                },
                new Partner
                {
                    PartnerName = "Partner11",
                    FeePercent = random.Next(1, 20),
                    PartnerId = 11,
                    ParentPartnerId = 6
                },
                new Partner
                {
                    PartnerName = "Partner12",
                    FeePercent = random.Next(1, 20),
                    PartnerId = 12,
                    ParentPartnerId  = 7
                },
            };
        }
        private List<Partner> partners;

        public bool AddToPartner(Partner partner)
        {
            if (partner != null)
            {
                if (partners == null)
                {
                    partners = new List<Partner>();
                }
                partners.Add(partner);
                return true;
            }

            return false;
        }

        public List<Partner> GetAllPartners()
        {
            return partners;
        }

        public Partner GetPartnerById(int id)
        {
            return partners.Find(x => x.PartnerId == id);
        }
    }
}
