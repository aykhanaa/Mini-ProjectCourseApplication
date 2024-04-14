using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Education> Educations { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }

        public Task<List<Group>> SortWithCapacityAsync(string text)
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-M839BQT\\SQLEXPRESS;Database=EntityFrameworkDb;Trusted_Connection=true;TrustServerCertificate=True");
            
        }
    }
}
