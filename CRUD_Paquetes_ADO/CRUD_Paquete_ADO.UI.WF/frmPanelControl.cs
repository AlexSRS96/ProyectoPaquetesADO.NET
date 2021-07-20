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
    public partial class frmPanelControl : Form
    {
        public frmPanelControl()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios frmUsuarios = new frmUsuarios();
            frmUsuarios.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmClientes frmClientes = new frmClientes();
            frmClientes.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmPaquetes frmPaquetes = new frmPaquetes();
            frmPaquetes.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }      

        private void frmPanelControl_Load(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmReporte frmReporte = new frmReporte();
            frmReporte.Show();
        }
    }
}
