using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketsUtils;

namespace ServicioComunicacionesApp.Hilos
{
    class HiloMedidor
    {
        private MedidorSocket medidorSocket;
        //private Ilecturas? para poder leer los datos?
        // en el mensajeroApp pide los mensajes a crear... leer ese proyecto
        

        public HiloMedidor(MedidorSocket medidorSocket)
        {
            this.medidorSocket = medidorSocket;
        }


        public void Ejecutar()
        {
            


        }
    }
}
