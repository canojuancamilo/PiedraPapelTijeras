﻿// <auto-generated />
using BackendPiendraPapelTijeras.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendPiendraPapelTijeras.Migrations
{
    [DbContext(typeof(AplicationBdContext))]
    partial class AplicationBdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("PartidaIdPartida")
                        .HasColumnType("int");

                    b.HasKey("IdJugador");

                    b.HasIndex("PartidaIdPartida");

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

                    b.Property<int>("PartidaIdPartida")
                        .HasColumnType("int");

                    b.Property<string>("Resultado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTurno");

                    b.HasIndex("IdJugadorGanador");

                    b.HasIndex("PartidaIdPartida");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("BackendPiendraPapelTijeras.Models.Jugador", b =>
                {
                    b.HasOne("BackendPiendraPapelTijeras.Models.Partida", "Partida")
                        .WithMany()
                        .HasForeignKey("PartidaIdPartida")
                        .OnDelete(DeleteBehavior.Cascade)
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
                        .HasForeignKey("PartidaIdPartida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ganador");

                    b.Navigation("Partida");
                });
#pragma warning restore 612, 618
        }
    }
}
