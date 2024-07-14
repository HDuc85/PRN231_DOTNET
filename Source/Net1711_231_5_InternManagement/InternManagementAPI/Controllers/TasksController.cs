using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternManagementData.Models;
using Task = InternManagementData.Models.Task;
using InternManagementBusiness.Category;
using InternManagementData.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InternManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskBusiness _taskBusiness;

        public TasksController()
        {
            _taskBusiness = new TaskBusiness();
        }

        // GET: api/Tasks
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _taskBusiness.GetAll();
            if (result.Status > 0)
            {
                return Ok(result.Data);
            }
            else { return NotFound(result.Message); }
        }

        // GET: api/Tasks/5
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int code)
        {
            var result = await _taskBusiness.GetById(code);
            if (result.Status > 0)
            {
                return Ok(result.Data as Task);
            }
            else { return NotFound(result.Message); }
        }

        [HttpPost]
        [Route("Search")]
        public async Task<IActionResult> Search(TaskSearchRequest request)
        {
            var result = await _taskBusiness.Search(request);
            if (result.Status > 0)
            {
                return Ok(result.Data);
            }
            else { return NotFound(result.Message); }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(TaskDTO request)
        { 
            var task = new Task
            {
                 TaskId = request.TaskId ,
                 TaskName = request.TaskName ,
                 TaskDecription = request.TaskDecription ,
                 StartDate = request.StartDate ,
                 EndDate = request.EndDate ,
                 Priority = request.Priority ,
                 TaskCategory = request.TaskCategory ,
                 Comments = request.Comments ,
                 DateCreated = request.DateCreated ,
                 LastUpdated = request.LastUpdated ,
                 StatusId = request.StatusId,
            };

            var result = await _taskBusiness.Update(task);
            if (result.Status > 0)
            {
                return Ok(result.Data as Task);
            }
            else { return NotFound(result.Message); }
        }
        

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Task>> PostTask(TaskDTO request)
        {
            var task = new Task
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

            var result = await _taskBusiness.Create(task);
            if (result.Status > 0)
            {
                return Ok(result.Data as Task);
            }
            else { return NotFound(result.Message); }

           
        }

    
        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> Remove(int taskid)
        {
            var task = await _taskBusiness.GetById(taskid);
            Task taskData = task.Data as Task;
            var result = await _taskBusiness.Remove(taskData);
            if (result.Status > 0)
            {
                return Ok(result.Data as Task);
            }
            else { return NotFound(result.Message); }
        }
    }
}
