using CRUD_Paquete_ADO.BL.BE;
using CRUD_Paquete_ADO.DL.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Paquete_ADO.BL.BC
{
    public class CustomerBL
    {
        CustomerDALC customerDALC = new CustomerDALC();
        public bool AgregarCliente(CustomerBE customerBE)
        {
            bool agregado = false;

            try
            {
                agregado = customerDALC.AgregarCliente(customerBE);
            }
            catch (Exception)
            {

                throw;
            }
            return agregado;
        }
        public bool ActualizarCliente(CustomerBE customerBE)
        {
            bool actualizado = false;

            try
            {
                actualizado = customerDALC.ActualizarCliente(customerBE);
            }
            catch (Exception)
            {

                throw;
            }
            return actualizado;
        }
        public bool EliminarCliente(int customerID)
        {
            bool eliminado = false;

            try
            {
                eliminado = customerDALC.EliminarCliente(customerID);
            }
            catch (Exception)
            {

                throw;
            }
            return eliminado;
        }
        public List<CustomerBE> ListarClientes()
        {
            List<CustomerBE> clientes = new List<CustomerBE>();

            try
            {
                clientes = customerDALC.ListarClientes();
            }
            catch (Exception)
            {

                throw;
            }
            return clientes;
        }
        public CustomerBE ObtenerCliente(String DNI)
        {
            CustomerBE customerBE = new CustomerBE();

            try
            {
                customerBE = customerDALC.ObtenerCliente(DNI);
            }
            catch (Exception)
            {

                throw;
            }
            return customerBE;
        }
    }
}
