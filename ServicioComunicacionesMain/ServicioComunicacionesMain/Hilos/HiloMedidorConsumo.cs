using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioComunicacionesModel.DAL.Consumos;
using ServicioComunicacionesModel.DTO;
using SocketsUtils;

namespace ServicioComunicacionesApp.Hilos
{
    class HiloMedidorConsumo
    {
        private MedidorConsumoSocket medidorConsumoSocket;
        private IConsumosDAL dal = ConsumosDALFactory.CreateDal();

        public HiloMedidorConsumo(MedidorConsumoSocket medidorConsumoSocket)
        {
            this.medidorConsumoSocket = medidorConsumoSocket;
        }

        //Aqui el cliente ingresa los datos requeridos fecha|nro_medidor|tipo
        //Posteriormente tener un metodo para confirmar la palabra WAIT en la respuesta del servidor
        public void Ejecutar()
        {
            try
            {
                string tipo, nro_medidor;
                DateTime fecha = DateTime.Now;
                Console.WriteLine("Fecha:" + " " + fecha);
                do
                {
                    Console.WriteLine("Ingrese nro de Medidor: ");
                    nro_medidor = Console.ReadLine().Trim();
                } while (nro_medidor == string.Empty);
                do
                {
                    Console.WriteLine("Tipo:" );//aqui deberia ir la lista static para ver el tipo de medidores.
                    tipo = Console.ReadLine();
                } while (tipo == string.Empty);

                Consumo c = new Consumo()
                {
                    Fecha = "fecha",
                    NroMedidor = nro_medidor,
                    Tipo = tipo
                };
                lock (dal)
                {
                    dal.Save(c);
                }
                medidorConsumoSocket.CerrarConexion();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error en el try catch hilo CONSUMO" + ex);
            }         
        }
    }
}
