using Microsoft.AspNetCore.Mvc;
using InternManagementData.Models;
using Newtonsoft.Json;
using System.Text;
using InternManagementData.DTO;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Net.Http;

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
                return PartialView("_add", new InternProfileDTO());
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                using (var httpClient = new HttpClient())
                using (var response = await httpClient.GetAsync(apiUrl + "GetById?code=" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        var result = JsonConvert.DeserializeObject<InternProfile>(content);
                          return PartialView("_edit", new InternProfileDTO { InternAddress =  result.InternAddress,
                          InternEmail = result.InternEmail,
                          InternID = result.InternId,
                          InternName = result.InternName,
                          InternPhone = result.InternPhone,
                          Major = result.Major,
                          University = result.University});
                    }
                    throw new Exception("id is not exits");
                }

              
            }
            catch (Exception ex)
            {
                // Log the exception
                // LogError(ex);
                return BadRequest("An error occurred while loading the form.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(InternProfileDTO profileDTO)
        {

            try
            {
                var payload = new
                {
                    InternID = profileDTO.InternID,
                    InternName = profileDTO.InternName,
                    InternAddress = profileDTO.InternAddress,
                    InternEmail = profileDTO.InternEmail,
                    InternPhone = profileDTO.InternPhone,
                    University = profileDTO.University,
                    Major = profileDTO.Major
                };


                var jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var result = new List<InternProfile>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync(apiUrl + "Create", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return Json(new { status = 1, message = "Intern profile created successfully." });

                        }
                    }
                }
                return Json(new { status = 0, message = "Failed to create intern profile: " });

            }
            catch (Exception ex)
            {
                return Json(new { status = 0, message = "Failed to create intern profile: " + ex });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InternProfileDTO profileDTO)
        {

            try
            {
                var payload = new
                {
                    InternID = profileDTO.InternID,
                    InternName = profileDTO.InternName,
                    InternAddress = profileDTO.InternAddress,
                    InternEmail = profileDTO.InternEmail,
                    InternPhone = profileDTO.InternPhone,
                    University = profileDTO.University,
                    Major = profileDTO.Major
                };


                var jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var result = new List<InternProfile>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync(apiUrl + "Update", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return Json(new { status = 1, message = "Intern profile Updated successfully." });

                        }
                    }
                }
                return Json(new { status = 0, message = "Failed to update intern profile: " });

            }
            catch (Exception ex)
            {
                return Json(new { status = 0, message = "Failed to update intern profile: " + ex });
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
