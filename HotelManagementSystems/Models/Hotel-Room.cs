using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystems.Models
{
    public class Hotel_Room
    {
        public int HotelID { get; set; }
        public int RoomNumberID { get; set; }
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
