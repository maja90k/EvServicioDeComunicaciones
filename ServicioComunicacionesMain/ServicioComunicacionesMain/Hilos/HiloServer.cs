using ServicioComunicacionesMain.Hilos;
using SocketsUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioComunicacionesApp.Hilos
{

    public class HiloServer
    {

        private int puerto;
        private ServerSocket server;
        private ServerSocket clienteSocket;

        public HiloServer(int puerto)
        {
            this.puerto = puerto;
        }

        public HiloServer(ServerSocket clienteSocket)
        {
            this.clienteSocket = clienteSocket;
        }

        public void Ejecutar()
        {
            server = new ServerSocket(puerto);
            Console.WriteLine("Inicio del servidor en el puerto {0}", puerto);
            while (true)
            {             
                if (server.Iniciar())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Esperando clientes [][][][][][]");
                    ServerSocket clienteSocket = server.ObtenerCliente();
                    HiloServer hiloCliente = new HiloServer(clienteSocket);
                    Thread t = new Thread(new ThreadStart(hiloCliente.Ejecutar));
                    t.IsBackground = true;
                    t.Start();
                }                               
            }
        }
    }  
}
     