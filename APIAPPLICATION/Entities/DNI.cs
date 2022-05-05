
using System.Collections.Generic;

namespace Entities
{
    public class DNI
    {
        public int IdDni { get; set; }
        public string Dni { get; set; }
        public int? CodVerificacion { get; set; }
        public string Direccion { get; set; }
        public string Referencia { get; set; }

        public Usuario Usuario { get; set; }
        //fk
        public int IdDistrito { get; set; }

        public Distrito Distrito { get; set; }  

       


    }
}
