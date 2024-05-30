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
        
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                return PartialView("_add", new InternProfile());
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<List<InternProfile>?> Remove(int id)
        {
            try
            {
                List<InternProfile>? result = null;
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(apiUrl + "Create" + id))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var data = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<List<InternProfile>>(data);
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
