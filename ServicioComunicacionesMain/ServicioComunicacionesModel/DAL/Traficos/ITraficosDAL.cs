using ServicioComunicacionesModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesModel.DAL.Traficos
{
    public interface ITraficosDAL
    {
        void Save(Trafico t);
        List<Trafico> GetAll();
        List<Trafico> ObtenerMedidoresTrafico();

    }
}
