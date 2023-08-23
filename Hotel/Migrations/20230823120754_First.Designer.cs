﻿// <auto-generated />
using System;
using Hotel.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Hotel.Migrations
{
    [DbContext(typeof(OracleDbContext))]
    [Migration("20230823120754_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HospedeReserva", b =>
                {
                    b.Property<int>("HospedesHospedeID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ReservasReservaID")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("HospedesHospedeID", "ReservasReservaID");

                    b.HasIndex("ReservasReservaID");

                    b.ToTable("HospedeReserva");
                });

            modelBuilder.Entity("Hotel.Models.Hospede", b =>
                {
                    b.Property<int>("HospedeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HospedeID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("HospedeID");

                    b.ToTable("TB_HOSPEDE");
                });

            modelBuilder.Entity("Hotel.Models.Pagamento", b =>
                {
                    b.Property<int>("PagamentoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PagamentoID"));

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.HasKey("PagamentoID");

                    b.ToTable("TB_PAGAMENTO");
                });

            modelBuilder.Entity("Hotel.Models.Quarto", b =>
                {
                    b.Property<int>("QuartoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuartoID"));

                    b.Property<string>("NumeroQuarto")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("PrecoPorNoite")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int?>("ReservaID")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("QuartoID");

                    b.HasIndex("ReservaID");

                    b.ToTable("TB_QUARTOS");
                });

            modelBuilder.Entity("Hotel.Models.Reserva", b =>
                {
                    b.Property<int>("ReservaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaID"));

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime>("DataSaida")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int?>("PagamentoID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.HasKey("ReservaID");

                    b.HasIndex("PagamentoID");

                    b.ToTable("TB_RESERVA");
                });

            modelBuilder.Entity("Hotel.Models.TipoQuarto", b =>
                {
                    b.Property<int>("TipoQuartoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoQuartoID"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("TipoQuartoID");

                    b.ToTable("TB_TP_QUARTOS");
                });

            modelBuilder.Entity("QuartoTipoQuarto", b =>
                {
                    b.Property<int>("QuartosQuartoID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("TipoQuartosTipoQuartoID")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("QuartosQuartoID", "TipoQuartosTipoQuartoID");

                    b.HasIndex("TipoQuartosTipoQuartoID");

                    b.ToTable("QuartoTipoQuarto");
                });

            modelBuilder.Entity("HospedeReserva", b =>
                {
                    b.HasOne("Hotel.Models.Hospede", null)
                        .WithMany()
                        .HasForeignKey("HospedesHospedeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.Models.Reserva", null)
                        .WithMany()
                        .HasForeignKey("ReservasReservaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hotel.Models.Quarto", b =>
                {
                    b.HasOne("Hotel.Models.Reserva", null)
                        .WithMany("Quartos")
                        .HasForeignKey("ReservaID");
                });

            modelBuilder.Entity("Hotel.Models.Reserva", b =>
                {
                    b.HasOne("Hotel.Models.Pagamento", null)
                        .WithMany("Reservas")
                        .HasForeignKey("PagamentoID");
                });

            modelBuilder.Entity("QuartoTipoQuarto", b =>
                {
                    b.HasOne("Hotel.Models.Quarto", null)
                        .WithMany()
                        .HasForeignKey("QuartosQuartoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.Models.TipoQuarto", null)
                        .WithMany()
                        .HasForeignKey("TipoQuartosTipoQuartoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hotel.Models.Pagamento", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Hotel.Models.Reserva", b =>
                {
                    b.Navigation("Quartos");
                });
#pragma warning restore 612, 618
        }
    }
}