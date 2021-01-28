using System;
using System.Collections.Generic;

#nullable disable

namespace SIGMA_ST.Models
{
    public partial class Ga
    {
        public Ga()
        {
            Invoices = new HashSet<Invoice>();
            Orders = new HashSet<Order>();
        }

        public int Idgas { get; set; }
        public string NameGas { get; set; }
        public double Number { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
