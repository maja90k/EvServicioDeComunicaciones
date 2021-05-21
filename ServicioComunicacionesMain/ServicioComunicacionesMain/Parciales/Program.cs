using ServicioComunicacionesApp.Hilos;
using ServicioComunicacionesMain.Hilos;
using ServicioComunicacionesModel.DAL.Lecturas;
using SocketsUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioComunicacionesApp
{
    public partial class Program
    {

        static ILecturasDAL dal = LecturasDALFactory.CreateDal();
        private static ServerSocket server;
        public void Consumo()
        {
            ServerSocket.
        }
        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("Que tipo de Cliente es?");
            Console.WriteLine("1.Medidor de Consumo");
            Console.WriteLine("2.Medidor de Trafico");
            string opcion = Console.ReadLine().Trim();
            switch (opcion)
            {
                case "1":
                    break;
                case "2":
                    break;
                default:
                    ;
                    break;
            }
            return continuar;
        }
    }
}
