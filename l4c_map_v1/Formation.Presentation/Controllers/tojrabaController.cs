using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class tojrabaController : Controller
    {
        // GET: tojraba
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TestAjax(string Name)
        {
            ViewBag.Name = Name;
            return PartialView();
        }

        // GET: tojraba/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: tojraba/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tojraba/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: tojraba/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: tojraba/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: tojraba/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: tojraba/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
