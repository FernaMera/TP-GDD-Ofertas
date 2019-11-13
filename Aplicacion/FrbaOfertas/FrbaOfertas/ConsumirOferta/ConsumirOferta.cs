using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ConsumirOferta
{
    public partial class ConsumirOferta : Form
    {
        private DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

        public ConsumirOferta()
        {
            InitializeComponent();
            if(Usuario.usuario.esProveedor())
            {
                proveedorBox.Text = Usuario.usuario.cuitUsuario();
                seleccionarProButton.Hide();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Enabled = true;
        }

        private void MostrarCuponesDelProveedor()
        {
            string query = "Select * from [SELECT_THISGROUP_FROM_APROBADOS].cupones_proveedor(@cuit, @fecha)";

            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            SqlConnection conexion = ConexionDB.getConexion();
            SqlCommand comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.Add("@cuit", SqlDbType.VarChar);
            comando.Parameters["@cuit"].Value = proveedorBox.Text;
            comando.Parameters.Add("@fecha", SqlDbType.DateTime);
            comando.Parameters["@fecha"].Value = fecha;

            try
            {
                dataAdapter = new SqlDataAdapter(comando);
                dataTable = new DataTable();

                dataGridView1.DataSource = dataTable;
                dataAdapter.Fill(dataTable);
                dataAdapter.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:\n" + e.Message);

            }
            conexion.Dispose();
            conexion.Close();
        }

        private void proveedorBox_TextChanged(object sender, EventArgs e)
        {
            MostrarCuponesDelProveedor();
        }

        private void seleccionarProButton_Click(object sender, EventArgs e)
        {
            using (CrearOferta.SeleccionarProveedor selProv = new CrearOferta.SeleccionarProveedor())
            {
                if (selProv.ShowDialog() == DialogResult.OK)
                    proveedorBox.Text = selProv.proveedorSeleccionado;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var clienteBusqueda = new Clases.Forms.BuscarCliente(clienteBox);
            clienteBusqueda.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (clienteBox.Text.Equals(""))
            {
                MessageBox.Show("Seleccione un Cliente");
                return;
            }

            var conexion = ConexionDB.getConexion();

            SqlCommand comando = conexion.CreateCommand();
            comando.CommandText = "[SELECT_THISGROUP_FROM_APROBADOS].consumir_oferta";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@id_cliente", SqlDbType.VarChar);
            comando.Parameters["@id_cliente"].Value = clienteBox.Text;
            comando.Parameters.Add("@cod_cupon", SqlDbType.Int);
            comando.Parameters["@cod_cupon"].Value = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            comando.Parameters.Add("@fecha_sistema", SqlDbType.DateTime);
            comando.Parameters["@fecha_sistema"].Value = fecha;
            comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
            comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

            conexion.Open();

            comando.ExecuteReader();

            int resultado = (int)comando.Parameters["@ReturnVal"].Value;

            switch (resultado)
            {
                case -1:
                    {
                        MessageBox.Show("Error al insertar en base de datos");
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Cupon consumido con éxito");
                        break;
                    }
            }

            conexion.Close();
            MostrarCuponesDelProveedor();
            button3.Enabled = false;
        }
    }
}
