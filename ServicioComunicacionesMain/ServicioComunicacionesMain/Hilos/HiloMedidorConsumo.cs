﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ServicioComunicacionesModel.DAL.Consumos;
using ServicioComunicacionesModel.DAL.Lecturas;
using ServicioComunicacionesModel.DTO;
using SocketsUtils;

namespace ServicioComunicacionesApp.Hilos
{
    class HiloMedidorConsumo
    {
        private MedidorConsumoSocket comMedidor;
        private IConsumosDAL dal = ConsumosDALFactory.CreateDal();
        private ILecturasDAL Ldal = LecturasDALFactory.CreateDal();
        private static bool valido = false;
        private static string regex = "yyyy-MM-dd-HH-mm-ss";

        public static bool ValidarFecha(String fechaActual)
        {
            bool res = false;
            DateTime parsed;    
            valido = DateTime.TryParseExact(fechaActual, "yyyy-MM-dd-HH-mm-ss",CultureInfo.InvariantCulture,DateTimeStyles.None,out parsed);
            if (valido == false)
            {
                res = false;
            }
            else
            {
                res = true;
            }
            return res;
        }

        public HiloMedidorConsumo(MedidorConsumoSocket medidorConsumoSocket)
        {
            this.comMedidor = medidorConsumoSocket;
        }
        
        public void Ejecutar()
        {
            string tipo, nMedidor;
            string fecha = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            bool r = false;

            this.comMedidor.Escribir("Fecha");
            fecha = this.comMedidor.Leer();
            ValidarFecha(fecha);


            this.comMedidor.Escribir("Numero Medidor:");
            nMedidor = this.comMedidor.Leer();
            lock (dal)
            {
                dal.ObtenerMedidoresConsumo().ForEach(d =>
                {
                    if (d.NroMedidor == Convert.ToInt32(nMedidor))
                    {
                        Console.WriteLine(fecha + "| WAIT");
                        this.comMedidor.Escribir(fecha + "| WAIT");
                        r = true;
                    }
                    if (d.NroMedidor != Convert.ToInt32(nMedidor))
                    {
                        this.comMedidor.Escribir(fecha + "|" + "ERROR");
                        this.comMedidor.CerrarConexion();
                        r = false;
                    }
                });
            }
        
            if (r == true)
            {
                Console.WriteLine("{0}" + "|" + "{1}" + "|" + "{2}", fecha, nMedidor, tipo);

                this.comMedidor.Escribir("Ingrese numero de serie");
                string nroMedidor = this.comMedidor.Leer().Trim();

                this.comMedidor.Escribir("Ingrese fecha");
                string fechaEstado = this.comMedidor.Leer().Trim();

                //tipo
                this.comMedidor.Escribir("Indique tipo de cliente");
                string tipo = this.comMedidor.Leer().Trim();
                
                this.comMedidor.Escribir("Ingrese valor");
                string valor = this.comMedidor.Leer().Trim();

                this.comMedidor.Escribir("Ingrese estado");
                string estado = this.comMedidor.Leer().Trim();

                Console.WriteLine(nroMedidor + "|" + fechaEstado + "|" + tipo + "|" + valor + "|" + estado + "|" + "UPDATE");
                this.comMedidor.Escribir(nroMedidor + "|" + fechaEstado + "|" + tipo + "|" + valor + "|" + estado + "|" + "UPDATE");
                this.comMedidor.CerrarConexion();


                Lectura l = new Lectura()
                {
                    NMedidor = Convert.ToInt32(nroMedidor),
                    Fecha = Convert.ToDateTime(fechaEstado),
                    Tipo = tipo,
                    Valor = valor,
                    Estado = estado

                };

                lock (Ldal)
                {
                    Ldal.RegistrarLectura(l);
                }
            }
        }
    }
}
