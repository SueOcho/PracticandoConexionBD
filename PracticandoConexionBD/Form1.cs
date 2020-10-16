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
    public partial class Form1 : Form
    {
        SqlConnection cnx = new SqlConnection(@"server=DESKTOP-DR3B8JA\EQUIPO; database=VentasLeon;Integrated Security=true");
        

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            
            try
            {
                cnx.Open();
                MessageBox.Show("Se abrio la conexion");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (cnx.State == ConnectionState.Open)
            {
                btnConectar.Enabled = false;
                btnDesconectar.Enabled = true;
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {

            cnx.Close();
            btnConectar.Enabled = true;
            btnDesconectar.Enabled = false;
            MessageBox.Show("Se cerró la conexion");




        }
    }
}
