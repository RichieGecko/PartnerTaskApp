using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PartnerTaskApp.Models.ViewModels;
using PartnerTaskApp.Services.Interfaces;
using System.Linq;

namespace PartnerTaskApp.Controllers
{
    public class FinancialItemController : Controller
    {
        private readonly IFinancialItemService _financialItemService;
        private readonly IPartnerService _partnerService;

        public FinancialItemController(IFinancialItemService financialItemService, IPartnerService partnerService)
        {
            _financialItemService = financialItemService;
            _partnerService = partnerService;
        }
        // GET: FinancialItemController
        public ActionResult Index()
        {
            return View(_financialItemService.GetAllFinancialItems());
        }

        // GET: FinancialItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FinancialItemController/Create
        public ActionResult Create()
        {
            var partners = _partnerService.GetAllPartnersAsViewModel();
            if(partners != null)
            {
                ViewBag.Partners = partners.Select(x => new SelectListItem() { Value = x.PartnerId.ToString(), Text = x.PartnerName });
            }
            
            return View();
        }

        // POST: FinancialItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]FinancialItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var added = _financialItemService.AddNewFinancialItem(model);
                    if (!added)
                    {
                        return View();
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            return View(model);
        }

        // GET: FinancialItemController/Edit/5
        public ActionResult Edit(int id)
        {
            var partners = _partnerService.GetAllPartnersAsViewModel();
            if (partners != null)
            {
                ViewBag.Partners = partners.Select(x => new SelectListItem() { Value = x.PartnerId.ToString(), Text = x.PartnerName });
            }
            return View(_financialItemService.GetFinancialItemById(id));
        }

        // POST: FinancialItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] FinancialItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _financialItemService.UpdateFinancialItem(model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            return View(model);
        }

        public ActionResult DeleteAll()
        {
            try
            {
                _financialItemService.DeleteAllFinancialItems();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FinancialItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_financialItemService.GetFinancialItemById(id));
        }

        // POST: FinancialItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _financialItemService.DeleteFinancialItemById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
