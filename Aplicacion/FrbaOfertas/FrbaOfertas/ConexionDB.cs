using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;
using FrbaOfertas.Clases;

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

        public static void llenar_grilla(DataGridView dataGridView, string consulta)
        {
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            SqlConnection conexion = ConexionDB.getConexion();
            try
            {
                dataAdapter = new SqlDataAdapter(consulta, conexion);
                dataTable = new DataTable();

                dataGridView.DataSource = dataTable;
                dataAdapter.Fill(dataTable);
                dataAdapter.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:\n" + e.Message);

            }
            conexion.Dispose();
            conexion.Close();
        }

        public static void cargar_comboRubro(ComboBox c)
        {
            SqlConnection conexion = ConexionDB.getConexion();
            string selectRubros = "SELECT id, descripcion FROM [SELECT_THISGROUP_FROM_APROBADOS].Rubro";
            conexion.Open();
            SqlCommand comando = new SqlCommand(selectRubros, conexion);
            SqlDataReader sqlReader = comando.ExecuteReader();
            c.DisplayMember = "descripcion";
            c.ValueMember = "id";

            List<Rubro> rubros = new List<Rubro>();
            rubros.Add(new Rubro(0, ""));

            while (sqlReader.Read())
            {
                rubros.Add(new Rubro(Convert.ToInt16(sqlReader["id"]), sqlReader["descripcion"].ToString()));
            }

            c.DataSource = rubros;

            sqlReader.Close();
            conexion.Close();
        }

    }
}