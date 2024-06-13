using Dato;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_usuario
    {

        private D_usuario objetoCD = new D_usuario();
        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarPRod(string Nombre, string Usuario, string Clave, bool Administrador)
        {
            objetoCD.Insertar(Nombre, Usuario, Clave, Administrador);
        }
        public void EditarProd(string Nombre, string Usuario, string Clave, int id_Usuario, bool Administrador)
        {
            objetoCD.Editar(Nombre, Usuario, Clave, id_Usuario, Administrador);
        }





        public void EliminarPRod(string id_Usuario)
        {
            objetoCD.Eliminar(Convert.ToInt32(id_Usuario));
        }


    }
}
