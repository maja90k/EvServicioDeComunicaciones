using SocketsUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketsUtils
{
    public class ServerSocket
    {
        private int puerto;
        private Socket servidor;
      
        public ServerSocket(int puerto)
        {
            this.puerto = puerto;
        }

        public bool Iniciar()
        {
            try
            {
                //1. Crear un socket
                this.servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2. Tomar control del puerto            
                this.servidor.Bind(new IPEndPoint(IPAddress.Any, this.puerto));
                //3. Definir cuantos clientes atendere
                this.servidor.Listen(10);
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine("Server socket, INICIO ERROR" + ex);

                return false;
            }

        }

        public MedidorConsumoSocket ObtenerMedidorConsumo()
        {
            try
            {          
                return new MedidorConsumoSocket(this.servidor.Accept());
            }catch(IOException ex)
            {
                Console.WriteLine("Server socket, obtenermedidor ERROR" + ex);
                return null;
            }
        }

        public MedidorTransitoSocket ObtenerMedidorTransito()
        {
            try
            {
                return new MedidorTransitoSocket(this.servidor.Accept());
            }
            catch (IOException ex)
            {
                Console.WriteLine("Server socket, obtenermedidor ERROR" + ex);
                return null;
            }
        }
    }
}
