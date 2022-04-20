



namespace Entities
{
    public class Wifi
    {
        public int IdWifi { get; set; }
        public string Modelo { get; set; }  
        public string Standar { get; set; }
        public string Protocolo { get; set; }

        public string Red { get; set; }
        
        public Sensor Sensor { get; set; }

    }
}
