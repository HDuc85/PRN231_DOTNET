using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternManagementData.Models;

namespace InternManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly Net17112315InternManagementContext _context;

        public MentorController(Net17112315InternManagementContext context)
        {
            _context = context;
        }

        // GET: api/MentorProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MentorProfile>>> GetMentorProfiles()
        {
            return await _context.MentorProfiles.ToListAsync();
        }

        // GET: api/MentorProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MentorProfile>> GetMentorProfile(int id)
        {
            var mentorProfile = await _context.MentorProfiles.FindAsync(id);

            if (mentorProfile == null)
            {
                return NotFound();
            }

            return mentorProfile;
        }

        // PUT: api/MentorProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMentorProfile(int id, MentorProfile mentorProfile)
        {
            if (id != mentorProfile.MentorId)
            {
                return BadRequest();
            }

            _context.Entry(mentorProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MentorProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool MentorProfileExists(int id)
        {
            return _context.MentorProfiles.Any(e => e.MentorId == id);
        }
    }
}
