using HotelManagementSystems.Data;
using HotelManagementSystems.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Controllers
{
    public class Hotel_RoomController : Controller
    {
        private readonly HotelManagementDbContext _context;

        public Hotel_RoomController(HotelManagementDbContext context)
        {
            _context = context;
        }

        // GET: Hotel_Room
        public async Task<IActionResult> Index()
        {
            var hotelManagementDbContext = _context.HotelRooms.Include(h => h.Hotel);
            return View(await hotelManagementDbContext.ToListAsync());
        }

        // GET: Hotel_Room/Details/5
        public async Task<IActionResult> Details(int? roomNumberID, int? hotelID)
        {
            if(roomNumberID == null || hotelID == null)
            {
                return NotFound();
            }

            var hotel_Room = await _context.HotelRooms.Include(m => m.Room)
                             .Include(h => h.Hotel)
                             .FirstOrDefaultAsync(m => m.RoomNumberID == roomNumberID && m.HotelID == hotelID);
            if (hotel_Room == null)
            {
                return NotFound();
            }

            return View(hotel_Room);
        }

        // GET: Hotel_Room/Create
        public IActionResult Create(bool isDuplicate)
            {
            if (isDuplicate)
            {
                ViewData["errorMsg"] = "This Room already exists";
            }
            else
            {
                ViewData["errorMsg"] = "";
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name");

            return View();
        }

        // POST: Hotel_Room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumberID,RoomID,Rate,PetFriendly")] Hotel_Room hotel_Room)
        {
            if (ModelState.IsValid)
            {
                bool isDuplicate = false;
                if(Hotel_RoomExists(hotel_Room.RoomNumberID, hotel_Room.HotelID))
                {
                    isDuplicate = true;
                    return RedirectToAction("Create", new { isDuplicate });
                }
                else
                {
                         ViewData["errorMsg"] = "";
                        _context.Add(hotel_Room);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                }
                
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotel_Room.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Hotels, "ID", "Name", hotel_Room.RoomID);

            return View(hotel_Room);
        }

        // GET: Hotel_Room/Edit/5
        public async Task<IActionResult> Edit(int? roomNumberID, int? hotelID, bool isDuplicate)
        {
            if (isDuplicate)
            {
                ViewData["errorMsg"] = "Room already exists";
            }
            else
            {
                ViewData["errorMsg"] = "";
            }
            if(roomNumberID == null || hotelID == null)
            {
                return NotFound();
            }

            var hotel_Room = await _context.HotelRooms.FirstOrDefaultAsync(m => m.RoomNumberID == roomNumberID && m.HotelID == hotelID);

            if(hotel_Room == null)
            {
                return NotFound();
            }
            //if (hotel_Room == null)
            //{
            //   
            //}
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotel_Room.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", hotel_Room.RoomID);

            return View(hotel_Room);
        }

        // POST: Hotel_Room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int roomNumberID, int hotelID, [Bind("HotelID,RoomNumberID,RoomID,Rate,PetFriendly")] Hotel_Room hotel_Room)
        {         

            if (ModelState.IsValid)
            {
                bool isDuplicate = false;
                try
                {
                    _context.Update(hotel_Room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (Hotel_RoomExists(hotel_Room.RoomNumberID, hotel_Room.HotelID))
                    {
                        isDuplicate = true;
                        return RedirectToAction("Edit", new { isDuplicate });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotel_Room.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Hotels, "ID", "Name", hotel_Room.RoomID);

            return View(hotel_Room);
        }

        // GET: Hotel_Room/Delete/5
        public async Task<IActionResult> Delete(int? roomNumberID, int? hotelID)
        {
            if(roomNumberID == null || hotelID == null)
            {
                return NotFound();
            }

            var hotel_Room = await _context.HotelRooms.Include(m => m.Room)
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.RoomNumberID == roomNumberID && m.HotelID == hotelID);
            if (hotel_Room == null)
            {
                return NotFound();
            }

            return View(hotel_Room);
        }

        // POST: Hotel_Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int roomNumberID, int hotelID)
        {
            var hotel_Room = await _context.HotelRooms.
                FirstOrDefaultAsync(m => m.RoomNumberID == roomNumberID && m.HotelID == hotelID);
            _context.HotelRooms.Remove(hotel_Room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Hotel_RoomExists(int roomNumberID, int hotelID)
        {
            return _context.HotelRooms.Any(e => e.HotelID == hotelID && e.RoomNumberID == roomNumberID);
        }
    }
}
