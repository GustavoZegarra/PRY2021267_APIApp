

using System;
using System.Collections.Generic;

namespace Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }  
        
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public byte[] Token { get; set; }

        public string Celular { get; set; }
        public DateTime? FechaNacimiento { get; set; }


        //fk
        public int? IdDni { get; set; }  
        public DNI DNI { get; set; }

        //fk
        public int? IdPasaporte { get; set; }
        public Pasaporte Pasaporte { get; set; }

        public virtual ICollection<Incidente> Incidentes { get; set; }



    }
}
