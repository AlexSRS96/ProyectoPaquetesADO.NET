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
    public partial class frmRegistroCliente : Form
    {
        public CustomerBE customerBE = null;
        private CustomerBL customerBL = new CustomerBL();
        public frmClientes oFrmCliente = new frmClientes();
        public frmRegistroCliente()
        {
            InitializeComponent();
        }

        private void btnGuardarC_Click(object sender, EventArgs e)
        {
            try
            {
                if(customerBE != null)
                {
                    customerBE.CustomerID = int.Parse(txtCustomerIDC.Text);
                    customerBE.Name = txtNameC.Text;
                    customerBE.LastName = txtLastNameC.Text;
                    customerBE.DNI = txtDNIC.Text;
                    customerBE.Email = txtEmailC.Text;
                    customerBE.PhoneNumber = txtPhoneNumberC.Text;
                    customerBE.Region = txtRegionC.Text;
                    customerBE.City = txtCityC.Text;
                    customerBE.Address = txtAddressC.Text;

                    var result = customerBL.ActualizarCliente(customerBE);

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
                    customerBE = new CustomerBE();
                    //customerBE.CustomerID = int.Parse(txtCustomerIDC.Text);
                    customerBE.Name = txtNameC.Text;
                    customerBE.LastName = txtLastNameC.Text;
                    customerBE.DNI = txtDNIC.Text;
                    customerBE.Email = txtEmailC.Text;
                    customerBE.PhoneNumber = txtPhoneNumberC.Text;
                    customerBE.Region = txtRegionC.Text;
                    customerBE.City = txtCityC.Text;
                    customerBE.Address = txtAddressC.Text;

                    var result = customerBL.AgregarCliente(customerBE);

                    if (result)
                    {
                        MessageBox.Show("Se Agrego satisfactoriamente");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Agregar intentelo mas tarde.");
                    }
                }

                oFrmCliente.UpdateDGVClientes();

                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un problema",ex.Message);
            }
        }

        private void frmRegistroCliente_Load(object sender, EventArgs e)
        {
            if (customerBE != null)
            {
                txtCustomerIDC.Text = customerBE.CustomerID.ToString();
                txtNameC.Text = customerBE.Name;
                txtLastNameC.Text = customerBE.LastName;
                txtDNIC.Text = customerBE.DNI;
                txtEmailC.Text = customerBE.Email;
                txtPhoneNumberC.Text = customerBE.PhoneNumber;
                txtRegionC.Text = customerBE.Region;
                txtCityC.Text = customerBE.City;
                txtAddressC.Text = customerBE.Address;
            }
        }
    }
}
