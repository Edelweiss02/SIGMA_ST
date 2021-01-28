using System;
using System.Collections.Generic;

#nullable disable

namespace SIGMA_ST.Models
{
    public partial class Order
    {
        public Order()
        {
            Sales = new HashSet<Sale>();
        }

        public int Idorder { get; set; }
        public DateTime Date { get; set; }
        public double Liters { get; set; }
        public double Cost { get; set; }
        public int Idgas { get; set; }
        public int? Idcard { get; set; }

        public virtual DiscountCard IdcardNavigation { get; set; }
        public virtual Ga IdgasNavigation { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
