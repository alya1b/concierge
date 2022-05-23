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
    public class CarTenantRelationshipsController : Controller
    {
        private readonly ConciergeContext _context;

        public CarTenantRelationshipsController(ConciergeContext context)
        {
            _context = context;
        }

        // GET: CarTenantRelationships
        public async Task<IActionResult> Index()
        {
            var conciergeContext = _context.CarTenantRelationships.Include(c => c.NumberNavigation).Include(c => c.Tenant);
            return View(await conciergeContext.ToListAsync());
        }

        // GET: CarTenantRelationships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarTenantRelationships == null)
            {
                return NotFound();
            }

            var carTenantRelationship = await _context.CarTenantRelationships
                .Include(c => c.NumberNavigation)
                .Include(c => c.Tenant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carTenantRelationship == null)
            {
                return NotFound();
            }

            return View(carTenantRelationship);
        }

        // GET: CarTenantRelationships/Create
        public IActionResult Create()
        {
            ViewData["Number"] = new SelectList(_context.Cars, "Number", "Number");
            ViewData["TenantId"] = new SelectList(_context.Tenants, "TenantId", "Email");
            return View();
        }

        // POST: CarTenantRelationships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,TenantId")] CarTenantRelationship carTenantRelationship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carTenantRelationship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Number"] = new SelectList(_context.Cars, "Number", "Number", carTenantRelationship.Number);
            ViewData["TenantId"] = new SelectList(_context.Tenants, "TenantId", "Email", carTenantRelationship.TenantId);
            return View(carTenantRelationship);
        }

        // GET: CarTenantRelationships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarTenantRelationships == null)
            {
                return NotFound();
            }

            var carTenantRelationship = await _context.CarTenantRelationships.FindAsync(id);
            if (carTenantRelationship == null)
            {
                return NotFound();
            }
            ViewData["Number"] = new SelectList(_context.Cars, "Number", "Number", carTenantRelationship.Number);
            ViewData["TenantId"] = new SelectList(_context.Tenants, "TenantId", "Email", carTenantRelationship.TenantId);
            return View(carTenantRelationship);
        }

        // POST: CarTenantRelationships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,TenantId")] CarTenantRelationship carTenantRelationship)
        {
            if (id != carTenantRelationship.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carTenantRelationship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarTenantRelationshipExists(carTenantRelationship.Id))
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
            ViewData["Number"] = new SelectList(_context.Cars, "Number", "Number", carTenantRelationship.Number);
            ViewData["TenantId"] = new SelectList(_context.Tenants, "TenantId", "Email", carTenantRelationship.TenantId);
            return View(carTenantRelationship);
        }

        // GET: CarTenantRelationships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarTenantRelationships == null)
            {
                return NotFound();
            }

            var carTenantRelationship = await _context.CarTenantRelationships
                .Include(c => c.NumberNavigation)
                .Include(c => c.Tenant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carTenantRelationship == null)
            {
                return NotFound();
            }

            return View(carTenantRelationship);
        }

        // POST: CarTenantRelationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarTenantRelationships == null)
            {
                return Problem("Entity set 'ConciergeContext.CarTenantRelationships'  is null.");
            }
            var carTenantRelationship = await _context.CarTenantRelationships.FindAsync(id);
            if (carTenantRelationship != null)
            {
                _context.CarTenantRelationships.Remove(carTenantRelationship);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarTenantRelationshipExists(int id)
        {
          return _context.CarTenantRelationships.Any(e => e.Id == id);
        }
    }
}
