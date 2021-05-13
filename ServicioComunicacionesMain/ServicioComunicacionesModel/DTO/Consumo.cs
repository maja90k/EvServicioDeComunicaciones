using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesModel.DTO
{
    public class Consumo
    {
        private int idMConsumo;
        private int muestra;
        private string estado;

        public int IdMConsumo { get => idMConsumo; set => idMConsumo = value; }
        public int Muestra { get => muestra; set => muestra = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
