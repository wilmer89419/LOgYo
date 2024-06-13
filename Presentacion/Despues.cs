using Negocio;
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
    public partial class Despues : Form
    {
        private string nombreUsuario;
        private SqlConnection Conexion = new SqlConnection("Server=WILMER;DataBase= Logn;Integrated Security=true");

        N_producto objetoCN = new N_producto();
        private string idProducto = null;
        private bool Editar = false;

        public Despues()
        {
            InitializeComponent();
        }
        public Despues(string nombreUsuario)
        {
            InitializeComponent();
            this.nombreUsuario = nombreUsuario; // Asignar el nombre de usuario recibido al campo de la clase
        }


        private void Despues_Load(object sender, EventArgs e)
        {
            


            MostrarProdctos();
            VerificarRolUsuario();


        }
        private void VerificarRolUsuario()
        {
            try
            {
                Conexion.Open();
                // Consulta SQL para obtener el rol del usuario actual
                SqlCommand cmd = new SqlCommand("SELECT Administrador FROM Usuario1 WHERE Nombre = @Nombre", Conexion);
                cmd.Parameters.AddWithValue("@Nombre", nombreUsuario);

                // Ejecutar la consulta y obtener el resultado
                object result = cmd.ExecuteScalar();
                int esAdministrador = result != null ? Convert.ToInt32(result) : 0;

                // Cerrar la conexión
                Conexion.Close();

                // Verificar si el usuario es administrador o no
                if (esAdministrador == 0)
                {
                    // Si no es administrador, deshabilitar los botones
                    btn_editar.Visible = false;
                    btn_usuario.Visible = false;
                }
                else
                {
                    // Si es administrador, dejar los botones habilitados
                    btn_editar.Visible = true;
                    btn_usuario.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el rol del usuario: " + ex.Message);
            }

        }

        private void MostrarProdctos()
        {
            N_producto objeto = new N_producto();
            dgv_datosP.DataSource = objeto.MostrarProd();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
           
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarPRod(txt_nombre.Text,  txt_stock.Text,txt_descripcion.Text);
                    MessageBox.Show("se inserto correctamente");
                    MostrarProdctos();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo insertar los datos por: " + ex);
                }
            }
            //EDITAR
            if (Editar == true)
            {
                try
                {
                    txt_id.Enabled = false;
                    txt_id.Text = dgv_datosP.SelectedCells.Count > 0 ? dgv_datosP.Rows[dgv_datosP.SelectedCells[0].RowIndex].Cells[0].Value?.ToString() : string.Empty;

                    objetoCN.EditarProd(txt_nombre.Text, txt_stock.Text, txt_descripcion.Text, txt_id.Text);
                    MessageBox.Show("se edito correctamente");
                    MostrarProdctos();
                    limpiarForm();
                    Editar = false;
                    txt_id.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo editar los datos por: " + ex);
                }
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
          
            if (dgv_datosP.SelectedRows.Count > 0)
            {
                Editar = true;
                txt_id.Enabled = true;
                txt_nombre.Text = dgv_datosP.CurrentRow.Cells["Nombre"].Value.ToString();
               
                txt_stock.Text = dgv_datosP.CurrentRow.Cells["Stock"].Value.ToString();
                txt_descripcion.Text = dgv_datosP.CurrentRow.Cells["Descripcion"].Value.ToString();
                


            }
            else
                MessageBox.Show("seleccione una fila por favor");

        }

        private void limpiarForm()
        {
            txt_nombre.Clear();
           
            txt_stock.Clear();
            txt_descripcion.Clear();
           

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_datosP.SelectedRows.Count > 0)
            {
                idProducto = dgv_datosP.CurrentRow.Cells["Id_Producto"].Value.ToString();
                objetoCN.EliminarPRod(idProducto);
                MessageBox.Show("Eliminado correctamente");
                MostrarProdctos();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btn_usuario_Click(object sender, EventArgs e)
        {
          
            Form Usuarios = new Usuarios();
            Usuarios.Show();
        
            //AbrirFF(new Usuarios());
            this.Close();

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Form Inicio = new Inicio();
            Inicio.Close();
            Close();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void AbrirFF(object Usuarios)
        {
            if (this.panelC.Controls.Count > 0)
                this.panelC.Controls.RemoveAt(0);
            Form fh= Usuarios as Form;
            fh.TopLevel=false;
            fh.Dock = DockStyle.Fill;
            this.panelC.Controls.Add(fh);
            this.panelC.Tag=fh;
            fh.Show();
        }




    }
}
