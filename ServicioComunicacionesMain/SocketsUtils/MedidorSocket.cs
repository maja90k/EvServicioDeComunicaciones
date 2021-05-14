using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketsUtils
{
    //el medidor es el cliente.
    public class MedidorSocket
    {
        private Socket comMedidor;
        private StreamReader reader;
        private StreamWriter writer;

        public MedidorSocket(Socket comMedidor)
        {
            this.comMedidor = comMedidor;
            Stream stream = new NetworkStream(this.comMedidor);
            this.writer = new StreamWriter(stream);
            this.reader = new StreamReader(stream);

        }

        public bool Escribir(string mensaje)
        {
            try
            {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
                return true;
            }
            catch (IOException ex)
            {
                return false;
            }
        }

        public string Leer()
        {
            try
            {
                return this.reader.ReadLine().Trim();
            }
            catch (IOException ex)
            {
                return null;
            }
        }

        public void CerrarConexion()
        {
            this.comMedidor.Close();
        }
    }
}
