using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaOfertas.CargaCredito
{
    public partial class CargaCredito : Form
    {
        private DateTime fechaCarga = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);
        private bool nonNumberEntered;
        private enum TipoPago
        {   //ordenados segun aparecen en la base de datos
            Ninguno,
            Debito,
            Credito,
            Efectivo
        }
        private TipoPago tipoPago = TipoPago.Ninguno;

        public CargaCredito()
        {
            InitializeComponent();
            if(Usuario.usuario.esCliente())
            {
                clienteBox.Text = Clases.Cliente.cliente.id.ToString();
                clienteBox.Hide();
                clienteLabel.Hide();
                button2.Hide();
            }

            fechaVencimientoPicker.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(tipoPagoBox.SelectedItem.ToString())
            {
                case "Tarj. Credito":
                    {
                        panelTarjeta.Show();
                        tipoPago = TipoPago.Credito;

                        break;
                    }
                case "Tarj. Debito":
                    {
                        panelTarjeta.Show();
                        tipoPago = TipoPago.Debito;

                        break;
                    }
                case "Efectivo":
                    {
                        panelTarjeta.Hide();
                        tipoPago = TipoPago.Efectivo;

                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var buscarCliente = new Clases.Forms.BuscarCliente(clienteBox);
            buscarCliente.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tipoPago == TipoPago.Ninguno)
            {
                MessageBox.Show("Seleccione un metodo de pago");
                return;
            }

            if (montoBox.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el monto a cargar");
                return;
            }
            else if(!Util.esDecimalValido(montoBox.Text))
            {
                MessageBox.Show("Incorrecto formato de monto a cargar");
                return;
            }

            switch (tipoPagoBox.SelectedItem.ToString())
            {
                case "Efectivo":
                    {
                        CargarCreditoEfectivo();

                        break;
                    }
                default:
                    {
                        if (numeroBox.Text.Equals(""))
                        {
                            MessageBox.Show("Ingrese numero de la tarjeta");
                            return;
                        }

                        if (codigoBox.Text.Equals(""))
                        {
                            MessageBox.Show("Ingrese codigo de seguridad de la tarjeta");
                            return;
                        }

                        if (titularBox.Text.Equals(""))
                        {
                            MessageBox.Show("Ingrese nombre de titular de la tarjeta");
                            return;
                        }

                        if(fechaVencimientoPicker.Value > fechaCarga)
                        {
                            MessageBox.Show("La tarjeta está vencida");
                            return;
                        }

                        CargarCredito();

                        break;
                    }
            }
        }

        private void CargarCreditoEfectivo()
        {
            var conexion = ConexionDB.getConexion();

            SqlCommand comando = conexion.CreateCommand();
            comando.CommandText = "[SELECT_THISGROUP_FROM_APROBADOS].nueva_carga_efectivo";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@id_cliente", SqlDbType.VarChar);
            comando.Parameters["@id_cliente"].Value = clienteBox.Text;
            comando.Parameters.Add("@monto", SqlDbType.Decimal);
            comando.Parameters["@monto"].Value = Convert.ToDecimal(montoBox.Text);
            comando.Parameters.Add("@fecha", SqlDbType.DateTime);
            comando.Parameters["@fecha"].Value = fechaCarga;
            comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
            comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

            conexion.Open();

            comando.ExecuteReader();

            int resultado = (int)comando.Parameters["@ReturnVal"].Value;

            switch (resultado)
            {
                case -1:
                case -2:
                    {
                        MessageBox.Show("Error al cargar datos", "Error");
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Carga realizada con éxito");
                        MessageBox.Show("Si no realiza el pago en una semana se le descontara del saldo", "Precaucion");
                        break;
                    }
            }

            conexion.Close();
        }

        private void CargarCredito()
        {
            var conexion = ConexionDB.getConexion();

            SqlCommand comando = conexion.CreateCommand();
            comando.CommandText = "[SELECT_THISGROUP_FROM_APROBADOS].nueva_carga_tarjeta";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@id_cliente", SqlDbType.VarChar);
            comando.Parameters["@id_cliente"].Value = clienteBox.Text;
            comando.Parameters.Add("@nombre_titular", SqlDbType.VarChar);
            comando.Parameters["@nombre_titular"].Value = titularBox.Text;
            comando.Parameters.Add("@numero_tarjeta", SqlDbType.VarChar);
            comando.Parameters["@numero_tarjeta"].Value = numeroBox.Text;
            comando.Parameters.Add("@monto", SqlDbType.Decimal);
            comando.Parameters["@monto"].Value = Convert.ToDecimal(montoBox.Text);
            comando.Parameters.Add("@tipo_pago", SqlDbType.SmallInt);
            comando.Parameters["@tipo_pago"].Value = tipoPago;
            comando.Parameters.Add("@fecha", SqlDbType.DateTime);
            comando.Parameters["@fecha"].Value = fechaCarga;
            comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
            comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

            conexion.Open();

            comando.ExecuteReader();

            int resultado = (int)comando.Parameters["@ReturnVal"].Value;

            switch(resultado)
            {
                case -1:
                case -2:
                case -3:
                    {
                        MessageBox.Show("Error al cargar datos", "Error");
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Carga realizada con éxito");
                        break;
                    }
            }

            conexion.Close();
        }

        private void numeroBox_KeyDown(object sender, KeyEventArgs e)
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

        private void numeroBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void montoBox_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;

            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }
    }
}
