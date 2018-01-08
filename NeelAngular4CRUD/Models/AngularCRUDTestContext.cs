using Microsoft.EntityFrameworkCore;

namespace NeelAngular4CRUD.Models
{
    public partial class AngularCRUDTestContext : DbContext
    {
        public virtual DbSet<Employees> Employees { get; set; }

        public AngularCRUDTestContext(DbContextOptions<AngularCRUDTestContext> options)
: base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.EmpCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
