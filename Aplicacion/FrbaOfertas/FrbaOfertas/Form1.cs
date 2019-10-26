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

namespace FrbaOfertas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void iniciar_sesion_Click(object sender, EventArgs e)
        {
            if (this.contrasenia.Text.Length == 0 || this.usuario.Text.Length == 0)
            {
                MessageBox.Show("Se debe completar usuario y contraseña", "Login");
                this.usuario.Clear();
                this.contrasenia.Clear();
            }

            var conexion = ConexionDB.getConexion();

            SqlCommand comando = new SqlCommand("[SELECT_THISGROUP_FROM_APROBADOS].sp_validar_login", conexion);

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@username", SqlDbType.VarChar);
            comando.Parameters.Add("@password", SqlDbType.VarChar);
            comando.Parameters["@username"].Value = usuario.Text;
            comando.Parameters["@password"].Value = contrasenia.Text;
            comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
            comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            int retorno = (int)comando.Parameters["@ReturnVal"].Value;
            conexion.Close();

            MessageBox.Show(retorno.ToString(), "Resultado Login");

            if (retorno == -3)
            {
                MessageBox.Show("Usuario/Contraseña inexistente o incorrecto", "Resultado Login");
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this.Hide();
            var form = new CrearUsuario.Form1();
            //form.Closed += (s, args) => this.Show();
            form.Show();
        }
    }
}
