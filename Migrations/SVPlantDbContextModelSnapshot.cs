﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SVPlant;

namespace SVPlant.Migrations
{
    [DbContext(typeof(SVPlantDbContext))]
    partial class SVPlantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("SVPlant.Models.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsGettingWatered")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Plants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsGettingWatered = false,
                            Name = "Plant1"
                        },
                        new
                        {
                            Id = 2,
                            IsGettingWatered = false,
                            Name = "Plant2"
                        },
                        new
                        {
                            Id = 3,
                            IsGettingWatered = false,
                            Name = "Plant3"
                        },
                        new
                        {
                            Id = 4,
                            IsGettingWatered = false,
                            Name = "Plant4"
                        },
                        new
                        {
                            Id = 5,
                            IsGettingWatered = false,
                            Name = "Plant5"
                        });
                });

            modelBuilder.Entity("SVPlant.Models.WateringLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlantId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StopTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.ToTable("WateringLogs");
                });

            modelBuilder.Entity("SVPlant.Models.WateringLog", b =>
                {
                    b.HasOne("SVPlant.Models.Plant", null)
                        .WithMany("WateringLogs")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
