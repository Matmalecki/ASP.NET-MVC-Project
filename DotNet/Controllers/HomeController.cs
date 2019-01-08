using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNet.Models;
using Microsoft.AspNetCore.Authorization;


namespace DotNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult About()
        {
            ViewData["Message"] = "Admin can access this page";

            return View();
        }
        [Authorize(Roles = "User,Admin")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "User and Admin can access this page";

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
