namespace tp_pelicula_Francisco_Secrestat.Models
{
    public class PeliculaActores
    {
        public int PeliculaId { get; set; }
        public int ActoresId { get; set; }

        public Pelicula peliculas { get; set; }
        public Actor actores { get; set; }
    }
}
