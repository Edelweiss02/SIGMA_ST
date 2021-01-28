using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGMA_ST.Models
{
    public class ViewModel2
    {
        public IEnumerable<Invoice> Invoices { get; set; }
        public IEnumerable<Ga> Gases { get; set; } 
    }
}
