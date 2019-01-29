using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Models.Interfaces
{
    interface IHotelManager
    {
        // create a new hotel
        void CreateHotel(Hotel hotel);

        // read details of a hotel
        Hotel GetHotel(int id);

        // update a hotel
        void UpdateHotel(Hotel hotel);

        // delete a hotel
        void DeleteHotel(Hotel hotel);

        void DeleteHotel(int id);
    }
}
