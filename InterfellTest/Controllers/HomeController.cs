using Business.Services;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterfellTest.Controllers
{
    public class HomeController : Controller
    {
        private IGameRentService _gameRentService;

        public HomeController(IGameRentService gameRentService)
        {
            _gameRentService = gameRentService;
        }
        public ActionResult Index()
        {
            var data = _gameRentService.GetSumary();
            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}