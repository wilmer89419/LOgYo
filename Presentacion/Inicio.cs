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
    public partial class Inicio : Form
    {
         private string nombreUsuario;
        public Inicio()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Server=(local);Database=Logn;UId=Sistemas;Pwd=12345678");
        private void Inicio_Load(object sender, EventArgs e)
        {
           
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            string U = txt_usuario.Text;
            string P = txt_clave.Text;

            try
            {
                SqlCommand cmd = new SqlCommand("select * from Usuario1 where Usuario='" + U + "'and clave='" + P + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    nombreUsuario = dr.GetString(1); // Obtener el nombre de usuario
                    MessageBox.Show("Hola " + nombreUsuario);
                    Form Despues = new Despues(nombreUsuario); // Pasar el nombre de usuario al formulario Despues
                    Despues.Show();
                    this.Hide();
                



            }
                else
                {
                    MessageBox.Show("El usuario y/o la contraseña son incorrectos ");
                    txt_clave.Clear();
                    txt_usuario.Clear();
                    txt_usuario.Focus(); 
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
