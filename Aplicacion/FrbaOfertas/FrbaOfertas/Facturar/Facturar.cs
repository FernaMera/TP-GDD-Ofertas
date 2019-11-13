using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Facturar
{
    public partial class Facturar : Form
    {
        public Facturar()
        {
            InitializeComponent();
        }

        private void btn_seleccionarProveedor_Click(object sender, EventArgs e)
        {
            using (CrearOferta.SeleccionarProveedor selProv = new CrearOferta.SeleccionarProveedor())
            {
                if (selProv.ShowDialog() == DialogResult.OK)
                    textBox_proveedor.Text = selProv.proveedorSeleccionado;
            }
        }
    }
}
