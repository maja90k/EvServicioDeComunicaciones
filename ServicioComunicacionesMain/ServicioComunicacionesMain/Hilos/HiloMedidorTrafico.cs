using ServicioComunicacionesModel.DAL.Lecturas;
using ServicioComunicacionesModel.DAL.Traficos;
using ServicioComunicacionesModel.DTO;
using SocketsUtils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesMain.Hilos
{
    class HiloMedidorTrafico
    {
        private ITraficosDAL dal = TraficosDALFactory.CreateDal();
        private MedidorTraficoSocket comTrafico;
        private ILecturasDAL Ldal = LecturasDALFactory.CreateDal();
        private static bool valido = false;
        private static string regex = "yyyy-MM-dd-HH-mm-ss";

        public static bool ValidarFecha(String fechaActual)
        {
            bool res = false;
            DateTime parsed;
            valido = DateTime.TryParseExact(fechaActual, "yyyy-MM-dd-HH-mm-ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed);
            if (valido == false)
            {
                res = false;
            }
            else
            {
                res = true;
            }
            return res;
        }

        public HiloMedidorTrafico(MedidorTraficoSocket comTrafico)
        {
            this.comTrafico = comTrafico;
        }

        public void Ejecutar()
        {
            string tipo, nTrafico;
            string fecha = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            bool r = false;

            this.comTrafico.Escribir("Fecha");
            fecha = this.comTrafico.Leer();
            ValidarFecha(fecha);


            this.comTrafico.Escribir("Numero Medidor:");
            nTrafico = this.comTrafico.Leer();
            lock (dal)
            {
                dal.ObtenerMedidoresTrafico().ForEach(d =>
                {
                    if (d.NroMedidor == Convert.ToInt32(nMedidor))
                    {
                        Console.WriteLine(fecha + "| WAIT");
                        this.comMedidor.Escribir(fecha + "| WAIT");
                        r = true;
                    }
                    if (d.NroMedidor != Convert.ToInt32(nMedidor))
                    {
                        this.comMedidor.Escribir(fecha + "|" + "ERROR");
                        this.comMedidor.CerrarConexion();
                        r = false;
                    }
                });
            }

            if (r == true)
            {
                Console.WriteLine("{0}" + "|" + "{1}" + "|" + "{2}", fecha, nTrafico, tipo);

                this.comTrafico.Escribir("Ingrese numero de serie");
                string nroMedidor = this.comTrafico.Leer().Trim();

                this.comTrafico.Escribir("Ingrese fecha");
                string fechaEstado = this.comTrafico.Leer().Trim();

                //tipo
                this.comTrafico.Escribir("Indique tipo de cliente");
                string tipo = this.comTrafico.Leer().Trim();

                this.comTrafico.Escribir("Ingrese valor");
                string valor = this.comTrafico.Leer().Trim();

                this.comTrafico.Escribir("Ingrese estado");
                string estado = this.comTrafico.Leer().Trim();

                Console.WriteLine(nroMedidor + "|" + fechaEstado + "|" + tipo + "|" + valor + "|" + estado + "|" + "UPDATE");
                this.comTrafico.Escribir(nroMedidor + "|" + fechaEstado + "|" + tipo + "|" + valor + "|" + estado + "|" + "UPDATE");
                this.comTrafico.CerrarConexion();


                Lectura l = new Lectura()
                {
                    NMedidor = Convert.ToInt32(nroMedidor),
                    Fecha = Convert.ToDateTime(fechaEstado),
                    Tipo = tipo,
                    Valor = valor,
                    Estado = estado

                };

                lock (Ldal)
                {
                    Ldal.RegistrarLectura(l);
                }
            }
        }
    }
}
