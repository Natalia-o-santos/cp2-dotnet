using Microsoft.EntityFrameworkCore;
using FleetRental.Domain.Entities;

namespace FleetRental.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Rider> Riders => Set<Rider>();
    public DbSet<Motorcycle> Motorcycles => Set<Motorcycle>();
    public DbSet<Rental> Rentals => Set<Rental>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rider>(b =>
        {
            b.ToTable("Riders");
            b.HasKey(x => x.Id);
            b.Property(x => x.FullName).IsRequired().HasMaxLength(150);
            b.Property(x => x.DocumentNumber).IsRequired().HasMaxLength(20);
            b.HasIndex(x => x.DocumentNumber).IsUnique();
            b.Property(x => x.Phone).IsRequired().HasMaxLength(30);
            b.Property(x => x.RegisteredAtUtc).IsRequired();
        });

        modelBuilder.Entity<Motorcycle>(b =>
        {
            b.ToTable("Motorcycles");
            b.HasKey(x => x.Id);
            b.Property(x => x.Plate).IsRequired().HasMaxLength(10);
            b.HasIndex(x => x.Plate).IsUnique();
            b.Property(x => x.Model).IsRequired().HasMaxLength(100);
            b.Property(x => x.Year).IsRequired();
            b.Property(x => x.RegisteredAtUtc).IsRequired();
        });

        modelBuilder.Entity<Rental>(b =>
        {
            b.ToTable("Rentals");
            b.HasKey(x => x.Id);
            b.Property(x => x.DailyRate).HasColumnType("decimal(10,2)").IsRequired();
            b.Property(x => x.StartDateUtc).IsRequired();
            b.HasOne(x => x.Rider)
                .WithMany()
                .HasForeignKey(x => x.RiderId)
                .OnDelete(DeleteBehavior.Restrict);
            b.HasOne(x => x.Motorcycle)
                .WithMany()
                .HasForeignKey(x => x.MotorcycleId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
