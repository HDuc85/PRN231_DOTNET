<<<<<<< HEAD
using InternManagementData.DTO;
using InternManagementWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
=======
using Azure.Core;
using InternManagementData.DTO;
using InternManagementData.Models;
using InternManagementWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Policy;
using System.Text;
>>>>>>> 0f76685bb13278b4ca612a3b2abd16e6aca92ffa

namespace InternManagementWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
<<<<<<< HEAD
        private readonly IHttpClientFactory _clientFactory;
        private const string LoginApiUrl = "https://localhost:7038/api/Account/Login";

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

=======

        private string LoginapiUrl = "https://localhost:7038/api/Account/Login";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


>>>>>>> 0f76685bb13278b4ca612a3b2abd16e6aca92ffa
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                var jsonPayload = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

<<<<<<< HEAD
                var client = _clientFactory.CreateClient();
                var response = await client.PostAsync(LoginApiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    HttpContext.Session.SetString("accessToken", jsonResponse);
                    return RedirectToAction("Index", "InternProfiles");
                }

                ViewBag.ErrorMessage = "Email or password incorrect";
                return View("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while logging in.");
                return RedirectToAction("Error");
            }
        }

=======
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
>>>>>>> 0f76685bb13278b4ca612a3b2abd16e6aca92ffa
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
<<<<<<< HEAD
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(errorViewModel);
=======
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
>>>>>>> 0f76685bb13278b4ca612a3b2abd16e6aca92ffa
        }
    }
}
