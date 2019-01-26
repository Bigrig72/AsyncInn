using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Models
{
    public class Hotel_Room
    {
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }
        public decimal RoomID { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }

        // Navigational props

        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
