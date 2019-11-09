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

namespace FrbaOfertas.Clases.Forms
{
    public partial class BuscarCliente : Form
    {
        private int idCliente;
        private TextBox clienteBox;
        private bool nonNumberEntered;
        private string where;

        public BuscarCliente(TextBox cliente)
        {
            InitializeComponent();

            clienteBox = cliente;
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            where = " WHERE habilitado = 1 AND ";
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
            where = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarButton.Enabled = true;

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

        private void BuscarClientes()
        {
            string query = @"SELECT nombre, apellido, dni, telefono, mail, direccion, ciudad, cod_postal, fecha_nac, saldo 
                            FROM [SELECT_THISGROUP_FROM_APROBADOS].[Cliente]" + where;

            ConexionDB.llenar_grilla(dataGridView1, query);
        }

        private void seleccionarButton_Click(object sender, EventArgs e)
        {
            clienteBox.Text = idCliente.ToString();
            Close();
        }
    }
}
