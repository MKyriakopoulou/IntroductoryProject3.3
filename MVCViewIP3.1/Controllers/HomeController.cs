using MVCViewIP3._1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCViewIP3._1.Controllers
{
    public class HomeController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = " https://localhost:44372/";

        public async Task<ActionResult> Index(string searchStringname, string searchStringsurname)
        {
            List<Lawyer> EmpInfo = new List<Lawyer>();

            using (var client = new HttpClient())
            {
                if (!String.IsNullOrEmpty(searchStringname) && !String.IsNullOrEmpty(searchStringsurname))
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("api/lawyer?Name=" + searchStringname + "&&Surname=" + searchStringsurname);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        EmpInfo = JsonConvert.DeserializeObject<List<Lawyer>>(EmpResponse);

                    }
                    //returning the employee list to view  
                    return View(EmpInfo);
                }
               else if (!String.IsNullOrEmpty(searchStringname) && String.IsNullOrEmpty(searchStringsurname))
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("api/lawyer?Name=" + searchStringname);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        EmpInfo = JsonConvert.DeserializeObject<List<Lawyer>>(EmpResponse);

                    }
                    //returning the employee list to view  
                    return View(EmpInfo);
                }
                else if (String.IsNullOrEmpty(searchStringname) && !String.IsNullOrEmpty(searchStringsurname))
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("api/lawyer?Surname=" + searchStringsurname);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        EmpInfo = JsonConvert.DeserializeObject<List<Lawyer>>(EmpResponse);

                    }
                    //returning the employee list to view  
                    return View(EmpInfo);
                }
                else
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("api/Lawyer/GetAllLawyers");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        EmpInfo = JsonConvert.DeserializeObject<List<Lawyer>>(EmpResponse);

                    }
                    //returning the employee list to view  
                    return View(EmpInfo);
                }

            }
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Lawyer lawyer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/lawyer");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Lawyer>("lawyer", lawyer);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(lawyer);
        }

        public ActionResult Details()
        {
            return View();
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult Details(int id)
        {
            Lawyer lawyer = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/");
                //HTTP GET
                var responseTask = client.GetAsync("lawyer?lid=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Lawyer>();
                    readTask.Wait();

                    lawyer = readTask.Result;
                }
            }

            return View(lawyer);
        }

        public ActionResult Edit(int id)
        {
            Lawyer lawyer = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/");
                //HTTP GET
                var responseTask = client.GetAsync("lawyer?lid=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Lawyer>();
                    readTask.Wait();

                    lawyer = readTask.Result;
                }
            }

            return View(lawyer);
        }

        [HttpPost]
        public ActionResult Edit(Lawyer lawyer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/lawyer");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Lawyer>("lawyer", lawyer);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(lawyer);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("lawyer/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }



    }

}
