using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3_Car_App.Models;

namespace P3_Car_App.Data
{
        public class AppDbContext : DbContext
        {
            public DbSet<Car> Cars { get; set; }
            public DbSet<Manufacturer> Manufacturers { get; set; }
            public DbSet<EngineCapacity> EngineCapacities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "car.db"
            );

            options.UseSqlite($"Data Source={path}");
        }
    }
    
}
