using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace FrbaOfertas
{
    class ConexionDB
    {
        private static string servidor = ConfigurationManager.AppSettings["servidor"].ToString();
        private static string usuario = ConfigurationManager.AppSettings["usuario"].ToString();
        private static string password = ConfigurationManager.AppSettings["password"].ToString();

        public static SqlConnection getConexion()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "SERVER=" + servidor + "\\SQLSERVER2012; DATABASE = GD2C2019;UID=" + usuario + ";PASSWORD=" + password + ";";
            return conexion;
        }

    }
}