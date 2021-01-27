using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGMA_ST.Models
{
    public class Orders
    {
        [Key]
        public int IDOrder { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public float Liters { get; set; }
        public float Cost { get; set; }
       
        public int IDGas { get; set; }
        [ForeignKey("IDGas")]
        public Gas Gas { get; set; }
        public int IDCard { get; set; }
        [ForeignKey("IDCard")]
        public DiscountCard DiscountCard { get; set; }


    }
}
