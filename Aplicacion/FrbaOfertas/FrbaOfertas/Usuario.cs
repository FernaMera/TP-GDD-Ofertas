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

        internal bool esCliente()
        {
            return rol.nombre == "Cliente";
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

        public int GetUsuarioId()
        {
            return id;
        }

        public int GetClienteId()
        {
            var conexion = ConexionDB.getConexion();

            SqlCommand comando = new SqlCommand(@"select C.id from SELECT_THISGROUP_FROM_APROBADOS.Cliente C ,SELECT_THISGROUP_FROM_APROBADOS.Usuario U
                                                    where C.id_usuario = " + usuario.GetUsuarioId(), conexion);

            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();

            int id = (int)reader.GetDecimal(reader.GetOrdinal("id"));

            reader.Close();
            conexion.Close();
            return id;
        }
    }
}
