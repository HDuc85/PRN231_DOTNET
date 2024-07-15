using InternManagementBusiness.Category;
using InternManagementData.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternManagementWebAPI.Controllers
{
  [ApiController]
  [Route("api/mentor")]
  public class MentorController : ControllerBase
  {
    private readonly MentorBusiness _mentorBusiness;

    public MentorController()
    {
      _mentorBusiness = new MentorBusiness();
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
      var result = await _mentorBusiness.GetAll();
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
      var result = await _mentorBusiness.GetById(id);
      if (result.Status > 0)
      {
        return Ok(result.Data as MentorProfile);
      }
      else { return NotFound(result.Message); }
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(MentorProfile profile)
    {
      var result = await _mentorBusiness.Create(profile);
      if (result.Status > 0)
      {
        return Ok(result.Data as MentorProfile);
      }
      else { return NotFound(result.Message); }
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Update(MentorProfile profile)
    {
      var result = await _mentorBusiness.Update(profile);
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
      var result = await _mentorBusiness.Remove(id);
      if (result.Status > 0)
      {
        return Ok(result.Data as InternProfile);
      }
      else { return NotFound(result.Message); }
    }
  }
}
