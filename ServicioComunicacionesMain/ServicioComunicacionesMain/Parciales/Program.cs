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
        private ServerSocket server;
        private static ILecturasDAL dal = LecturasDALFactory.CreateDal();
  
            //Formato del mensaje enviado pir el cliente fecha|nro_medidor|tipo.
            //********convertidor de formato de 
            //DateTime fecha = DateTime.ParseExact(edtStartDate.Text, new[] { "YYYYMMDD", "YYMMDD" }, CultureInfo.InvariantCulture, DateTimeStyles.None);
            //tbSubject.Text = fecha.ToString("yy-MM-dd");
      
        public static void EjecutarHConsumo()
        {
            
                MedidorConsumoSocket medidorSocket = server.ObtenerMedidorConsumo();
                HiloMedidorConsumo hiloMedidor = new HiloMedidorConsumo(medidorSocket);
                Thread t = new Thread(new ThreadStart(hiloMedidor.Ejecutar));
                t.IsBackground = true;
                t.Start();
            
        }

        public static void EjecutarHTrafico()
        {
            MedidorTransitoSocket transitoSocket = server.ObtenerMedidorTransito();
            HiloMedidorTransito hiloTransito = new HiloMedidorTransito(transitoSocket);
            Thread t = new Thread(new ThreadStart(hiloTransito.Ejecutar));
            t.IsBackground = true;
            t.Start();
        }
       

    }
}
