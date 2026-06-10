using FreeCodeCampWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeCodeCampWeb.Controllers.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-NJCLCBC\\MSSQLSERVER01;Database=MyDatabase;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
    
}
