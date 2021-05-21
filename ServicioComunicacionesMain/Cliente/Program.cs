using ServicioComunicacionesModel.DAL.Lecturas;
using ServicioComunicacionesModel.DTO;
using SocketsUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente { 

   partial class Program
   {
   

    public void ClienteConsumo()
    {


        
        static ILecturasDAL dal = LecturasDALFactory.CreateDal();
        private static ServerSocket server;

        MedidorConsumoSocket = new ClienteSocket(ipServidor, puerto);

        if (MedidorConsumoSocket.Conectar())
        {
            Console.WriteLine("Conectado exitosamente");

            string lectura = MedidorConsumoSocket.Leer();
            Console.WriteLine("S:{0}", mensaje);

            Lectura = MedidorConsumoSocke.Leer();

            String nromedidor;
            do
            {
                Console.WriteLine("S:{0}", lectura);
                nromedidor = Console.ReadLine().Trim();

                ValidarNroMedidor(nromedidor);

                if (!ValidarNroMedidor(nromedidor))
                {
                    Console.WriteLine(nromedidor + "|" + "ERROR");
                }


            } while (!ValidarNroSerieCont(nromedidor));
        }

        public void ClienteTrafico()
        {

        }

        static void Main(string[] args)
        {

            string ipServidor = ConfigurationManager.AppSettings["servidor"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);

            Console.WriteLine("Conectando a {0} en puerto {1}", ipServidor, puerto);
            Console.WriteLine("Indique que tipo de cliente es");
            Console.WriteLine("1. Consumo");
            Console.WriteLine("2. Trafico");
            string opcion = Console.ReadLine().Trim();
            switch (opcion)
            {
                case "1":
                    ClienteConsumo()
                    break;
                case "2":
                    ClienteTrafico()
                    break;
                default:
                    ;
                    break;
            }
            return continuar;




            ClienteSocket clienteSocket = new ClienteSocket(ipServidor, puerto);
            if (clienteSocket.Conectar())
            {
                Console.WriteLine("Conectado exitosamente");

                string lectura = clienteSocket.Leer();
                Console.WriteLine("S:{0}", mensaje);

                Lectura = clienteSocket.Leer();

                String nromedidor;
                do
                {
                    Console.WriteLine("S:{0}", mensaje);
                    nroSerCont = Console.ReadLine().Trim();

                    ValidarNroSerieCont(nroSerCont);

                    if (!ValidarNroMedidor(nroSerCont))
                    {
                        Console.WriteLine(nroSerCont + "|" + "ERROR");
                    }


                } while (!ValidarNroSerieCont(nroSerCont));

                clienteSocket.Escribir(nroSerCont);
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine(                      "'Bienvenido '");
                Console.WriteLine("-----------------------------------------------------------");

                mensaje = clienteSocket.Leer();
                Console.WriteLine("S:{0}", mensaje);

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

                    if (nroSerie != nroSerCont)
                    {
                        Console.WriteLine("no corresponde al ID logeado");
                    }

                } while (!ValidarNroSerie(nroSerie) || nroSerie != nroSerCont);

                Convert.ToInt32(nroSerie);
                clienteSocket.Escribir(nroSerie);


                mensaje = clienteSocket.Leer();
                Console.WriteLine("el servidor respondio: {0}", mensaje);

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

                string[] datos = hr.Split('/');
                String hrfecha = fechaEstado + "-" + datos[2] + "-" + datos[1] + "-" + datos[0];
                clienteSocket.Escribir(hrfecha);

                mensaje = clienteSocket.Leer();
                Console.WriteLine("el servidor respondio: {0}", mensaje);

                string estado = "";
                do
                {

                    estado = Console.ReadLine().Trim();

                    ValidarEstado(estado);

                    if (!ValidarEstado(estado))
                    {
                        Console.WriteLine("Ingrese solamente 1,0,-1");
                    }

                } while (!ValidarEstado(estado));


                clienteSocket.Escribir(estado);

                mensaje = clienteSocket.Leer();
                Console.WriteLine("el servidor respondio: {0}", mensaje);



                String nivell = "";

                do
                {
                    nivell = Console.ReadLine().Trim();
                    ValidarNivLlendo(nivell);

                    if (!ValidarNivLlendo(nivell))
                    {
                        Console.WriteLine("Ingrese un numero de 1 a 100");

                    }


                } while (!ValidarNivLlendo(nivell));

                clienteSocket.Escribir(nivell + "%");

                mensaje = clienteSocket.Leer();
                Console.WriteLine("el servidor respondio: {0}", mensaje);

                clienteSocket.Escribir("MENSAJE REGISTRADO");

                clienteSocket.Desconectar();
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Error al establecer comunicacion");
            }
}