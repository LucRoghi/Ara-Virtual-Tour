using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AraVirtualTour;

namespace AraVirtualTour.Controllers
{
    public class VirtualTourController : Controller
    {
        private readonly AppContext _context;

        public VirtualTourController(AppContext context)
        {
            _context = context;
        }

        // GET: VirtualTour
        public async Task<IActionResult> Index()
        {
              return _context.VirtualTourModel != null ? 
                          View(await _context.VirtualTourModel.ToListAsync()) :
                          Problem("Entity set 'AppContext.VirtualTourModel'  is null.");
        }

        // GET: VirtualTour/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VirtualTourModel == null)
            {
                return NotFound();
            }

            var virtualTourModel = await _context.VirtualTourModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (virtualTourModel == null)
            {
                return NotFound();
            }

            return View(virtualTourModel);
        }

        // GET: VirtualTour/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VirtualTour/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Link")] VirtualTourModel virtualTourModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(virtualTourModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(virtualTourModel);
        }

        // GET: VirtualTour/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VirtualTourModel == null)
            {
                return NotFound();
            }

            var virtualTourModel = await _context.VirtualTourModel.FindAsync(id);
            if (virtualTourModel == null)
            {
                return NotFound();
            }
            return View(virtualTourModel);
        }

        // POST: VirtualTour/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Link")] VirtualTourModel virtualTourModel)
        {
            if (id != virtualTourModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(virtualTourModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VirtualTourModelExists(virtualTourModel.id))
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
            return View(virtualTourModel);
        }

        // GET: VirtualTour/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VirtualTourModel == null)
            {
                return NotFound();
            }

            var virtualTourModel = await _context.VirtualTourModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (virtualTourModel == null)
            {
                return NotFound();
            }

            return View(virtualTourModel);
        }

        // POST: VirtualTour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VirtualTourModel == null)
            {
                return Problem("Entity set 'AppContext.VirtualTourModel'  is null.");
            }
            var virtualTourModel = await _context.VirtualTourModel.FindAsync(id);
            if (virtualTourModel != null)
            {
                _context.VirtualTourModel.Remove(virtualTourModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VirtualTourModelExists(int id)
        {
          return (_context.VirtualTourModel?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
