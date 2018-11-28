using Domain.entities;
using Presentation.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using static Domain.entities.applicant;

namespace Presentation.Controllers
{
    [HandleError]
    public class ApplicantController : Controller
    {
        // GET: Applicant
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("/l4c_map-v1-web/rest/applicant").Result;
            var applicants = new List<ApplicantVm>();
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<applicant>>().Result;
                foreach(applicant applicant in ViewBag.result)
                {
                    applicants.Add(new ApplicantVm()
                    {
                        age = applicant.age,
                        applicantState = applicant.applicantState,
                        chanceOfSuccess = applicant.chanceOfSuccess,
                        country = (PaysVm)Enum.Parse(typeof(PaysVm), applicant.country),
                        lastname = applicant.lastname,
                        name = applicant.name,
                        role = applicant.role,
                        username = applicant.username,
                        picture = applicant.picture,
                        id = applicant.id ,
                        password = applicant.password,
                        arrival = applicant.arrival,
                        demand = applicant.demand                        
                    });
                }
            }
            else
            {
                applicants = null;
            }
            Session["applicants"] = applicants;
            return View(applicants);
        }

        [HttpPost]
        public ActionResult Index(string searchstring)
        {
            List<ApplicantVm> applicants = Session["applicants"] as List<ApplicantVm>;

            if (!String.IsNullOrEmpty(searchstring))
            {
                applicants = applicants.Where(m => m.name.ToLower().Contains(searchstring.ToLower())).ToList();
            }
            return View(applicants);
        }

        // GET: Applicant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Applicant/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Applicant/Create
        [HttpPost]
        public ActionResult Create(ApplicantVm avm,HttpPostedFileBase File)
        {
            if (ModelState.IsValid )
            {
                if(File != null && File.ContentLength != 0)
                {
                    applicant applicant = new applicant()
                    {
                        lastname = avm.lastname,
                        name = avm.name,
                        password = avm.password,
                        picture = File.FileName,
                        username = avm.username,
                        age = avm.age,
                        country = avm.country.ToString()
                    };
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:8080");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));        
                    client.PostAsJsonAsync<applicant>("/l4c_map-v1-web/rest/inscription", applicant).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                    if (File.ContentLength > 0)
                    {
                        var path = Path.Combine(Server.MapPath("~/images/"), File.FileName);
                        File.SaveAs(path);
                    }
                    return RedirectToAction("Login","User");
                }
            }
            return View(avm);
        }

        // GET: Applicant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Applicant/Edit/5
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

        // GET: Applicant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Applicant/Delete/5
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

        public new ActionResult Profile(ApplicantVm applicantvm)
        {
            var user = (user)Session["user"];
            if (user != null && user.role.Equals("Responsable"))
            {
                user.id = applicantvm.id;
            }      
            if(user != null)
            {
                HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri("http://localhost:8080");
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = Client.GetAsync("/l4c_map-v1-web/rest/applicant/" + user.id).Result;
                if (response.IsSuccessStatusCode)
                {
                    applicant applicant = response.Content.ReadAsAsync<applicant>().Result;
                    ApplicantVm avm = new ApplicantVm()
                    {
                        id = applicant.id,
                        age = applicant.age,
                        applicantState = applicant.applicantState,
                        chanceOfSuccess = applicant.chanceOfSuccess,
                        country = (PaysVm)Enum.Parse(typeof(PaysVm), applicant.country),
                        lastname = applicant.lastname,
                        name = applicant.name,
                        role = applicant.role,
                        username = applicant.username,
                        picture = applicant.picture,
                        demand = applicant.demand,
                        arrival = applicant.arrival                
                    };
                    ArrivalVm arrivalvm = new ArrivalVm()
                    {
                        arrivalDate = avm.arrival.arrivalDate ,
                        idArrival = avm.arrival.idArrival,
                        flightNumber = avm.arrival.flightNumber
                        
                    };
                    avm.arrivalvm = arrivalvm;
                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response_test = Client.GetAsync("/l4c_map-v1-web/rest/test/").Result;
                    if (response_test.IsSuccessStatusCode)
                    {
                        ICollection<test> alltest = (ICollection<test>)response_test.Content.ReadAsAsync<IEnumerable<test>>().Result;
                        
                        foreach (test test in alltest)
                        {
                            TestVm tvm = new TestVm()
                            {
                                dateOfPassing = test.dateOfPassing,
                                difficulty = test.difficulty,
                                //files = test.files,
                                //idResponsable = test.idResponsable,
                                idTest = test.idTest,
                                mark = test.mark,
                                name = test.name,
                                specialty = test.specialty,
                            };
                            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            HttpResponseMessage response_question = Client.GetAsync("/l4c_map-v1-web/rest/question/" + test.idTest).Result;
                            ICollection<QuestionVm> allquestion = (ICollection<QuestionVm>)response_question.Content.ReadAsAsync<IEnumerable<QuestionVm>>().Result;
                            foreach (QuestionVm question in allquestion)
                            {
                                tvm.questions.Add(new QuestionVm()
                                {
                                    correct = question.correct,
                                    idQuestion = question.idQuestion,
                                    syn1 = question.syn1,
                                    syn2 = question.syn2,
                                    syn3 = question.syn3,
                                    task = question.task,
                                    test = question.test
                                });
                            }
                            avm.tests.Add(tvm);                                 
                        }
                        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response_testpassed = Client.GetAsync("/l4c_map-v1-web/rest/test/"+user.id).Result;
                        if (response_testpassed.IsSuccessStatusCode)
                        {
                            ICollection<test> testpassed = (ICollection<test>)response_testpassed.Content.ReadAsAsync<IEnumerable<test>>().Result;
                            foreach(test test in testpassed)
                            {
                                avm.testpassed.Add(new TestVm()
                                {
                                    dateOfPassing = test.dateOfPassing,
                                    difficulty = test.difficulty,
                                    idTest = test.idTest,
                                    mark = test.mark,
                                    name = test.name,
                                    specialty = test.specialty
                                });
                            }
                        }
                    }
                    foreach(var passed in avm.testpassed)
                    {
                        avm.tests.Remove(passed);
                    }
                    return View(avm);
                }
            }           
            return RedirectToAction("Error","Shared");
        }
        [HttpGet]
        public ActionResult Accept(ApplicantVm avm)
        {
            applicant applicant = new applicant()
            {
                id = avm.id,
                applicantState = "Applicant_Being_Recruted",
                username = avm.username,
                role = avm.role,
                picture = avm.picture,
                age = avm.age,
                arrival = avm.arrival,
                chanceOfSuccess = avm.chanceOfSuccess,
                country = avm.country.ToString(),
                demand = avm.demand,
                lastname = avm.lastname,
                name = avm.name,
                password = avm.password
            };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.PutAsJsonAsync<applicant>("/l4c_map-v1-web/rest/applicant/", applicant).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Profile", "Applicant");
        }
        [HttpPost]
        public ActionResult Accept()
        {
            return View();
        }
    }
}
