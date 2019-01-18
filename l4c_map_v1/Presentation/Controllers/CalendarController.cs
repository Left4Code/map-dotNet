using Domain.entities;
using Newtonsoft.Json;
using Presentation.Models;
using Presentation.Utils;
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
            user user = (user)Session["user"];

            if (user != null)
                return View();          
            return RedirectToAction("Error", "Shared");
        }

        [HttpPost]
        public JsonResult SaveEvent(demand_time_offVM e)
        {
            user user = (user)Session["user"];
            if(user!= null && user.role.Equals("Ressource"))
            {
                var status = false;
                {
                    if (e.idDemandeTimeOff > 0)
                    {
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri("http://localhost:18080");
                        StringContent content = new StringContent(JsonConvert.SerializeObject(e), UTF8Encoding.UTF8, "application/json");
                        client.PutAsJsonAsync<demand_time_offVM>("l4c_map-v2-web/rest/conge?idRessource="+user.id, e).ContinueWith((postTask) =>
                        {
                            postTask.Result.EnsureSuccessStatusCode();

                        });
                    }
                    else
                    {
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri("http://localhost:18080");
                        StringContent content = new StringContent(JsonConvert.SerializeObject(e), UTF8Encoding.UTF8, "application/json");
                        client.PostAsJsonAsync<demand_time_offVM>("l4c_map-v2-web/rest/conge?idRessource="+user.id, e).ContinueWith((postTask) =>
                        {
                            postTask.Result.EnsureSuccessStatusCode();
                        });
                    }

                    status = true;
                }
                return new JsonResult { Data = new { status = status } };
            }
            return null;
        }

        [HttpPost]
        public JsonResult Modify(demand_time_offVM e)
        { string rep; 
            user user = (user)Session["user"];
            if (user != null && user.role.Equals("Responsable"))
            {
                var status = false;
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:18080");
                    StringContent content = new StringContent(JsonConvert.SerializeObject(e), UTF8Encoding.UTF8, "application/json");
                    client.PutAsJsonAsync<demand_time_offVM>("l4c_map-v2-web/rest/conge?idResponsable="+user.id, e).ContinueWith((postTask) =>
                    {
                        postTask.Result.EnsureSuccessStatusCode();

                    });
                    DateTime dt = (DateTime)e.DateBegin;;
                    DateTime dt2 = (DateTime)e.DateEnd;
                    if (e.StateDemande == "Accepted") {
                       
                        rep = "Votre demande de congée datée du :" + dt.ToShortDateString()+ " jusqu'au : " + dt2.ToShortDateString() + " a été : <br> Acceptée" ;
                    }else
                    {
                        rep = "Votre demande de congée datée du :" + dt.ToShortDateString() + " jusqu'au : " + dt2.ToShortDateString() + " a été : <br> Refusée";

                    }
                    var ss = Session["email"].ToString();
                    Gmailer.GmailUsername = "mysoulmatepi@gmail.com";
                    Gmailer.GmailPassword = "mysoulmatePI*";
                    Gmailer mailer = new Gmailer();
                    mailer.ToEmail = ss;
                    mailer.Subject = "Etat de congé";
                    mailer.Body = rep;
                    mailer.IsHtml = true;
                    mailer.Send();
                    status = true;
                }
                return new JsonResult { Data = new { status = status } };
            }
            return null;
        }


        public JsonResult GetEvents()
        {
            user user = (user)Session["user"];
            if (user != null && user.role.Equals("Ressource"))
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://localhost:18080");
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.GetAsync("l4c_map-v2-web/rest/conge?id="+user.id).Result;
                if (response.IsSuccessStatusCode)
                {
                    List<demand_time_offVM> ld = (List<demand_time_offVM>)response.Content.ReadAsAsync<IEnumerable<demand_time_offVM>>().Result;

                    return new JsonResult { Data = ld, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            return new JsonResult {};
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            user user = (user)Session["user"];
            if (user != null && user.role.Equals("Ressource"))
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response1 = client.DeleteAsync("l4c_map-v2-web/rest/conge/" + id).Result;
                var status = true;

                return new JsonResult { Data = new { status = status } };
            }
            return null; 
        }


    }
}