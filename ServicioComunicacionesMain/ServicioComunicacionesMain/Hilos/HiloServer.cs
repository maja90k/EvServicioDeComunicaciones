using ServicioComunicacionesMain.Hilos;
using SocketsUtils;
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

        public  void HiloConsumo()
        {
            MedidorConsumoSocket medidorSocket = server.ObtenerMedidorConsumo();
            HiloMedidorConsumo hiloMedidor = new HiloMedidorConsumo(medidorSocket);
            Thread t = new Thread(new ThreadStart(hiloMedidor.Ejecutar));
            t.IsBackground = true;
            t.Start();
        }

        public void HiloTransito()
        {
            MedidorTransitoSocket transitoSocket = server.ObtenerMedidorTransito();
            HiloMedidorTransito hiloTransito = new HiloMedidorTransito(transitoSocket);
            Thread t = new Thread(new ThreadStart(hiloTransito.Ejecutar));
            t.IsBackground = true;
            t.Start();
        }

        public void Ejecutar()
        {
            server = new ServerSocket(puerto);
            Console.WriteLine("Inicio del servidor en el puerto {0}", puerto);
            if (server.Iniciar())
            {
                while (true)
                {                  
                    Console.WriteLine("Esperando algun Cliente...");
                   
                }
            }
        }    
    }
}
