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
    public partial class frmClientes : Form
    {
        private CustomerBL customerBL = new CustomerBL();

        public frmClientes()
        {
            InitializeComponent();
        }
        public void UpdateDGVClientes()
        {
            dgvClientes.DataSource = customerBL.ListarClientes();
        } 
        public void MostrarCliente(String DNI)
        {
            dgvClientes.DataSource = customerBL.ObtenerCliente(DNI);
        }
        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistroCliente frmRegistroCliente = new frmRegistroCliente();
            frmRegistroCliente.oFrmCliente = this;
            frmRegistroCliente.Show();
        }
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                var customer = (CustomerBE)dgvClientes.SelectedRows[0].DataBoundItem;

                frmRegistroCliente frmRegistroCliente  = new frmRegistroCliente();
                frmRegistroCliente.oFrmCliente = this;
                frmRegistroCliente.customerBE = customer;
                frmRegistroCliente.Show();
            }
        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                var customer = (CustomerBE)dgvClientes.SelectedRows[0].DataBoundItem;

                DialogResult result = MessageBox.Show("Esta seguro de eliminar este Cliente?", "Alerta!!!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    customerBL.EliminarCliente(customer.CustomerID);
                    MessageBox.Show("Se elimino Satisfactorimanente");
                    UpdateDGVClientes();
                }
            }
        }
        
        private void btnBuscarCustomer_Click(object sender, EventArgs e)
        {
            var customer = (CustomerBE)dgvClientes.SelectedRows[0].DataBoundItem;
            for (int i = 0; i < dgvClientes.SelectedRows.Count; i++)
            {
                if (customer.DNI == txtDNI.Text)
                {
                    
                    MessageBox.Show("La busqueda finalizo ", "Aviso", MessageBoxButtons.OK);
                    MostrarCliente(Convert.ToString(txtDNI));
                }
            }
            
        }
        private void frmClientes_Load(object sender, EventArgs e)
        {
            UpdateDGVClientes();
        }
    }
}
