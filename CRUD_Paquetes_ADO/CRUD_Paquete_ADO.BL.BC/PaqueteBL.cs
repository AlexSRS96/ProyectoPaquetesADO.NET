using CRUD_Paquete_ADO.BL.BE;
using CRUD_Paquete_ADO.DL.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Paquete_ADO.BL.BC
{
    public class PaqueteBL
    {
        PaqueteDALC paqueteDALC = new PaqueteDALC();
        public bool AgregarPaquete(PaqueteBE paqueteBE)
        {
            bool agregado = false;

            try
            {
                agregado = paqueteDALC.AgregarPaquete(paqueteBE);
            }
            catch (Exception)
            {

                throw;
            }
            return agregado;
        }
        public bool ActualizarPaquete(PaqueteBE paqueteBE)
        {
            bool actualizado = false;

            try
            {
                actualizado = paqueteDALC.ActualizarPaquete(paqueteBE);
            }
            catch (Exception)
            {

                throw;
            }
            return actualizado;
        }
        public bool EliminarPaquete(int packageID)
        {
            bool eliminado = false;

            try
            {
                eliminado = paqueteDALC.EliminarPaquete(packageID);
            }
            catch (Exception)
            {

                throw;
            }
            return eliminado;
        }
        public List<PaqueteBE> ListarPaquetes()
        {
            List<PaqueteBE> paquetes = new List<PaqueteBE>();

            try
            {
                paquetes = paqueteDALC.ListarPaquetes();
            }
            catch (Exception)
            {

                throw;
            }
            return paquetes;
        }
        public PaqueteBE ObtenerPaquete(int customerID)
        {
            PaqueteBE paqueteBE = new PaqueteBE();

            try
            {
                paqueteBE = paqueteDALC.ObtenerPaquete(customerID);
            }
            catch (Exception)
            {

                throw;
            }
            return paqueteBE;
        }
    }
}
