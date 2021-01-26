using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SIGMA_ST.ViewModels
{
    public class IndexViewModel
    {
        [Key]
        public int IDCard { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public float Bonuses { get; set; }
        [Key] public int IDGas { get; set; }
        public string NameGas { get; set; }
        public double Number { get; set; }
        public double Price { get; set; }

    }
}
