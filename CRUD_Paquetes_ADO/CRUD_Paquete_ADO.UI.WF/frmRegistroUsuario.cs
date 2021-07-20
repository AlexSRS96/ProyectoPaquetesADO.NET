using CRUD_Paquete_ADO.BL.BC;
using CRUD_Paquete_ADO.BL.BE;
using System;
using System.Windows.Forms;

namespace CRUD_Paquete_ADO.UI.WF
{
    public partial class frmRegistroUsuario : Form
    {
        public UserBE userBE = null;
        private UserBL userBL = new UserBL();
        public frmUsuarios oFrmUsuario = new frmUsuarios();
        public frmRegistroUsuario()
        {
            InitializeComponent();
        }
        private void btnGuardarC_Click(object sender, EventArgs e)
        {
            try
            {
                if (userBE != null)
                {
                    userBE.UserID = int.Parse(txtUserIDU.Text);
                    userBE.UserName = txtUserNameU.Text;
                    userBE.Name = txtNameU.Text;
                    userBE.LastName = txtLastNameU.Text;
                    userBE.DNI = txtDNIU.Text;
                    userBE.Email = txtEmailU.Text;
                    userBE.UserType = cbUserTypeU.Text;
                    userBE.PhoneNumber = txtPhoneNumberU.Text;
                    userBE.Password = txtPasswordU.Text;

                    var result = userBL.ActualizarUsuario(userBE);

                    if (result)
                    {
                        MessageBox.Show("Se Actualizo Satisfactoriamente");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Actualizar intentelo mas tarde.");
                    }
                }
                else
                {
                    userBE = new UserBE();
                    //userBE.UserID = int.Parse(txtUserIDU.Text);
                    userBE.UserName = txtUserNameU.Text;
                    userBE.Name = txtNameU.Text;
                    userBE.LastName = txtLastNameU.Text;
                    userBE.DNI = txtDNIU.Text;
                    userBE.Email = txtEmailU.Text;
                    userBE.UserType = cbUserTypeU.Text;
                    userBE.PhoneNumber = txtPhoneNumberU.Text;
                    userBE.Password = txtPasswordU.Text;

                    var result = userBL.AgregarUsuario(userBE);

                    if (result)
                    {
                        MessageBox.Show("Se Agrego satisfactoriamente");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Agregar intentelo mas tarde.");
                    }
                }

                oFrmUsuario.UpdateDGVUsuarios();

                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un Problema", ex.Message);
            }
        }
        private void frmRegistroUsuario_Load(object sender, EventArgs e)
        {
            if (userBE != null)
            {
                txtUserIDU.Text = userBE.UserID.ToString();
                txtUserNameU.Text = userBE.UserName;
                txtNameU.Text = userBE.Name;
                txtLastNameU.Text = userBE.LastName;
                txtDNIU.Text = userBE.DNI;
                txtEmailU.Text = userBE.Email;
                cbUserTypeU.Text = userBE.UserType;
                txtPhoneNumberU.Text = userBE.PhoneNumber;
                txtPasswordU.Text = userBE.Password;
            }
        }
    }
}
