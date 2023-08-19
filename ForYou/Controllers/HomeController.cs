using ForYou.Dtos;
using ForYou.Models;
using ForYou.Services;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ForYou.Controllers
{
    public class HomeController : Controller
    {

        private readonly IContractService _contractService;
        public HomeController(IContractService contractService)
        {
            _contractService = contractService;
        }

        public async Task<IActionResult> Index()
        {
            var contracts = await _contractService.GetContracts();
            if (contracts != null)
            {
                return View(contracts);
            }
            return View();
        }
        public async Task<IActionResult> Detail(long id)
        {
            var contract = await _contractService.GetById(id);
            if (contract != null)
            {
                return View(contract);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContractDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var id = await _contractService.Create(dto);
            if (id > 0)
            {
                return RedirectToAction("Detail", new { id = id });
            }
            return View();
        }
    }
}