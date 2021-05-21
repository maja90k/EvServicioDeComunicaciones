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

        public HiloServer(int puerto)
        {
            this.puerto = puerto;
        }


        public void Ejecutar()
        {
            server = new ServerSocket(puerto);
            Console.WriteLine("Inicio del servidor en el puerto {0}", puerto);
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Esperando Clientes...");
                if (server.ObtenerCliente())
                {
                    if (server.Iniciar())
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Conexion Establecida con exito!");
                        string mensaje = "";
                        while (mensaje.ToLower() != "Chao servidor")
                        {
                            mensaje = server.Leer();
                            Console.WriteLine("C:{0}", mensaje);

                            if (mensaje.ToLower() != "Chao consola")
                            {
                                this.server.Escribir("S: {0}", repuesta);
                                server.Escribir(mensaje);
                            }
                        }
                        server.CerrarConexion();
                    }
                   
                }
            }
        }
    }  
}
     