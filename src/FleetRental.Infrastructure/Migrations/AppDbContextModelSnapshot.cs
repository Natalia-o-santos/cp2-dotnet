using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using FleetRental.Infrastructure.Persistence;

#nullable disable

namespace FleetRental.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("FleetRental.Domain.Entities.Motorcycle", b =>
            {
                b.Property<Guid>("Id").HasColumnType("char(36)");
                b.Property<string>("Model").IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
                b.Property<string>("Plate").IsRequired().HasMaxLength(10).HasColumnType("varchar(10)");
                b.Property<DateTime>("RegisteredAtUtc").HasColumnType("datetime(6)");
                b.Property<int>("Year").HasColumnType("int");
                b.HasKey("Id");
                b.HasIndex("Plate").IsUnique();
                b.ToTable("Motorcycles");
            });

            modelBuilder.Entity("FleetRental.Domain.Entities.Rental", b =>
            {
                b.Property<Guid>("Id").HasColumnType("char(36)");
                b.Property<decimal>("DailyRate").HasColumnType("decimal(10,2)");
                b.Property<DateTime?>("EndDateUtc").HasColumnType("datetime(6)");
                b.Property<Guid>("MotorcycleId").HasColumnType("char(36)");
                b.Property<Guid>("RiderId").HasColumnType("char(36)");
                b.Property<DateTime>("StartDateUtc").HasColumnType("datetime(6)");
                b.HasKey("Id");
                b.HasIndex("MotorcycleId");
                b.HasIndex("RiderId");
                b.ToTable("Rentals");
            });

            modelBuilder.Entity("FleetRental.Domain.Entities.Rider", b =>
            {
                b.Property<Guid>("Id").HasColumnType("char(36)");
                b.Property<string>("DocumentNumber").IsRequired().HasMaxLength(20).HasColumnType("varchar(20)");
                b.Property<string>("FullName").IsRequired().HasMaxLength(150).HasColumnType("varchar(150)");
                b.Property<string>("Phone").IsRequired().HasMaxLength(30).HasColumnType("varchar(30)");
                b.Property<DateTime>("RegisteredAtUtc").HasColumnType("datetime(6)");
                b.HasKey("Id");
                b.HasIndex("DocumentNumber").IsUnique();
                b.ToTable("Riders");
            });

            modelBuilder.Entity("FleetRental.Domain.Entities.Rental", b =>
            {
                b.HasOne("FleetRental.Domain.Entities.Motorcycle", null)
                    .WithMany()
                    .HasForeignKey("MotorcycleId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                b.HasOne("FleetRental.Domain.Entities.Rider", null)
                    .WithMany()
                    .HasForeignKey("RiderId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}
