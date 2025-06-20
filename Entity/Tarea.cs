using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string FechaAsignacion { get; set; }
        public string FechaVencimiento { get; set; }
        public int EstatusTarea { get; set; }
    }
}
