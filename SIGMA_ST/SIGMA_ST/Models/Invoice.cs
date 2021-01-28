using System;
using System.Collections.Generic;

#nullable disable

namespace SIGMA_ST.Models
{
    public partial class Invoice
    {
        public int Idchange { get; set; }
        public DateTime Date { get; set; }
        public string EventType { get; set; }
        public double ChangeAmount { get; set; }
        public double Amount { get; set; }
        public int Idgas { get; set; }

        public virtual Ga IdgasNavigation { get; set; }
    }
}
