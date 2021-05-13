using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesModel.DAL.Consumos
{
    public class ConsumosDALFactory
    {
        public static IConsumosDAL CreateDal()
        {
            return ConsumosDALArchivos.GetInstancia();
        }
    }
}
