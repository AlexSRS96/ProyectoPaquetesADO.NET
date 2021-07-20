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
    public partial class frmPaquetes : Form
    {
        private PaqueteBL paqueteBL = new PaqueteBL();
        public frmPaquetes()
        {
            InitializeComponent();
        }
        public void UpdateDGVPaquetes()
        {
            dgvPackages.DataSource = paqueteBL.ListarPaquetes();
        }
        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistroPaquete frmRegistroPaquete = new frmRegistroPaquete();
            frmRegistroPaquete.oFrmPaquete = this;
            frmRegistroPaquete.Show();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPackages.SelectedRows.Count > 0)
            {
                var package = (PaqueteBE)dgvPackages.SelectedRows[0].DataBoundItem;

                frmRegistroPaquete frmRegistroPaquete = new frmRegistroPaquete();
                frmRegistroPaquete.oFrmPaquete = this;
                frmRegistroPaquete.paqueteBE = package;
                frmRegistroPaquete.Show();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPackages.SelectedRows.Count > 0)
            {
                var package = (PaqueteBE)dgvPackages.SelectedRows[0].DataBoundItem;

                DialogResult result = MessageBox.Show("Esta seguro de eliminar este Paquete?", "Alerta!!!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    paqueteBL.EliminarPaquete(package.PackageID);
                    MessageBox.Show("Se elimino el Paquete");
                    UpdateDGVPaquetes();
                }
            }
        }

        private void frmPaquetes_Load(object sender, EventArgs e)
        {
            UpdateDGVPaquetes();
        }

        private void detallePaquetesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadosPaquetes frmEstadosPaquetes = new frmEstadosPaquetes();
            frmEstadosPaquetes.Show();
        }
    }
}
