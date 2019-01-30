using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Models.Interfaces
{
    public interface IAmenityManager
    {
        Task CreateAmenity(Amentities amenity);

        Task<Amentities> GetAmentities(int id);

        IEnumerable<Amentities> GetAmentities();

        void UpdateAmenity(Amentities amenity);

        void DeleteAmenity(Amentities amenity);

        void DeleteAmenity(int id);
    }
}
