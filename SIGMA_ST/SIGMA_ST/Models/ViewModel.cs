using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGMA_ST.Models
{
    public class ViewModel
    {
        public IEnumerable<Ga> Gases { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<DiscountCard> DiscountCards { get; set; }
        public double Liters { get; set; }
        public bool bon { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public double Bonuses { get; set; }
        public int Idgas { get; set; }
        public int? Idcard { get; set; }
    }
}
