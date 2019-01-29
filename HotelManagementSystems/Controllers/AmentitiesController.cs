using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystems.Data;
using HotelManagementSystems.Models;

namespace HotelManagementSystems.Controllers
{
    public class AmentitiesController : Controller
    {
        private readonly HotelManagementDbContext _context;

        public AmentitiesController(HotelManagementDbContext context)
        {
            _context = context;
        }

        // GET: Amentities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Amentities.ToListAsync());
        }

        // GET: Amentities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amentities = await _context.Amentities
                .FirstOrDefaultAsync(m => m.ID == id);
            if (amentities == null)
            {
                return NotFound();
            }

            return View(amentities);
        }

        // GET: Amentities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amentities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Amentities amentities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amentities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amentities);
        }

        // GET: Amentities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amentities = await _context.Amentities.FindAsync(id);
            if (amentities == null)
            {
                return NotFound();
            }
            return View(amentities);
        }

        // POST: Amentities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amentities amentities)
        {
            if (id != amentities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amentities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmentitiesExists(amentities.ID))
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
            return View(amentities);
        }

        // GET: Amentities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amentities = await _context.Amentities
                .FirstOrDefaultAsync(m => m.ID == id);
            if (amentities == null)
            {
                return NotFound();
            }

            return View(amentities);
        }

        // POST: Amentities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amentities = await _context.Amentities.FindAsync(id);
            _context.Amentities.Remove(amentities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmentitiesExists(int id)
        {
            return _context.Amentities.Any(e => e.ID == id);
        }
    }
}
