using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TrainingDay.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Training Day-Drive your Growth";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "John McCorkell";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
