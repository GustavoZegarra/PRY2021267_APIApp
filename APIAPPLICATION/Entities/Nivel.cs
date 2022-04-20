using System.Collections.Generic;

namespace Entities
{
    public class Nivel
    {
        public int IdNivel { get; set; }
        public string Riesgo { get; set; }
        public float? PrecipitacionLimSup { get; set; }
        public float? PrecipitacionLimInf { get; set; }

        public virtual ICollection<Alerta> Alertas { get; set; }
        public virtual ICollection<Recomendacion> Recomendaciones { get; set; }
    }
}
