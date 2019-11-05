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

            if (idUser > 0)
            {
                MessageBox.Show("Nombre de usuario ya existe");
                reader.Close();
                conexion.Close();
                return;
            }

            reader.Close();

            comando = new SqlCommand(@"SELECT id, nombre From [SELECT_THISGROUP_FROM_APROBADOS].Rol
                                                 where nombre like '" + rolComboBox.SelectedItem.ToString() + "'", conexion);
            
            reader = comando.ExecuteReader();
            reader.Read();

            id_rol = (int)reader.GetDecimal(reader.GetOrdinal("id"));
            string nombre = reader["nombre"].ToString();

            reader.Close();

            switch(nombre)
            {
                case "Cliente": //Cliente
                    {
                        Form nuevoCliente = new CrearUsuario.ClienteNuevoForm(usuarioBox.Text, contrasenaBox.Text, id_rol);
                        nuevoCliente.Show();
                        this.Close();

                        break;
                    }
                case "Proveedor": //Proveedor
                    {
                        Form nuevoProveedor = new CrearUsuario.ProveedorNuevoForm(usuarioBox.Text, contrasenaBox.Text, id_rol);
                        nuevoProveedor.Show();
                        this.Close();

                        break;
                    }
                default: //Administrador o Rol creado
                    {
                        //nuevo usuario
                        comando = new SqlCommand("[SELECT_THISGROUP_FROM_APROBADOS].nuevo_usuario", conexion);

                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.Add("@username", SqlDbType.VarChar);
                        comando.Parameters["@username"].Value = usuarioBox.Text;
                        comando.Parameters.Add("@password", SqlDbType.VarChar);
                        comando.Parameters["@password"].Value = contrasenaBox.Text;
                        comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

                        //conexion.Open();
                        reader = comando.ExecuteReader();
                        int id_usuario = (int)comando.Parameters["@ReturnVal"].Value;
                        reader.Close();
                        if (id_usuario < 0)
                        {
                            MessageBox.Show("Error");
                            conexion.Close();
                            this.Close();
                        }

                        //asociar usuario con su rol
                        comando = new SqlCommand(@"[SELECT_THISGROUP_FROM_APROBADOS].nuevo_rol_usuario", conexion);

                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.Add("@id_user", SqlDbType.VarChar);
                        comando.Parameters["@id_user"].Value = id_usuario;
                        comando.Parameters.Add("@id_rol", SqlDbType.VarChar);
                        comando.Parameters["@id_rol"].Value = id_rol;
                        comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

                        reader = comando.ExecuteReader();
                        conexion.Close();

                        int resultado = (int)comando.Parameters["@ReturnVal"].Value;
                        if (resultado == 0)
                            MessageBox.Show("Usuario creado con éxito", "Nuevo Usuario");
                        else
                            MessageBox.Show("Error al cargar Datos");
                        this.Close();
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
