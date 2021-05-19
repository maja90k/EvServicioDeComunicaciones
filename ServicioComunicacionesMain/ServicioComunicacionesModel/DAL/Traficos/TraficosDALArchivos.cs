using ServicioComunicacionesModel.DAL.Traficos;
using ServicioComunicacionesModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesModel.DAL.Traficos
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

        public class Obtener
        {
            public static void ObtenerMedidoresTransito()
            {
                //****Aqui se compone la lista estatica
                List<int> medidores = new List<int>();

                medidores.Add(1);
                medidores.Add(2);
                medidores.Add(3);
                medidores.Add(4);
                medidores.Add(5);
                medidores.Add(6);
                medidores.Add(7);
                medidores.Add(8);
                medidores.Add(9);
                medidores.Add(10);

                //***este metodo los lee 
                //##ojo no estoy seguro que vaya aca 
                foreach (var dato in medidores)
                {
                    // (dato.ToString());
                }
            }


        }

        public void Save(Trafico t)
        {
            throw new NotImplementedException();
        }
    }
}
