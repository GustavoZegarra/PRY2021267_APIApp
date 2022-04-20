



using System.Collections.Generic;

namespace Entities
{
    public class Pais
    {
        public int IdPais { get; set; }
        public string Nombre { get; set; }  
        public string Codigo { get; set; }  
        public string Gentilicio { get; set; }  

        //fk
        public int IdContinente { get; set; }
        public Continente Continente { get; set; }  

        public virtual ICollection<Pasaporte> Pasaportes { get; set; }  


    }
}
