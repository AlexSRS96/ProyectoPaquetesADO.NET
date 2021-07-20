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
    public class UserDALC
    {
        String connectionString = ConfigurationManager.ConnectionStrings["BDAgencia"].ConnectionString;

        public  UserBE doLogin(String userName, String password)
        {
            UserBE user = new UserBE();

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_LOGIN", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
                    //var pass = PasswordSC.PasswordEncriptarSHA512(password);
                    var pass = PasswordSC.PasswordEncriptar(password);
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = pass;

                    cnx.Open();
                    IDataReader dr = cmd.ExecuteReader();

                    using (dr)
                    {
                        while (dr.Read())
                        {
                            user.UserID = dr.GetInt32(dr.GetOrdinal("UserID"));
                            user.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                            user.Name = dr.GetString(dr.GetOrdinal("Name"));
                            user.LastName = dr.GetString(dr.GetOrdinal("LastName"));
                            user.DNI = dr.GetString(dr.GetOrdinal("DNI"));
                            user.Email = dr.GetString(dr.GetOrdinal("Email"));
                            user.UserType = dr.GetString(dr.GetOrdinal("UserType"));
                            user.PhoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
                            user.Password = dr.GetString(dr.GetOrdinal("Password"));
                        }
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return user;
        }
        public bool AgregarUsuario(UserBE userBE)
        {
            bool agregado = false;

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_AGREGARUSUARIO", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    SQLHelper.AddParam(ref cmd, "@UserName", ParameterDirection.Input, SqlDbType.VarChar, 50, userBE.UserName);
                    SQLHelper.AddParam(ref cmd, "@Name", ParameterDirection.Input, SqlDbType.VarChar, 250, userBE.Name);
                    SQLHelper.AddParam(ref cmd, "@LastName", ParameterDirection.Input, SqlDbType.VarChar, 250, userBE.LastName);
                    SQLHelper.AddParam(ref cmd, "@DNI", ParameterDirection.Input, SqlDbType.VarChar, 9, userBE.DNI);
                    SQLHelper.AddParam(ref cmd, "@Email", ParameterDirection.Input, SqlDbType.VarChar, 250, userBE.Email);
                    SQLHelper.AddParam(ref cmd, "@UserType", ParameterDirection.Input, SqlDbType.VarChar, 50, userBE.UserType);
                    SQLHelper.AddParam(ref cmd, "@PhoneNumber", ParameterDirection.Input, SqlDbType.VarChar, 250, userBE.PhoneNumber);
                    var pass = PasswordSC.PasswordEncriptar(userBE.Password);
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = pass;


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
        public bool ActualizarUsuario(UserBE userBE)
        {
            bool actualizado = false;

            SqlConnection cnx = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZARUSUARIO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 600;

            try
            {
                SQLHelper.AddParam(ref cmd, "@UserID", ParameterDirection.Input, SqlDbType.Int, userBE.UserID);
                SQLHelper.AddParam(ref cmd, "@UserName", ParameterDirection.Input, SqlDbType.VarChar, 50, userBE.UserName);
                SQLHelper.AddParam(ref cmd, "@Name", ParameterDirection.Input, SqlDbType.VarChar, 250, userBE.Name);
                SQLHelper.AddParam(ref cmd, "@LastName", ParameterDirection.Input, SqlDbType.VarChar, 250, userBE.LastName);
                SQLHelper.AddParam(ref cmd, "@DNI", ParameterDirection.Input, SqlDbType.VarChar, 9, userBE.DNI);
                SQLHelper.AddParam(ref cmd, "@Email", ParameterDirection.Input, SqlDbType.VarChar, 250, userBE.Email);
                SQLHelper.AddParam(ref cmd, "@UserType", ParameterDirection.Input, SqlDbType.VarChar, 50, userBE.UserType);
                SQLHelper.AddParam(ref cmd, "@PhoneNumber", ParameterDirection.Input, SqlDbType.VarChar, 250, userBE.PhoneNumber);
                //var pass = PasswordSC.PasswordDesencriptar(userBE.Password);
                var pass = PasswordSC.PasswordDesencriptar(userBE.Password);
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = pass;
                
                
                //var passUpdate = PasswordSC.PasswordEncriptarSHA512(userBE.Password);

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
        public bool EliminarUsuario(int userID)
        {
            bool eliminado = false;

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    SQLHelper.AddParam(ref cmd, "@UserID", ParameterDirection.Input, SqlDbType.Int, userID);

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
        public List<UserBE> ListarUsuarios()
        {
            List<UserBE> usuarios = new List<UserBE>();

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_LISTARUSUARIOS", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    cnx.Open();

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            UserBE userBE = ParseUsuario(dr);

                            usuarios.Add(userBE);
                        }
                        cnx.Close();
                    }
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return usuarios;
        }
        public UserBE ObtenerUsuario(String DNI)
        {
            UserBE userBE = new UserBE();

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_OBTENERUSUARIO", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    SQLHelper.AddParam(ref cmd, "@DNI", ParameterDirection.Input, SqlDbType.VarChar, DNI);

                    cnx.Open();

                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            userBE = ParseUsuario(dr);
                        }
                        cnx.Close();
                    }
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return userBE;
        }
        private UserBE ParseUsuario(IDataReader dr)
        {
            UserBE userBE = new UserBE();

            userBE.UserID = dr.GetInt32(dr.GetOrdinal("UserID"));
            userBE.UserName = dr.GetString(dr.GetOrdinal("UserName"));
            userBE.Name = dr.GetString(dr.GetOrdinal("Name"));
            userBE.LastName = dr.GetString(dr.GetOrdinal("LastName"));
            userBE.DNI = dr.GetString(dr.GetOrdinal("DNI"));
            userBE.Email = dr.GetString(dr.GetOrdinal("Email"));
            userBE.UserType = dr.GetString(dr.GetOrdinal("UserType"));
            userBE.PhoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
            userBE.Password = dr.GetString(dr.GetOrdinal("Password"));

            return userBE;
        }
    }
}
