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
    public class TStudentProfilesController : Controller
    {
        private readonly CramSchoolDBContext _context;

        public TStudentProfilesController(CramSchoolDBContext context)
        {
            _context = context;
        }

        // GET: TStudentProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.TStudentProfiles.ToListAsync());
        }

        // GET: TStudentProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tStudentProfile = await _context.TStudentProfiles
                .FirstOrDefaultAsync(m => m.FId == id);
            if (tStudentProfile == null)
            {
                return NotFound();
            }

            return View(tStudentProfile);
        }

        // GET: TStudentProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TStudentProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FId,FAccount,FPassword,FName,FGender,FBirthDate,FPhone,FEmail,FAddress,FEnrollment,FGrade,FStatus,FThumbnailUrl,FParentName,FCreateDate,FUpdateDate")] TStudentProfile tStudentProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tStudentProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tStudentProfile);
        }

        // GET: TStudentProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tStudentProfile = await _context.TStudentProfiles.FindAsync(id);
            if (tStudentProfile == null)
            {
                return NotFound();
            }
            return View(tStudentProfile);
        }

        // POST: TStudentProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FId,FAccount,FPassword,FName,FGender,FBirthDate,FPhone,FEmail,FAddress,FEnrollment,FGrade,FStatus,FThumbnailUrl,FParentName,FCreateDate,FUpdateDate")] TStudentProfile tStudentProfile)
        {
            if (id != tStudentProfile.FId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tStudentProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TStudentProfileExists(tStudentProfile.FId))
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
            return View(tStudentProfile);
        }

        // GET: TStudentProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tStudentProfile = await _context.TStudentProfiles
                .FirstOrDefaultAsync(m => m.FId == id);
            if (tStudentProfile == null)
            {
                return NotFound();
            }

            return View(tStudentProfile);
        }

        // POST: TStudentProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tStudentProfile = await _context.TStudentProfiles.FindAsync(id);
            _context.TStudentProfiles.Remove(tStudentProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TStudentProfileExists(int id)
        {
            return _context.TStudentProfiles.Any(e => e.FId == id);
        }
    }
}
