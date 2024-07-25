using Azure.Core;
using InternManagementBusiness.Category;
using InternManagementData.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobboardProfileController : ControllerBase
    {
        private JobboardBusiness jobboardBusiness;
        public JobboardProfileController()
        {
            jobboardBusiness = new JobboardBusiness();
        }
        // GET: api/<JobboardProfileController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? search)
        {
            var result = await jobboardBusiness.GetAll(search);
            return Ok(result.Data);
        }

        // GET api/<JobboardProfileController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await jobboardBusiness.GetById(id);
            return Ok(result.Data);
        }

        // POST api/<JobboardProfileController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobboardProfileRequest request)
        {
            var result = await jobboardBusiness.Create(request);
            return Created("", result.Data);
        }

        // PUT api/<JobboardProfileController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] JobboardProfileRequest request)
        {
            var result = await jobboardBusiness.Update(id, request);
            return Ok(result.Data);
        }

        // DELETE api/<JobboardProfileController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await jobboardBusiness.Remove(id);
            return Ok(result.Data);
        }
    }
}
