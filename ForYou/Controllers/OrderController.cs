using ForYou.Dtos;
using ForYou.Models;
using ForYou.Services;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ForYou.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;
        private readonly IContractService _contractService;

        public OrderController(IOrderService orderService, IContractService contractService)
        {
            _orderService = orderService;
            _contractService = contractService;
        }

        public async Task<IActionResult> Index(PagingRequest request)
        {
            if(request.PageIndex == 0)
                request.PageIndex = 1;
            if(request.PageSize == 0)
                request.PageSize = 10;
            if(!String.IsNullOrEmpty(request.Keyword))
                ViewBag.Keyword = request.Keyword;
            var orders = await _orderService.GetOrdersPaymentDue(request);
            if (orders != null)
            {
                ViewBag.Contracts = await _contractService.GetListContracts();
                return View(orders);
            }
            return View();
        }
    }
}