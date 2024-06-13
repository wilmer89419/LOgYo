using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dato;
using System.Data.SqlClient;

namespace Negocio
{
    public class N_producto
    {

        private D_producto objetoCD = new D_producto();

        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarPRod(string Nombre, string Stock,string Descripcion)
        {
            objetoCD.Insertar(Nombre, Convert.ToInt32(Stock), Descripcion);
        }
        public void EditarProd(string Nombre,  string Stock, string Descripcion, string Id_Producto)
        {
            objetoCD.Editar(Nombre, Convert.ToInt32(Stock), Descripcion, Convert.ToInt32(Id_Producto));
        }
        public void EliminarPRod(string Id_Producto)
        {
            objetoCD.Eliminar(Convert.ToInt32(Id_Producto));
        }

    }
}
