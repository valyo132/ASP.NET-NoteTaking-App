using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoteTaking.Data.Models;

namespace NoteTaking.Data
{
    public class NoteTakingContext : IdentityDbContext
    {
        public NoteTakingContext()
        {

        }

        public NoteTakingContext(DbContextOptions options)
            :base(options)
        {

        }

        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
