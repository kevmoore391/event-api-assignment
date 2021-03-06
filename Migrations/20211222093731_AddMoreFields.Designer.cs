// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using EventApiAssignment.Models;

#nullable disable

namespace EventApiAssignment.Migrations
{
    [DbContext(typeof(EventContext))]
    [Migration("20211222093731_AddMoreFields")]
    partial class AddMoreFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("event_api.Models.Event", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EventDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PerformanceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VenueCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VenueName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
