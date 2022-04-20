
using System.Collections.Generic;

namespace Entities
{
    public class Departamento
    {
       public int IdDepartamento { get; set; }
       public string Nombre { get; set; }
       public virtual ICollection<Provincia> Provincias { get; set; }    

    }
}
