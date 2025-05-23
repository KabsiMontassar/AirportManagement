﻿// <auto-generated />
using System;
using AM.InfraStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Class_Library.InfraStructure.Migrations
{
    [DbContext(typeof(AMContext))]
    [Migration("20250306130011_reservationticket")]
    partial class reservationticket
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Class_Library.Domain.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<string>("AirlineLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EffectiveArrival")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstimatedDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Planefk")
                        .HasColumnType("int");

                    b.HasKey("FlightId");

                    b.HasIndex("Planefk");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Class_Library.Domain.Passenger", b =>
                {
                    b.Property<string>("PassportNumber")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassportNumber");

                    b.ToTable("Passengers");

                    b.HasDiscriminator().HasValue("Passenger");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Class_Library.Domain.Plane", b =>
                {
                    b.Property<int>("PlaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaneId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("PlaneCapacity");

                    b.Property<DateTime>("ManufactureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlaneType")
                        .HasColumnType("int");

                    b.HasKey("PlaneId");

                    b.ToTable("MyPlanes", (string)null);
                });

            modelBuilder.Entity("Class_Library.Domain.ReservationTicket", b =>
                {
                    b.Property<int>("TicketFk")
                        .HasColumnType("int");

                    b.Property<string>("PassengerFk")
                        .HasColumnType("nvarchar(7)");

                    b.Property<DateTime>("DateReservation")
                        .HasColumnType("datetime2");

                    b.Property<float>("Prix")
                        .HasColumnType("real");

                    b.HasKey("TicketFk", "PassengerFk", "DateReservation");

                    b.HasIndex("PassengerFk");

                    b.ToTable("ReservationTicket");
                });

            modelBuilder.Entity("Class_Library.Domain.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Classe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.Property<int>("FlightsFlightId")
                        .HasColumnType("int");

                    b.Property<string>("PassengersPassportNumber")
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("FlightsFlightId", "PassengersPassportNumber");

                    b.HasIndex("PassengersPassportNumber");

                    b.ToTable("FlightPassenger", (string)null);
                });

            modelBuilder.Entity("Class_Library.Domain.Staff", b =>
                {
                    b.HasBaseType("Class_Library.Domain.Passenger");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Function")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("Staff");
                });

            modelBuilder.Entity("Class_Library.Domain.Traveller", b =>
                {
                    b.HasBaseType("Class_Library.Domain.Passenger");

                    b.Property<string>("HealthInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Traveller");
                });

            modelBuilder.Entity("Class_Library.Domain.Flight", b =>
                {
                    b.HasOne("Class_Library.Domain.Plane", "Plane")
                        .WithMany("Flights")
                        .HasForeignKey("Planefk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("Class_Library.Domain.Passenger", b =>
                {
                    b.OwnsOne("Class_Library.Domain.Fullname", "Fullname", b1 =>
                        {
                            b1.Property<string>("PassengerPassportNumber")
                                .HasColumnType("nvarchar(7)");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("nvarchar(25)")
                                .HasColumnName("Firstname");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Lastname");

                            b1.HasKey("PassengerPassportNumber");

                            b1.ToTable("Passengers");

                            b1.WithOwner()
                                .HasForeignKey("PassengerPassportNumber");
                        });

                    b.Navigation("Fullname")
                        .IsRequired();
                });

            modelBuilder.Entity("Class_Library.Domain.ReservationTicket", b =>
                {
                    b.HasOne("Class_Library.Domain.Passenger", "Passenger")
                        .WithMany("ReservationsTickets")
                        .HasForeignKey("PassengerFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Class_Library.Domain.Ticket", "Ticket")
                        .WithMany("reservationTickets")
                        .HasForeignKey("TicketFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.HasOne("Class_Library.Domain.Flight", null)
                        .WithMany()
                        .HasForeignKey("FlightsFlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Class_Library.Domain.Passenger", null)
                        .WithMany()
                        .HasForeignKey("PassengersPassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Class_Library.Domain.Passenger", b =>
                {
                    b.Navigation("ReservationsTickets");
                });

            modelBuilder.Entity("Class_Library.Domain.Plane", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("Class_Library.Domain.Ticket", b =>
                {
                    b.Navigation("reservationTickets");
                });
#pragma warning restore 612, 618
        }
    }
}
