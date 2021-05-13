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
        private DateTime fecha;
        private String valor;
        //tipo de vehiculo electricio o dual
        private Boolean tipo;
        //unidad de medida KwH 
        private String unme;

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Valor { get => valor; set => valor = value; }
        public Boolean Tipo { get => tipo; set => tipo = value; }
        public string Unme { get => unme; set => unme = value; }
        public int IdLectura { get => idLectura; set => idLectura = value; }
    }
}
