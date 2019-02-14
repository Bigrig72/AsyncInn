using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Models.Interfaces
{
    public interface IHotelManager
    {
        // create a new hotel
        Task CreateHotel(Hotel hotel);

        // read details of a hotel
        Task<Hotel> GetHotel(int id);

        Task<IEnumerable<Hotel>> GetHotels(string searchString);

        IEnumerable<Hotel> GetHotels();

        // update a hotel
        void UpdateHotel(Hotel hotel);

        // delete a hotel
        void DeleteHotel(Hotel hotel);

        void DeleteHotel(int id);
    }
}
