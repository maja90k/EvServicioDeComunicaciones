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

        public static object Nro { get; private set; }

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

        public static List<Consumo> ObtenerMedidoresConsumo()
            {
                //****Aqui se compone la lista estatica
                List<Consumo> medidores = new List<Consumo>();

                Consumo consu1 = new Consumo() { NroMedidor = 1111 };
                Consumo consu2 = new Consumo() { NroMedidor = 1122 };
                Consumo consu3 = new Consumo() { NroMedidor = 1333 };
                Consumo consu4 = new Consumo() { NroMedidor = 4444 };

            medidores.Add(consu1);
            medidores.Add(consu2);
            medidores.Add(consu3);
            medidores.Add(consu4);

            return medidores;
            }
           

        }
    }
}
