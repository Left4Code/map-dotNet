using Domain.entities;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class ArrivalController : Controller
    {
        // GET: Arrival
        public ActionResult Index()
        {
            return View();
        }

        // GET: Arrival/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Arrival/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arrival/Create
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

        // GET: Arrival/Edit/5
        public ActionResult Edit(int id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("/l4c_map-v2-web/rest/arrival/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                arrival arrival= response.Content.ReadAsAsync<arrival>().Result;
                ArrivalVm avm = new ArrivalVm()
                {
                    idArrival = arrival.idArrival ,
                    arrivalDate = arrival.arrivalDate,
                    flightNumber = arrival.flightNumber
                };
                return View(avm);
            }
            return View();
        }

        // POST: Arrival/Edit/5
        [HttpPost]
        public ActionResult Edit(ArrivalVm avm)
        {
            user user = Session["user"] as user;
            if(user != null)
            {
                arrival arrival = new arrival()
                {
                    idArrival = avm.idArrival,
                    arrivalDate = avm.arrivalDate,
                    flightNumber = avm.flightNumber
                };
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.PutAsJsonAsync<arrival>("/l4c_map-v2-web/rest/arrival", arrival).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Profile", "Applicant");
            }
            return View();
        }

        // GET: Arrival/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Arrival/Delete/5
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
