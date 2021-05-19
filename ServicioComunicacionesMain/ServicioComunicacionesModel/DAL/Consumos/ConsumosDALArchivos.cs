using ServicioComunicacionesModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionesModel.DAL.Consumos
{
    public class ConsumosDALArchivos : IConsumosDAL
    {
        public static List<Consumo> medidoresConsumos = new List<Consumo>();

        private ConsumosDALArchivos()
        {

        }
        
        private static IConsumosDAL instancia;
      
        public static IConsumosDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new ConsumosDALArchivos();
            return instancia;
        }

        private string arconsumo = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "consumos.txt";

        private Consumo FindByNroMedidor(string nroMedidor)
        {
            return medidoresConsumos.Find(c => c.NroMedidor == nroMedidor);
        }

        public List<Consumo> GetAll()
        {
            List<Consumo> consumos = new List<Consumo>();
            try
            {
                using(StreamReader reader = new StreamReader(arconsumo))
                {
                    string mensj = null;
                    do
                    {
                        mensj = reader.ReadLine();
                        if (mensj != null)
                        {
                            String[] mensjArray = mensj.Split('|');
                            Consumo c = new Consumo()
                            {
                               //el dato fecha se esta capturando como string y no como datetime
                               Fecha = mensjArray[0],
                               NroMedidor = mensjArray[1],
                               Tipo = mensjArray[2]
                            };
                            consumos.Add(c);
                        }

                    } while (mensj != null);
                }
            }catch (IOException ex)
            {

            }

            return consumos;
        }

        public void Save(Consumo c)
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(arconsumo, true))
                {
                    writer.WriteLine(c);
                    writer.Flush();
                }
            }catch (IOException ex)
            {

            }
        }

        public class Obtener
        {
            public static void ObtenerMedidoresConsumo()
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
    }
}
