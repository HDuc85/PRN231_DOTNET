using InternManagementBusiness.Category;
using InternManagementData.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternManagementWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InternController : ControllerBase
    {
        private readonly InternBusiness _internBusiness;

        public InternController()
        {
            _internBusiness = new InternBusiness();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _internBusiness.GetAll();
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
            var result = await _internBusiness.GetById(code);
            if (result.Status > 0)
            {
                return Ok(result.Data as InternProfile);
            }
            else { return NotFound(result.Message); }
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(InternProfile profile)
        {
            var result = await _internBusiness.Create(profile);
            if (result.Status > 0)
            {
                return Ok(result.Data as InternProfile);
            } 
            else {  return NotFound(result.Message); }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(InternProfile profile)
        {
            var result = await _internBusiness.Update(profile);
            if (result.Status > 0)
            {
                return Ok(result.Data as InternProfile);
            }
            else { return NotFound(result.Message); }
        }
        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> Remove(InternProfile profile)
        {
            var result = await _internBusiness.Remove(profile);
            if (result.Status > 0)
            {
                return Ok(result.Data as InternProfile);
            }
            else { return NotFound(result.Message); }
        }
    }
}
