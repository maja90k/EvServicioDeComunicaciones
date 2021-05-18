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

        public static void IniciarHiloServer()
        {
          
        }

        public static void IniciarHiloConsumo()
        {
            
        }

        public static void IniciarHiloTrafico()
        {

        }
  
        //static void EnviarMensaje()
        //{
            
         //  string tipo;
          //  int nro_medidor;
          //  DateTime fecha = DateTime.Now;

          //  do
           // {
           //     Console.WriteLine("Ingrese fecha:");
            //    string fechaText = Console.ReadLine().Trim();
            //    if (!DateTime.TryParse(fechaText, out fecha))
//{

             //   }
          //  } while (fecha != DateTime.Now);
          //  do
           // {
           //     Console.WriteLine("Seleccione tipo de medidor: ");//esto va realmente despues de tener lo del menu?
           //     tipo = Console.ReadLine().Trim();
           // } while (tipo == string.Empty);

            //Formato del mensaje enviado pir el cliente fecha|nro_medidor|tipo.
            //********convertidor de formato de 
            //DateTime fecha = DateTime.ParseExact(edtStartDate.Text, new[] { "YYYYMMDD", "YYMMDD" }, CultureInfo.InvariantCulture, DateTimeStyles.None);
            //tbSubject.Text = fecha.ToString("yy-MM-dd");
       // }

        static void EnviarRespuesta()
        {
           
        }
        static bool Menu()
        {
            return true;
        }

    }
}
