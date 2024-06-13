using InternManagementBusiness.Category;
using InternManagementData.DTO;
using InternManagementData.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
        public async Task<IActionResult> Create(InternProfileDTO profileDTO)
        {
            var profile = new InternProfile
            {
                InternId = profileDTO.InternID,
                InternName = profileDTO.InternName,
                InternAddress = profileDTO.InternAddress,
                InternEmail = profileDTO.InternEmail,
                InternPhone = profileDTO.InternPhone,
                University = profileDTO.University,
                Major = profileDTO.Major
            };
            var result = await _internBusiness.Create(profile);
            if (result.Status > 0)
            {
                return Ok(result.Data as InternProfile);
            } 
            else {  return NotFound(result.Message); }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(InternProfileDTO profileDTO)
        {


            var profile = new InternProfile
            {
                InternId = profileDTO.InternID,
                InternName = profileDTO.InternName,
                InternAddress = profileDTO.InternAddress,
                InternEmail = profileDTO.InternEmail,
                InternPhone = profileDTO.InternPhone,
                University = profileDTO.University,
                Major = profileDTO.Major
            };

            var result = await _internBusiness.Update(profile);
            if (result.Status > 0)
            {
                return Ok(result.Data as InternProfile);
            }
            else { return NotFound(result.Message); }
        }
        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> Remove(int profileid)
        {
            var profile = await _internBusiness.GetById(profileid);
            InternProfile internProfile = profile.Data as InternProfile;
            var result = await _internBusiness.Remove(internProfile);
            if (result.Status > 0)
            {
                return Ok(result.Data as InternProfile);
            }
            else { return NotFound(result.Message); }
        }
    }
}
