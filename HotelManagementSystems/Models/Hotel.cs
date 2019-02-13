using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystems.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }

        // Navigational props

        public ICollection<Hotel_Room> Room { get; set; }
    }
}
