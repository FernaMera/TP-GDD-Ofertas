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
using System.Configuration;

namespace FrbaOfertas.CrearOferta
{
    public partial class CrearOferta : Form
    {
        DateTime fechaConfig = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

        public CrearOferta()
        {
            InitializeComponent();
            if (Usuario.usuario.esProveedor())
            {
                btn_seleccionarProveedor.Hide();
                textBox_proveedor.Text = Usuario.usuario.cuitUsuario();
            }


            dateTimePicker_publi.Value = fechaConfig;
            dateTimePicker_venc.Value = fechaConfig.AddDays(1);
            dateTimePicker_publi.MinDate = fechaConfig;
            dateTimePicker_venc.MinDate = fechaConfig.AddDays(1);
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
            dateTimePicker_publi.Value = fechaConfig;
            dateTimePicker_venc.Value = fechaConfig.AddDays(1);
            richTextBox_descripcion.Clear();

            if (!Usuario.usuario.esProveedor())
                textBox_proveedor.Clear();
        }

        private void btn_crearOferta_Click(object sender, EventArgs e)
        {
            List<string> errores = new List<string>();

            if(string.IsNullOrEmpty(textBox_proveedor.Text) || string.IsNullOrEmpty(richTextBox_descripcion.Text))
                errores.Add("Todos los campos deben estar completos");

            if (numericUpDown_precioOferta.Value >= numericUpDown_precioLista.Value)
                errores.Add("El precio de oferta es mayor o igual que el precio de lista");

            if (numericUpDown_cantMax.Value > numericUpDown_cantDisp.Value)
                errores.Add("La cantidad total ofrecida es menor que la cantidad ofrecida por cliente");

            if (dateTimePicker_publi.Value > dateTimePicker_venc.Value)
                errores.Add("La fecha de publicación no puede ser después de la fecha de vencimiento");

            if (errores.Count == 0)
            {
                string nuevaOferta = "INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Oferta (cuit_prov, descripcion, fec_public, fec_venc, precio_oferta, precio_lista, cantidad_disponible, max_por_cliente) VALUES (@cuitProv, @desc, @fecPub, @fecVenc, @precioOf, @precioLista, @cantDisp, @cantMaxCliente)";

                SqlConnection conexion = ConexionDB.getConexion();
                SqlCommand comando = new SqlCommand(nuevaOferta, conexion);

                comando.Parameters.Add("@cuitProv", SqlDbType.Char);
                comando.Parameters["@cuitProv"].Value = textBox_proveedor.Text;

                comando.Parameters.Add("@desc", SqlDbType.VarChar);
                comando.Parameters["@desc"].Value = richTextBox_descripcion.Text;

                comando.Parameters.Add("@fecPub", SqlDbType.DateTime);
                comando.Parameters["@fecPub"].Value = dateTimePicker_publi.Value;

                comando.Parameters.Add("@fecVenc", SqlDbType.DateTime);
                comando.Parameters["@fecVenc"].Value = dateTimePicker_venc.Value;

                comando.Parameters.Add("@precioOf", SqlDbType.Decimal);
                comando.Parameters["@precioOf"].Value = numericUpDown_precioOferta.Value;

                comando.Parameters.Add("@precioLista", SqlDbType.Decimal);
                comando.Parameters["@precioLista"].Value = numericUpDown_precioLista.Value;

                comando.Parameters.Add("@cantDisp", SqlDbType.Int);
                comando.Parameters["@cantDisp"].Value = numericUpDown_cantDisp.Value;

                comando.Parameters.Add("@cantMaxCliente", SqlDbType.Int);
                comando.Parameters["@cantMaxCliente"].Value = numericUpDown_cantMax.Value;
                conexion.Open();
               
                try
                {
                    if (comando.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Oferta creada con éxito!");
                        conexion.Close();
                        this.Close();
                    }
                }
                catch (SqlException exc)
                {
                        MessageBox.Show("No se pudo realizar el alta: " + exc.Message);
                        conexion.Close();
                }
            }
            else
            {
                Util.mostrarListaErrores(errores, "Creación de Oferta");
            }

        }

        private void dateTimePicker_venc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label_fechaPubli_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_publi_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label_fechaVenc_Click(object sender, EventArgs e)
        {

        }

        private void textBox_proveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_proveedor_Click(object sender, EventArgs e)
        {

        }

    }
}


