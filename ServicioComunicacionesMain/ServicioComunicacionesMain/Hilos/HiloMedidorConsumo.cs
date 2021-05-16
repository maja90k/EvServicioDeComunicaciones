using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioComunicacionesModel.DAL.Consumos;
using SocketsUtils;

namespace ServicioComunicacionesApp.Hilos
{
    class HiloMedidorConsumo
    {
        private MedidorConsumoSocket medidorConsumoSocket;
        private IConsumosDAL dal = ConsumosDALFactory.CreateDal();
        // en el mensajeroApp pide los mensajes a crear... leer ese proyecto
        
        public HiloMedidorConsumo(MedidorConsumoSocket medidorConsumoSocket)
        {
            this.medidorConsumoSocket = medidorConsumoSocket;
        }


        public void Ejecutar()
        {
            string tipo, nro_medidor;
            
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
                Console.WriteLine("Ingrese nro de Medidor: ");
                nro_medidor = Console.ReadLine().Trim();
                if (nro_medidor.Length != 3)
                {
                    Console.WriteLine("El nro ");
                    nro_medidor = String.Empty;
                }
                else if (dal.FindByNroMedidor(nro_medidor) != null)
                {
                    Console.WriteLine("");
                    nro_medidor = string.Empty;
                }
            } while (nro_medidor == string.Empty);
            do
            {
                Console.WriteLine("ingrese tipo de medidor: ");
                tipo = Console.ReadLine();
            } while ();
        }
    }
}
