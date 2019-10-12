using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iniciarSesion_Click(object sender, EventArgs e)
        {
            EncriptadorClave encriptador = new EncriptadorClave();

            if(nombreUsuarioBox.Text.Equals(""))
            {
                MessageBox.Show("Ingrese Nombre de Usuario");
                return;
            }
            if (passwordBox.Text.Equals(""))
            {
                MessageBox.Show("Ingrese Contraseña");
                return;
            }

            //buscar usuario en base de datos

            //DEBUG ONLY
            MessageBox.Show(encriptador.Encriptar(passwordBox.Text));
            
            //comparar hashes

            this.Hide();
            var form = new ListadoFuncionalidades.Ofertas();
            form.Closed += (s, args) => this.Close();
            form.Show();
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
