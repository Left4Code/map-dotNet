using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;


namespace Presentation.Controllers
{
    public class ProjectStatController : Controller
    {
        // GET: ProjectStat
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProjects()
        {

            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("rest/project").Result;
                if (response.IsSuccessStatusCode)
                {
                    List<ProjetMv> lp= (List<ProjetMv>)response.Content.ReadAsAsync<IEnumerable<ProjetMv>>().Result;

                    return new JsonResult { Data = lp, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }

            }
            return new JsonResult { };

        }
       
        public JsonResult GetChartData()
        {
       
            //Here MyDatabaseEntities  is our dbContext
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("rest/profitability").Result;

            List<projectStat> data  =(List<projectStat>)response.Content.ReadAsAsync<IEnumerable<projectStat>>().Result;
            
          var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "name",
                "profitability",
                "gain",
                "lost"

                
           
               
            };

            int j = 0;
            foreach (var i in data)
            {
                j++;
                chartData[j] = new object[] { i.project.name,i.profitability,i.gain,i.lost};
            }
            return new JsonResult { Data = chartData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
