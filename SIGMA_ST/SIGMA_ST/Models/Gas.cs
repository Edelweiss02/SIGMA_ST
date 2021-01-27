using System.ComponentModel.DataAnnotations;

namespace SIGMA_ST.Models
{
    
    public class Gas
    {

        [Key]  public int IDGas { get; set; }
        public string NameGas { get; set; }
        public float Number { get; set; }
        public float Price { get; set; }
    }
}
