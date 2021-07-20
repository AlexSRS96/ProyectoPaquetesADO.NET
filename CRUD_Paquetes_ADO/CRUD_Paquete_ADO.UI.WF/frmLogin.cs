using CRUD_Paquete_ADO.BL.BC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Paquete_ADO.UI.WF
{
    public partial class frmLogin : Form
    {
        private UserBL userBL = new UserBL();
        

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text.Length > 3 && txtPassword.Text.Length >3)
                {
                    var user = userBL.doLogin(txtUserName.Text, txtPassword.Text);
                    
                    if (user.DNI != null)
                    {
                        if (user.UserType == "AGENTE")
                        {
                            frmPanelControl frm = new frmPanelControl();

                            frm.btnUsuarios.Enabled = false;                           
                            frm.Show();
                            txtUserName.Clear();
                            txtPassword.Clear();
                        }
                        else
                        {
                            frmPanelControl frm = new frmPanelControl();
                            
                            frm.Show();
                            txtUserName.Clear();
                            txtPassword.Clear();
                        }

                       
                    }
                    else
                    {
                        MessageBox.Show("El usuario ingresado no se encuentra registrado");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrecta.");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
