using InternManagementBusiness.Category;
using InternManagementData.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternManagementWebAPI.Controllers
{
  [ApiController]
  [Route("api/program")]
  public class ProgramController : ControllerBase
  {
    private readonly ProgramBusiness _programBusiness;

    public ProgramController()
    {
      _programBusiness = new ProgramBusiness();
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
      var result = await _programBusiness.GetAll();
      if (result.Status > 0)
      {
        return Ok(result.Data);
      }
      else { return NotFound(result.Message); }
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
      var result = await _programBusiness.GetById(id);
      if (result.Status > 0)
      {
        return Ok(result.Data as MentorProfile);
      }
      else { return NotFound(result.Message); }
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(TrainingProgram program)
    {
      var result = await _programBusiness.Create(program);
      if (result.Status > 0)
      {
        return Ok(result.Data as MentorProfile);
      }
      else { return NotFound(result.Message); }
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Update(TrainingProgram program)
    {
      var result = await _programBusiness.Update(program);
      if (result.Status > 0)
      {
        return Ok(result.Data as InternProfile);
      }
      else { return NotFound(result.Message); }
    }

    [HttpDelete]
    [Route("Remove")]
    public async Task<IActionResult> Remove(int id)
    {
      var result = await _programBusiness.Remove(id);
      if (result.Status > 0)
      {
        return Ok(result.Data);
      }
      else { return NotFound(result.Message); }
    }
  }
}
