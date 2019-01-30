using HotelManagementSystems.Data;
using HotelManagementSystems.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Models.Services
{
    public class RoomManagementService: IRoomsManager
    {
        private HotelManagementDbContext _context { get; }
        
        public RoomManagementService(HotelManagementDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
        } 

      

        public async Task<Room> GetRoom(int id)
        {
            return await _context.Room.FirstOrDefaultAsync(room => room.ID == id);

        }

        public IEnumerable<Room> GetRooms()
        {
            return _context.Room.ToList();
        }

        public void UpdateRoom(Room room)
        {
            _context.Room.Update(room);

            _context.SaveChanges();
        }

        public void DeleteRoom(Room room)
        {
            _context.Room.Remove(room);
            _context.SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            Room room = _context.Room.FirstOrDefault(h => h.ID == id);
            _context.Room.Remove(room);
            _context.SaveChanges();
        }
    }

   
}
