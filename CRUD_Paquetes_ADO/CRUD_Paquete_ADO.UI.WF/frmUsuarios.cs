using CRUD_Paquete_ADO.BL.BC;
using CRUD_Paquete_ADO.BL.BE;
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
    public partial class frmUsuarios : Form
    {
        private UserBL userBL = new UserBL();

        public frmUsuarios()
        {
            InitializeComponent();
        }
        public void UpdateDGVUsuarios()
        {
            dgvUsuarios.DataSource = userBL.ListarUsuarios();
        }   

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistroUsuario frmRegistroUsuario = new frmRegistroUsuario();
            frmRegistroUsuario.oFrmUsuario = this;
            frmRegistroUsuario.Show();
        }
        
        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var user = (UserBE)dgvUsuarios.SelectedRows[0].DataBoundItem;

                frmRegistroUsuario frmRegistroUsuario = new frmRegistroUsuario();
                frmRegistroUsuario.oFrmUsuario = this;
                frmRegistroUsuario.userBE = user;
                frmRegistroUsuario.Show();
            }
        }     

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var user = (UserBE)dgvUsuarios.SelectedRows[0].DataBoundItem;

                DialogResult result = MessageBox.Show("Esta seguro de eliminar este Usuario?","Alerta!!!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    userBL.EliminarUsuario(user.UserID);
                    MessageBox.Show("Se elimino Satisfactorimanente");
                    UpdateDGVUsuarios();
                }
            }
        }
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            UpdateDGVUsuarios();
        }
    }
}
