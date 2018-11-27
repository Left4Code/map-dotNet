using Domain.entities;
using Newtonsoft.Json;
using Presentation.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Credential uvm)
        {
            if (ModelState.IsValid)
            {
                user user = Session["user"] as user;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080");
                StringContent content = new StringContent(JsonConvert.SerializeObject(uvm), UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsJsonAsync("/l4c_map-v2-web/rest/authentication", uvm);
                Session["token"] = response.Content.ReadAsStringAsync().Result.ToString();
                HttpResponseMessage response1 = client.GetAsync("/l4c_map-v2-web/rest/user/" + uvm.username).Result;
                if (response.IsSuccessStatusCode && response1.IsSuccessStatusCode)
                {
                    Session["user"] = response1.Content.ReadAsAsync<user>().Result;
                }
                user = (user)Session["user"];
                if (user.role.Equals("Applicant"))
                    return RedirectToAction("Profile", "Applicant");
                else
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session["user"] = null;
            Session["token"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
