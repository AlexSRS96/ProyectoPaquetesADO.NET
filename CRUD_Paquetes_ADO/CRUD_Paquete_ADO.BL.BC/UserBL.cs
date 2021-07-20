using CRUD_Paquete_ADO.BL.BE;
using CRUD_Paquete_ADO.DL.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Paquete_ADO.BL.BC
{
    public class UserBL
    {
        UserDALC userDALC = new UserDALC();
        public UserBE doLogin(String userName, String password)
        {

            UserBE user = new UserBE();

            try
            {
                user = userDALC.doLogin(userName, password);
            }
            catch (Exception)
            {
                throw;
            }

            return user;

        }
        public bool AgregarUsuario(UserBE userBE)
        {
            bool agregado = false;

            try
            {
                agregado = userDALC.AgregarUsuario(userBE);
            }
            catch (Exception)
            {

                throw;
            }
            return agregado;
        }
        public bool ActualizarUsuario(UserBE userBE)
        {
            bool actualizado = false;

            try
            {
                actualizado = userDALC.ActualizarUsuario(userBE);
            }
            catch (Exception)
            {

                throw;
            }
            return actualizado;
        }
        public bool EliminarUsuario(int userID)
        {
            bool eliminado = false;

            try
            {
                eliminado = userDALC.EliminarUsuario(userID);
            }
            catch (Exception)
            {

                throw;
            }
            return eliminado;
        }
        public List<UserBE> ListarUsuarios()
        {
            List<UserBE> usuarios = new List<UserBE>();

            try
            {
                usuarios = userDALC.ListarUsuarios();
            }
            catch (Exception)
            {

                throw;
            }
            return usuarios;
        }
        public UserBE ObtenerUsuario(String DNI)
        {
            UserBE userBE = new UserBE();

            try
            {
                userBE = userDALC.ObtenerUsuario(DNI);
            }
            catch (Exception)
            {

                throw;
            }
            return userBE;
        }
    }
}
