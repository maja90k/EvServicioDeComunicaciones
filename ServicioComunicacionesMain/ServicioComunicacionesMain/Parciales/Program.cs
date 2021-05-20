using ServicioComunicacionesApp.Hilos;
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

        static void IniciarHiloServer()
        {
          
        }

        static void IniciarHiloConsumo()
        {
            
        }

        static void IniciarHiloTrafico()
        {

        }
  

            //Formato del mensaje enviado pir el cliente fecha|nro_medidor|tipo.
            //********convertidor de formato de 
            //DateTime fecha = DateTime.ParseExact(edtStartDate.Text, new[] { "YYYYMMDD", "YYMMDD" }, CultureInfo.InvariantCulture, DateTimeStyles.None);
            //tbSubject.Text = fecha.ToString("yy-MM-dd");
      

        static void EnviarRespuesta()
        {
           
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
                    IniciarHiloConsumo();
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
