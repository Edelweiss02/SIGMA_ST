using Microsoft.EntityFrameworkCore;

namespace SIGMA_ST.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Gas> Gas { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<DiscountCard> DiscountCard { get; set; }
}
}
