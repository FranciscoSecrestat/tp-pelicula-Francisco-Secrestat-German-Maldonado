using Microsoft.EntityFrameworkCore;

namespace tp_pelicula_Francisco_Secrestat.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeliculaActores>().HasKey(x => new { x.PeliculaId, x.ActoresId });

        }

        public DbSet<Actor> actor { get; set; }
        public DbSet<Genero> generos { get; set; }
        public DbSet<Pelicula> peliculas { get; set; }
        public DbSet<PeliculaActores> peliculasActores { get; set; }

    }
}
