using CRUD_Paquete_ADO.BL.BE;
using CRUD_Paquete_ADO.FL.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Paquete_ADO.DL.DC
{
    public class CustomerDALC
    {
        String connectionString = ConfigurationManager.ConnectionStrings["BDAgencia"].ConnectionString;

        public bool AgregarCliente(CustomerBE customerBE)
        {
            bool agregado = false;

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_AGREGARCLIENTE", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    SQLHelper.AddParam(ref cmd, "@Name", ParameterDirection.Input, SqlDbType.VarChar, 250, customerBE.Name);
                    SQLHelper.AddParam(ref cmd, "@LastName", ParameterDirection.Input, SqlDbType.VarChar, 250, customerBE.LastName);
                    SQLHelper.AddParam(ref cmd, "@DNI", ParameterDirection.Input, SqlDbType.VarChar, 9, customerBE.DNI);
                    SQLHelper.AddParam(ref cmd, "@Email", ParameterDirection.Input, SqlDbType.VarChar, 250, customerBE.Email);
                    SQLHelper.AddParam(ref cmd, "@PhoneNumber", ParameterDirection.Input, SqlDbType.VarChar, 250, customerBE.PhoneNumber);
                    SQLHelper.AddParam(ref cmd, "@Region", ParameterDirection.Input, SqlDbType.VarChar, 250, customerBE.Region);
                    SQLHelper.AddParam(ref cmd, "@City", ParameterDirection.Input, SqlDbType.VarChar, 250, customerBE.City);
                    SQLHelper.AddParam(ref cmd, "@Address", ParameterDirection.Input, SqlDbType.VarChar, 250, customerBE.Address);
                    cnx.Open();

                    cmd.ExecuteNonQuery();

                    agregado = true;

                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return agregado;
        }
        public bool ActualizarCliente(CustomerBE customerBE)
        {
            bool actualizado = false;

            SqlConnection cnx = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZARCLIENTE", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 600;

            try
            {
                SQLHelper.AddParam(ref cmd, "@CustomerID", ParameterDirection.Input, SqlDbType.Int, customerBE.CustomerID);
                SQLHelper.AddParam(ref cmd, "@Name", ParameterDirection.Input, SqlDbType.VarChar, 250, customerBE.Name);
                SQLHelper.AddParam(ref cmd, "@LastName", ParameterDirection.Input, SqlDbType.VarChar, 250, customerBE.LastName);
                SQLHelper.AddParam(ref cmd, "@DNI", ParameterDirection.Input, SqlDbType.VarChar, 9, customerBE.DNI);
                SQLHelper.AddParam(ref cmd, "@Email", ParameterDirection.Input, SqlDbType.VarChar, 250, customerBE.Email);
                SQLHelper.AddParam(ref cmd, "@PhoneNumber", ParameterDirection.Input, SqlDbType.VarChar, 250, customerBE.PhoneNumber);
                SQLHelper.AddParam(ref cmd, "@Region", ParameterDirection.Input, SqlDbType.VarChar, 250, customerBE.Region);
                SQLHelper.AddParam(ref cmd, "@City", ParameterDirection.Input, SqlDbType.VarChar, 250, customerBE.City);
                SQLHelper.AddParam(ref cmd, "@Address", ParameterDirection.Input, SqlDbType.VarChar, 250, customerBE.Address);

                cnx.Open();

                cmd.ExecuteNonQuery();

                actualizado = true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cnx.Dispose();
                cmd.Dispose();
            }
            return actualizado;
        }
        public bool EliminarCliente(int customerID)
        {
            bool eliminado = false;

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARCLIENTE", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    SQLHelper.AddParam(ref cmd, "@CustomerID", ParameterDirection.Input, SqlDbType.Int, customerID);

                    cnx.Open();

                    cmd.ExecuteNonQuery();

                    eliminado = true;
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return eliminado;
        }
        public List<CustomerBE> ListarClientes()
        {
            List<CustomerBE> clientes = new List<CustomerBE>();

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_LISTARCLIENTES", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    cnx.Open();

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CustomerBE customerBE = ParseCliente(dr);

                            clientes.Add(customerBE);
                        }
                        cnx.Close();
                    }
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return clientes;
        }
        public CustomerBE ObtenerCliente(String DNI)
        {
            CustomerBE customerBE = new CustomerBE();

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_OBTENERCLIENTE", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    SQLHelper.AddParam(ref cmd, "@DNI", ParameterDirection.Input, SqlDbType.VarChar, DNI);

                    cnx.Open();

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            customerBE = ParseCliente(dr);
                        }
                        cnx.Close();
                    }
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return customerBE;
        }
        private CustomerBE ParseCliente(IDataReader dr)
        {
            CustomerBE customerBE = new CustomerBE();

            customerBE.CustomerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
            customerBE.Name = dr.GetString(dr.GetOrdinal("Name"));
            customerBE.LastName = dr.GetString(dr.GetOrdinal("LastName"));
            customerBE.DNI = dr.GetString(dr.GetOrdinal("DNI"));
            customerBE.Email = dr.GetString(dr.GetOrdinal("Email"));
            customerBE.PhoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
            customerBE.Region = dr.GetString(dr.GetOrdinal("Region"));
            customerBE.City = dr.GetString(dr.GetOrdinal("City"));
            customerBE.Address = dr.GetString(dr.GetOrdinal("Address"));

            return customerBE;
        }
    }
}
