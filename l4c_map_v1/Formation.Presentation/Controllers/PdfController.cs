using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Aspose.Pdf;
using Presentation.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using Service;
using Domain;

namespace Presentation.Controllers
{
    public class PdfController : Controller
    {
        IMandateService ms = new MandateService();
        IProjectService ps = new ProjectService();
        // GET: Pdf
        protected ActionResult Pdf()
        {
            return Pdf(null, null, null);
        }

        protected ActionResult Pdf(string fileDownloadName)
        {
            return Pdf(fileDownloadName, null, null);
        }

        protected ActionResult Pdf(string fileDownloadName, string viewName)
        {
            return Pdf(fileDownloadName, viewName, null);
        }

        protected ActionResult Pdf(object model)
        {
            return Pdf(null, null, model);
        }

        protected ActionResult Pdf(string fileDownloadName, object model)
        {
            return Pdf(fileDownloadName, null, model);
        }

        protected ActionResult Pdf(string fileDownloadName, string viewName, object model)
        {
            // Based on View() code in Controller base class from MVC
            if (model != null)
            {
                ViewData.Model = model;
            }
            PdfResult pdf = new PdfResult()
            {
                FileDownloadName = fileDownloadName,
                ViewName = viewName,
                ViewData = ViewData,
                TempData = TempData,
                ViewEngineCollection = ViewEngineCollection
            };
            return pdf;
        }
        public virtual async System.Threading.Tasks.Task<ActionResult> PdfTest(int id)
        {   
            
            
            List<KeyValuePair<RessourceVM, string>> listWS = new List<KeyValuePair<RessourceVM, string>>();
            


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/l4c_map-v2-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await Client.GetAsync("rest/efficiencies?id=" + id);
            string data = await response.Content.ReadAsStringAsync();
            JavaScriptSerializer JSserializer = new JavaScriptSerializer();
            listWS = ListToDictionary(JSserializer.Deserialize<List<List<Object>>>(data));
            ViewBag.rate =listWS[0].Value;
            ViewBag.Ressource = listWS[0].Key;
            List<MandateVM> l = new List<MandateVM>();
            foreach (mandate s in ms.getMandates(id)) {
                ProjectVM p = new ProjectVM {name=ps.getProject(s.idProject).name,adresse=ps.getProject(s.idProject).adresse };
                MandateVM m = new MandateVM { dateBegin = s.dateBegin.ToString(), dateEnd = s.dateEnd.ToString(),project=p };
                l.Add(m);

            }

            ViewBag.mandates = l;

            ViewBag.test = id;
            

           return Pdf(new int[] { 1, 2, 3 });

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


    }
    public class PdfResult : PartialViewResult
    {
        // Setting a FileDownloadName downloads the PDF instead of viewing it
        public string FileDownloadName { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            // Set the model and data
            context.Controller.ViewData.Model = Model;
            ViewData = context.Controller.ViewData;
            TempData = context.Controller.TempData;


            // Get the view name
            if (string.IsNullOrEmpty(ViewName))
            {
                ViewName = context.RouteData.GetRequiredString("action");
            }

            // Get the view
            ViewEngineResult viewEngineResult = null;
            if (View == null)
            {
                viewEngineResult = FindView(context);
                View = viewEngineResult.View;
            }

            // Render the view
            StringBuilder sb = new StringBuilder();
            using (TextWriter tr = new StringWriter(sb))
            {
                ViewContext viewContext = new ViewContext(context, View, ViewData, TempData, tr);
                View.Render(viewContext, tr);
            }
            if (viewEngineResult != null)
            {
                viewEngineResult.ViewEngine.ReleaseView(context, View);
            }

            // Create a PDF from the rendered view content
            Aspose.Pdf.Generator.Pdf pdf = new Aspose.Pdf.Generator.Pdf();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString())))
            {
                pdf.BindXML(ms, null);
            }

            // Save the PDF to the response stream
            using (MemoryStream ms = new MemoryStream())
            {
                pdf.Save(ms);
                FileContentResult result = new FileContentResult(ms.ToArray(), "application/pdf")
                {
                    FileDownloadName = FileDownloadName
                };
                result.ExecuteResult(context);
            }

        }

    }
}
