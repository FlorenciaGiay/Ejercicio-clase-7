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
            ListaComputadoras = new List<Computadora>();
            ListaMonitores = new List<Monitor>();
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


        public List<Monitor> ListaMonitores { get; set; }
        public List<Computadora> ListaComputadoras { get; set; }

        public EventHandler<InfoElementoArg> EventoAgregarEliminar;

        public void AgregarElemento(string modelo, string marca, int numeroSerie, short anoFabricacion, Nullable<int> pulgadas)
        {
            Monitor monitor = new Monitor();
            monitor.CargarDatos(modelo, marca, numeroSerie, anoFabricacion, pulgadas);
            ListaMonitores.Add(monitor);

            EventoAgregarEliminar(this, new InfoElementoArg() { Operacion = "Agregado", TipoElemento = "Monitor", Identificador = monitor.Identificador });
        }

        public void AgregarElemento(string modelo, string marca, int numeroSerie, string descpripcionProcesador, Memoria memoriaRAM, string nombreFabricante)
        {
            Computadora computadora = new Computadora();
            computadora.CargarDatos(modelo, marca, numeroSerie, descpripcionProcesador, memoriaRAM, nombreFabricante);
            ListaComputadoras.Add(computadora);

            EventoAgregarEliminar(this, new InfoElementoArg() { Operacion = "Agregado", TipoElemento = "Computadora", Identificador = computadora.Identificador });
        }

        public bool EliminarElemento(string id)
        {
            List<ElementoComputacion> listaElementos = ObtenerListaElementos();
            ElementoComputacion elemento = listaElementos.Find(x => x.Identificador == id);
            string tipoElemento;
            if (elemento!=null)
            {
                if (elemento is Monitor)
                {
                    ListaMonitores.Remove(elemento as Monitor);
                    tipoElemento = "Monitor";
                }
                else
                {
                    ListaComputadoras.Remove(elemento as Computadora);
                    tipoElemento = "Computadora";
                }
                EventoAgregarEliminar(this, new InfoElementoArg() { Operacion = "Eliminado", TipoElemento = tipoElemento, Identificador = elemento.Identificador });
                return true;
            }
            return false;
        }

        public List<ElementoComputacion> ObtenerListaElementos()
        {
            List<ElementoComputacion> listaElementos = new List<ElementoComputacion>();
            listaElementos.AddRange(ListaMonitores);
            listaElementos.AddRange(ListaComputadoras);

            return listaElementos;
        }

        public string ObtenerDescrpicionElemento(ElementoComputacion elemento)
        {
            if (elemento is Monitor)
            {
                return (elemento as Monitor).ObtenerDescripcion();
            }
            return (elemento as Computadora).ObtenerDescripcion();
        }


        


    }
}
