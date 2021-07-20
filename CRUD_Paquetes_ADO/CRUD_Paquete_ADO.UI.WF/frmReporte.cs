using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Paquete_ADO.UI.WF
{
    public partial class frmReporte : Form
    {
        String conexion = ConfigurationManager.ConnectionStrings["BDAgencia"].ConnectionString;
        
        SqlCommand cmd;
        SqlDataReader dr;
        public frmReporte()
        {
            InitializeComponent();
        }      
        private void frmReporte_Load(object sender, EventArgs e)
        {
            CargarGrafico();
        }
        ArrayList Cantidad = new ArrayList();
        ArrayList Mes = new ArrayList();
        private void CargarGrafico()
        {
            SqlConnection cnx = new SqlConnection(conexion);
            cmd = new SqlCommand("SP_PACKAGEDELIVERY", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cnx.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                
                Cantidad.Add(dr.GetInt32(0));
                Mes.Add(dr.GetString(1));



            }
            ReportGraf.Series[0].Points.DataBindXY(Mes, Cantidad);
            dr.Close();
            cnx.Close();
        }
    }
}
