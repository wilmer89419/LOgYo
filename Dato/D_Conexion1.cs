using System;
using System.Data;
using System.Data.SqlClient;

namespace Dato
{
    public class D_Conexion
    {
       //conexion 
            private SqlConnection Conexion = new SqlConnection("Server=WILMER;DataBase= Logn;Integrated Security=true");


            public SqlConnection AbrirConexion()
            {
                if (Conexion.State == ConnectionState.Closed)
                    Conexion.Open();
                return Conexion;
            }



            public SqlConnection CerrarConexion()
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
                return Conexion;
            }
        
    }
}