using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PracticandoConexionBD
{
    public partial class Form2 : Form
    {
        SqlConnection cnx=new SqlConnection(@"server=DESKTOP-DR3B8JA\EQUIPO; database=VentasLeon;Integrated Security=true");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;

        public Form2()
        {
            InitializeComponent();
        }    

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarVendedor";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@vcod", lblCodigo.Text.Trim());

                cnx.Open();
                dtr = cmd.ExecuteReader();


                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    lblNombre.Text = dtr["Nom_ven"].ToString();
                    lblApellido.Text = dtr["Ape_ven"].ToString();
                    lblSueldo.Text = dtr["Sue_ven"].ToString();
                    lblCorreo.Text = dtr["Email_ven"].ToString();
                }
                else
                {
                    lblNombre.Text = "";
                    lblApellido.Text ="";
                    lblSueldo.Text = "";
                    lblCorreo.Text = "";
                    MessageBox.Show("Codigo de cliente no existe");
                }
                dtr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }
    }
}
