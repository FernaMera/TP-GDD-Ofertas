using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaOfertas.AbmRol
{
    public partial class Form1 : Form, Funcionalidad
    {
        public static Form1 ABMRol;

        public Form1()
        {
            ABMRol = this;
            InitializeComponent();

            var conexion = ConexionDB.getConexion();
            SqlCommand rolQuery = new SqlCommand("SELECT nombre FROM SELECT_THISGROUP_FROM_APROBADOS.Rol", conexion);

            conexion.Open();
            using (SqlDataReader reader = rolQuery.ExecuteReader())
            {
                while (reader.Read())
                {
                    listBox1.Items.Add(reader["nombre"].ToString());
                }
                reader.Close();
            }
            conexion.Close();
        }

        //nuevo ROL
        private void button1_Click(object sender, EventArgs e)
        {
            panelRol.Show();
            nombreRolBox.Enabled = true;
            nombreRolBox.Text = "";
            funcionesBox.Enabled = true;
            guardarButton.Show();
            foreach (int i in funcionesBox.CheckedIndices)
            {
                funcionesBox.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
            panelRol.Show();
            List<String> listaFunciones = new List<String>();

            //TODO: buscar en base de datos el rol seleccionado
            var conexion = ConexionDB.getConexion();
            SqlCommand rolQuery = new SqlCommand(@"select R.nombre, F.descripcion from SELECT_THISGROUP_FROM_APROBADOS.Rol R 
                                                  join SELECT_THISGROUP_FROM_APROBADOS.Rol_Funcionalidad RF on(R.id = RF.id_rol)
                                                  join SELECT_THISGROUP_FROM_APROBADOS.Funcionalidad F on(RF.id_func = F.id)
                                                  where R.nombre Like('" + listBox1.SelectedItem.ToString() + "')", conexion);

            conexion.Open();
            using (SqlDataReader reader = rolQuery.ExecuteReader())
            {
                while (reader.Read())
                {
                    nombreRolBox.Text = reader["nombre"].ToString();
                    String unaFunc = reader["descripcion"].ToString();

                    listaFunciones.Add(unaFunc);
                }
                reader.Close();
            }
            conexion.Close();

            foreach(string funcion in listaFunciones)
            {
                int index = funcionesBox.FindStringExact(funcion);
                if(index >= 0)
                {
                    funcionesBox.SetItemCheckState(index, CheckState.Checked);
                }
            }
        }
    }
}
