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
        private int nroMedidor;
        private string fecha;
        private string estado;
        private string tipo;



        public int IdMTrafico { get => idMTrafico; set => idMTrafico = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int NroMedidor { get => nroMedidor; set => nroMedidor = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Tipo { get => tipo; set => tipo = value; }

    }
}
