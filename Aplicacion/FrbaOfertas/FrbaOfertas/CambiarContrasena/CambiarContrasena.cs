using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaOfertas.CambiarContraseña
{
    public partial class CambiarContrasena : Form
    {
        public CambiarContrasena()
        {
            InitializeComponent();

            if(!Usuario.usuario.esAdministradorGeneral())
            {
                cambiarContraUsuarioButton.Hide();
            }
        }

        private void cambiarContraButton_Click(object sender, EventArgs e)
        {
            panelContrasenas.Show();
            panelSeleccionUsuario.Hide();
            usuarioBox.Text = Usuario.usuario.GetUsuarioId().ToString();
            viejaPassBox.Text = "";
            nuevaPassBox.Text = "";
            repetidaPassBox.Text = "";
        }

        private void cambiarContraUsuarioButton_Click(object sender, EventArgs e)
        {
            panelContrasenas.Show();
            panelSeleccionUsuario.Show();
            usuarioBox.Text = "";
            viejaPassBox.Text = "";
            nuevaPassBox.Text = "";
            repetidaPassBox.Text = "";
        }

        private void seleccionUsuarioButton_Click(object sender, EventArgs e)
        {
            Form form = new FrbaOfertas.CambiarContrasena.SeleccionarUsuario(usuarioBox);
            form.Show();
        }

        private void guardarCambiosButton_Click(object sender, EventArgs e)
        {
            if(viejaPassBox.Text.Equals(""))
            {
                MessageBox.Show("Ingrese contraseña actual");
                return;
            }

            if(nuevaPassBox.Text.Equals(""))
            {
                MessageBox.Show("Ingrese contraseña nueva");
                return;
            }

            if(repetidaPassBox.Text.Equals(""))
            {
                MessageBox.Show("Ingrese la repeticion de la contraseña nueva");
                return;
            }

            if(!nuevaPassBox.Text.Equals(repetidaPassBox.Text))
            {
                MessageBox.Show("Las contraseñas nuevas no coinciden");
                return;
            }

            var conexion = ConexionDB.getConexion();

            SqlCommand comando = conexion.CreateCommand();
            comando.CommandText = "[SELECT_THISGROUP_FROM_APROBADOS].cambiar_contrasena";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@id_usuario", SqlDbType.VarChar);
            comando.Parameters["@id_usuario"].Value = usuarioBox.Text;
            comando.Parameters.Add("@vieja_pass", SqlDbType.VarChar);
            comando.Parameters["@vieja_pass"].Value = viejaPassBox.Text;
            comando.Parameters.Add("@nueva_pass", SqlDbType.VarChar);
            comando.Parameters["@nueva_pass"].Value = nuevaPassBox.Text;
            comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
            comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

            conexion.Open();

            comando.ExecuteReader();

            int resultado = (int)comando.Parameters["@ReturnVal"].Value;

            if (resultado == -1)
                MessageBox.Show("Contraseña actual no es correcta");
            else
            {
                MessageBox.Show("Contraseña cambiada con éxito");
                viejaPassBox.Text = "";
                nuevaPassBox.Text = "";
                repetidaPassBox.Text = "";
            }

            conexion.Close();
        }
    }
}
