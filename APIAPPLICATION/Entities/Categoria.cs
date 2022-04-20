using System.Collections.Generic;

namespace Entities
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Detalle { get; set; }

        public virtual ICollection<Motivo> Motivos { get; set; }

    }
}
