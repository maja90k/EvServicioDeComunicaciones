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
