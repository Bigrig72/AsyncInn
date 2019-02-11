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

        // GET: RoomAmentities`
        public async Task<IActionResult> Index()
        {
            var hotelManagementDbContext = _context.RoomAmentities.Include(r => r.Amentities).Include(r => r.Room);
            return View(await hotelManagementDbContext.ToListAsync());
        }

        // GET: RoomAmentities/Create
        public IActionResult Create()
        {
          ViewData["AmentitiesID"] = new SelectList(_context.Amentities, "ID", "Name");
          ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name");
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
            ViewData["AmentitiesID"] = new SelectList(_context.Amentities, "ID", "Name", roomAmentities.AmentitiesID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", roomAmentities.RoomID);
            return View(roomAmentities);
        }

        // GET: RoomAmentities/Delete/5
        public async Task<IActionResult> Delete(int? amentitiesID, int? roomID)
        {
            if(amentitiesID == null || roomID == null)
            {
                return NotFound();
            }
            var roomAmentities = await _context.RoomAmentities
                .Include(r => r.Amentities)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.AmentitiesID == amentitiesID && m.RoomID == roomID);
            if(roomAmentities == null)
            {
                return NotFound();
            }

            return View(roomAmentities);
        }

        // POST: RoomAmentities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int amentitiesID, int roomID)
        {
            var roomAmentities = await _context.RoomAmentities
               .FirstOrDefaultAsync(m => m.AmentitiesID == amentitiesID && m.RoomID == roomID);
            _context.RoomAmentities.Remove(roomAmentities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    
        private bool RoomAmentitiesExists(int amenityID, int roomID)
        {
            return _context.RoomAmentities.Any(e => e.AmentitiesID == amenityID && e.RoomID == roomID);
        }
    }
}
