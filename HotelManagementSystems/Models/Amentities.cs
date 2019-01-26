using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Models
{
    public class Amentities
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // Navigation props

        public RoomAmentities RoomAmentities { get; set; }
    }
}
