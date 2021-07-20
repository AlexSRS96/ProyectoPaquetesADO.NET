using CRUD_Paquete_ADO.BL.BE;
using CRUD_Paquete_ADO.DL.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Paquete_ADO.BL.BC
{
    public class EstadoPaqueteBL
    {
        EstadoPaqueteDALC estadoPaqueteDALC = new EstadoPaqueteDALC();
        public bool AgregarDetalle(EstadoPaqueteBE estadoPaqueteBE)
        {
            bool agregado = false;

            try
            {
                agregado = estadoPaqueteDALC.AgregarDetalle(estadoPaqueteBE);
            }
            catch (Exception)
            {

                throw;
            }
            return agregado;
        }
        public bool ActualizarDetalle(EstadoPaqueteBE estadoPaqueteBE)
        {
            bool actualizado = false;

            try
            {
                actualizado = estadoPaqueteDALC.ActualizarDetalle(estadoPaqueteBE);
            }
            catch (Exception)
            {

                throw;
            }
            return actualizado;
        }
        public bool EliminarDetalle(int packageID)
        {
            bool eliminado = false;

            try
            {
                eliminado = estadoPaqueteDALC.EliminarDetalle(packageID);
            }
            catch (Exception)
            {

                throw;
            }
            return eliminado;
        }
        public List<EstadoPaqueteBE> ListarEstados()
        {
            List<EstadoPaqueteBE> estados = new List<EstadoPaqueteBE>();

            try
            {
                estados = estadoPaqueteDALC.ListarDetalles();
            }
            catch (Exception)
            {

                throw;
            }
            return estados;
        }
        public EstadoPaqueteBE ObtenerEstado(int packageID)
        {
            EstadoPaqueteBE estadoPaqueteBE = new EstadoPaqueteBE();

            try
            {
                estadoPaqueteBE = estadoPaqueteDALC.ObtenerEstado(packageID);
            }
            catch (Exception)
            {

                throw;
            }
            return estadoPaqueteBE;
        }
    }
}
