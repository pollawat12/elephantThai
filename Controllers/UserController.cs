using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace elephathai3.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult UserItemList()
        {
            return View();
        }

        public ActionResult UserDashboard()
        {
            return View();
        }

        public ActionResult UserItemCreate()
        {
            return View();
        }

        public ActionResult UserItemDetail()
        {
            return View();
        }

        public ActionResult UserItemPreview()
        {
            return View();
        }
    }
}