using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesModel.DAL.Consumos
{
    class ConsumosDALArchivos
    {
        //
        //
        //
        private ConsumosDALArchivos()
        {

        }
        //
        //
        private static IConsumosDAL instancia;
        //
        //
        public static IConsumosDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new ConsumosDALArchivos();
            return instancia;
        }
    }
}
