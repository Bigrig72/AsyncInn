using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Models
{
    public class Amentities
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        // Navigation props

        public ICollection<RoomAmentities> RoomAmentities { get; set; }
    }
}
