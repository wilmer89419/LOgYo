using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static Dato.D_Conexion;


namespace Dato
{
    public class D_producto
    {

        private D_Conexion conexion = new D_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SeleccionP";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string Nombre,  int Stock, string Descripcion)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarP";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Stock", Stock);
            comando.Parameters.AddWithValue("@descripcion", Descripcion);
            


            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }

        public void Editar(string Nombre, int Stock, string Descripcion, int Id_Producto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "pa_actualizar_producto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Stock", Stock);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);

            comando.Parameters.AddWithValue("@Id_producto", Id_Producto);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void Eliminar(int Id_Producto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarP";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id_producto", Id_Producto);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

    }
}
