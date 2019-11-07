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

namespace FrbaOfertas.AbmCliente
{
    public partial class Form1 : Form
    {
        private int idCliente;
        private bool nonNumberEntered;
        private string where;

        public Form1()
        {
            InitializeComponent();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            where = " WHERE ";
            string condicion1 = "1=1";
            string condicion2 = "1=1";
            string condicion3 = "1=1";
            string condicion4 = "1=1";

            if (!string.IsNullOrEmpty(nombreBox.Text))
            {
                condicion1 = "nombre LIKE '%" + nombreBox.Text + "%'";
            }

            if (!string.IsNullOrEmpty(apellidoBox.Text))
            {
                condicion2 = "apellido LIKE '%" + apellidoBox.Text + "%'";
            }

            if (!string.IsNullOrEmpty(dniBox.Text))
            {
                condicion3 = "dni = " + dniBox.Text;
            }

            if (!string.IsNullOrEmpty(mailBox.Text))
            {
                condicion2 = "mail LIKE '%" + mailBox.Text + "%'";
            }

            where = where + condicion1 + " AND " + condicion2 + " AND " + condicion3 + " AND " + condicion4;

            BuscarClientes();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            nombreBox.Clear();
            apellidoBox.Clear();
            dniBox.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            modificarButton.Hide();
            habilitarButton.Hide();
            where = "";
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            var form = new AbmCliente.ClienteForm("Modificar", idCliente);
            form.Show();
        }

        private void nuevoClienteButton_Click(object sender, EventArgs e)
        {
            var form = new AbmCliente.ClienteForm("Nuevo", 0);
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            modificarButton.Show();
            habilitarButton.Show();

            var conexion = ConexionDB.getConexion();
            string nombre = dataGridView1.SelectedCells[0].Value.ToString();
            string apellido = dataGridView1.SelectedCells[1].Value.ToString();
            int dni = Convert.ToInt32(dataGridView1.SelectedCells[2].Value);

            SqlCommand idQuery = new SqlCommand(@"SELECT id FROM SELECT_THISGROUP_FROM_APROBADOS.Cliente C
                                                where C.nombre like '" + nombre + "' and C.apellido like '"
                                                + apellido + "' and C.dni = " + dni, conexion);

            conexion.Open();
            using (SqlDataReader reader = idQuery.ExecuteReader())
            {
                reader.Read();

                idCliente = (int)reader.GetDecimal(reader.GetOrdinal("id"));

                reader.Close();
            }
            conexion.Close();
        }

        private void dniBox_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;

            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void dniBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void habilitarButton_Click(object sender, EventArgs e)
        {
            int habilitar = 0;
            if(Convert.ToInt32(dataGridView1.SelectedCells[dataGridView1.Columns.Count - 1].Value) == 0)
            {
                //habilitar
                habilitar = 1;
            }

            if (habilitar == 0)
            {
                var confirmResult = MessageBox.Show("Esta seguro que desea Inhabilitar el Cliente?", "Precaucion",
                                MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.No)
                {
                    return;
                }
            }

            var conexion = ConexionDB.getConexion();
            SqlCommand command = new SqlCommand(@"Update SELECT_THISGROUP_FROM_APROBADOS.Cliente
                                                    set habilitado = " + habilitar + 
                                                    "where id = " + idCliente, conexion);

            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            conexion.Close();

            if(habilitar == 1)
                MessageBox.Show("Cliente fue Habilitado");
            else
                MessageBox.Show("Cliente fue Inhabilitado");

            BuscarClientes();
        }

        private void BuscarClientes()
        {
            string query = @"SELECT nombre, apellido, dni, telefono, mail, direccion, ciudad, cod_postal, fecha_nac, saldo, habilitado 
                            FROM [SELECT_THISGROUP_FROM_APROBADOS].[Cliente]" + where;

            ConexionDB.llenar_grilla(dataGridView1, query);
        }
    }
}
