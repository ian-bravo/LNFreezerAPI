﻿// <auto-generated />
using LNFreezerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LNFreezerAPI.Migrations
{
    [DbContext(typeof(LNFreezerApiContext))]
    [Migration("20231215231638_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LNFreezerApi.Models.Box", b =>
                {
                    b.Property<int>("BoxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BoxAlpha")
                        .HasColumnType("longtext");

                    b.Property<int>("RackId")
                        .HasColumnType("int");

                    b.HasKey("BoxId");

                    b.ToTable("Boxes");

                    b.HasData(
                        new
                        {
                            BoxId = 1,
                            BoxAlpha = "A",
                            RackId = 1
                        },
                        new
                        {
                            BoxId = 20,
                            BoxAlpha = "A",
                            RackId = 45
                        },
                        new
                        {
                            BoxId = 25,
                            BoxAlpha = "C",
                            RackId = 3
                        },
                        new
                        {
                            BoxId = 30,
                            BoxAlpha = "D",
                            RackId = 50
                        });
                });

            modelBuilder.Entity("LNFreezerApi.Models.Freezer", b =>
                {
                    b.Property<int>("FreezerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FreezerNum")
                        .HasColumnType("int");

                    b.HasKey("FreezerId");

                    b.ToTable("Freezers");

                    b.HasData(
                        new
                        {
                            FreezerId = 1,
                            FreezerNum = 1
                        },
                        new
                        {
                            FreezerId = 2,
                            FreezerNum = 2
                        },
                        new
                        {
                            FreezerId = 3,
                            FreezerNum = 3
                        });
                });

            modelBuilder.Entity("LNFreezerApi.Models.Rack", b =>
                {
                    b.Property<int>("RackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FreezerId")
                        .HasColumnType("int");

                    b.Property<int>("RackNum")
                        .HasColumnType("int");

                    b.HasKey("RackId");

                    b.ToTable("Racks");

                    b.HasData(
                        new
                        {
                            RackId = 1,
                            FreezerId = 1,
                            RackNum = 1
                        },
                        new
                        {
                            RackId = 6,
                            FreezerId = 1,
                            RackNum = 6
                        },
                        new
                        {
                            RackId = 50,
                            FreezerId = 5,
                            RackNum = 30
                        },
                        new
                        {
                            RackId = 10,
                            FreezerId = 7,
                            RackNum = 30
                        });
                });

            modelBuilder.Entity("LNFreezerApi.Models.Specimen", b =>
                {
                    b.Property<int>("SpecimenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BoxId")
                        .HasColumnType("int");

                    b.Property<string>("Cohort")
                        .HasColumnType("longtext");

                    b.Property<int>("Date")
                        .HasColumnType("int");

                    b.Property<int>("NHPNum")
                        .HasColumnType("int");

                    b.Property<string>("Quantity")
                        .HasColumnType("longtext");

                    b.Property<int>("SpecimenNum")
                        .HasColumnType("int");

                    b.Property<string>("Tissue")
                        .HasColumnType("longtext");

                    b.HasKey("SpecimenId");

                    b.ToTable("Specimens");

                    b.HasData(
                        new
                        {
                            SpecimenId = 1,
                            BoxId = 1,
                            Cohort = "PC475",
                            Date = 51422,
                            NHPNum = 32283,
                            Quantity = "2e6",
                            SpecimenNum = 1,
                            Tissue = "BM"
                        },
                        new
                        {
                            SpecimenId = 4,
                            BoxId = 4,
                            Cohort = "PC475",
                            Date = 52122,
                            NHPNum = 33887,
                            Quantity = "8e6",
                            SpecimenNum = 4,
                            Tissue = "PBMC"
                        },
                        new
                        {
                            SpecimenId = 10,
                            BoxId = 20,
                            Cohort = "PC498",
                            Date = 91722,
                            NHPNum = 29396,
                            Quantity = "15e6",
                            SpecimenNum = 10,
                            Tissue = "PBMC"
                        },
                        new
                        {
                            SpecimenId = 82,
                            BoxId = 39,
                            Cohort = "PC521",
                            Date = 62123,
                            NHPNum = 34331,
                            Quantity = "8e6",
                            SpecimenNum = 1,
                            Tissue = "P.LN"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}