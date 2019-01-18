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
    public class TestController : Controller
    {
        static ITestService ItestServ;

        public TestController()
        {
            ItestServ = new TestService();

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult testAx()
        {
            string error = "";

            return Json("'Success':'true'");
        }
        public async System.Threading.Tasks.Task<ActionResult> ActivityRatioWebService(int id)
        {
            /*  KeyValuePair<RessourceVM, string> dictionary = new KeyValuePair<RessourceVM, string>();
              
              listFinal.Add(new KeyValuePair<RessourceVM, string>(r, Convert.ToString(x.ElementAt<Object>(1))));
              */
            List<Obj> listFinal = new List<Obj>();
            Obj obj1;
            //Double.TryParse(String, Double);
            
            string from="";
            string to = "";
            double c;
            double b;
            int incr;
            



            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         
            HttpResponseMessage response;
            string data;
            for (int m = 1; m < 12; m++) {
                from="2018/0"+m+"/01";
                incr = m + 1;
                to = "2018/0"+incr+"/01";

                 response = await Client.GetAsync("rest/applicant/abdouu?m=0&resID="+id+"&from="+from+"&to="+to);
             data = await response.Content.ReadAsStringAsync();
               
                if (data.Contains("%"))
                {
                    data=data.Remove(data.IndexOf("%"),1);
                    if (data.Contains("."))
                    {
                       data = data.Remove(data.IndexOf("."), data.Substring(data.IndexOf(".")).Length);
                    }

                    System.Diagnostics.Debug.WriteLine(data);
                    b = double.Parse(data, System.Globalization.CultureInfo.InvariantCulture);
                    c = b;
                }
                else
                    b = 0;
            
               obj1 = new Obj(new DateTime(2018, m, 1), b);
                listFinal.Add(obj1);
            }

            ViewBag.data = listFinal;


            return PartialView();
        }
        // GET: Test
        public ActionResult Index()
        {
            ViewBag.prof = ItestServ.getProf();
            List<Obj> dataP = new List<Obj>();
            Obj obj1 = new Obj( new DateTime(2008, 6, 1, 7, 47, 0), 35.939);
            Obj obj3 = new Obj(new DateTime(2008, 7, 1, 7, 47, 0), 0);
            Obj obj2 = new Obj(new DateTime(2008, 8, 1, 7, 47, 0), 60);
            Obj obj4 = new Obj(new DateTime(2008, 9, 1, 7, 47, 0), 90);
            Obj obj5 = new Obj(new DateTime(2008, 10, 1, 7, 47, 0), 10);
            Obj obj6 = new Obj(new DateTime(2008, 11, 1, 7, 47, 0), 20);
            dataP.Add(obj1);
            dataP.Add(obj2);
            dataP.Add(obj3);
            dataP.Add(obj4);
            dataP.Add(obj5);
            dataP.Add(obj6);
            
            ViewBag.dataP = dataP;

            return View();
        }
        public async System.Threading.Tasks.Task<ActionResult> testWebService()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //  HttpResponseMessage response = await Client.GetAsync("rest/project");
            // string data = await response.Content.ReadAsStringAsync();
            //JavaScriptSerializer JSserializer = new JavaScriptSerializer();
            // ViewBag.result = JSserializer.Deserialize<IEnumerable<ProjectVM>>(data);
            HttpResponseMessage response = await Client.GetAsync("rest/efficiencies?id=1");
            string data = await response.Content.ReadAsStringAsync();
            JavaScriptSerializer JSserializer = new JavaScriptSerializer();
            ViewBag.Resources = ListToDictionary(JSserializer.Deserialize<List<List<Object>>>(data));


            return View();
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


        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
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

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Test/Edit/5
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

        // GET: Test/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Test/Delete/5
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
    public static class ObjectExtensions
    {
        public static T ToObject<T>(this IDictionary<string, object> source)
            where T : class, new()
        {
            var someObject = new T();
            var someObjectType = someObject.GetType();

            foreach (var item in source)
            {
                try
                {
                    someObjectType
                             .GetProperty(item.Key)
                             .SetValue(someObject, item.Value, null);
                }
                catch
                {

                }
            }

            return someObject;
        }
    }
    public class Obj{
        public DateTime x { get; set; }
        public double y { get; set; }
        public double m { get; set; }
        public Obj(DateTime x, double y)
        {
            this.x = x;
            this.y = y;
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = x.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
            this.m = ts.TotalMilliseconds;

        }
        public double M()
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = this.x.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
            
            return ts.TotalMilliseconds;
        }
    }

}
