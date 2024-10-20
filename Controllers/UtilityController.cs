using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SbAdmin.Controllers
{
    public class UtilityController : Controller
    {
        public IActionResult Colors()
        {
            return View();
        }
        public IActionResult Borders()
        {
            return View();
        }
        public IActionResult Animations()
        {
            return View();
        }
        public IActionResult Other()
        {
            return View();
        }
    }
}
