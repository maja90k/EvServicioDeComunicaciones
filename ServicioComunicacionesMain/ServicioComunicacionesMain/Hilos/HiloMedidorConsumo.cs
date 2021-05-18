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
        // en el mensajeroApp pide los mensajes a crear... leer ese proyecto

        public HiloMedidorConsumo(MedidorConsumoSocket medidorConsumoSocket)
        {
            this.medidorConsumoSocket = medidorConsumoSocket;
        }


        //****aqui el cliente ingresa los datos requeridos fecha|nro_medidor|tipo
        //****posteriormente debe tener un metodo para confirmar la palabra WAIT en la respuesta del servidor

        public void Ejecutar()
        {
            string tipo, nro_medidor;

            DateTime fecha = DateTime.Now;


            do
            {
                Console.WriteLine("Ingrese fecha:");
                string fechaText = Console.ReadLine().Trim();
                //validacion para fecha erronea
                if (!DateTime.TryParse(fechaText, out fecha))
                {

                }
            } while (fecha != DateTime.Now);

            do
            {
                Console.WriteLine("Ingrese nro de Medidor: ");
                nro_medidor = Console.ReadLine().Trim();
            } while (nro_medidor == string.Empty);
            do
            {
                Console.WriteLine("ingrese tipo de medidor: ");
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
    }
}
