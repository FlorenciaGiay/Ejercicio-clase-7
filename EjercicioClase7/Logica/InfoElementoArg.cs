using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class InfoElementoArg: EventArgs
    {
        public string Operacion { get; set; }
        public string TipoElemento { get; set; }
        public string Identificador { get; set; }
    }
}
