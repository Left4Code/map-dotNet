using Domain.entities;
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
    public class RessourceController : Controller
    {
        // GET: Ressource
        public ActionResult Index()
        {
            user user = (user)Session["user"]; 
            if(user != null && user.role.Equals("Responsable"))
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://localhost:18080");
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.GetAsync("l4c_map-v2-web/rest/badis/0").Result;
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Ressource>>().Result;
                }
                else
                {
                    ViewBag.result = "error";
                }
                return View();
            }       
            return RedirectToAction("Error","Shared");
        }

        // GET: Ressource/Details/5
        public async System.Threading.Tasks.Task<ActionResult> Details(int id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:18080");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.GetAsync("l4c_map-v2-web/rest/badis/" + id);
            if (response.IsSuccessStatusCode)
            {

                String res = await response.Content.ReadAsStringAsync();
                ViewBag.result = new JavaScriptSerializer().Deserialize<Models.Ressource>(res);
                //JsonConvert.DeserializeObject<Models.Ressource>(response.Content.ToString());
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }
        public int nbrSKills()
        {
            int rs = 0;
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:18080");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response =  httpClient.GetAsync("l4c_map-v2-web/rest/badis").Result;
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

        // GET: Ressource/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Da()
        {
    return PartialView("~/Views/Ressource/_Skill.cshtml");
        }

        // POST: Ressource/Create
        [HttpPost]
        public ActionResult Create(RessourceSkills res)
        {
            int ids = nbrSKills();
       
                Ressource rs = res.ressource;
                rs.skills = new List<Skills>();
            if (res.skills1 != null)
            {
                res.skills.idSkills = ids + 1;
                res.skills1.idSkills = ids + 2;
                rs.skills.Add(res.skills);
                rs.skills.Add(res.skills1);

            }
            else if (res.skills2 != null)
            {
                res.skills.idSkills = ids + 1;
                res.skills1.idSkills = ids + 2;
                res.skills2.idSkills = ids + 3;


                rs.skills.Add(res.skills);
                rs.skills.Add(res.skills1);
                rs.skills.Add(res.skills2);
            }
            else
            {
                res.skills.idSkills = ids + 1;
                rs.skills.Add(res.skills);
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            StringContent content = new StringContent(JsonConvert.SerializeObject(rs), UTF8Encoding.UTF8, "application/json");
            rs.username = res.ressource.name;
            rs.password = "12345678";
            client.PostAsJsonAsync<Ressource>("l4c_map-v2-web/rest/badis", rs).ContinueWith((postTask) =>
            {
                postTask.Result.EnsureSuccessStatusCode();
                System.Console.WriteLine(postTask.Result.ToString());
            });
            return RedirectToAction("Index");
        }

        // GET: Ressource/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ressource/Edit/5
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

        // GET: Ressource/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Ressource/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response1 = client.DeleteAsync("l4c_map-v2-web/rest/badis/" + id).Result;
            var status = true;

            return new JsonResult { Data = new { status = status } };


        }
    }
}
