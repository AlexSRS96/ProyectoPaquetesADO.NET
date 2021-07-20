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
    public class EstadoPaqueteDALC
    {
        String connectionString = ConfigurationManager.ConnectionStrings["BDAgencia"].ConnectionString;

        public bool AgregarDetalle(EstadoPaqueteBE estadoPaqueteBE)
        {
            bool agregado = false;

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_AGREGARESTADO", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    //SQLHelper.AddParam(ref cmd, "@PackageID", ParameterDirection.Input, SqlDbType.Int, estadoPaqueteBE.PackageID);
                    SQLHelper.AddParam(ref cmd, "@StatusDescription", ParameterDirection.Input, SqlDbType.VarChar, 30 , estadoPaqueteBE.StatusDescription);
                    SQLHelper.AddParam(ref cmd, "@ReceptionDate", ParameterDirection.Input, SqlDbType.Date, estadoPaqueteBE.ReceptionDate);
                    SQLHelper.AddParam(ref cmd, "@DeliveryDate", ParameterDirection.Input, SqlDbType.Date, estadoPaqueteBE.DeliveryDate);
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
        public bool ActualizarDetalle(EstadoPaqueteBE estadoPaqueteBE)
        {
            bool actualizado = false;

            SqlConnection cnx = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZARESTADO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 600;

            try
            {
                SQLHelper.AddParam(ref cmd, "@PackageID", ParameterDirection.Input, SqlDbType.Int, estadoPaqueteBE.PackageID);
                SQLHelper.AddParam(ref cmd, "@StatusDescription", ParameterDirection.Input, SqlDbType.VarChar, 30, estadoPaqueteBE.StatusDescription);
                SQLHelper.AddParam(ref cmd, "@ReceptionDate", ParameterDirection.Input, SqlDbType.Date, estadoPaqueteBE.ReceptionDate);
                SQLHelper.AddParam(ref cmd, "@DeliveryDate", ParameterDirection.Input, SqlDbType.Date, estadoPaqueteBE.DeliveryDate);

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
        public bool EliminarDetalle(int packageID)
        {
            bool eliminado = false;

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARESTADO", cnx);
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

        public List<EstadoPaqueteBE> ListarDetalles()
        {
            List<EstadoPaqueteBE> estados = new List<EstadoPaqueteBE>();

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_LISTARESTADO", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    cnx.Open();

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EstadoPaqueteBE estadoPaqueteBE = ParseEstado(dr);

                            estados.Add(estadoPaqueteBE);
                        }
                        cnx.Close();
                    }
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return estados;
        }

        public EstadoPaqueteBE ObtenerEstado(int packageID)
        {
            EstadoPaqueteBE estadoPaqueteBE = new EstadoPaqueteBE();

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_OBTENERESTADO", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    SQLHelper.AddParam(ref cmd, "@PackageID", ParameterDirection.Input, SqlDbType.VarChar, packageID);

                    cnx.Open();

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            estadoPaqueteBE = ParseEstado(dr);
                        }
                        cnx.Close();
                    }
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return estadoPaqueteBE;
        }

        private EstadoPaqueteBE ParseEstado(IDataReader dr)
        {
            EstadoPaqueteBE estadoPaqueteBE = new EstadoPaqueteBE();

            estadoPaqueteBE.PackageID = dr.GetInt32(dr.GetOrdinal("PackageID"));
            estadoPaqueteBE.StatusDescription = dr.GetString(dr.GetOrdinal("StatusDescription"));
            estadoPaqueteBE.ReceptionDate = dr.GetDateTime(dr.GetOrdinal("ReceptionDate"));
            estadoPaqueteBE.DeliveryDate = dr.GetDateTime(dr.GetOrdinal("DeliveryDate"));
            

            return estadoPaqueteBE;
            
        }
    }
}
