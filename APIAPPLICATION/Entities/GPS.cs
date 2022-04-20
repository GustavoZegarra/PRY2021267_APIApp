


namespace Entities
{
    public class GPS
    {
        public int IdGps { get; set; }
        public float? Latitud { get; set; }
        public float? Longitud { get; set; }

        public Incidente Incidente { get; set; }
    }
}
