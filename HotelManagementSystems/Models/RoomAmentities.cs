using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Models
{
    public class RoomAmentities
    {
        public int AmentitiesID { get; set; }
        public int RoomID { get; set; }

        // Navigation props
        public Amentities Amentities { get; set; }
        public Room Room { get; set; }
    }
}
