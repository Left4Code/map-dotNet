using Domain.Entities;
using Presentation.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class FilmController : Controller
    {
        IFilmService filmService;

        public FilmController()
        {
            filmService = new FilmService();
        }

        // GET: Film
        public ActionResult Index(string searchString)
        {
            var listfilms = filmService.GetMany();

            if (!String.IsNullOrEmpty(searchString))
            {
                //listfilms = listfilms.Where(m => m.Titre.Contains(searchString)).ToList();

                listfilms = filmService.GetMany(m => m.Titre.Contains(searchString));

            }


            var films = new List<FilmVm>();

            foreach ( Film f in listfilms)
            {
                films.Add(new FilmVm()
                {
                    Description = f.Description,
                    ImageUrl = f.ImageUrl,
                    Genre = f.Genre,
                    Titre = f.Titre,
                });
            }

            return View(films);
        }

        // GET: Film/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Film/Create
        [HttpPost]
        public ActionResult Create(FilmVm FilmVm)
        {
            filmService.Add(new Film() {
                Description = FilmVm.Description,
                ImageUrl = FilmVm.ImageUrl,
                Genre = FilmVm.Genre,
                Titre = FilmVm.Titre,
            });

            filmService.Commit();

            return RedirectToAction("Index");
        }

        // GET: Film/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Film/Edit/5
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

        // GET: Film/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Film/Delete/5
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
