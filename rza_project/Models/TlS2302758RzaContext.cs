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

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Ticketbooking> Ticketbookings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=MySqlConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Attraction>(entity =>
        {
            entity.HasKey(e => e.AttractionId).HasName("PRIMARY");

            entity.ToTable("attraction");

            entity.Property(e => e.AttractionId).HasColumnName("attractionId");
            entity.Property(e => e.Name).HasMaxLength(45);
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

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PRIMARY");

            entity.ToTable("ticket");

            entity.HasIndex(e => e.AttractionId, "ticket_fk1_idx");

            entity.HasIndex(e => e.TicketbookingId, "ticket_fk2_idx");

            entity.Property(e => e.TicketId).HasColumnName("ticketId");
            entity.Property(e => e.AttractionId).HasColumnName("attractionId");
            entity.Property(e => e.TicketbookingId).HasColumnName("ticketbookingId");

            entity.HasOne(d => d.Attraction).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.AttractionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticket_fk1");

            entity.HasOne(d => d.Ticketbooking).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TicketbookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticket_fk2");
        });

        modelBuilder.Entity<Ticketbooking>(entity =>
        {
            entity.HasKey(e => e.TicketbookingId).HasName("PRIMARY");

            entity.ToTable("ticketbooking");

            entity.HasIndex(e => e.CustomerId, "ticketbooking_fk1_idx");

            entity.Property(e => e.TicketbookingId).HasColumnName("ticketbookingId");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DateBooked).HasColumnName("dateBooked");

            entity.HasOne(d => d.Customer).WithMany(p => p.Ticketbookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticketbooking_fk1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8mb3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
