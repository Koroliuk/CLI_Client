using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient.Models
{
    public class RoomCategory
    {
        public int CategoryNumber { get; set; }
        public string Name { get; set; }
        public decimal PricePerDay { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
    }
}
