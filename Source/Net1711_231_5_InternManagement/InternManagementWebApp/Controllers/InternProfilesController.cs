using Microsoft.AspNetCore.Mvc;
using InternManagementData.Models;
using Newtonsoft.Json;

namespace InternManagementWebApp.Controllers
{
    public class InternProfilesController : Controller
    {
        private string apiUrl = "https://localhost:7038/api/Intern/";
        public InternProfilesController()
        {
        }
        public IActionResult index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<InternProfile>> GetAll()
        {
            try
            {
                var result = new List<InternProfile>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetAll"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<List<InternProfile>>(content);
                        }
                    }
                }
                return result;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
