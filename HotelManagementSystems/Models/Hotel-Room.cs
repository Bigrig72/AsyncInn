using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Models
{
    public class Hotel_Room
    {
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }
        [Required]
        public int RoomID { get; set; }
        [Required]
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }

        // Navigational props

        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
