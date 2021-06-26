using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarManagement_Rajnish.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int WineBrandID { get; set; }
        public int WaiterID { get; set; }
        public WineBrand WineBrand { get; set; }
        public Waiter Waiter { get; set; }
    }
}
