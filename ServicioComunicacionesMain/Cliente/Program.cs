using Cliente.Sockets;
using ServicioComunicacionesModel.DAL.Lecturas;
using ServicioComunicacionesModel.DTO;
using SocketsUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente { 

   partial class Program
   {
     
    static void Main(string[] args)
    {
            string ipServidor = ConfigurationManager.AppSettings["servidor"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);

            Console.WriteLine("Conectando a {0} en puerto {1}", ipServidor, puerto);

            ClienteSocket clienteSocket = new ClienteSocket(ipServidor, puerto);

            if (clienteSocket.Conectar())
            {
                Console.WriteLine("Error al establecer comunicacion");
            }
            else
            {
                Console.WriteLine("Conectado exitosamente");

                string datos = clienteSocket.Leer();
                Console.WriteLine("S:{0}", datos);

                datos = clienteSocket.Leer();

                String nromedidor;
                do
                {
                    Console.WriteLine("S:{0}", datos);
                    nromedidor = Console.ReadLine().Trim();

                    ValidarNroMedidor(nromedidor);

                    if (!ValidarNroMedidor(nromedidor))
                    {
                        Console.WriteLine(nromedidor + "|" + "ERROR");
                    }


                } while (!ValidarNroMedidor(nromedidor));

                clienteSocket.Escribir(nromedidor);

                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("Seleccion el tipo de cliente que es: ");
                Console.WriteLine("1. Consumo");
                Console.WriteLine("2. Trafico");

                string tipo;
                do
                {
                    tipo = Console.ReadLine().Trim();

                    if (!ValidarTipo(tipo))
                    {

                    }
                } while (!ValidarTipo(tipo));
               


                string nroSerie = "";
                do
                {
                    nroSerie = Console.ReadLine().Trim();

                    if (!ValidarNroSerie(nroSerie))
                    {
                        Console.WriteLine("No corresponde  aun ID valido");

                    }

                    if (nroSerie.Length != 4)
                    {
                        Console.WriteLine("no puede ser inferior a 4 caracteres");

                    }


                } while (!ValidarNroSerie(nroSerie) || nroSerie != nroSerCont);

                Convert.ToInt32(nroSerie);
                clienteSocket.Escribir(nroSerie);


                datos = clienteSocket.Leer();
                Console.WriteLine("el servidor respondio: {0}", datos);

                String hr = DateTime.Now.ToString("ss/mm/HH/dd/MM/yyyy");
                string fechaEstado = "";

                do
                {
                    fechaEstado = Console.ReadLine().Trim();

                    ValidarFecha(fechaEstado);

                    if (!ValidarFecha(fechaEstado))
                    {
                        Console.WriteLine("Ingrese Fecha en formato [yyyy-MM-dd]");
                    }

                } while (!ValidarFecha(fechaEstado));

                string[] dat = hr.Split('|');
                String hrfecha = fechaEstado + "-" + dat[2] + "-" + dat[1] + "-" + dat[0];
                clienteSocket.Escribir(hrfecha);

                datos = clienteSocket.Leer();
                Console.WriteLine("el servidor respondio: {0}", datos);
                

                do
                {
                    valor = Console.ReadLine().Trim();
                    Validarvalor(valor);

                    if (!Validarvalor(valor))
                    {
                        Console.WriteLine("Ingrese un numero de 1 a 1000");

                    }


                } while (!Validarvalor(valor));


                string estado = "";
                do
                {

                    estado = Console.ReadLine().Trim();

                    ValidarEstado(estado);

                    if (!ValidarEstado(estado))
                    {
                        Console.WriteLine("Ingrese solamente -1,0,1,2");
                    }

                } while (!ValidarEstado(estado));
                clienteSocket.Escribir(estado);

                datos = clienteSocket.Leer();
                Console.WriteLine("el servidor respondio: {0}", datos);

                clienteSocket.Escribir("Lectura Registrada");

                clienteSocket.Desconectar();
                Console.ReadKey();

            }
        }