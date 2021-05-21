using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Sockets
    {
        public class ClienteSocket
        {
            private int puerto;
            private string servidor;
            private Socket conCliente;
            private StreamReader reader;
            private StreamWriter writer;

            public ClienteSocket(string servidor, int puerto)
            {
                this.puerto = puerto;
                this.servidor = servidor;
            }

            public bool Conectar()
            {
                try
                {
                    this.conCliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(this.servidor), this.puerto);
                    this.conCliente.Connect(ipEndPoint);
                    Stream stream = new NetworkStream(this.conCliente);
                    this.writer = new StreamWriter(stream);
                    this.reader = new StreamReader(stream);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            public void Desconectar()
            {
                this.conCliente.Close();
            }

            public void Escribir(string mensaje)
            {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
            }
            public string Leer()
            {
                return this.reader.ReadLine().Trim();
            }

        }
    }
}
}
