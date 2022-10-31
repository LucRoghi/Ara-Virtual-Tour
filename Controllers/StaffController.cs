using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AraVirtualTour;

namespace AraVirtualTour.Controllers
{
    [Authorize(Roles = "admin")]
    public class StaffController : Controller
    {
        private readonly AppContext _context;

        public StaffController(AppContext context)
        {
            _context = context;
        }

        // GET: Staff
        public async Task<IActionResult> Index()
        {
              return _context.StaffModel != null ? 
                          View(await _context.StaffModel.ToListAsync()) :
                          Problem("Entity set 'AppContext.StaffModel'  is null.");
        }

        // GET: Staff/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StaffModel == null)
            {
                return NotFound();
            }

            var staffModel = await _context.StaffModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (staffModel == null)
            {
                return NotFound();
            }

            return View(staffModel);
        }

        // GET: Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Title,Name,Department")] StaffModel staffModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffModel);
        }

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StaffModel == null)
            {
                return NotFound();
            }

            var staffModel = await _context.StaffModel.FindAsync(id);
            if (staffModel == null)
            {
                return NotFound();
            }
            return View(staffModel);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Title,Name,Department")] StaffModel staffModel)
        {
            if (id != staffModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffModelExists(staffModel.id))
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
            return View(staffModel);
        }

        // GET: Staff/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StaffModel == null)
            {
                return NotFound();
            }

            var staffModel = await _context.StaffModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (staffModel == null)
            {
                return NotFound();
            }

            return View(staffModel);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StaffModel == null)
            {
                return Problem("Entity set 'AppContext.StaffModel'  is null.");
            }
            var staffModel = await _context.StaffModel.FindAsync(id);
            if (staffModel != null)
            {
                _context.StaffModel.Remove(staffModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffModelExists(int id)
        {
          return (_context.StaffModel?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
