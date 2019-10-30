﻿using System;
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
            LimpiarFunciones();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarFunciones();
            nombreRolBox.Enabled = false;
            funcionesBox.Enabled = false;
            guardarButton.Hide();
            button2.Enabled = true;
            button3.Enabled = true;
            panelRol.Show();
            List<String> listaFunciones = new List<String>();

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

        private void LimpiarFunciones()
        {
            for (int i = 0; i < funcionesBox.Items.Count; i++)
            {
                funcionesBox.SetItemChecked(i, false);
            }
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            var conexion = ConexionDB.getConexion();

            SqlCommand comando = new SqlCommand("[SELECT_THISGROUP_FROM_APROBADOS].nuevo_rol", conexion);

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = nombreRolBox.Text;
            comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
            comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            int id_rol = (int)comando.Parameters["@ReturnVal"].Value;
            conexion.Close();

            if(id_rol < 0)
            {
                MessageBox.Show("Ya Existe un Rol con ese Nombre", "ERROR");
                return;
            }

            List<string> listaFunciones = new List<string>();
            listaFunciones = funcionesBox.CheckedItems.Cast<string>().ToList();
            comando = new SqlCommand("[SELECT_THISGROUP_FROM_APROBADOS].agregar_funcionalidad", conexion);

            foreach (string funcion in listaFunciones)
            {
                comando.Parameters.Add("@id_rol", SqlDbType.Int);
                comando.Parameters["@id_rol"].Value = id_rol;
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = funcion;

                conexion.Open();
                reader = comando.ExecuteReader();
                conexion.Close();
            }
        }
    }
}
