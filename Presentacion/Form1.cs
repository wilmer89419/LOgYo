using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Presentacion
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();





        private void txt_entrar_Click(object sender, EventArgs e)
        {
          


            string U = txt_usuario.Text;
            string P = txt_clave.Text;

            try
            {
                SqlCommand cmd = new SqlCommand("select * from Usuario where Usuario='" + U + "'and clave='" + P + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Hola " + dr.GetValue(1));
                    Form Despues = new Despues();
                    Despues.Show();

                    this.Hide();



                }
                else
                {
                    MessageBox.Show("no no no ");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
    }
}
