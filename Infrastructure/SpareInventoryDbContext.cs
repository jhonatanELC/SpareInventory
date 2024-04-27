using Core.Domain.Entities;
using Core.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure
{
    public class SpareInventoryDbContext : DbContext
    {
        public SpareInventoryDbContext(DbContextOptions<SpareInventoryDbContext> options) : base(options)
        {
            
        }

        public DbSet<Spare> Spares { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<SpareBrand> SpareBrands { get; set; }
        public DbSet<Price> Prices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpareIventoryDbContext).Assembly);

            // Spare
            modelBuilder.Entity<Spare>()
                .HasMany(s => s.Brands)
                .WithMany(b => b.Spares)
                .UsingEntity<SpareBrand>();

            modelBuilder.Entity<Spare>()
                .Property(s => s.Description)
                .HasMaxLength(100);

            modelBuilder.Entity<Spare>()
                .Property(s => s.Comments)
                .HasMaxLength(100);

            modelBuilder.Entity<Spare>()
                .Property(s => s.Keyword)
                .HasMaxLength(20);

            modelBuilder.Entity<Spare>()
                .Property(s => s.OemCode)
                .HasMaxLength(20);

            var converter = new ValueConverter<Group, string>(
                v => v.ToString(),
                v => (Group)Enum.Parse(typeof(Group), v));

            modelBuilder.Entity<Spare>()
                .Property(s => s.Group)
                .HasConversion(converter)
                .HasColumnType("nvarchar(20)");

            //Brand
            modelBuilder.Entity<Brand>()
                .Property(b => b.Name)
                .HasMaxLength(20);

            //Vehicle
            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.Spares) 
                .WithOne(s => s.Vehicle)
                .HasForeignKey(s => s.VehicleId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Brand)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Model)
                .HasMaxLength(20);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Year)
                .HasColumnType("smallint");

            // SpareBrand
            modelBuilder.Entity<SpareBrand>()
                .HasKey(sb => sb.SpareBrandId);

            modelBuilder.Entity<SpareBrand>()
                .HasOne(sb => sb.Price)
                .WithOne(p => p.SpareBrand)
                .HasForeignKey<Price>(p => p.SpareBrandId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpareBrand>()
                .Property(sb => sb.Quantity)
                .HasColumnType("smallint");

            modelBuilder.Entity<SpareBrand>()
                .Property(sb => sb.Unit)
                .HasMaxLength(5);

            modelBuilder.Entity<SpareBrand>()
                .Property(sb => sb.CodeByBrand)
                .HasMaxLength(20);

            // Price
            modelBuilder.Entity<Price>()
                .Property(p => p.UnitPrice)
                .HasColumnType("smallmoney")
                .IsRequired();

            modelBuilder.Entity<Price>()
                .Property(p => p.SellPrice)
                .HasColumnType("smallmoney");

            var converter2 = new ValueConverter<Currency, string>(
                v => v.ToString(),
                v => (Currency)Enum.Parse(typeof(Currency), v));

            modelBuilder.Entity<Price>()
                .Property(p => p.Currency)
                .HasConversion(converter2)
                .HasColumnType("nvarchar(10)");
        }
    }
}
