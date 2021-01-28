using System;
using System.Collections.Generic;

#nullable disable

namespace SIGMA_ST.Models
{
    public partial class DiscountCard
    {
        public DiscountCard()
        {
            Orders = new HashSet<Order>();
        }

        public int Idcard { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Bonuses { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
