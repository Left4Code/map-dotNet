using Domain;
using Presentation.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Presentation.Controllers
{
    public class AController : Controller
    {
        public KeyValuePair<RessourceVM, double> ract;
        public List<KeyValuePair<RessourceVM, string>> listWS;
        // GET: A
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            ITestService ts = new TestService();
            IRessourceService rs = new RessourceService();
            //ts.getProf();
            var x= ts.nbByCountry();
            //ViewBag.count = 20;
            double b;
           
            List<KeyValuePair<RessourceVM, double>> flist = new List<KeyValuePair<RessourceVM, double>>();


            foreach (ressource r in rs.getRessources())
            {
                listWS = new List<KeyValuePair<RessourceVM, string>>();
                RessourceVM rVM = new RessourceVM {id=r.id, Name=r.user.name, LastName=r.user.lastname };
                

                HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await Client.GetAsync("rest/efficiencies?id=" + r.id);
                string data = await response.Content.ReadAsStringAsync();
                JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                listWS = ListToDictionary(JSserializer.Deserialize<List<List<Object>>>(data));
                string actStr = listWS[0].Value;
                if (actStr.Contains("%"))
                {
                    actStr = actStr.Remove(actStr.IndexOf("%"), 1);

                    System.Diagnostics.Debug.WriteLine(actStr);
                    b = double.Parse(actStr, System.Globalization.CultureInfo.InvariantCulture);

                }
                else
                {
                    b = 0;
                }
                ract = new KeyValuePair<RessourceVM, double>(rVM,b);
                flist.Add(ract);
            }
            ViewBag.listOfPair = flist;

                return View();
        }
     
        public async System.Threading.Tasks.Task<ActionResult> partialV()
        {
            ITestService ts = new TestService();
            IRessourceService rs = new RessourceService();
           // ts.getProf();
            //ViewBag.count = 20;
            double b;

            List<KeyValuePair<RessourceVM, double>> flist = new List<KeyValuePair<RessourceVM, double>>();


            foreach (ressource r in rs.getRessources())
            {
                listWS = new List<KeyValuePair<RessourceVM, string>>();
                RessourceVM rVM = new RessourceVM { id = r.id, Name = r.user.name, LastName = r.user.lastname };


                HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await Client.GetAsync("rest/efficiencies?id=" + r.id);
                string data = await response.Content.ReadAsStringAsync();
                JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                listWS = ListToDictionary(JSserializer.Deserialize<List<List<Object>>>(data));
                string actStr = listWS[0].Value;
                if (actStr.Contains("%"))
                {
                    actStr = actStr.Remove(actStr.IndexOf("%"), 1);

                    System.Diagnostics.Debug.WriteLine(actStr);
                    b = double.Parse(actStr, System.Globalization.CultureInfo.InvariantCulture);

                }
                else
                {
                    b = 0;
                }
                ract = new KeyValuePair<RessourceVM, double>(rVM, b);
                flist.Add(ract);
            }
            ViewBag.listOfPair = flist;

            return PartialView();
        }

        private List<KeyValuePair<RessourceVM, string>> ListToDictionary(List<List<Object>> list)
        {
            KeyValuePair<RessourceVM, string> dictionary = new KeyValuePair<RessourceVM, string>();

            List<KeyValuePair<RessourceVM, string>> listFinal = new List<KeyValuePair<RessourceVM, string>>();
            foreach (var x in list)
            {
                
                RessourceVM r = ObjectExtensions.ToObject<RessourceVM>((IDictionary<string, object>)x.ElementAt<Object>(0));
                listFinal.Add(new KeyValuePair<RessourceVM, string>(r, Convert.ToString(x.ElementAt<Object>(1))));

            }

            return listFinal;
        }

        public ActionResult RByCountry()
        {
            ITestService ts = new TestService();
            ViewBag.pays = ts.nbByCountry().Keys.ToArray();
            ViewBag.nb = ts.nbByCountry().Values.ToArray();

            return View();
        }
        public  async System.Threading.Tasks.Task<ActionResult> PigisteVsEmployee()
        {
            KeyValuePair<string, string> listkv = new KeyValuePair<string, string>();
            string s;
            string v;


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await Client.GetAsync("rest/others?n=1");
            string data = await response.Content.ReadAsStringAsync();
            JavaScriptSerializer JSserializer = new JavaScriptSerializer();
            listkv = ToDictionary(JSserializer.Deserialize<List<Object>>(data));
            ViewBag.nbPigiste = double.Parse(listkv.Value.Substring(22, 1), System.Globalization.CultureInfo.InvariantCulture); 
            ViewBag.nbEmp = double.Parse(listkv.Key.Substring(23, 1), System.Globalization.CultureInfo.InvariantCulture);



            return View();
        }
        public async System.Threading.Tasks.Task<ActionResult> mandVsInter()
        {
            KeyValuePair<string, string> listkv = new KeyValuePair<string, string>();
            string s;
            string v;


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await Client.GetAsync("rest/others?n=2");
            string data = await response.Content.ReadAsStringAsync();
            JavaScriptSerializer JSserializer = new JavaScriptSerializer();
            listkv = ToDictionary(JSserializer.Deserialize<List<Object>>(data));
            s=listkv.Value.Substring(38, 1);
            v=listkv.Key.Substring(32, 1);
            ViewBag.nbPM = double.Parse(listkv.Key.Substring(32, 1), System.Globalization.CultureInfo.InvariantCulture);
            ViewBag.nbPIM = double.Parse(listkv.Value.Substring(38, 1), System.Globalization.CultureInfo.InvariantCulture);



            return View();
        }
        public ActionResult StatApiPage()
        {
            return View();
        }

        private KeyValuePair<string, string> ToDictionary(List<Object> list)
        {
    
                string emp = Convert.ToString(list.ElementAt<Object>(0));
                string pigistes = Convert.ToString(list.ElementAt<Object>(1));

                KeyValuePair<string, string> dictionary = new KeyValuePair<string, string>(emp,pigistes);
            
            return dictionary;
        }

        // GET: A/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: A/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: A/Create
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

        // GET: A/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: A/Edit/5
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

        // GET: A/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: A/Delete/5
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
