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
    public class TenantsController : Controller
    {
        private readonly ConciergeContext _context;
        public TenantsController(ConciergeContext context)
        {
            _context = context;
        }
        // GET: Tenants
        public async Task<IActionResult> Index(int? id, int? number)
        {
            if (id == null) return RedirectToAction( "Index", "Apartments");///////////////////////////////

            ViewBag.ApartmentId = id;
            ViewBag.ApartmentNumber=number;
            //var conciergeContext = _context.Tenants.Include(t => t.Appartment);
            //return View(await conciergeContext.ToListAsync());
            var TenantsByApartment = _context.Tenants.Where(t => t.AppartmentId==id).Include(t => t.Appartment);
            return View(await TenantsByApartment.ToListAsync());
           
        }

        // GET: Tenants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tenants == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants
                .Include(t => t.Appartment)
                .FirstOrDefaultAsync(m => m.TenantId == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // GET: Tenants/Create
        public IActionResult Create(int apartmentId)
        {
            // ViewData["AppartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentId");
            ViewBag.ApartmentId = apartmentId;
            ViewBag.ApartmentNumber = _context.Apartments.Where(t => t.ApartmentId == apartmentId).FirstOrDefault().Number;
            return View();
        }

        // POST: Tenants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int apartmentId, [Bind("TenantId,Name,Email,PhoneNumber,AppartmentId")] Tenant tenant) //[Bind("ApartmentId,Floor,Area,Porch,Number")][Bind("TenantId,Name,Email,PhoneNumber,AppartmentId")]
        {
            tenant.AppartmentId= apartmentId;

            if (ModelState.IsValid)
            {
                _context.Add(tenant);
                await _context.SaveChangesAsync();
               // return RedirectToAction(nameof(Index));
               return RedirectToAction("Index", "Tenants", new { id = apartmentId, number = _context.Apartments.Where(a => a.ApartmentId==apartmentId).FirstOrDefault().Number});
            }
            //ViewData["AppartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentId", tenant.AppartmentId);
            //return View(tenant);
            return RedirectToAction("Index", "Tenants", new { id = apartmentId, number = _context.Apartments.Where(a => a.ApartmentId == apartmentId).FirstOrDefault().Number });
        }

        // GET: Tenants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tenants == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }
            ViewData["AppartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentId", tenant.AppartmentId);
            return View(tenant);
        }

        // POST: Tenants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TenantId,Name,Email,PhoneNumber,AppartmentId")] Tenant tenant)
        {
            if (id != tenant.TenantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantExists(tenant.TenantId))
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
            ViewData["AppartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentId", tenant.AppartmentId);
            return View(tenant);
        }

        // GET: Tenants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tenants == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants
                .Include(t => t.Appartment)
                .FirstOrDefaultAsync(m => m.TenantId == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // POST: Tenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tenants == null)
            {
                return Problem("Entity set 'ConciergeContext.Tenants'  is null.");
            }
            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant != null)
            {
                _context.Tenants.Remove(tenant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenantExists(int id)
        {
          return (_context.Tenants?.Any(e => e.TenantId == id)).GetValueOrDefault();
        }
    }
}