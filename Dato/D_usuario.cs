using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dato.D_Conexion;

namespace Dato
{
    public class D_usuario
    {

        private D_Conexion conexion = new D_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SeleccionU";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string Nombre, string Usuario, string Clave, bool Administrador)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarU";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Usuario", Usuario);
            comando.Parameters.AddWithValue("@Clave", Clave);
            comando.Parameters.AddWithValue("@Administrador", Administrador);


            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }

        public void Editar(string Nombre, string Usuario, string Clave, int id_Usuario, bool Administrador)
        {
           
           

            // Convertir el valor booleano de Administrador a entero (0 o 1)
            int adminValue = Administrador ? 1 : 0;

            // Abrir la conexión
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarU";
            comando.CommandType = CommandType.StoredProcedure;

            // Agregar los parámetros al comando
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Usuario", Usuario);
            comando.Parameters.AddWithValue("@Clave", Clave);
            comando.Parameters.AddWithValue("@id_Usuario", id_Usuario);
            comando.Parameters.AddWithValue("@Administrador", adminValue);

            // Ejecutar el comando
            comando.ExecuteNonQuery();

            // Limpiar los parámetros y cerrar la conexión
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }


        public void Eliminar(int id_Usuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarU";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_Usuario", id_Usuario);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

    }
}
