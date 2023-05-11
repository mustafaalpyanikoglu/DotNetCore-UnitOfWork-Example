using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.DataAccess
{
    public class UnitOfWorkContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-I6QFS5F;Initial Catalog=UnitOfWorkDB;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
