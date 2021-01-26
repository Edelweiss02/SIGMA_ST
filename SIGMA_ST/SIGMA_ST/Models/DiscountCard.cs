using System.ComponentModel.DataAnnotations;

namespace SIGMA_ST.Models
{
    public class DiscountCard
    {
        [Key] 
        public int IDCard { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public float Bonuses { get; set; }

    }
}
