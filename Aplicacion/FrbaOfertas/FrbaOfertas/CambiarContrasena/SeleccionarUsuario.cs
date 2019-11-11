using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CambiarContrasena
{
    public partial class SeleccionarUsuario : Form
    {
        private TextBox usuario;

        public SeleccionarUsuario(TextBox usuario_box)
        {
            InitializeComponent();

            usuario = usuario_box;

            MostrarUsuarios();
        }

        private void MostrarUsuarios()
        {
            string query = "SELECT username FROM [SELECT_THISGROUP_FROM_APROBADOS].Usuario";
            ConexionDB.llenar_grilla(dataGridView1, query);
            dataGridView1.Columns[0].Width = 274;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionar.Show();
        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
            int indice = dataGridView1.SelectedRows[0].Index + 1;
            usuario.Text = indice.ToString();
            Close();
        }
    }
}
