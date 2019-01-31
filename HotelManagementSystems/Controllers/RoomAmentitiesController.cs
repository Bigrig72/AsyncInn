using HotelManagementSystems.Data;
using HotelManagementSystems.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Controllers
{
    public class RoomAmentitiesController : Controller
    {
        private readonly HotelManagementDbContext _context;

        public RoomAmentitiesController(HotelManagementDbContext context)
        {
            _context = context;
        }

        // GET: RoomAmentities
        public async Task<IActionResult> Index()
        {
            var hotelManagementDbContext = _context.RoomAmentities.Include(r => r.Amentities).Include(r => r.Room);
            return View(await hotelManagementDbContext.ToListAsync());
        }

        // GET: RoomAmentities/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var roomAmentities = await _context.RoomAmentities
                .Include(r => r.Amentities)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.AmentitiesID == id);
            if (roomAmentities == null)
            {
                return NotFound();
            }

            return View(roomAmentities);
        }

        // GET: RoomAmentities/Create
        public IActionResult Create()
        {
            ViewData["AmentitiesID"] = new SelectList(_context.Amentities, "ID", "ID");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID");
            return View();
        }

        // POST: RoomAmentities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmentitiesID,RoomID")] RoomAmentities roomAmentities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomAmentities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmentitiesID"] = new SelectList(_context.Amentities, "ID", "ID", roomAmentities.AmentitiesID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID", roomAmentities.RoomID);
            return View(roomAmentities);
        }

        // GET: RoomAmentities/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var roomAmentities = await _context.RoomAmentities.FindAsync(id);
            if (roomAmentities == null)
            {
                return NotFound();
            }
            ViewData["AmentitiesID"] = new SelectList(_context.Amentities, "ID", "ID", roomAmentities.AmentitiesID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID", roomAmentities.RoomID);
            return View(roomAmentities);
        }

        // POST: RoomAmentities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AmentitiesID,RoomID")] RoomAmentities roomAmentities)
        {
            if (id != roomAmentities.AmentitiesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomAmentities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomAmentitiesExists(roomAmentities.AmentitiesID))
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
            ViewData["AmentitiesID"] = new SelectList(_context.Amentities, "ID", "ID", roomAmentities.AmentitiesID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID", roomAmentities.RoomID);
            return View(roomAmentities);
        }

        // GET: RoomAmentities/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var roomAmentities = await _context.RoomAmentities
                .Include(r => r.Amentities)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.AmentitiesID == id);
            if (roomAmentities == null)
            {
                return NotFound();
            }

            return View(roomAmentities);
        }

        // POST: RoomAmentities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomAmentities = await _context.RoomAmentities.FindAsync(id);
            _context.RoomAmentities.Remove(roomAmentities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomAmentitiesExists(int id)
        {
            return _context.RoomAmentities.Any(e => e.AmentitiesID == id);
        }
    }
}
