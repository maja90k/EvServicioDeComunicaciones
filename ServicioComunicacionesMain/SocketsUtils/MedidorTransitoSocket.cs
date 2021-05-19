﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketsUtils
{
    public class MedidorTransitoSocket
    {
        private Socket comCliente;
        private StreamReader reader;
        private StreamWriter writer;

        public MedidorTransitoSocket (Socket conCliente)
        {
            this.comCliente = conCliente;
            Stream stream = new NetworkStream(this.comCliente);
            this.writer = new StreamWriter(stream);
            this.reader = new StreamReader(stream);
        }

        public bool Escribir(string lectura)
        {
            try
            {
                this.writer.WriteLine(lectura);
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
            this.comCliente.Close();
        }
    }
}
