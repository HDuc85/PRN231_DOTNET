using InternManagementBusiness.Category;
using InternManagementData.DTO;
using m = InternManagementData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;

namespace InternManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskBusiness _taskBusiness;
        public TaskController()
        {
            _taskBusiness = new TaskBusiness();
        }

        [HttpGet]
        [Route("GetAll")]
        /*[Authorize]*/
        public async Task<IActionResult> GetAll()
        {
            var result = await _taskBusiness.GetAll();
            if (result.Status > 0)
            {
                return Ok(result.Data);
            }
            else { return NotFound(result.Message); }
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int code)
        {
            var result = await _taskBusiness.GetById(code);
            if (result.Status > 0)
            {
                return Ok(result.Data as m.Task);
            }
            else { return NotFound(result.Message); }
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(TaskRequest request)
        {
            m.Task task = new m.Task
            {
                TaskName = request.TaskName,
                TaskDescription = request.TaskDecription,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                StatusId = request.StatusId,
            };
            var result = await _taskBusiness.Create(task);
            if (result.Status > 0)
            {
                return Ok(result.Data as m.Task);
            }
            else { return NotFound(result.Message); }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(TaskDTO request)
        {
            m.Task profile = new m.Task
            {
                TaskId = request.TaskId,
                TaskName = request.TaskName,
                TaskDescription = request.TaskDescription,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                StatusId = request.StatusId,
                ProgramTasks = request.ProgramTasks,
                TaskManages = request.TaskManages,
            };

            var result = await _taskBusiness.Update(profile);
            if (result.Status > 0)
            {
                return Ok(result.Data as m.Task);
            }
            else { return NotFound(result.Message); }
        }
        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _taskBusiness.GetById(id);
            m.Task? task = result.Data as m.Task;
            result = await _taskBusiness.Remove(task);
            if (result.Status > 0)
            {
                return Ok(result.Data as m.Task);
            }
            else { return NotFound(result.Message); }
        }
    }
}
