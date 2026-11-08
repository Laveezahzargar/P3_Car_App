using P3_Car_App.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Car_App.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // Foreign Keys
        public int ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }

        public int EngineCapacityId { get; set; }
        public EngineCapacity? EngineCapacity { get; set; }

        // Enums (safe, no required needed)
        public FuelType FuelType { get; set; }
        public Transmission Transmission { get; set; }

        public decimal Price { get; set; }

        public int Year { get; set; }
    }
}
