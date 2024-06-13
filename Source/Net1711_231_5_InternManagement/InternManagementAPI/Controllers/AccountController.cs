using InternManagementData.DTO;
using InternManagementData.Models;
using InternManagementData.Repository.Interface;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InternManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IInternRepository internRepository;
        private readonly IMentorRepository mentorRepository;

        private readonly IConfiguration _config;

        public AccountController(IInternRepository internRepository,
                IMentorRepository mentorRepository,
                IConfiguration config)
        {
            this.internRepository = internRepository;
            this.mentorRepository = mentorRepository;

            _config = config;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var intern = this.internRepository.CheckLogin(request.Email, request.Password);
            
            var mentor = this.mentorRepository.CheckLogin(request.Email, request.Password);
            

            if(intern != null)
            {
               var token = this.GenerateJSONWebToken(intern);

                return Ok(token);
            }

            if (mentor != null)
            {
                var token = this.GenerateJSONWebToken(mentor);

                return Ok(token);
            }
            return Unauthorized();

        }

        private string GenerateJSONWebToken(MentorProfile mentorProfile)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              new Claim[]
              {
                  new(ClaimTypes.Email, mentorProfile.MentorEmail),
                 // new(ClaimTypes.Role, userInfo.Role.ToString()),
                  new("userId", mentorProfile.MentorId.ToString()),
              },
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials
              );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private string GenerateJSONWebToken(InternProfile internProfile)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              new Claim[]
              {
                  new(ClaimTypes.Email, internProfile.InternEmail),
                 // new(ClaimTypes.Role, userInfo.Role.ToString()),
                  new("userId", internProfile.InternId.ToString()),
              },
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials
              );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }

}
