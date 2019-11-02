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

namespace FrbaOfertas.CrearOferta
{
    public partial class CrearOferta : Form
    {

        public CrearOferta()
        {
            InitializeComponent();
            if (Usuario.usuario.esProveedor())
            {
                btn_seleccionarProveedor.Hide();
                textBox_proveedor.Text = Usuario.usuario.cuitUsuario();
            }
        }

        private void seleccionarProveedor_Click(object sender, EventArgs e)
        {
            
        }



    }
}


