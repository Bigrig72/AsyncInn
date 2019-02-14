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

        public async Task<IEnumerable<Amentities>> GetAmentities()
        {
            var amenities = from m in _context.Amentities
                            select m;

            return await amenities.ToListAsync();
        }

        public async Task DeleteAmenity(int id)
        {
            Amentities amenity = _context.Amentities.FirstOrDefault(A => A.ID == id);
            _context.Amentities.Remove(amenity);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateAmenity(Amentities amenity)
        {
            _context.Amentities.Update(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Amentities>> GetAmentities(string SearchString)
        {
            var amenities = from s in _context.Amentities
                            select s;

            if (!String.IsNullOrEmpty(SearchString))
            {
                amenities = amenities.Where(a => a.Name.Contains(SearchString));
            }


            return await amenities.ToListAsync();
        }
    }
}
