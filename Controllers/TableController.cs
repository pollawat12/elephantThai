using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SbAdmin.Controllers
{
   [ApiController]
   [Route("CarController2")]
    public class TableController : Controller
    {
   
        [HttpGet("xx")]
        public ActionResult<IEnumerable<string>> Gets()
        {
        return new string[] { "v1", "v2" };

        }


        public IActionResult Tables()
        {
            return View();
        }
    }
}
