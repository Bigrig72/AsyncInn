using HotelManagementSystems.Data;
using HotelManagementSystems.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Models.Services
{
    public class HotelManagementService : IHotelManager
    {
        private HotelManagementDbContext _context { get; }

        public HotelManagementService(HotelManagementDbContext context)
        {
            _context = context;
        }


        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
           await _context.SaveChangesAsync();
        }

        public void DeleteHotel(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
            _context.SaveChanges();
        }

        public void DeleteHotel(int id)
        {
            Hotel hotel = _context.Hotels.FirstOrDefault(h => h.ID == id);
            _context.Hotels.Remove(hotel);
            _context.SaveChanges();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(hotel => hotel.ID == id);
        }

        public void UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
        }

        public IEnumerable<Hotel> GetHotels()
        {
            return  _context.Hotels.ToList();
        }
    }
}
