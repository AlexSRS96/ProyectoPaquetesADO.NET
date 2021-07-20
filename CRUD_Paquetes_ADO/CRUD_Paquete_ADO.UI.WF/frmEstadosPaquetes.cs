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
    public partial class frmEstadosPaquetes : Form
    {
        private EstadoPaqueteBL estadoPaqueteBL = new EstadoPaqueteBL();
        public frmEstadosPaquetes()
        {
            InitializeComponent();
        }
        public void UpdateDGVStatusPackage()
        {
            dgvEstadosPaquetes.DataSource = estadoPaqueteBL.ListarEstados();
        }

        private void agregarEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistroEstado frmRegistroEstado = new frmRegistroEstado();
            frmRegistroEstado.oFrmEstado = this;
            frmRegistroEstado.Show();
        }

        private void editarEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEstadosPaquetes.SelectedRows.Count > 0)
            {
                var status = (EstadoPaqueteBE)dgvEstadosPaquetes.SelectedRows[0].DataBoundItem;

                frmRegistroEstado frmRegistroEstado = new frmRegistroEstado();
                frmRegistroEstado.oFrmEstado = this;
                frmRegistroEstado.estadoPaqueteBE = status;
                frmRegistroEstado.Show();
            }
        }

        private void eliminarEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEstadosPaquetes.SelectedRows.Count > 0)
            {
                var package = (EstadoPaqueteBE)dgvEstadosPaquetes.SelectedRows[0].DataBoundItem;

                DialogResult result = MessageBox.Show("Esta seguro de eliminar este Detalle?", "Alerta!!!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    estadoPaqueteBL.EliminarDetalle(package.PackageID);
                    MessageBox.Show("Se elimino el Detalle");
                    UpdateDGVStatusPackage();
                }
            }
        }

        private void frmEstadosPaquetes_Load(object sender, EventArgs e)
        {
            UpdateDGVStatusPackage();
        }

        private void btnBuscarUser_Click(object sender, EventArgs e)
        {

        }
    }
}
