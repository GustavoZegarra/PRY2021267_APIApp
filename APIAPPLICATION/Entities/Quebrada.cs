using System.Collections.Generic;

namespace Entities
{
    public class Quebrada
    {
        public int IdQuebrada { get; set; }
        public string Nombre { get; set; }  
        public string Descripcion { get; set; }

        public virtual ICollection<Sensor> Sensores { get; set; }
        public virtual ICollection<Incidente> Incidentes { get; set; }
    }
}
