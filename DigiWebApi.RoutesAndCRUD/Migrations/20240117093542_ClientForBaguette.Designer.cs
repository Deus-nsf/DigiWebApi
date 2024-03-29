﻿// <auto-generated />
using System;
using DigiWebApi.RoutesAndCRUD.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DigiWebApi.RoutesAndCRUD.Migrations
{
    [DbContext(typeof(BakeryDbContext))]
    [Migration("20240117093542_ClientForBaguette")]
    partial class ClientForBaguette
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DigiWebApi.RoutesAndCRUD.Models.Baguette", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Baguettes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 2,
                            Currency = "Euros",
                            Description = "Du pain artisanal à la farine de blé complet.",
                            Name = "Pain complet",
                            Price = 2.5f
                        },
                        new
                        {
                            Id = 2,
                            ClientId = 1,
                            Currency = "Euros",
                            Description = "Du pain artisanal à la farine blanche et plein de glucose !",
                            Name = "Baguette tradition",
                            Price = 1.2f
                        },
                        new
                        {
                            Id = 3,
                            Currency = "Euros",
                            Description = "Ça existe au moins ?",
                            Name = "Pain sans gluten",
                            Price = 4.5f
                        });
                });

            modelBuilder.Entity("DigiWebApi.RoutesAndCRUD.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "432 avenue de la Gourmandise",
                            Name = "Marie Madelaine"
                        },
                        new
                        {
                            Id = 2,
                            Address = "123 rue de la Jean-Michelerie",
                            Name = "Jean Michel"
                        });
                });

            modelBuilder.Entity("DigiWebApi.RoutesAndCRUD.Models.Baguette", b =>
                {
                    b.HasOne("DigiWebApi.RoutesAndCRUD.Models.Client", "Client")
                        .WithMany("Baguettes")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("DigiWebApi.RoutesAndCRUD.Models.Client", b =>
                {
                    b.Navigation("Baguettes");
                });
#pragma warning restore 612, 618
        }
    }
}
