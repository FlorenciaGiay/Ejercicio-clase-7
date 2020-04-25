using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Monitor: ElementoComputacion
    {
        public short AnoFabricacion { get; set; }
        public bool NuevoOUsado { get { return AnoFabricacion == DateTime.Today.Year ? true : false; } }
        public Nullable<int> Pulgadas { get; set; }
        
        public void CargarDatos(string modelo, string marca, int numeroSerie, short anoFabricacion, Nullable<int> pulgadas)
        {
            Modelo = modelo;
            Marca = marca;
            NumeroSerie = numeroSerie;
            AnoFabricacion = anoFabricacion;
            Pulgadas = pulgadas;
        }

        public override string ObtenerDescripcion()
        {
            return (Pulgadas != null) ? $"MONITOR {Marca} - {Modelo} {Pulgadas}" : $"MONITOR {Marca} - {Modelo}";
        }
    }
}
