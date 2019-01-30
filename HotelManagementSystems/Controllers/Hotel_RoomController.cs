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
        public async Task<IActionResult> Details(decimal id)
        {
            
            var hotel_Room = await _context.HotelRooms
                             .Include(h => h.Hotel)
                         .FirstOrDefaultAsync(m => m.RoomID == id);
            if (hotel_Room == null)
            {
                return NotFound();
            }

            return View(hotel_Room);
        }

        // GET: Hotel_Room/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID");
            return View();
        }

        // POST: Hotel_Room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] Hotel_Room hotel_Room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotel_Room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotel_Room.HotelID);
            return View(hotel_Room);
        }

        // GET: Hotel_Room/Edit/5
        public async Task<IActionResult> Edit(decimal id)
        {
            var hotel_Room = await _context.HotelRooms.FindAsync(id);
            if (hotel_Room == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotel_Room.HotelID);
            return View(hotel_Room);
        }

        // POST: Hotel_Room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] Hotel_Room hotel_Room)
        {
            if (id != hotel_Room.RoomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel_Room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Hotel_RoomExists(hotel_Room.RoomID))
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
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotel_Room.HotelID);
            return View(hotel_Room);
        }

        // GET: Hotel_Room/Delete/5
        public async Task<IActionResult> Delete(decimal id)
        {
            var hotel_Room = await _context.HotelRooms
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.RoomID == id);
            if (hotel_Room == null)
            {
                return NotFound();
            }

            return View(hotel_Room);
        }

        // POST: Hotel_Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var hotel_Room = await _context.HotelRooms.FindAsync(id);
            _context.HotelRooms.Remove(hotel_Room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Hotel_RoomExists(decimal id)
        {
            return _context.HotelRooms.Any(e => e.RoomID == id);
        }
    }
}
