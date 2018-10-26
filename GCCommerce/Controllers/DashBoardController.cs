using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GCCommerce.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DashBoard()
        {
            ViewBag.Sessionv  = HttpContext.Session.GetString("UserName");

            return View();
        }
    }
}