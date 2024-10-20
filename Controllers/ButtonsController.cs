using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SbAdmin.Controllers
{
    public class ButtonsController : Controller
    {
        // GET: ButtonsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ButtonsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ButtonsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ButtonsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ButtonsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ButtonsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ButtonsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ButtonsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
