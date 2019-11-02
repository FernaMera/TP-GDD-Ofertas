using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace FrbaOfertas
{
    public class Usuario
    {
        private int id;
        private Rol rol;
        public static readonly Usuario usuario = new Usuario();

        private Usuario()
        {

        }

        public void crear_usuario(int id_input)
        {
            id = id_input;
            rol = new Rol(id_input);
        }

        public bool TieneFuncion(string unaFunc)
        {
            return rol.TieneFuncion(unaFunc);
        }

        public bool esProveedor()
        {
            return rol.nombre == "Proveedor";
        }

        public string cuitUsuario()
        {
            var conexion = ConexionDB.getConexion();
            string query = "SELECT cuit FROM [SELECT_THISGROUP_FROM_APROBADOS].[Proveedor] WHERE id_usuario = " + usuario.id;
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader reg = comando.ExecuteReader();
            reg.Read();
            return reg["cuit"].ToString();
        }



    }
}
