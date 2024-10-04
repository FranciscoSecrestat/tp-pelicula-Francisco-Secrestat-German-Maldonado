namespace tp_pelicula_Francisco_Secrestat.Models
{
    public class Actor
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string FechaNacimiento { set; get; }   
        public string Foto { set; get; }

        public List<Pelicula>? pelicula { set; get;}



    }
}
