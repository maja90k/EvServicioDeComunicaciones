using ServicioComunicacionesModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesModel.DAL.Lecturas
{
    public interface ILecturasDAL
    {
        void RegistrarLectura(Lectura lectura);
        List<Lectura> GetAll();
    }
}
