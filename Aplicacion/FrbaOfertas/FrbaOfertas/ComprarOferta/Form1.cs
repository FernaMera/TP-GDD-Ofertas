using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaOfertas.ComprarOferta
{
    public partial class Form1 : Form
    {
        private int id_cliente = 0;
        private decimal saldo;
        private DateTime fechaCompra = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

        public Form1()
        {
            InitializeComponent();

            if (Usuario.usuario.esCliente())
            {
                id_cliente = Clases.Cliente.cliente.id;
                clienteBox.Hide();
                seleccionarClienteButton.Hide();
            }
            else
            {
                saldoLabel.Text = "";
            }

            ActualizarSaldo();

            MostrarOfertas();
        }

        private void MostrarOfertas()
        {
            string query = "Select * from [SELECT_THISGROUP_FROM_APROBADOS].ofertas_disponibles(@fecha)";
            
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            SqlConnection conexion = ConexionDB.getConexion();
            SqlCommand comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.Add("@fecha", SqlDbType.DateTime);
            comando.Parameters["@fecha"].Value = fechaCompra;

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

        private void ActualizarSaldo()
        {
            if(id_cliente != 0)
            {
                var conexion = ConexionDB.getConexion();

                SqlCommand comando = new SqlCommand(@"select C.saldo from SELECT_THISGROUP_FROM_APROBADOS.Cliente C 
                                                    where C.id = " + id_cliente, conexion);

                conexion.Open();
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    reader.Read();

                    saldoLabel.Text = "Saldo: " + reader.GetDecimal(reader.GetOrdinal("saldo"));
                    saldo = reader.GetDecimal(reader.GetOrdinal("saldo"));
                }
                
                conexion.Close();
            }
        }

        private void seleccionarClienteButton_Click(object sender, EventArgs e)
        {
            var buscarCliente = new Clases.Forms.BuscarCliente(clienteBox);
            buscarCliente.Show();
        }

        private void clienteBox_TextChanged(object sender, EventArgs e)
        {
            id_cliente = Convert.ToInt32(clienteBox.Text);
            ActualizarSaldo();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panelComprar.Show();
        }

        private void comprarButton_Click(object sender, EventArgs e)
        {
            if(clienteBox.Text.Equals(""))
            {
                MessageBox.Show("Seleccione un Cliente");
                return;
            }

            var conexion = ConexionDB.getConexion();

            SqlCommand comando = conexion.CreateCommand();
            comando.CommandText = "[SELECT_THISGROUP_FROM_APROBADOS].nueva_compra";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@id_cliente", SqlDbType.VarChar);
            comando.Parameters["@id_cliente"].Value = clienteBox.Text;
            comando.Parameters.Add("@id_oferta", SqlDbType.Int);
            comando.Parameters["@id_oferta"].Value = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            comando.Parameters.Add("@fecha", SqlDbType.DateTime);
            comando.Parameters["@fecha"].Value = fechaCompra;
            comando.Parameters.Add("@cantidad", SqlDbType.Decimal);
            comando.Parameters["@cantidad"].Value = cantidad.Value;
            comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
            comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

            conexion.Open();

            comando.ExecuteReader();

            int resultado = (int)comando.Parameters["@ReturnVal"].Value;

            switch (resultado)
            {
                case -1:
                    {
                        MessageBox.Show("Cantidad maxima por cliente superada");
                        break;
                    }
                case -2:
                case -4:
                    {
                        MessageBox.Show("Error al cargar datos", "Error");
                        break;
                    }
                case -3:
                    {
                        MessageBox.Show("Saldo insuficiente");
                        break;
                    }
                case -5:
                    {
                        MessageBox.Show("No puede comprar la misma oferta");
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Compra realizada con éxito");
                        break;
                    }
            }

            conexion.Close();
            ActualizarSaldo();
            MostrarOfertas();
        }
    }
}
