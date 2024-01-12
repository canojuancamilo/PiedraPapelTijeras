﻿// <auto-generated />
using BackendPiendraPapelTijeras.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendPiendraPapelTijeras.Migrations
{
    [DbContext(typeof(AplicationBdContext))]
    [Migration("20240110192141_foraneas")]
    partial class Foraneas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackendPiendraPapelTijeras.Models.Jugador", b =>
                {
                    b.Property<int>("IdJugador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdJugador"));

                    b.Property<int>("IdPartida")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdJugador");

                    b.HasIndex("IdPartida");

                    b.ToTable("Jugadores");
                });

            modelBuilder.Entity("BackendPiendraPapelTijeras.Models.Partida", b =>
                {
                    b.Property<int>("IdPartida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPartida"));

                    b.Property<int>("Ganador")
                        .HasColumnType("int");

                    b.HasKey("IdPartida");

                    b.ToTable("Partidas");
                });

            modelBuilder.Entity("BackendPiendraPapelTijeras.Models.Turno", b =>
                {
                    b.Property<int>("IdTurno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTurno"));

                    b.Property<int>("IdJugadorGanador")
                        .HasColumnType("int");

                    b.Property<int>("IdPartida")
                        .HasColumnType("int");

                    b.Property<string>("Resultado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTurno");

                    b.HasIndex("IdJugadorGanador");

                    b.HasIndex("IdPartida");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("BackendPiendraPapelTijeras.Models.Jugador", b =>
                {
                    b.HasOne("BackendPiendraPapelTijeras.Models.Partida", "Partida")
                        .WithMany()
                        .HasForeignKey("IdPartida")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Partida");
                });

            modelBuilder.Entity("BackendPiendraPapelTijeras.Models.Turno", b =>
                {
                    b.HasOne("BackendPiendraPapelTijeras.Models.Jugador", "Ganador")
                        .WithMany()
                        .HasForeignKey("IdJugadorGanador")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackendPiendraPapelTijeras.Models.Partida", "Partida")
                        .WithMany()
                        .HasForeignKey("IdPartida")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ganador");

                    b.Navigation("Partida");
                });
#pragma warning restore 612, 618
        }
    }
}
