using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketsUtils
{
    public class MedidorSocket
    {
        private Socket comCliente;
        private StreamReader reader;
        private StreamWriter writer;

        public MedidorSocket(Socket comCliente)
        {
            this.comCliente = comCliente;

            Stream stream = new NetworkStream(this.comCliente);
            this.writer = new StreamWriter(stream);
            this.reader = new StreamReader(stream);
        }
    }
}
