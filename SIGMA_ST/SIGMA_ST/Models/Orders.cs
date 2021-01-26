using System;
using System.ComponentModel.DataAnnotations;

namespace SIGMA_ST.Models
{
    public class Orders
    {
        [Key]
        public int IDOrder { get; set; }
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        public float Liters { get; set; }
        public float Cost { get; set; }
        public int IDGas { get; set; }
        public int IDCard { get; set; }

    }
}
