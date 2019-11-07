using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaOfertas;

namespace FrbaOfertas.CrearOferta
{
    public partial class CrearOferta : Form
    {

        public CrearOferta()
        {
            InitializeComponent();
            if (Usuario.usuario.esProveedor())
            {
                btn_seleccionarProveedor.Hide();
                textBox_proveedor.Text = Usuario.usuario.cuitUsuario();
            }
            dateTimePicker_publi.MinDate = DateTime.Today;
            dateTimePicker_venc.MinDate = DateTime.Today.AddDays(1);
        }

        private void seleccionarProveedor_Click(object sender, EventArgs e)
        {
            using (SeleccionarProveedor selProv = new SeleccionarProveedor())
            {
                if (selProv.ShowDialog() == DialogResult.OK)
                    textBox_proveedor.Text = selProv.proveedorSeleccionado;
            }

        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            numericUpDown_cantDisp.Value = numericUpDown_cantDisp.Minimum;
            numericUpDown_cantMax.Value = numericUpDown_cantMax.Minimum;
            numericUpDown_precioLista.Value = numericUpDown_precioLista.Minimum;
            numericUpDown_precioOferta.Value = numericUpDown_precioOferta.Minimum;
            dateTimePicker_publi.Value = DateTime.Today;
            dateTimePicker_venc.Value = DateTime.Today.AddDays(1);

            if (!Usuario.usuario.esProveedor())
                textBox_proveedor.Clear();
        }

        private void btn_crearOferta_Click(object sender, EventArgs e)
        {
            List<string> errores = new List<string>();

            if (numericUpDown_precioOferta.Value >= numericUpDown_precioLista.Value)
            {
                errores.Add("El precio de oferta es mayor que el precio de lista");
            }

            if (numericUpDown_cantMax.Value > numericUpDown_cantDisp.Value)
            {
                errores.Add("La cantidad total ofrecida es menor que la cantidad ofrecida por cliente");
            }

            if (dateTimePicker_publi.Value > dateTimePicker_venc.Value)
            {
                errores.Add("La fecha de publicación no puede ser después de la fecha de vencimiento");
            }


            Util.mostrarListaErrores(errores, "Creación de Oferta");

        }



    }
}


