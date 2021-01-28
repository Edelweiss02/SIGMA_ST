using System;
using System.Collections.Generic;

#nullable disable

namespace SIGMA_ST.Models
{
    public partial class Sale
    {
        public int Idsale { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Percentage { get; set; }
        public int Idorder { get; set; }

        public virtual Order IdorderNavigation { get; set; }
    }
}
