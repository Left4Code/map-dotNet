using Newtonsoft.Json;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveEvent(demand_time_offVM e)
        {
            var status = false;
            {
                if (e.idDemandeTimeOff > 0)
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:18080");
                    StringContent content = new StringContent(JsonConvert.SerializeObject(e), UTF8Encoding.UTF8, "application/json");
                    client.PutAsJsonAsync<demand_time_offVM>("l4c_map-v2-web/rest/conge?idRessource=6", e).ContinueWith((postTask) =>
                    {
                        postTask.Result.EnsureSuccessStatusCode();
                       
                    });
                }
                else
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:18080");
                    StringContent content = new StringContent(JsonConvert.SerializeObject(e), UTF8Encoding.UTF8, "application/json");
                    client.PostAsJsonAsync<demand_time_offVM>("l4c_map-v2-web/rest/conge?idRessource=6", e).ContinueWith((postTask) =>
                    {
                        postTask.Result.EnsureSuccessStatusCode();
                    });
                }
                
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }


        public JsonResult GetEvents()
        {

            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://localhost:18080");
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.GetAsync("l4c_map-v2-web/rest/conge?id=6").Result;
                if (response.IsSuccessStatusCode)
                {
                    List<demand_time_offVM> ld =(List<demand_time_offVM>) response.Content.ReadAsAsync<IEnumerable<demand_time_offVM>>().Result;

                return new JsonResult { Data =ld, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }

            }
            return new JsonResult {};

        }

        [HttpPost]
        public JsonResult Delete(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response1 = client.DeleteAsync("l4c_map-v2-web/rest/conge/" + id).Result;
           var status = true;

            return new JsonResult { Data = new { status = status } };

        }
    }
}