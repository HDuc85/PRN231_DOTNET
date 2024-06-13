using Azure.Core;
using InternManagementData.DTO;
using InternManagementData.Models;
using InternManagementWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Policy;
using System.Text;

namespace InternManagementWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private string LoginapiUrl = "https://localhost:7038/api/Account/Login";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                var jsonPayload = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var result = new List<InternProfile>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync(LoginapiUrl, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonResponse = await response.Content.ReadAsStringAsync();
                            HttpContext.Session.SetString("accessToken", jsonResponse);
                           return RedirectToAction("index", "InternProfiles");
                        }
                        string error = "Email or password incorrect";
                        ViewBag.ErrorMessage = error;
                          return View("Index");
                    }
                }
                

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
