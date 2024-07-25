using InternManagementData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace InternManagementWebApp.Controllers
{
    public class CVController : Controller
    {
        private string apiUrl = "https://localhost:7038/api/Intern/";

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                var jsonPayload = JsonConvert.SerializeObject(null);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var result = new List<InternProfile>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync("LoginapiUrl", content))
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
