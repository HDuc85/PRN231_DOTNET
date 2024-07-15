using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternManagementData.Models;

namespace InternManagementWebApp.Views
{
    public class MentorProfilesController : Controller
    {
        private readonly Net17112315InternManagementContext _context;

        public MentorProfilesController(Net17112315InternManagementContext context)
        {
            _context = context;
        }

        // GET: MentorProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.MentorProfiles.ToListAsync());
        }

        // GET: MentorProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentorProfile = await _context.MentorProfiles
                .FirstOrDefaultAsync(m => m.MentorId == id);
            if (mentorProfile == null)
            {
                return NotFound();
            }

            return View(mentorProfile);
        }

        // GET: MentorProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MentorProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MentorId,MentorName,MentorAddress,MentorPhone,MentorEmail,Password")] MentorProfile mentorProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mentorProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mentorProfile);
        }

        // GET: MentorProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentorProfile = await _context.MentorProfiles.FindAsync(id);
            if (mentorProfile == null)
            {
                return NotFound();
            }
            return View(mentorProfile);
        }

        // POST: MentorProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MentorId,MentorName,MentorAddress,MentorPhone,MentorEmail,Password")] MentorProfile mentorProfile)
        {
            if (id != mentorProfile.MentorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mentorProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MentorProfileExists(mentorProfile.MentorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mentorProfile);
        }

        // GET: MentorProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentorProfile = await _context.MentorProfiles
                .FirstOrDefaultAsync(m => m.MentorId == id);
            if (mentorProfile == null)
            {
                return NotFound();
            }

            return View(mentorProfile);
        }

        // POST: MentorProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mentorProfile = await _context.MentorProfiles.FindAsync(id);
            if (mentorProfile != null)
            {
                _context.MentorProfiles.Remove(mentorProfile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MentorProfileExists(int id)
        {
            return _context.MentorProfiles.Any(e => e.MentorId == id);
        }
    }
}
