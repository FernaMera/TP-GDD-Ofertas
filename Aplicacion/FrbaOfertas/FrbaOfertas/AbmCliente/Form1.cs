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
    public partial class Form1 : Form, Funcionalidad
    {
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
        }
    }
}
