using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CargaCredito
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem.ToString())
            {
                case "Tarj. Credito":
                    {
                        panelCredito.Show();
                        panelDebito.Hide();
                        break;
                    }
                case "Tarj. Debito":
                    {
                        panelCredito.Hide();
                        panelDebito.Show();
                        break;
                    }
            }
        }
    }
}
