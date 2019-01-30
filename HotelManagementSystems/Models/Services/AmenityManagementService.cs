using HotelManagementSystems.Data;
using HotelManagementSystems.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Models.Services
{
    public class AmenityManagementService: IAmenityManager
    {
        private HotelManagementDbContext _context { get; }

        public AmenityManagementService(HotelManagementDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmenity(Amentities amenity)
        {
            _context.Amentities.Add(amenity);
            await _context.SaveChangesAsync();

        }

        public async Task<Amentities> GetAmentities(int id)
        {
            return await _context.Amentities.FirstOrDefaultAsync(h => h.ID == id);

        }

        public IEnumerable<Amentities> GetAmentities()
        {
              return _context.Amentities.ToList();
        }

        public void UpdateAmenity(Amentities amenity)
        {
            _context.Amentities.Update(amenity);
            _context.SaveChanges();

        }

        public void DeleteAmenity(Amentities amenity)
        {
            _context.Amentities.Remove(amenity);
            _context.SaveChanges();

        }

        public void DeleteAmenity(int id)
        {
            Amentities amenity = _context.Amentities.FirstOrDefault(A => A.ID == id);
            _context.Amentities.Remove(amenity);
            _context.SaveChanges();
        }

       
    }
}
