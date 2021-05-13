using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesModel.DTO
{
    public class Trafico
    {
        private int idMTrafico;
        private int cantidad;

        public int IdMTrafico { get => idMTrafico; set => idMTrafico = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
