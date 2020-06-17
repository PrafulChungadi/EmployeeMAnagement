using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.AspNetCore.Http;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        int x = 0;
        public IActionResult Index()
        {
            int y = Convert.ToInt32(HttpContext.Session.GetInt32("valueofx"));
            if (y == null)
            {
                x = 0;
            }
            else {
                x = y;
                x++;
            }
            HttpContext.Session.SetInt32("valueofx",x);
            return Content(x.ToString());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
