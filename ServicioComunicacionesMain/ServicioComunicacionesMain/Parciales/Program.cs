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
                string fechaText = Console.ReadLine().Trim();
                if (!DateTime.TryParse(fechaText, out fecha))
                {

                }
            } while (fecha != DateTime.Now);
            do
            {
                Console.WriteLine("ingrese tipo de medidor: ");
                tipo = Console.ReadLine();
            } while (tipo ==string.Empty);

            //***Fromato del mensaje enviado pir el cliente fecha|nro_medidor|tipo***//
            //********convertidor de formato de 
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
