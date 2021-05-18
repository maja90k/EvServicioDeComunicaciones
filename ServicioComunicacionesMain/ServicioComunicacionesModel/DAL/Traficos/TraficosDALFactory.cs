using ServicioComunicacionesModel.DAL.Traficos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesModel.DAL.Traficos

{
    public class TraficosDALFactory
    {
        public static ITraficosDAL CreateDal()
        {
            return TraficosDALArchivos.GetInstancia();
        }
    }
}
