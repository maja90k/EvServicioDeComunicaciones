using ServicioComunicacionesApp.Hilos;
using ServicioComunicacionesModel.DAL.Lecturas;
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

        public static void IniciarHiloConsumo()
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            HiloServer hiloServer = new HiloServer(puerto);
            Thread t = new Thread(new ThreadStart(hiloServer.Ejecutar));
            t.IsBackground = true;
            t.Start();
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
            bool continuar = true;
            Console.WriteLine("Que tipo de Cliente es?");
            Console.WriteLine("1.Medidor de Consumo");
            Console.WriteLine("2.Medidor de Trafico");
            string opcion = Console.ReadLine().Trim();
            switch (opcion)
            {
                case "1":IniciarHiloConsumo();
                    break;
                case "2":IniciarHiloTrafico();
                    break;
            }
            return continuar;
        }

    }
}
