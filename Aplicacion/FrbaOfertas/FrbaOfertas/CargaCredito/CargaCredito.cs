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

namespace FrbaOfertas.CargaCredito
{
    public partial class CargaCredito : Form
    {
        private DateTime fechaCarga = Convert.ToDateTime(Configuracion.Default.Fecha_Sistema);

        public CargaCredito()
        {
            InitializeComponent();
            if(Usuario.usuario.esCliente())
            {
                clienteBox.Text = Usuario.usuario.GetClienteId().ToString();
                clienteBox.Hide();
                button2.Hide();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem.ToString())
            {
                case "Tarj. Credito":
                case "Tarj. Debito":
                    {
                        panelTarjeta.Show();

                        break;
                    }
                case "Efectivo":
                    {
                        panelTarjeta.Hide();

                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var buscarCliente = new BuscarCliente(clienteBox);
            buscarCliente.Show();
        }
    }
}
