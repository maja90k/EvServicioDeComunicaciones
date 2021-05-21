using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesModel.DTO
{
    public class Lectura
    {
        private int idLectura;
        private int nMedidor;
        private DateTime fecha;
        private String valor;
        //tipo de vehiculo electricio o dual
        private string tipo;
        //unidad de medida KwH 
        private String unme;
        private string estado;

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Valor { get => valor; set => valor = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Unme { get => unme; set => unme = value; }
        public int IdLectura { get => idLectura; set => idLectura = value; }
        public int NMedidor { get => nMedidor; set => nMedidor = value; }
        public string Estado { get => estado; set => estado = value; }

        




    }
}
