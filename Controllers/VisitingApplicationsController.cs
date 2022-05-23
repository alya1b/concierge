using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConciergeWebApplication.Models;

namespace ConciergeWebApplication.Controllers
{
    public class VisitingApplicationsController : Controller
    {
        private readonly ConciergeContext _context;

        public VisitingApplicationsController(ConciergeContext context)
        {
            _context = context;
        }

        // GET: VisitingApplications
        public async Task<IActionResult> Index()
        {
            var conciergeContext = _context.VisitingApplications.Include(v => v.Apartment);
            return View(await conciergeContext.ToListAsync());
        }

        // GET: VisitingApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VisitingApplications == null)
            {
                return NotFound();
            }

            var visitingApplication = await _context.VisitingApplications
                .Include(v => v.Apartment)
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (visitingApplication == null)
            {
                return NotFound();
            }

            return View(visitingApplication);
        }

        // GET: VisitingApplications/Create
        public IActionResult Create()
        {
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentId");
            return View();
        }

        // POST: VisitingApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationId,Date,PeriodStart,PeriodEnd,Visitor,ApartmentId")] VisitingApplication visitingApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitingApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentId", visitingApplication.ApartmentId);
            return View(visitingApplication);
        }

        // GET: VisitingApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VisitingApplications == null)
            {
                return NotFound();
            }

            var visitingApplication = await _context.VisitingApplications.FindAsync(id);
            if (visitingApplication == null)
            {
                return NotFound();
            }
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentId", visitingApplication.ApartmentId);
            return View(visitingApplication);
        }

        // POST: VisitingApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationId,Date,PeriodStart,PeriodEnd,Visitor,ApartmentId")] VisitingApplication visitingApplication)
        {
            if (id != visitingApplication.ApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitingApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitingApplicationExists(visitingApplication.ApplicationId))
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
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentId", visitingApplication.ApartmentId);
            return View(visitingApplication);
        }

        // GET: VisitingApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VisitingApplications == null)
            {
                return NotFound();
            }

            var visitingApplication = await _context.VisitingApplications
                .Include(v => v.Apartment)
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (visitingApplication == null)
            {
                return NotFound();
            }

            return View(visitingApplication);
        }

        // POST: VisitingApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VisitingApplications == null)
            {
                return Problem("Entity set 'ConciergeContext.VisitingApplications'  is null.");
            }
            var visitingApplication = await _context.VisitingApplications.FindAsync(id);
            if (visitingApplication != null)
            {
                _context.VisitingApplications.Remove(visitingApplication);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitingApplicationExists(int id)
        {
          return _context.VisitingApplications.Any(e => e.ApplicationId == id);
        }
    }
}
