namespace Entities
{
    public class Recomendacion
    {
        public int IdRecomendacion { get; set; }
        public string Detalle { get; set; }
        
        //fk
        public int? IdNivel { get; set; }
        public Nivel Nivel { get; set; }

    }
}
