using ServicioComunicacionesModel.DAL.Consumos;
using ServicioComunicacionesModel.DAL.Lecturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cliente
{
    public class Validaciones
    {
        private static string regex = "yyyy-MM-dd-HH-mm-ss";
        private ILecturasDAL Ldal = LecturasDALFactory.CreateDal();
        private static bool valido = false;
        private static string regex = "yyyy-MM-dd-HH-mm-ss";
        public static bool ValidarNroSerieCont(String nroSerCont)
        {
            bool re = false;
            valido = (Regex.IsMatch(nroSerCont, regex));
            if (valido == false || nroSerCont.Contains("-"))
            {
                valido = false;
            }
            else
            {
                lock (dal)
                {
                    Ldal.Obte().ForEach(c => {
                        if (c.IdContenedor == Convert.ToInt32(nroSerCont))
                        {

                            re = true;
                        }
                    });

                }
            }
            return re;
        }

    }
}
