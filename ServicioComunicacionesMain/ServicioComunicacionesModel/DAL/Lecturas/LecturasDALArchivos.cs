using ServicioComunicacionesModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesModel.DAL.Lecturas
{
    public class LecturasDALArchivos : ILecturasDAL
    {
        //patron singleton
        //*****************//
        //constructor de la clase
        private LecturasDALArchivos()
        {

        }
        //*****************//
        //Referencia de la clase
        private static ILecturasDAL instancia;
        //****************//
        //metodo de acceso a la instancia
        public static ILecturasDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new LecturasDALArchivos();
            return instancia;
        }

        private string lectura = Directory.GetCurrentDirectory() +
            Path.DirectorySeparatorChar + "lectura.json";

        public List<Lectura> GetAll()
        {
            List<Lectura> lecturas = new List<Lectura>();
            try
            {

            }catch(IOException ex)
            {

            }
            return lecturas;
        }

        public void Save(Lectura l)
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(lectura,true))
                {
                    writer.WriteLine(l);
                    writer.Flush();
                }
            }catch(IOException ex)
            {

            }
        }

    }
}
