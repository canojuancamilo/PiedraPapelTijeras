using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BackendPiendraPapelTijeras.Models.Context
{
    public class AplicationBdContext : DbContext
    {
        public AplicationBdContext(DbContextOptions<AplicationBdContext> options)
            : base(options)
        {

        }

        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Turno> Turnos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turno>()
                .HasOne(p => p.Ganador)
                .WithMany()
                .HasForeignKey(p => p.IdJugadorGanador)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Turno>()
                .HasOne(p => p.Partida)
                .WithMany()
                .HasForeignKey(p => p.IdPartida)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Jugador>()
                .HasOne(p => p.Partida)
                .WithMany()
                .HasForeignKey(p => p.IdPartida)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
