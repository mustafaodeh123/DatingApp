namespace DatingApp.API
{
  using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Value> Values { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          base.OnModelCreating(modelBuilder);
          modelBuilder.RemovePlural();

          modelBuilder.Entity<Value>().Property(p => p.Name).HasMaxLength(100);
        }
    }
}