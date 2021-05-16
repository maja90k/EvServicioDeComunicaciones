using ServicioComunicacionesModel.DAL.Lecturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesApp
{
    public partial class Program
    {
        static ILecturasDAL dal = LecturasDALFactory.CreateDal();

        
        static void EnviarMensaje()
        {
            
            string tipo;
            int nro_medidor;
            DateTime fecha = DateTime.Now;

            
            do
            {
                Console.WriteLine("Ingrese fecha:");
                fecha = Console.ReadLine();
            } while //(fecha == int.Empty);
            do
            {
                Console.WriteLine("Ingrese numero de medidor:");
                nro_medidor = Console.ReadLine();
            } while ();
            do
            {
                Console.WriteLine("ingrese tipo de medidor: ");
                tipo = Console.ReadLine();
            } while ();

            //***Fromato del mensaje enviado pir el cliente fecha|nro_medidor|tipo***//
            //********convertidor de formato de fecha*****//
            //DateTime fecha = DateTime.ParseExact(edtStartDate.Text, new[] { "YYYYMMDD", "YYMMDD" }, CultureInfo.InvariantCulture, DateTimeStyles.None);
            //tbSubject.Text = fecha.ToString("yy-MM-dd");

        }

        static void EnviarRespuesta()
        {

        }


        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            String opcion = Console.ReadLine().Trim();
            switch (opcion)
            {

            }
            return continuar;
        }



    }
}
