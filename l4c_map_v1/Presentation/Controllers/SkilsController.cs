using Newtonsoft.Json;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Presentation.Controllers
{
    public class SkilsController : Controller
    {
        // GET: Skils
        public ActionResult Index()
        {
            return View();
        }

        // GET: Skils/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Skils/Create
        public ActionResult Create()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:18080");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync("l4c_map-v2-web/rest/badis/0").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Models.Ressource>>().Result;
            }

                return View();
        }
        public int nbrSKills()
        {
            int rs = 0;
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:18080");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync("l4c_map-v2-web/rest/badis").Result;
            if (response.IsSuccessStatusCode)
            {

                String res = response.Content.ReadAsStringAsync().Result;
                rs = new JavaScriptSerializer().Deserialize<int>(res);
                //JsonConvert.DeserializeObject<Models.Ressource>(response.Content.ToString());
            }
            else
            {
                rs = 0;
            }
            return rs;
        }
        // POST: Skils/Create
        [HttpPost]
        public ActionResult Create(Skills skills)
        {
            int nbr = nbrSKills();
            skills.idSkills = nbr + 1;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080");
                StringContent content = new StringContent(JsonConvert.SerializeObject(skills), UTF8Encoding.UTF8, "application/json");
                client.PostAsJsonAsync<Skills> ("l4c_map-v2-web/rest/skills?id="+skills.idP, skills).ContinueWith((postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                    System.Console.WriteLine(postTask.Result.ToString());
                });
                return RedirectToAction("Index","Ressource");
            }
            catch
            {
                return View();
            }
        }

        // GET: Skils/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Skils/Edit/5
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

        // GET: Skils/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Skils/Delete/5
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
