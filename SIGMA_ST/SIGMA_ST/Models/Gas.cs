using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIGMA_ST.Models
{
    
    public class Gas
    {

        [Key]  public int IDGas { get; set; }
        public string NameGas { get; set; }
        public double Number { get; set; }
        public double Price { get; set; }
    }
}
