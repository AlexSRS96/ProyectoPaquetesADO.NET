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
    public partial class frmRegistroEstado : Form
    {
        public EstadoPaqueteBE estadoPaqueteBE = null;
        private EstadoPaqueteBL estadoPaqueteBL = new EstadoPaqueteBL();
        public frmEstadosPaquetes oFrmEstado = new frmEstadosPaquetes();
        public frmRegistroEstado()
        {
            InitializeComponent();
        }

        private void btnGuardarC_Click(object sender, EventArgs e)
        {
            try
            {
                if (estadoPaqueteBE != null)
                {
                    estadoPaqueteBE.PackageID = int.Parse(txtPackageID.Text);
                    estadoPaqueteBE.StatusDescription = cbEstado.Text;
                    estadoPaqueteBE.ReceptionDate = Convert.ToDateTime(txtFechaRecep.Text);
                    estadoPaqueteBE.ReceptionDate = Convert.ToDateTime(txtFechaRecep.Text);

                    var result = estadoPaqueteBL.ActualizarDetalle(estadoPaqueteBE);

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
                    estadoPaqueteBE = new EstadoPaqueteBE();

                    //estadoPaqueteBE.PackageID = int.Parse(txtPackageID.Text);
                    estadoPaqueteBE.StatusDescription = cbEstado.Text;
                    estadoPaqueteBE.ReceptionDate = Convert.ToDateTime(txtFechaRecep.Text);
                    estadoPaqueteBE.DeliveryDate = Convert.ToDateTime(txtFechaEntre.Text);

                    var result = estadoPaqueteBL.AgregarDetalle(estadoPaqueteBE);

                    if (result)
                    {
                        MessageBox.Show("Se Agrego satisfactoriamente");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Agregar intentelo mas tarde.");
                    }
                }

                oFrmEstado.UpdateDGVStatusPackage();

                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un Problema", ex.Message);
            }
        }

        private void frmRegistroEstado_Load(object sender, EventArgs e)
        {
            if (estadoPaqueteBE != null)
            {
                txtPackageID.Text = estadoPaqueteBE.PackageID.ToString();
                cbEstado.Text = estadoPaqueteBE.StatusDescription;
                txtFechaEntre.Text = estadoPaqueteBE.ReceptionDate.ToString();
                txtFechaEntre.Text = estadoPaqueteBE.DeliveryDate.ToString();
            }
        }
    }
}
