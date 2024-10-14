using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace rza_project.Models;

public partial class TlS2302758RzaContext : DbContext
{
    public TlS2302758RzaContext()
    {
    }

    public TlS2302758RzaContext(DbContextOptions<TlS2302758RzaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attraction> Attractions { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Roombooking> Roombookings { get; set; }

    public virtual DbSet<Ticketbooking> Ticketbookings { get; set; }

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseMySql("name=MySqlConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Attraction>(entity =>
        {
            entity.HasKey(e => e.AttractionId).HasName("PRIMARY");

            entity.ToTable("attractions");

            entity.Property(e => e.AttractionId)
                .ValueGeneratedNever()
                .HasColumnName("attractionId");
            entity.Property(e => e.AttractionName)
                .HasMaxLength(30)
                .HasColumnName("attractionName");
            entity.Property(e => e.Availability)
                .HasMaxLength(10)
                .HasColumnName("availability");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.ExhibitSchedule)
                .HasMaxLength(30)
                .HasColumnName("exhibitSchedule");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "phoneNumber_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Username, "username_UNIQUE").IsUnique();

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customerID");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasColumnName("firstName");
            entity.Property(e => e.LasttName)
                .HasMaxLength(20)
                .HasColumnName("lasttName");
            entity.Property(e => e.LoyaltyPoints).HasColumnName("loyaltyPoints");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Postcode)
                .HasMaxLength(8)
                .HasColumnName("postcode");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PRIMARY");

            entity.ToTable("room");

            entity.Property(e => e.RoomId)
                .ValueGeneratedNever()
                .HasColumnName("roomId");
            entity.Property(e => e.Availability)
                .HasMaxLength(10)
                .HasColumnName("availability");
            entity.Property(e => e.HotelRoomType)
                .HasMaxLength(20)
                .HasColumnName("hotelRoomType");
            entity.Property(e => e.PricePerNight)
                .HasPrecision(7, 2)
                .HasColumnName("pricePerNight");
            entity.Property(e => e.RoomCapacity).HasColumnName("roomCapacity");
        });

        modelBuilder.Entity<Roombooking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PRIMARY");

            entity.ToTable("roombooking");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("bookingId");
            entity.Property(e => e.CheckinDate).HasColumnName("checkinDate");
            entity.Property(e => e.CheckoutDate).HasColumnName("checkoutDate");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.HotelRoomType)
                .HasMaxLength(20)
                .HasColumnName("hotelRoomType");
            entity.Property(e => e.NoOfGuests).HasColumnName("noOfGuests");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(7, 2)
                .HasColumnName("totalPrice");
        });

        modelBuilder.Entity<Ticketbooking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PRIMARY");

            entity.ToTable("ticketbookings");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("bookingId");
            entity.Property(e => e.BookingDate).HasColumnName("bookingDate");
            entity.Property(e => e.LoyaltyPoints).HasColumnName("loyaltyPoints");
            entity.Property(e => e.NoOfGuests).HasColumnName("noOfGuests");
            entity.Property(e => e.TicketId).HasColumnName("ticketId");
            entity.Property(e => e.TicketPrice)
                .HasPrecision(7, 2)
                .HasColumnName("ticketPrice");
            entity.Property(e => e.VisitDate).HasColumnName("visitDate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
