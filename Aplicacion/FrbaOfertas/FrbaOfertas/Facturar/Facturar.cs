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
using System.Configuration;

namespace FrbaOfertas.Facturar
{
    public partial class Facturar : Form
    {

        DateTime fechaConfig = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);
        public Facturar()
        {
            InitializeComponent();
            dateTimePicker_desde.Value = fechaConfig;
            dateTimePicker_hasta.Value = fechaConfig;
        }

        private void btn_seleccionarProveedor_Click(object sender, EventArgs e)
        {
            using (CrearOferta.SeleccionarProveedor selProv = new CrearOferta.SeleccionarProveedor())
            {
                if (selProv.ShowDialog() == DialogResult.OK)
                    textBox_proveedor.Text = selProv.proveedorSeleccionado;
            }
        }

        private void btn_facturar_Click(object sender, EventArgs e)
        {
            List<string> errores = new List<string>();

            if (string.IsNullOrEmpty(textBox_proveedor.Text))
                errores.Add("Debe completarse un proveedor");

            if (dateTimePicker_desde.Value > dateTimePicker_hasta.Value)
                errores.Add("La fecha 'desde' debe ser menor o igual a la fecha 'hasta'");


            if (errores.Count == 0)
            {
                var conexion = ConexionDB.getConexion();

                SqlCommand cmd = new SqlCommand("[SELECT_THISGROUP_FROM_APROBADOS].sp_facturar", conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cuitProveedor", SqlDbType.Char);
                cmd.Parameters.Add("@fechaDesde", SqlDbType.Date);
                cmd.Parameters.Add("@fechaHasta", SqlDbType.Date);

                cmd.Parameters["@cuitProveedor"].Value = textBox_proveedor.Text;
                cmd.Parameters["@fechaDesde"].Value = dateTimePicker_desde.Value;
                cmd.Parameters["@fechaHasta"].Value = dateTimePicker_hasta.Value;
                cmd.Parameters.Add("@numeroFact", SqlDbType.Int);
                cmd.Parameters.Add("@importeTotal", SqlDbType.Decimal);
                cmd.Parameters["@numeroFact"].Direction = ParameterDirection.Output;
                cmd.Parameters["@importeTotal"].Direction = ParameterDirection.Output;

                conexion.Open();

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    int numeroFactura = (int)cmd.Parameters["@numeroFact"].Value;
                    decimal importeTotal = (decimal)cmd.Parameters["@importeTotal"].Value;

                    conexion.Close();

                    if (numeroFactura == -1 && importeTotal == -1) // quiere decir que no hay facturas para el periodo/proveedor seleccionado
                    {
                        MessageBox.Show("No existen compras en el período seleccionado para ese proveedor", "Error al facturar");
                        return;
                    }

                    textBox_factura.Text = Convert.ToString(numeroFactura);
                    textBox_importeTotal.Text = " $ " + Convert.ToString(importeTotal);

                    string query = "SELECT numero_factura, id_oferta, cantidad, monto FROM [SELECT_THISGROUP_FROM_APROBADOS].[Detalle_Facturacion] WHERE numero_factura = " + numeroFactura;

                    ConexionDB.llenar_grilla(dataGridView_ofertasAdquiridas, query);
                }
                catch (SqlException exc)
                {
                    MessageBox.Show("No se pudo realizar la facturación: " + exc.Message);
                }

                conexion.Close();
            }
            else
            {
                Util.mostrarListaErrores(errores, "Error al facturar");
            }

        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_factura.Clear();
            textBox_importeTotal.Clear();
            textBox_proveedor.Clear();
            dataGridView_ofertasAdquiridas.DataSource = null;
            dateTimePicker_desde.Value = fechaConfig;
            dateTimePicker_hasta.Value = fechaConfig;
        }
    }
}
