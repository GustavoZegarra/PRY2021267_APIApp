

using System;

namespace Entities
{
    public class Incidente
    {
        public int IdIncidente { get; set; }    
        public string Descripcion { get; set; } 
        public byte[] Imagen { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? Resuelto { get; set; }


        //fk
        public int? IdUsuario { get; set; } 
        public Usuario Usuario { get; set; }


        ////fk
        public int? IdQuebrada { get; set; }
        public Quebrada Quebrada { get; set; }

        //fk
        public int? IdMotivo { get; set; }
        public Motivo Motivo { get; set; }

        //fk
        public int? IdGPS { get; set; }
        public GPS GPS { get; set; }

    }
}
