



namespace Entities
{
    public class Pasaporte
    {
        public int IdPasaporte { get; set; }    
        public string Numero { get; set; }

        public Usuario Usuario { get; set; }

        //fk
        public int IdPais { get; set; }
        public Pais Pais { get; set; }  



    }
}
