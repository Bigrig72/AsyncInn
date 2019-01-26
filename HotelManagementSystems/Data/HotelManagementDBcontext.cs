using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Data
{
    public class HotelManagementDbContext: DbContext
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options):base(options)
        {

        }
    }
}
