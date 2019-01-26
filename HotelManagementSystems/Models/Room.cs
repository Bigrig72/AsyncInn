using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Layout Roomlayout  { get; set; }

        // Navigational props
        public Hotel_Room HotelRoom { get; set; }
        public RoomAmentities RoomAmentities { get; set; }
    }
    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom
    }

  
}
