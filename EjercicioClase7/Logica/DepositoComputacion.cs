using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public sealed class DepositoComputacion
    {
        private static DepositoComputacion instance = null;

        private DepositoComputacion()
        {
        }

        public static DepositoComputacion Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = new DepositoComputacion();
                }
                return instance;
            }
        }


        public List<ElementoComputacion> ListaElementos { get; set; }

        public void AgregarElemento(string modelo, string marca, int numeroSerie, short anoFabricacion, Nullable<int> pulgadas)
        {
            Monitor monitor = new Monitor();
            monitor.CargarDatos(modelo, marca, numeroSerie, anoFabricacion, pulgadas);
            ListaElementos.Add(monitor);

        }

        public void AgregarElemento(string modelo, string marca, int numeroSerie, string descpripcionProcesador, Memoria memoriaRAM, string nombreFabricante)
        {
            Computadora computadora = new Computadora();
            computadora.CargarDatos(modelo, marca, numeroSerie, descpripcionProcesador, memoriaRAM, nombreFabricante);
            ListaElementos.Add(computadora);
        }

        public bool EliminarElemento(string id)
        {
            ElementoComputacion elemento = ListaElementos.Find(x => x.Identificador == id);
            if(elemento!=null)
            {
                ListaElementos.Remove(elemento);
                return true;
            }
            return false;
        }

        
    }
}
