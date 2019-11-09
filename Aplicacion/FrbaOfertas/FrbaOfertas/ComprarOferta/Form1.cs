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

namespace FrbaOfertas.ComprarOferta
{
    public partial class Form1 : Form
    {
        private int id_cliente = 0;
        private decimal saldo;

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
            //
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
    }
}
