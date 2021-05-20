using ServicioComunicacionesModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesModel.DAL.Consumos
{
    public interface IConsumosDAL
    {
        void RegistrarLectura(Consumo c);
        List<Consumo> GetAll();
        List<Consumo> ObtenerMedidoresConsumo();
    }
}
