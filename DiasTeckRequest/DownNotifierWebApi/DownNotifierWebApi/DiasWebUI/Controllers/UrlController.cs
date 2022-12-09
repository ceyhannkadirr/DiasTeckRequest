using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiasWebUI.Controllers
{
    public class UrlController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddUrl()
        {
            return View();
        }
        public IActionResult EditUrl()
        {
            return View();
        }
    }
}
