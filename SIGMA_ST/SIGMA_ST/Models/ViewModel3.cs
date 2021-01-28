using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGMA_ST.Models
{
    public class ViewModel3
    {
        public IEnumerable<Invoice> Invoices { get; set; }
        public IEnumerable<Ga> Gases { get; set; }

        public int Idgas { get; set; }
        public double Price { get; set; }
        public double newPrice { get; set; }
        public double Number { get; set; }
    }
}
