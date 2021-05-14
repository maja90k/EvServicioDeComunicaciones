using ServicioComunicacionesModel.DAL.Traficos;
using ServicioComunicacionesModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesModel.DAL
{
    public class TraficosDALArchivos : ITraficosDAL
    {
        //patron singleton
        //*****************//
        //constructor de la clase
        private TraficosDALArchivos()
        {

        }
        //*****************//
        //Referencia de la clase
        private static ITraficosDAL instancia;
        //****************//
        //metodo de acceso a la instancia
        public static ITraficosDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new TraficosDALArchivos();
            return instancia;
        }

        private string trafico = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "traficos.txt" ;

        public List<Trafico> GetAll()
        {
            //throw new NotImplementedException();
            List<Trafico> traficos = new List<Trafico>();
            try
            {

            }catch(IOException ex)
            {

            }
            return traficos;
        }

        public void Save()
        {
            try 
            {
                using (StreamWriter writer = new StreamWriter(trafico, true))
                {
                    writer.WriteLine();
                    writer.Flush();
                }

            }catch(IOException ex)
            {
                
            }
        }

        public void Save(Trafico t)
        {
            throw new NotImplementedException();
        }
    }
}
