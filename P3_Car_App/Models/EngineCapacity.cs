using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Car_App.Models
{
    public class EngineCapacity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Capacity { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
