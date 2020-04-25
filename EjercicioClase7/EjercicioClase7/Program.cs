using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;

namespace EjercicioClase7
{
    class Program
    {
        static void Main(string[] args)
        {
            DepositoComputacion.Instance.EventoAgregarEliminar += DepositoComputacion_EventoAgregarEliminar;
            DepositoComputacion.Instance.EventoAgregarEliminar += DepositoComputacion_DescripcionProductos;

            string modelo = Console.ReadLine();
            string marca = Console.ReadLine();
            int nroSerie = int.Parse(Console.ReadLine());
            string elemento = Console.ReadLine();
            if (elemento=="Monitor")
            {
                short anoFabricacion = short.Parse(Console.ReadLine());
                Nullable<int> pulgadas = int.Parse(Console.ReadLine());
                DepositoComputacion.Instance.AgregarElemento(modelo, marca, nroSerie, anoFabricacion, pulgadas);
                DepositoComputacion.Instance.AgregarElemento(modelo, marca, nroSerie, anoFabricacion, 10);
            }
            else
            {
                string procesador = Console.ReadLine();
                string valorMemoria = Console.ReadLine();
                if (valorMemoria.ValidarValorRAM())
                {
                    Memoria memoria = (Memoria)Enum.Parse(typeof(Memoria), valorMemoria);
                    string fabricante = Console.ReadLine();
                    DepositoComputacion.Instance.AgregarElemento(modelo, marca, nroSerie, procesador, memoria, fabricante);
                }
                else
                {
                    Console.WriteLine("Valor de memoria fuera del rango.");
                }
            }


            Console.ReadKey();
        }

        private static void DepositoComputacion_EventoAgregarEliminar(object sender, InfoElementoArg e)
        {
            Console.WriteLine($"{e.Operacion}: {e.TipoElemento} - {e.Identificador}");
        }

        private static void DepositoComputacion_DescripcionProductos(object sender, InfoElementoArg e)
        {
            foreach (ElementoComputacion elemento in DepositoComputacion.Instance.ObtenerListaElementos())
            {
                if(DepositoComputacion.Instance.ObtenerListaElementos().Last()==elemento)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.WriteLine(DepositoComputacion.Instance.ObtenerDescrpicionElemento(elemento));
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }


    }
}
