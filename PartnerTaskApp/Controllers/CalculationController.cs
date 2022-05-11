using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartnerTaskApp.Services.Interfaces;

namespace PartnerTaskApp.Controllers
{
    public class CalculationController : Controller
    {
        private readonly ICalculationService _calculationService;
        public CalculationController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }
        // GET: CalculationController
        public ActionResult Index()
        {
            var calculationViewModel = _calculationService.CalculatePartnerData();
            return View(calculationViewModel);
        }
    }
}
