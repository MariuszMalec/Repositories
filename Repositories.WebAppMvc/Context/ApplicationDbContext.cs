using Microsoft.EntityFrameworkCore;
using Repositories.WebAppMvc.Models;

namespace Repositories.WebAppMvc.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
            .IsRequired();

        }
    }
}
