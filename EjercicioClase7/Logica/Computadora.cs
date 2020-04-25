using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Computadora: ElementoComputacion
    {
        public string DescripcionProcesador { get; set; }
        public Memoria MemoriaRAM { get; set; }
        public string NombreFabricante { get; set; }

        public void CargarDatos(string modelo, string marca, int numeroSerie, string descpripcionProcesador, Memoria memoriaRAM, string nombreFabricante)
        {
            Modelo = modelo;
            Marca = marca;
            NumeroSerie = numeroSerie;
            DescripcionProcesador = descpripcionProcesador;
            MemoriaRAM = memoriaRAM;
            NombreFabricante = nombreFabricante;
        }
    }
}
