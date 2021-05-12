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

        
        public List<> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            try 
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine();
                    writer.Flush();
                }

            }catch(IOException ex)
            {
                
            }
        }
    }
}
