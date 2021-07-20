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
    public partial class frmRegistroPaquete : Form
    {
        public PaqueteBE paqueteBE = null;
        private PaqueteBL paqueteBL = new PaqueteBL();
        public frmPaquetes oFrmPaquete = new frmPaquetes();
        public frmRegistroPaquete()
        {
            InitializeComponent();
        }

        private void btnGuardarP_Click(object sender, EventArgs e)
        {
            try
            {
                if (paqueteBE != null)
                {
                    paqueteBE.PackageID = int.Parse(txtPackageID.Text);
                    paqueteBE.Description = txtDescription.Text;
                    paqueteBE.Price = Decimal.Parse(txtPrice.Text);
                    paqueteBE.CustomerID = int.Parse(txtCustomerIDE.Text);
                    paqueteBE.CustomerReceptionID = int.Parse(txtCustomerReceptionID.Text);

                    var result = paqueteBL.ActualizarPaquete(paqueteBE);

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
                    paqueteBE = new PaqueteBE();
                    //paqueteBE.PackageID = int.Parse(txtPackageID.Text);
                    paqueteBE.Description = txtDescription.Text;
                    paqueteBE.Price = Decimal.Parse(txtPrice.Text);
                    paqueteBE.CustomerID = int.Parse(txtCustomerIDE.Text);
                    paqueteBE.CustomerReceptionID = int.Parse(txtCustomerReceptionID.Text);

                    var result = paqueteBL.AgregarPaquete(paqueteBE);

                    if (result)
                    {
                        MessageBox.Show("Se agrego Satisfactoriamente");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Agregar intentelo mas tarde.");
                    }
                }
                oFrmPaquete.UpdateDGVPaquetes();

                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un Problema",ex.Message);
            }
        }

        private void frmRegistroPaquete_Load(object sender, EventArgs e)
        {
            if (paqueteBE != null)
            {
                txtPackageID.Text = paqueteBE.PackageID.ToString();
                txtDescription.Text = paqueteBE.Description;
                txtPrice.Text = paqueteBE.Price.ToString();
                txtCustomerIDE.Text = paqueteBE.CustomerID.ToString();
                txtCustomerReceptionID.Text = paqueteBE.CustomerReceptionID.ToString();
            }
        }
    }
}
