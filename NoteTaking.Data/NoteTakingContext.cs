using Microsoft.EntityFrameworkCore;
using NoteTaking.Data.Models;

namespace NoteTaking.Data
{
    public class NoteTakingContext : DbContext
    {
        public NoteTakingContext()
        {

        }

        public NoteTakingContext(DbContextOptions options)
            :base(options)
        {

        }

        public virtual DbSet<Note> Notes { get; set; } = null!;
    }
}
