using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterfellTest.Controllers
{
    public class RentalHistoryController : Controller
    {
        private IGameRentService _gameRentService;
        public RentalHistoryController(IGameRentService gameRentService)
        {
            _gameRentService = gameRentService;
        }

        // GET: RentHistory
        public ActionResult Index(int? customerCode)
        {
            if(customerCode == null)
            {
                
                return RedirectToAction("Index", "Home", null);
            }

            var data = _gameRentService.GetSumaryByCustomer(customerCode.Value);

            if(data.Customer.Name == null)
            {
                return RedirectToAction("Index", "Home", null);
            }

            return View(data);
        }
    }
}