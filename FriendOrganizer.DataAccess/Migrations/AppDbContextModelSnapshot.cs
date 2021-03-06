﻿// <auto-generated />
using FriendOrganizer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FriendOrganizer.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("FriendOrganizer.Model.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Friends");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Thomas",
                            LastName = "Huber"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Andreas",
                            LastName = "Boehler"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Julia",
                            LastName = "Huber"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Chrissi",
                            LastName = "Egin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
