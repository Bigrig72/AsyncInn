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

        Task<IEnumerable<Amentities>> GetAmentities(string SearchString);

        Task UpdateAmenity(Amentities amenity);
        

        Task DeleteAmenity(int id);
    }
}
