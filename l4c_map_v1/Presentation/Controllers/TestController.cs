using Domain.entities;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("/l4c_map-v2-web/rest/test").Result;
            var testsvm = new List<TestVm>();
            if (response.IsSuccessStatusCode)
            {
                var tests = response.Content.ReadAsAsync<IEnumerable<test>>().Result;
                foreach (test test in tests)
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
                    HttpResponseMessage response_question = Client.GetAsync("/l4c_map-v2-web/rest/question/" + test.idTest).Result;
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
                    testsvm.Add(tvm);
                }
            }
            Session["alltest"] = testsvm;
            return View(testsvm);
        }
        [HttpPost]
        public ActionResult Index(string searchstring)
        {
            List<TestVm> tests = Session["alltest"] as List<TestVm>;

            if (!String.IsNullOrEmpty(searchstring))
            {
                tests = tests.Where(m => m.name.ToLower().Contains(searchstring.ToLower())).ToList();
            }
            return View(tests);
        }
        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Test/Create
        [HttpGet]
        public ActionResult Create()
        {
            user user = (user)Session["user"];
            TestVm testvm = (TestVm)Session["test"];
            test newtest = new test()
            {
                dateOfPassing = DateTime.Now,
                difficulty = testvm.difficulty,
                //files = testvm.files,
                //idResponsable = testvm.idResponsable,
                idTest = testvm.idTest,
                mark = testvm.mark,
                name = testvm.name,
                specialty = testvm.specialty
            };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.PutAsJsonAsync<test>("/l4c_map-v2-web/rest/applicant/" + user.id, newtest).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Profile", "Applicant");
        }

        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(TestVm test)
        {
            TestVm testvm = (TestVm)Session["test"];
            if (test != null)
            {
                foreach (var question in test.questions)
                {
                    if (question.numberChosed.Equals("first"))
                    {
                        if (question.correct.Equals(question.syn1))
                        {
                            test.mark++;
                        }
                    }
                    else if (question.numberChosed.Equals("second"))
                    {
                        if (question.correct.Equals(question.syn2))
                        {
                            test.mark++;
                        }
                    }
                    else
                    {
                        if (question.correct.Equals(question.syn3))
                        {
                            test.mark++;
                        }
                    }
                }
            }
            return RedirectToAction("Profile", "Applicant");
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
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Add(TestVm testvm)
        {
            user user = (user)Session["user"];
            if (ModelState.IsValid && user != null && user.role.Equals("Responsable"))
            {
                test test = new test()
                {
                    name = testvm.name,
                    difficulty = testvm.difficulty,
                    specialty = testvm.specialty
                };
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsJsonAsync<test>("/l4c_map-v2-web/rest/responsable/" + user.id, test).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                string id = response.Content.ReadAsStringAsync().Result.ToString();
                testvm.idTest = System.Convert.ToInt32(id);
                return RedirectToAction("Add", "Question", testvm);
            }
            return RedirectToAction("Index", "Applicant", testvm);
        }
    }
}
