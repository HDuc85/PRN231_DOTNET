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


    }
}
