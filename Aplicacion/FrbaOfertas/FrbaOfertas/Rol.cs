using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    class Rol
    {
        private int id;
        private string nombre;
        private HashSet<string> funciones = new HashSet<string>();

        //se llama cuando se carga la base de datos
        public Rol(int id_user)
        {
            //cargar desde base de datos
            var conexion = ConexionDB.getConexion();

            SqlCommand comando = new SqlCommand(@"SELECT R.id, R.nombre, F.descripcion 
                                                from SELECT_THISGROUP_FROM_APROBADOS.Rol R 
                                                join SELECT_THISGROUP_FROM_APROBADOS.Rol_Funcionalidad RF on RF.id_rol= R.id 
                                                join SELECT_THISGROUP_FROM_APROBADOS.Funcionalidad F on F.id = RF.id_func 
                                                join SELECT_THISGROUP_FROM_APROBADOS.Rol_Usuario RU on R.id = RU.id_rol
                                                join SELECT_THISGROUP_FROM_APROBADOS.Usuario U on U.id = RU.id_usuario
                                                where U.id = " + id_user, conexion);

            conexion.Open();
        
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                reader.Read();

                id = (int)reader.GetSqlDecimal(reader.GetOrdinal("id"));
                nombre = reader["nombre"].ToString();
                String unaFunc = reader["descripcion"].ToString();
                funciones.Add(unaFunc);

                while (reader.Read())
                {
                    unaFunc = reader["descripcion"].ToString();

                    funciones.Add(unaFunc);
                }

                reader.Close();
            }

            conexion.Close();
        }

        public Rol (int id_input, string nom, HashSet<string> func)
        {
            id = id_input;
            nombre = nom;
            funciones = func;
        }

        //Llamar este metodo cuando se crea un nuevo rol
        public void NuevoRol(string nom_input, HashSet<String> fun_input)
        {
            //generar nuevo id
            id = 0;
            nombre = nom_input;
        }

        public void ModRol(string nom_input, HashSet<String> fun_input)
        {
            nombre = nom_input;
        }

        public bool TieneFuncion(string funcion)
        {
            return funciones.Contains(funcion);
        }
    }
}
