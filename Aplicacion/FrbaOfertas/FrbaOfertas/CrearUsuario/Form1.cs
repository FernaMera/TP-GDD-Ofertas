using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CrearUsuario
{
    public partial class Form1 : Form
    {
        private int id_rol;

        public Form1()
        {
            InitializeComponent();

            var conexion = ConexionDB.getConexion();
            SqlCommand rolQuery = new SqlCommand("SELECT nombre FROM SELECT_THISGROUP_FROM_APROBADOS.Rol", conexion);

            conexion.Open();
            using (SqlDataReader reader = rolQuery.ExecuteReader())
            {
                while (reader.Read())
                {
                    rolComboBox.Items.Add(reader["nombre"].ToString());
                }
                reader.Close();
            }
            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(usuarioBox.Text.Equals("") || contrasenaBox.Text.Equals("") || confirmacionBox.Text.Equals("") || rolComboBox.SelectedItem == null)
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            if (!contrasenaBox.Text.Equals(confirmacionBox.Text))
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return;
            }

            var conexion = ConexionDB.getConexion();

            SqlCommand comando = new SqlCommand(@"SELECT id From [SELECT_THISGROUP_FROM_APROBADOS].Usuario
                                                    where username like '" + usuarioBox.Text + "'", conexion);

            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();

            int idUser = 0;
            try
            {
                idUser = (int)reader.GetDecimal(reader.GetOrdinal("id"));
            }
            catch(Exception)
            {
                //no hay usuario con ese nombre
            }

            reader.Close();
            conexion.Close();

            comando = new SqlCommand(@"SELECT id From [SELECT_THISGROUP_FROM_APROBADOS].Rol
                                                 where nombre like '" + rolComboBox.SelectedItem.ToString() + "'", conexion);

            conexion.Open();
            reader = comando.ExecuteReader();
            reader.Read();

            id_rol = (int)reader.GetDecimal(reader.GetOrdinal("id"));

            reader.Close();
            conexion.Close();

            switch(id_rol)
            {
                case 1: //Administrador
                    {
                        break;
                    }
                case 2: //Cliente
                    {
                        Form nuevoCliente = new CrearUsuario.ClienteNuevoForm(usuarioBox.Text, contrasenaBox.Text, id_rol);
                        nuevoCliente.Show();
                        this.Close();

                        break;
                    }
                case 3: //Proveedor
                    {
                        break;
                    }
                default: //Rol creado
                    {
                        break;
                    }
            }
        }

        private void rolComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
