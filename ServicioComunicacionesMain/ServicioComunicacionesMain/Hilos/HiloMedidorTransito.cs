using ServicioComunicacionesModel.DAL.Lecturas;
using ServicioComunicacionesModel.DTO;
using SocketsUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesMain.Hilos
{
    class HiloMedidorTransito
    {
        private MedidorTransitoSocket transitoSocket;
        private ILecturasDAL dal = LecturasDALFactory.CreateDal();

        public HiloMedidorTransito(MedidorTransitoSocket transitoSocket)
        {
            this.transitoSocket = transitoSocket;
        }

        public void Ejecutar()
        {

            Lectura l = new Lectura()
            {
                Fecha = "fecha",
               

            };
            lock (dal)
            {
                dal.Save(l);
            }
            transitoSocket.CerrarConexion();
        }
    }
}
