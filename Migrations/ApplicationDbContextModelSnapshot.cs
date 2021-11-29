﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test.Data;

#nullable disable

namespace test.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("test.Models.Copa", b =>
                {
                    b.Property<int>("Id_pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_pedido"), 1L, 1);

                    b.Property<string>("Bebida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FK_id_pedido")
                        .HasColumnType("int");

                    b.Property<int?>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id_pedido");

                    b.ToTable("tbl_copa");
                });

            modelBuilder.Entity("test.Models.Cozinha", b =>
                {
                    b.Property<int>("Id_pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_pedido"), 1L, 1);

                    b.Property<int>("FK_id_pedido")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Prazo")
                        .HasColumnType("datetime2");

                    b.HasKey("Id_pedido");

                    b.ToTable("tbl_cozinha");
                });

            modelBuilder.Entity("test.Models.Pedido", b =>
                {
                    b.Property<int>("Id_pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_pedido"), 1L, 1);

                    b.Property<string>("Bebida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mesa")
                        .HasColumnType("int");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomePrato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id_pedido");

                    b.ToTable("tbl_pedido");
                });
#pragma warning restore 612, 618
        }
    }
}