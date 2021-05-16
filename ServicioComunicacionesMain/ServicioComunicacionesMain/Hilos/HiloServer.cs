using SocketsUtils;
using SocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioComunicacionesApp.Hilos

    //antes de leer esta clase, recordar que el medidor es el que siempre
    //hace la solicitud para conectarse con el servidor asi poder 
    //informar de la situacion y poder hacer la lectura de datos.

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
            Console.WriteLine("Iniciando el sv en el puerto {0}", puerto);
            if (server.Iniciar())
            {
                Console.WriteLine("Servidor iniciado con exito!");
                while (true)
                {
                    Console.WriteLine("Esperando Clientes");
                    MedidorConsumoSocket medidorSocket = server.ObtenerMedidor();
                    HiloMedidor hiloMedidor= new HiloMedidor(medidorSocket);
                    Thread t = new Thread(new ThreadStart(hiloMedidor.Ejecutar));
                    t.IsBackground = true;
                    t.Start();
                }
            }
        }


    }
}
