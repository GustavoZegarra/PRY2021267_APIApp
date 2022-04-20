using System.Collections.Generic;

namespace Entities
{
    public class Sensor
    {
        public int IdSensor { get; set; }
        public string Modelo { get; set; }
        public float? PrecipitacionMax { get; set; }
        public float? PrecipitacionMin { get; set; }
        
        //fk
        public int? IdQuebrada { get; set; }
        public Quebrada Quebrada { get; set; }

        //fk 1 a 1
        public int? IdWifi { get; set; }
        public Wifi Wifi { get; set; }

        public virtual ICollection<Alerta> Alertas { get; set; }


    }
}
