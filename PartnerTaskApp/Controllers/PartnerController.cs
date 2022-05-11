using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartnerTaskApp.Services.Interfaces;
using System;

namespace PartnerTaskApp.Controllers
{
    public class PartnerController : Controller
    {
        private readonly IPartnerService _partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        // GET: PartnerController
        public ActionResult Index()
        {
            return View(_partnerService.GetAllPartnersAsViewModel());
        }
    }
}
