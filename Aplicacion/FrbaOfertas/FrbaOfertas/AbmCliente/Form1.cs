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

        public Form1()
        {
            InitializeComponent();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            string dni;
            if (dniBox.Text.Equals(""))
                dni = "null";
            else dni = dniBox.Text;

            var conexion = ConexionDB.getConexion();
            SqlCommand command = new SqlCommand(@"SELECT * FROM SELECT_THISGROUP_FROM_APROBADOS.buscar_cliente( 
                                                '" + nombreBox.Text + "', '" + apellidoBox.Text + "', " + dni + ")", conexion);

            //command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.Add("@nombre", SqlDbType.VarChar);
            //command.Parameters["@nombre"].Value = nombreBox.Text;

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(command);
            conexion.Open();

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;

            conexion.Close();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            nombreBox.Clear();
            apellidoBox.Clear();
            dniBox.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            modificarButton.Hide();
            eliminarButton.Hide();
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
            eliminarButton.Show();

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
    }
}
