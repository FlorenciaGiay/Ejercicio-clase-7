using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public enum Memoria
    {
        DosGB,
        CuatroGB,
        OchoGB,
        Dieciseis16GB
    }

    public static class Extenciones
    {
        public static bool ValidarValorRAM(this string valor)
        {
            return Enum.IsDefined(typeof(Memoria), valor);
        }
    }
    
}
