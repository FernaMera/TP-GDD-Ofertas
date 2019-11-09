using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Clases
{
    public class Cliente
    {
        public int id { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public static readonly Cliente cliente = new Cliente();

        public Cliente()
        {
        }

        public void Crear_Cliente(int id_usuario)
        {
            var conexion = ConexionDB.getConexion();

            SqlCommand comando = new SqlCommand(@"select C.id, C.nombre, C.apellido, C.dni from SELECT_THISGROUP_FROM_APROBADOS.Cliente C 
                                                    where C.id_usuario = " + Usuario.usuario.GetUsuarioId(), conexion);

            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();

            id = (int)reader.GetDecimal(reader.GetOrdinal("id"));
            nombre = reader["nombre"].ToString();
            apellido = reader["apellido"].ToString();
            dni = (int)reader.GetDecimal(reader.GetOrdinal("dni"));

            reader.Close();
            conexion.Close();
        }
    }
}
