using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Usuarios : Form
    {

        N_usuario objetoCN = new N_usuario();
        private string idProducto = null;
        private bool Editar = false;

        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            MostrarProdctos();

        }

        private void MostrarProdctos()
        {
            N_usuario objeto = new N_usuario();
            dgv_usuari.DataSource = objeto.MostrarProd();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarPRod(txt_nombre.Text, txt_usuario.Text, txt_clave.Text, chkAdmin.Checked);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarProdctos();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por: " + ex.Message);
                }
            }
            // EDITAR
            if (Editar == true)
            {
                if (int.TryParse(txt_id.Text, out int idUsuario))
                {
                    try
                    {
                        objetoCN.EditarProd(txt_nombre.Text, txt_usuario.Text, txt_clave.Text, idUsuario, chkAdmin.Checked);
                        MessageBox.Show("Se editó correctamente");
                        MostrarProdctos();
                        limpiarForm();
                        Editar = false;
                        txt_id.Enabled = false;
                        txt_id.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo editar los datos por: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("El ID del usuario no es válido.");
                }
            }
        }


        private void btn_editar_Click(object sender, EventArgs e)
        {
           
            if (dgv_usuari.SelectedRows.Count > 0)
            {
                Editar = true;
                txt_id.Enabled = true;
                txt_id.Text = dgv_usuari.CurrentRow.Cells["id_Usuario"].Value.ToString();
                txt_nombre.Text = dgv_usuari.CurrentRow.Cells["Nombre"].Value.ToString();

                txt_usuario.Text = dgv_usuari.CurrentRow.Cells["Usuario"].Value.ToString();
                txt_clave.Text = dgv_usuari.CurrentRow.Cells["Clave"].Value.ToString();
              
                chkAdmin.Checked = Convert.ToBoolean(dgv_usuari.CurrentRow.Cells["Administrador"].Value);




            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void limpiarForm()
        {
            txt_nombre.Clear();

            txt_usuario.Clear();
            txt_clave.Clear();
            chkAdmin.Checked = false;

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_usuari.SelectedRows.Count > 0)
            {
                idProducto = dgv_usuari.CurrentRow.Cells["id_Usuario"].Value.ToString();
                objetoCN.EliminarPRod(idProducto);
                MessageBox.Show("Eliminado correctamente");
                MostrarProdctos();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
           this.Close();

            Form Inicio = new Inicio();
            Inicio.Show();

        }
    }
}
