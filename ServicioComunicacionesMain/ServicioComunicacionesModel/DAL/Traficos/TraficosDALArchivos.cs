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
        
        private TraficosDALArchivos()
        {

        }
       
        private static ITraficosDAL instancia;
       
        public static ITraficosDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new TraficosDALArchivos();
            return instancia;
        }

        private string trafico = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "traficos.txt" ;

        public List<Trafico> GetAll()
        {            
            List<Trafico> traficos = new List<Trafico>();
            try
            {

            }catch(IOException ex)
            {

            }
            return traficos;
        }

        public void Save(Trafico t)
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
                Console.WriteLine(ex);
            }
        }

        
        public List<Trafico> ObtenerMedidoresTrafico()
        {
            //****Aqui se compone la lista estatica
            List<Trafico> medidorTraf = new List<Trafico>();

            Trafico tra1 = new Trafico() { NroMedidor = 2222 };
            Trafico tra2 = new Trafico() { NroMedidor = 2333 };
            Trafico tra3 = new Trafico() { NroMedidor = 2444 };
            Trafico tra4 = new Trafico() { NroMedidor = 2555 };

            medidorTraf.Add(tra1);
            medidorTraf.Add(tra2);
            medidorTraf.Add(tra3);
            medidorTraf.Add(tra4);

            return medidorTraf;
        }
       
    }
}
