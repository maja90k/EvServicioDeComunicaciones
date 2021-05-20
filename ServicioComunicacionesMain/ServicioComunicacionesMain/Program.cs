using ServicioComunicacionesApp.Hilos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioComunicacionesApp
{
    partial class Program
    {
        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("Que tipo de Cliente es?");
            Console.WriteLine("1.Medidor de Consumo");
            Console.WriteLine("2.Medidor de Trafico");
            string opcion = Console.ReadLine().Trim();
            switch (opcion)
            {
                case "1":
                    EjecutarHConsumo();
                    break;
                case "2":
                    EjecutarHTrafico();
                    break;
                default:
                    ;
                    break;
            }
            return continuar;
        }

        static void Main(String[] args)
        {
            Console.WriteLine("Iniciando Hilo de server Socket...");
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            HiloServer hiloServer = new HiloServer(puerto);
            Thread t = new Thread(new ThreadStart(hiloServer.Ejecutar));
            t.IsBackground = true;
            t.Start();
            while(Menu());
            
        }
    }
}
