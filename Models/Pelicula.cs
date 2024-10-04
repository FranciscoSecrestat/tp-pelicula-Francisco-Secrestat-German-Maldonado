using Microsoft.VisualBasic;

namespace tp_pelicula_Francisco_Secrestat.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string FechaEstreno { get; set; }
        public string Portada { get; set; }
        public string Trailer { get; set; }
        public string Resumen { get; set; }
        public int GeneroID { get; set; }
        public Genero genero { get; set; }

        public List<PeliculaActores> peliculasActores { get; set; }
    }
}
