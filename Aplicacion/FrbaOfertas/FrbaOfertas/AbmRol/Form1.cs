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
    public partial class Form1 : Form
    {
        public static Form1 ABMRol;
        private int idRol;
        private string nombreRol;
        private List<string> funciones;

        public Form1()
        {
            ABMRol = this;
            InitializeComponent();

            ActualizarListaRoles();
        }

        private void ActualizarListaRoles()
        {
            listBox1.Items.Clear();

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
            guardarModButton.Hide();
            inhabilitarButton.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            estadoRolLabel.Text = "Si";
            //listBox1.SetSelected(listBox1.SelectedIndex, false);
            LimpiarFunciones();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarFunciones();
            nombreRolBox.Enabled = false;
            funcionesBox.Enabled = false;
            guardarButton.Hide();
            guardarModButton.Hide();
            button2.Enabled = true;
            button3.Enabled = true;
            inhabilitarButton.Enabled = true;
            panelRol.Show();

            ActualizarDatos();
        }

        private void ActualizarDatos()
        {
            List<String> listaFunciones = new List<String>();

            var conexion = ConexionDB.getConexion();
            SqlCommand rolQuery = new SqlCommand(@"select R.id, R.nombre, R.habilitado, F.descripcion from SELECT_THISGROUP_FROM_APROBADOS.Rol R 
                                                  left join SELECT_THISGROUP_FROM_APROBADOS.Rol_Funcionalidad RF on(R.id = RF.id_rol)
                                                  left join SELECT_THISGROUP_FROM_APROBADOS.Funcionalidad F on(RF.id_func = F.id)
                                                  where R.nombre Like('" + listBox1.SelectedItem.ToString() + "')", conexion);

            conexion.Open();
            using (SqlDataReader reader = rolQuery.ExecuteReader())
            {
                reader.Read();

                idRol = (int)reader.GetDecimal(reader.GetOrdinal("id"));
                nombreRolBox.Text = reader["nombre"].ToString();

                if (reader.GetBoolean(reader.GetOrdinal("habilitado")))
                {
                    estadoRolLabel.Text = "Si";
                }
                else
                {
                    estadoRolLabel.Text = "No";
                }

                String unaFunc = reader["descripcion"].ToString();

                listaFunciones.Add(unaFunc);

                while (reader.Read())
                {
                    unaFunc = reader["descripcion"].ToString();

                    listaFunciones.Add(unaFunc);
                }

                reader.Close();
            }
            conexion.Close();

            foreach (string funcion in listaFunciones)
            {
                int index = funcionesBox.FindStringExact(funcion);
                if (index >= 0)
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

        //guardar nuevo rol
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

            switch (id_rol)
            {
                case -1:
                    {
                        MessageBox.Show("Ya Existe un Rol con ese Nombre", "ERROR");
                        return;
                    }
                case -2:
                    {
                        MessageBox.Show("No se pudo crear el Rol", "ERROR");
                        return;
                    }
                default:
                    {
                        //se creo el rol correctamente
                        break;
                    }
            }

            List<string> listaFunciones = new List<string>();
            listaFunciones = funcionesBox.CheckedItems.Cast<string>().ToList();
            comando = new SqlCommand("[SELECT_THISGROUP_FROM_APROBADOS].agregar_funcionalidad", conexion);

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@id_rol", SqlDbType.Int);
            comando.Parameters["@id_rol"].Value = id_rol;
            comando.Parameters.Add("@descripcion", SqlDbType.VarChar);

            foreach (string funcion in listaFunciones)
            {
                comando.Parameters["@descripcion"].Value = funcion;

                conexion.Open();
                reader = comando.ExecuteReader();
                conexion.Close();
            }

            MessageBox.Show("Rol creado con éxito","");
            ActualizarListaRoles();
        }

        //Modificar Rol
        private void button2_Click(object sender, EventArgs e)
        {
            guardarModButton.Show();
            inhabilitarButton.Enabled = false;
            nombreRolBox.Enabled = true;
            funcionesBox.Enabled = true;

            nombreRol = nombreRolBox.Text;

            funciones = new List<string>();
            funciones = funcionesBox.CheckedItems.Cast<string>().ToList();
        }

        private void guardarModButton_Click(object sender, EventArgs e)
        {
            var conexion = ConexionDB.getConexion();

            SqlCommand comando = new SqlCommand("[SELECT_THISGROUP_FROM_APROBADOS].mod_rol", conexion);

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@nombre_actual", SqlDbType.VarChar);
            comando.Parameters["@nombre_actual"].Value = nombreRol;
            comando.Parameters.Add("@nombre_nuevo", SqlDbType.VarChar);
            comando.Parameters["@nombre_nuevo"].Value = nombreRolBox.Text;
            comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
            comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            int id_rol = (int)comando.Parameters["@ReturnVal"].Value;
            conexion.Close();

            List<string> nuevaListaFunciones = new List<string>();
            nuevaListaFunciones = funcionesBox.CheckedItems.Cast<string>().ToList();

            //agregar funciones
            foreach(string funcion in nuevaListaFunciones)
            {
                if(!funciones.Contains(funcion))
                {
                    comando = new SqlCommand("[SELECT_THISGROUP_FROM_APROBADOS].agregar_funcionalidad", conexion);

                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add("@id_rol", SqlDbType.Int);
                    comando.Parameters["@id_rol"].Value = id_rol;
                    comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                    comando.Parameters["@descripcion"].Value = funcion;

                    conexion.Open();
                    reader = comando.ExecuteReader();
                    conexion.Close();
                }
            }

            //quitar funciones
            foreach(string funcion in funciones)
            {
                if(!nuevaListaFunciones.Contains(funcion))
                {
                    comando = new SqlCommand("[SELECT_THISGROUP_FROM_APROBADOS].quitar_funcionalidad", conexion);

                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add("@id_rol", SqlDbType.Int);
                    comando.Parameters["@id_rol"].Value = id_rol;
                    comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                    comando.Parameters["@descripcion"].Value = funcion;

                    conexion.Open();
                    reader = comando.ExecuteReader();
                    conexion.Close();
                }
            }

            //TODO: manejo de errores
            MessageBox.Show("Cambios guardados con éxito", "");
        }

        //Eliminar ROL
        private void button3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Esta seguro que desea eliminar el Rol: "+ listBox1.SelectedItem.ToString() + "?", "Precaucion",
                                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                //Eliminar en Rol_Funcionalidad
                var conexion = ConexionDB.getConexion();

                SqlCommand comando = new SqlCommand(@"DELETE FROM [SELECT_THISGROUP_FROM_APROBADOS].Rol_Funcionalidad WHERE
                                                    id_rol = " + idRol, conexion);

                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                conexion.Close();

                //Eliminar en Rol
                conexion = ConexionDB.getConexion();

                comando = new SqlCommand(@"DELETE FROM [SELECT_THISGROUP_FROM_APROBADOS].Rol WHERE
                                                    id = " + idRol, conexion);

                conexion.Open();
                reader = comando.ExecuteReader();
                conexion.Close();

                ActualizarListaRoles();
            }
        }

        //Habilitar/Inhabilitar Rol
        private void inhabilitarButton_Click(object sender, EventArgs e)
        {
            var conexion = ConexionDB.getConexion();

            SqlCommand comando = new SqlCommand("[SELECT_THISGROUP_FROM_APROBADOS].habilitar_rol", conexion);

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@id_rol", SqlDbType.Decimal);
            comando.Parameters["@id_rol"].Value = idRol;
            comando.Parameters.Add("@estado_nuevo", SqlDbType.Bit);
            if(estadoRolLabel.Text.Equals("Si"))
            {
                //inhabilitar
                comando.Parameters["@estado_nuevo"].Value = 0;
            }
            else
            {
                //habilitar
                comando.Parameters["@estado_nuevo"].Value = 1;
            }
            
            comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
            comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
            int resultado = (int)comando.Parameters["@ReturnVal"].Value;
            if (resultado < 0)
                MessageBox.Show("Error al habilitar o inhabilitar rol", "ERROR");
            else
                ActualizarDatos();

            conexion.Close();
        }
    }
}
