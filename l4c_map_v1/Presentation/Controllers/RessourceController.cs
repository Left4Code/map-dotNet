using Domain.entities;
using Newtonsoft.Json;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Presentation.Controllers
{
    public class RessourceController : Controller
    {
        // GET: Ressource
        public ActionResult Index()
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


        [HttpPost]

        public JsonResult Specs(string keyword)

        {

            //This can be replaced with database call.

            List<Specialty> specialtyList = new List<Specialty>

                (){

                   new Specialty {Name="Software Developer" },
                   new Specialty {Name="Database Administrator" },
                   new Specialty {Name="Computer Hardware Engineer" },
                   new Specialty {Name="Computer Systems Analyst" },
                   new Specialty {Name="Computer Network Architect" },
                   new Specialty {Name="Web Developer" },
                   new Specialty {Name="Information Security Analyst" },
                   new Specialty {Name="Computer Programmer" },
                   new Specialty {Name="Project Manager" },
                   new Specialty {Name="Applications Architect" },
                   new Specialty {Name="Manager, Applications Development" },
                   new Specialty {Name="Manager, Information Systems Security" },
                   new Specialty {Name="Manager, Data Warehouse" },
                   new Specialty {Name="Manager, Software Quality Assurance (QA) / Testing" },
                   new Specialty {Name="UX Designer" },
                   new Specialty {Name="Marketing Technologist" },
                   new Specialty {Name="SEO Consultant" },
                   new Specialty {Name="Web Analytics Developer" },
                   new Specialty {Name="Social Media Manager" },
                   new Specialty {Name="UI Designer" },
                   new Specialty {Name="Front End designer" },
                   new Specialty {Name="Back End designer" },
                   new Specialty {Name="C# developper" },
                   new Specialty {Name="JEE developper" },
                   new Specialty {Name="Manager, Data Warehouse" },
                   new Specialty {Name="Full-Stack Developer" },
                   new Specialty {Name="Data Analyst" }



            };



            var result = (from a in specialtyList

                          where a.Name.ToLower().StartsWith(keyword.ToLower())

                          select new { a.Name });


            return Json(result, JsonRequestBehavior.AllowGet);

        }


    }
}
