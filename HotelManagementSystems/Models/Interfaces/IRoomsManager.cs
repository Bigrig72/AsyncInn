using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Models.Interfaces
{
    public interface IRoomsManager
    {
        // Create a room
        Task CreateRoom(Room room);

        // Deatails or read
        Task<Room> GetRoom(int id);

        IEnumerable<Room> GetRooms();

        // Update a room
        void UpdateRoom(Room room);

        // Delete a room
        void DeleteRoom(int id);

        void DeleteRoom(Room room);



    }
}
