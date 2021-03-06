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
        private string fecha;
        private string tipo;
        private int nroMedidor;
        private int muestra;
        private string estado;

        public int IdMConsumo { get => idMConsumo; set => idMConsumo = value; }
        public int Muestra { get => muestra; set => muestra = value; }
        public string Estado { get => estado; set => estado = value; }
        public int NroMedidor { get => nroMedidor; set => nroMedidor = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        public override string ToString()
        {
            return Fecha + "|" + NroMedidor + "|" + Tipo;
        }

       // public static implicit operator Consumo(Consumo v)
        //{
          //  throw new NotImplementedException();
        //}
    }
}
