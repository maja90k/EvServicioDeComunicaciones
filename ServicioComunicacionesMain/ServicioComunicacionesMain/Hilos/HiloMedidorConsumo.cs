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
        private MedidorConsumoSocket medConSocket;
        private IConsumosDAL dal = ConsumosDALFactory.CreateDal();


        public HiloMedidorConsumo(MedidorConsumoSocket medidorConsumoSocket)
        {
            this.medConSocket = medidorConsumoSocket;
        }

        //Aqui el cliente ingresa los datos requeridos fecha|nro_medidor|tipo
        //Posteriormente tener un metodo para confirmar la palabra WAIT en la respuesta del servidor
        public void Ejecutar()
        {
            try
            {
                
                string tipo, nro_medidor;
                int idConsumo;
                string fecha = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                Console.WriteLine("Fecha:" + " | " + fecha);
                bool respuesta = false;

                do
                {   
                   nro_medidor = Console.ReadLine().Trim();
                    lock (dal)
                    {
                        dal.ObtenerMedidoresConsumo().ForEach(d =>
                        {
                            if (d.NroMedidor == Convert.ToInt32(nro_medidor))
                            {
                                respuesta = true;
                            }
                        });
                    }
                } while (nro_medidor == string.Empty);
                do
                {
                    tipo = Console.ReadLine();
                } while (tipo == string.Empty);

                Console.WriteLine(fecha + "|" + "WAIT");
                string mensaje = this.medConSocket.Leer().Trim();

                Console.WriteLine( fecha + " | " + tipo);

                Consumo c = new Consumo()
                {
                    Fecha = "fecha",
                    NroMedidor = 123,
                    Tipo = tipo
                };
                lock (dal)
                {
                    dal.RegistrarLectura(c);
                }
                medConSocket.CerrarConexion();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error en el try catch hilo CONSUMO" + ex);
            }         
        }
    }
}
