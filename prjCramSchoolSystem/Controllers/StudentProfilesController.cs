using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prjCramSchoolSystem.Models;

namespace prjCramSchoolSystem.Controllers
{
    public class StudentProfilesController : Controller
    {
        private readonly CramSchoolDBContext _context;

        public StudentProfilesController(CramSchoolDBContext context)
        {
            _context = context;
        }

        // GET: StudentProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentProfiles.ToListAsync());
        }

        // GET: StudentProfiles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentProfile = await _context.StudentProfiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentProfile == null)
            {
                return NotFound();
            }

            return View(studentProfile);
        }

        // GET: StudentProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Gender,BirthDate,Address,Enrollment,Grade,Status,ThumbnailName,FatherName,MotherName,CreateDate,UpdateDate,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] StudentProfile studentProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentProfile);
        }

        // GET: StudentProfiles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentProfile = await _context.StudentProfiles.FindAsync(id);
            if (studentProfile == null)
            {
                return NotFound();
            }
            return View(studentProfile);
        }

        // POST: StudentProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,Gender,BirthDate,Address,Enrollment,Grade,Status,ThumbnailName,FatherName,MotherName,CreateDate,UpdateDate,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] StudentProfile studentProfile)
        {
            if (id != studentProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentProfileExists(studentProfile.Id))
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
            return View(studentProfile);
        }

        // GET: StudentProfiles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentProfile = await _context.StudentProfiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentProfile == null)
            {
                return NotFound();
            }

            return View(studentProfile);
        }

        // POST: StudentProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var studentProfile = await _context.StudentProfiles.FindAsync(id);
            _context.StudentProfiles.Remove(studentProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentProfileExists(string id)
        {
            return _context.StudentProfiles.Any(e => e.Id == id);
        }
    }
}
