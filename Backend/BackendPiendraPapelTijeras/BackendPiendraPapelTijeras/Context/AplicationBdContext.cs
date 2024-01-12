using BackendPiendraPapelTijeras.Context.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BackendPiendraPapelTijeras.Context
{
    /// <summary>
    /// Clase que representa el contexto de la base de datos de la aplicación.
    /// </summary>
    public class AplicationBdContext : DbContext
    {
        /// <summary>
        /// Constructor de la clase <see cref="AplicationBdContext"/>.
        /// </summary>
        /// <param name="options">Opciones de configuración del contexto.</param>
        public AplicationBdContext(DbContextOptions<AplicationBdContext> options)
            : base(options)
        {

        }

        /// <summary>
        /// Conjunto de entidades para la tabla de Jugadores en la base de datos.
        /// </summary>
        public DbSet<Jugador> Jugadores { get; set; }

        /// <summary>
        /// Conjunto de entidades para la tabla de Partidas en la base de datos.
        /// </summary>
        public DbSet<Partida> Partidas { get; set; }

        /// <summary>
        /// Conjunto de entidades para la tabla de Turnos en la base de datos.
        /// </summary>
        public DbSet<Turno> Turnos { get; set; }

        /// <summary>
        /// Configuraciones adicionales para el modelo de la base de datos.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo de la base de datos.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación entre Turno y Jugador (Ganador)
            modelBuilder.Entity<Turno>()
                .HasOne(p => p.Ganador)
                .WithMany()
                .HasForeignKey(p => p.IdJugadorGanador)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación entre Turno y Partida
            modelBuilder.Entity<Turno>()
                .HasOne(p => p.Partida)
                .WithMany()
                .HasForeignKey(p => p.IdPartida)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación entre Jugador y Partida
            modelBuilder.Entity<Jugador>()
                .HasOne(p => p.Partida)
                .WithMany()
                .HasForeignKey(p => p.IdPartida)
                .OnDelete(DeleteBehavior.Restrict);

            // Llamada al método base para aplicar otras configuraciones
            base.OnModelCreating(modelBuilder);
        }
    }
}
