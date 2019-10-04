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

            //DEBUG ONLY
            MessageBox.Show(encriptador.Encriptar(passwordBox.Text));

            //buscar usuario en base de datos
            //comparar hashes

            //si el login es correcto, esconder ventana y abrir nueva
            /*WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;*/

            this.Hide();
            var form = new ListadoFuncionalidades.Ofertas();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
