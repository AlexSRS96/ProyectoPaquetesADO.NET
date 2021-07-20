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
    public class PaqueteDALC
    {
        String connectionString = ConfigurationManager.ConnectionStrings["BDAgencia"].ConnectionString;

        public bool AgregarPaquete(PaqueteBE paqueteBE)
        {
            bool agregado = false;

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_AGREGARPAQUETE", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    SQLHelper.AddParam(ref cmd, "@Description", ParameterDirection.Input, SqlDbType.VarChar, 250, paqueteBE.Description);
                    SQLHelper.AddParam(ref cmd, "@Price", ParameterDirection.Input, SqlDbType.Decimal, paqueteBE.Price);
                    SQLHelper.AddParam(ref cmd, "@CustomerID", ParameterDirection.Input, SqlDbType.Int, paqueteBE.CustomerID);                   
                    SQLHelper.AddParam(ref cmd, "@CustomerReceptionID", ParameterDirection.Input, SqlDbType.Int, paqueteBE.CustomerReceptionID);
                  
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
        public bool ActualizarPaquete(PaqueteBE paqueteBE)
        {
            bool actualizado = false;

            SqlConnection cnx = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZARPAQUETE", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 600;

            try
            {
                SQLHelper.AddParam(ref cmd, "@PackageID", ParameterDirection.Input, SqlDbType.Int, paqueteBE.PackageID);
                SQLHelper.AddParam(ref cmd, "@Description", ParameterDirection.Input, SqlDbType.VarChar, 250, paqueteBE.Description);
                SQLHelper.AddParam(ref cmd, "@Price", ParameterDirection.Input, SqlDbType.Decimal, paqueteBE.Price);
                SQLHelper.AddParam(ref cmd, "@CustomerID", ParameterDirection.Input, SqlDbType.Int, paqueteBE.CustomerID);
                SQLHelper.AddParam(ref cmd, "@CustomerReceptionID", ParameterDirection.Input, SqlDbType.Int, paqueteBE.CustomerReceptionID);

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
        public bool EliminarPaquete(int packageID)
        {
            bool eliminado = false;

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARPAQUETE", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    SQLHelper.AddParam(ref cmd, "@PackageID", ParameterDirection.Input, SqlDbType.Int, packageID);

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
        public List<PaqueteBE> ListarPaquetes()
        {
            List<PaqueteBE> paquetes = new List<PaqueteBE>();

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_LISTARPAQUETES", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    cnx.Open();

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            PaqueteBE paqueteBE = ParsePaquete(dr);

                            paquetes.Add(paqueteBE);
                        }
                        cnx.Close();
                    }
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return paquetes;
        }
        public PaqueteBE ObtenerPaquete(int userID)
        {
            PaqueteBE paqueteBE = new PaqueteBE();

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_OBTENERPAQUETE", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    SQLHelper.AddParam(ref cmd, "@CustomerID", ParameterDirection.Input, SqlDbType.Int, userID);

                    cnx.Open();

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            paqueteBE = ParsePaquete(dr);
                        }
                        cnx.Close();
                    }
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return paqueteBE;
        }
        private PaqueteBE ParsePaquete(IDataReader dr)
        {
            PaqueteBE paqueteBE = new PaqueteBE();

            paqueteBE.PackageID = dr.GetInt32(dr.GetOrdinal("PackageID"));
            paqueteBE.Description = dr.GetString(dr.GetOrdinal("Description"));          
            paqueteBE.Price = dr.GetDecimal(dr.GetOrdinal("Price"));
            paqueteBE.CustomerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
            paqueteBE.CustomerReceptionID = dr.GetInt32(dr.GetOrdinal("CustomerReceptionID"));

            return paqueteBE;
        }
    }
}
