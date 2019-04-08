namespace MyApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyApp.Models;

    public class Context : DbContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        public DbSet<Emoloyee> Emoloyees { get; set; }
    }
}
