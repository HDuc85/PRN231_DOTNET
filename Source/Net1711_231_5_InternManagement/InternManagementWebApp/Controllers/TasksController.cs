using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternManagementData.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

using Task = InternManagementData.Models.Task;
using InternManagementData.DTO;
using System.Text;
using Azure.Core;

namespace InternManagementWebApp.Controllers
{
    public class TasksController : Controller
    {

        
        private string apiUrl = "https://localhost:7038/api/Tasks/";
        private readonly int PageSize = 10;

        public TasksController()
        {
            
        }

        [HttpGet]
        public async Task<List<Task>> GetAll()
        {
            try
            {
                var result = new List<Task>();
                using (var httpClient = new HttpClient())
                {
                    string token = HttpContext.Session.GetString("accessToken");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    using (var response = await httpClient.GetAsync(apiUrl + "GetAll"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<List<Task>>(content);
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public async Task<Task> GetById(int? id)
        {
            try
            {
                var result = new Task();
                using (var httpClient = new HttpClient())
                {
                    string token = HttpContext.Session.GetString("accessToken");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    using (var response = await httpClient.GetAsync(apiUrl + "GetById?code=" + id))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<Task>(content);
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(TaskDTO request)
        {

            try
            {
                var payload = new
                {
                    TaskId = request.TaskId,
                    TaskName = request.TaskName,
                    TaskDecription = request.TaskDecription,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Priority = request.Priority,
                    TaskCategory = request.TaskCategory,
                    Comments = request.Comments,
                    DateCreated = request.DateCreated,
                    LastUpdated = request.LastUpdated,
                    StatusId = request.StatusId,
                };


                var jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var result = new List<Task>();
                using (var httpClient = new HttpClient())
                {
                    string token = HttpContext.Session.GetString("accessToken");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using (var response = await httpClient.PostAsync(apiUrl + "Create", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return Json(new { status = 1, message = "Task created successfully." });

                        }
                    }
                }
                return Json(new { status = 0, message = "Failed to create Task: " });

            }
            catch (Exception ex)
            {
                return Json(new { status = 0, message = "Failed to create Task: " + ex });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TaskDTO request)
        {

            try
            {
                var payload = new
                {
                    TaskId = request.TaskId,
                    TaskName = request.TaskName,
                    TaskDecription = request.TaskDecription,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Priority = request.Priority,
                    TaskCategory = request.TaskCategory,
                    Comments = request.Comments,
                    DateCreated = request.DateCreated,
                    LastUpdated = request.LastUpdated,
                    StatusId = request.StatusId,
                };


                var jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var result = new List<Task>();
                using (var httpClient = new HttpClient())
                {
                    string token = HttpContext.Session.GetString("accessToken");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using (var response = await httpClient.PutAsync(apiUrl + "Update", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return Json(new { status = 1, message = "Task Updated successfully." });

                        }
                    }
                }
                return Json(new { status = 0, message = "Failed to update Task: " });

            }
            catch (Exception ex)
            {
                return Json(new { status = 0, message = "Failed to update Task: " + ex });
            }
        }
        [HttpGet]
        public IActionResult Search()
        {
          return  RedirectToAction("Index");
        }
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            string token = HttpContext.Session.GetString("accessToken");
            if (token == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Task> takes = new List<Task>();
            var tasks = HttpContext.Session.GetString("tasks");
            if(tasks == null)
            {
                takes = await this.GetAll();
            }
            else
            {
                takes = JsonConvert.DeserializeObject<List<Task>>(tasks);
            }
            ViewBag.TotalCount = takes.Count;
            ViewBag.pageNumber = pageNumber;

            var result = takes.Skip((pageNumber-1)*PageSize ).Take(PageSize);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Search([FromBody] List<KeyValuePair<string, string>> searchCriteria)
        {
            if (searchCriteria == null || !searchCriteria.Any())
            {
                HttpContext.Session.Remove("tasks");


                return Json(new { success = true, redirectUrl = Url.Action("Index", "Tasks") });

            }



            var payload = new
            {
                TaskName = string.Empty,
                TaskDescription = string.Empty,
                StartDate = (DateTime?)null,
                EndDate = (DateTime?)null,
                Priority = (int?)null,
                TaskCategory = string.Empty,
                Comments = string.Empty
            };
            var payloadDict = payload.GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(payload));

            foreach (var criteria in searchCriteria)
            {
                switch (criteria.Key)
                {
                    case "TaskName":
                        payloadDict["TaskName"] = criteria.Value;
                        break;
                    case "TaskDescription":
                        payloadDict["TaskDescription"] = criteria.Value;
                        break;
                    case "Priority":
                        payloadDict["Priority"] = criteria.Value;
                        break;
                    case "TaskCategory":
                        payloadDict["TaskCategory"] = criteria.Value;
                        break;
                    case "Comments":
                        payloadDict["Comments"] = criteria.Value;
                        break;
                }
            }
           

            try
            {
                var updatedPayload = new
                {
                    taskName = payloadDict["TaskName"],
                    taskDecription = payloadDict["TaskDescription"],
                    startDate = payloadDict["StartDate"],
                    endDate = payloadDict["EndDate"],
                    priority = payloadDict["Priority"],
                    taskCategory = payloadDict["TaskCategory"],
                    comments = payloadDict["Comments"]
                };


                var jsonPayload = JsonConvert.SerializeObject(updatedPayload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var result = new List<Task>();
                using (var httpClient = new HttpClient())
                {
                    string token = HttpContext.Session.GetString("accessToken");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using (var response = await httpClient.PostAsync(apiUrl + "Search", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            HttpContext.Session.SetString("tasks", await response.Content.ReadAsStringAsync());
                           
                            return Json(new { success = true, redirectUrl = Url.Action("Index", "Tasks") });
                           
                        }
                    }
                }
                return Json(new { status = 0, message = "Failed to update Task: " });

            }
            catch (Exception ex)
            {
                return Json(new { status = 0, message = "Failed to update Task: " + ex });
            }


          
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await this.GetById(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        public IActionResult Create()
        {
            List<int> statusIds = new List<int> { 1, 2, 3, 4 };

            // Create SelectList using SelectListItem constructor
            var selectList = new SelectList(statusIds.Select(id => new SelectListItem
            {
                Value = id.ToString(),
                Text = id.ToString()
            }), "Value", "Text");
            ViewData["StatusId"] = selectList;
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> Create([Bind("TaskId,TaskName,TaskDecription,StartDate,EndDate,Priority,TaskCategory,Comments,DateCreated,LastUpdated,StatusId")] InternManagementData.Models.Task request)
        {
            if (ModelState.IsValid)
            {
                var Dto = new TaskDTO() 
                {
                    TaskId = request.TaskId,
                    TaskName = request.TaskName,
                    TaskDecription = request.TaskDecription,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Priority = request.Priority,
                    TaskCategory = request.TaskCategory,
                    Comments = request.Comments,
                    DateCreated = request.DateCreated,
                    LastUpdated = request.LastUpdated,
                    StatusId = request.StatusId,
                };


                await this.Save(Dto);
                return RedirectToAction(nameof(Index));
            }
            List<int> statusIds = new List<int> { 1, 2, 3, 4 };

            
            var selectList = new SelectList(statusIds.Select(id => new SelectListItem
            {
                Value = id.ToString(),
                Text = id.ToString()
            }), "Value", "Text");
            ViewData["StatusId"] = selectList;
            return View(request);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await this.GetById(id);
            if (task == null)
            {
                return NotFound();
            }

            List<int> statusIds = new List<int> { 1, 2, 3, 4 };


            var selectList = new SelectList(statusIds.Select(id => new SelectListItem
            {
                Value = id.ToString(),
                Text = id.ToString()
            }), "Value", "Text");
            ViewData["StatusId"] = new SelectList(selectList);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,TaskName,TaskDecription,StartDate,EndDate,Priority,TaskCategory,Comments,DateCreated,LastUpdated,StatusId")] InternManagementData.Models.Task request)
        {
            if (id != request.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var Dto = new TaskDTO()
                    {
                        TaskId = request.TaskId,
                        TaskName = request.TaskName,
                        TaskDecription = request.TaskDecription,
                        StartDate = request.StartDate,
                        EndDate = request.EndDate,
                        Priority = request.Priority,
                        TaskCategory = request.TaskCategory,
                        Comments = request.Comments,
                        DateCreated = request.DateCreated,
                        LastUpdated = request.LastUpdated,
                        StatusId = request.StatusId,
                    };
                    var task =  await this.Edit(Dto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TaskExists(request.TaskId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            List<int> statusIds = new List<int> { 1, 2, 3, 4 };


            var selectList = new SelectList(statusIds.Select(id => new SelectListItem
            {
                Value = id.ToString(),
                Text = id.ToString()
            }), "Value", "Text");
            ViewData["StatusId"] = new SelectList(selectList);
            return View(request);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await this.GetById(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await this.GetById(id);
            if (task != null)
            {
                await this.Delete(id);
            }

           
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public async Task<string> Delete(int id)
        {
            try
            {
                string? result = null;
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(apiUrl + "Remove?taskid=" + id))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            result = "Delete Successful";
                        }
                        else
                        {
                            result = "Can not Delete";
                        }

                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private async Task<bool> TaskExists(int id)
        {
            var task = await this.GetById(id);
            if(task != null)
            {
                return true;
            }
            return false;
        }
    }
}
