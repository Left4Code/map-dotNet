using Domain.entities;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult Index()
        {

            return View();
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Question/Create
        public ActionResult Create(int number)
        {
            if (Session["test"] != null)
            {
                TestVm test = (TestVm)Session["test"];
                ViewBag.numberOfQuestion = test.questions.Count();
                ViewBag.number = number;
                if (number < test.questions.Count())
                {
                    Session["question"] = test.questions.ElementAt(number);
                    return View(test.questions.ElementAt(number));
                }
                else
                {

                    return RedirectToAction("Create", "Test");
                }

            }
            return RedirectToAction("Error", "Shared");
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(QuestionVm question)
        {
            QuestionVm questionfromsession = (QuestionVm)Session["question"];
            questionfromsession.numberChosed = question.numberChosed;
            question = questionfromsession;
            TestVm test = (TestVm)Session["test"];
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            string choice;
            if (question.numberChosed.ToString().Equals("first"))
                choice = question.syn1;
            else if (question.numberChosed.ToString().Equals("second"))
                choice = question.syn2;
            else
                choice = question.syn3;
            HttpResponseMessage response = Client.GetAsync("/l4c_map-v2-web/rest/question/" + question.idQuestion + "/" + choice).Result;
            if (response.IsSuccessStatusCode)
            {
                int next = test.questions.IndexOf(question);
                if (choice.Equals(question.correct))
                    test.mark++;
                Session["test"] = test;
                next++;
                if (next < test.questions.Count())
                {
                    return RedirectToAction("Create", "Question", new { number = next });
                }
            }
            return RedirectToAction("Create", "Test");
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Question/Edit/5
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

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Question/Delete/5
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
        public ActionResult Add(TestVm test)
        {
            Session["testSelected"] = test;
            user user = (user)Session["user"];
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response_question = Client.GetAsync("/l4c_map-v2-web/rest/question/" + test.idTest).Result;
            ICollection<QuestionVm> allquestion = (ICollection<QuestionVm>)response_question.Content.ReadAsAsync<IEnumerable<QuestionVm>>().Result;
            if (allquestion == null)
            {
                allquestion = new Collection<QuestionVm>();
            }
            ViewBag.numberOfQuestion = allquestion.Count() + 1;

            if (ViewBag.numberOfQuestion <= 5 && user != null && user.role.Equals("Responsable"))
            {
                return View();
            }
            return RedirectToAction("Index", "Test");
        }
        [HttpPost]
        public ActionResult Add(QuestionVm questionvm)
        {
            TestVm test = (TestVm)Session["testSelected"];
            user user = (user)Session["user"];
            if (questionvm.numberChosed.ToString().Equals("first"))
                questionvm.correct = questionvm.syn1;
            else if (questionvm.numberChosed.ToString().Equals("second"))
                questionvm.correct = questionvm.syn2;
            else
                questionvm.correct = questionvm.syn3;

            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080");
                Question question = new Question()
                {
                    correct = questionvm.correct,
                    idQuestion = questionvm.idQuestion,
                    numberChosed = questionvm.numberChosed,
                    syn1 = questionvm.syn1,
                    syn2 = questionvm.syn2,
                    syn3 = questionvm.syn3,
                    task = questionvm.task,
                    test = questionvm.test
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.PostAsJsonAsync<Question>("/l4c_map-v2-web/rest/question/" + test.idTest, question).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            }
            return Add(test);
        }
    }
}
