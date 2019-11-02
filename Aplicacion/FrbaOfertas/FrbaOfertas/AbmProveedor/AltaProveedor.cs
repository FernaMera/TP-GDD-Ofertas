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

namespace FrbaOfertas.AbmProveedor
{
    public partial class AltaProveedor : Form
    {
        public AltaProveedor()
        {
            InitializeComponent();
            ConexionDB.cargar_comboRubro(comboBox_rubro);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_alta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_cuit.Text) ||
                string.IsNullOrEmpty(textBox_rs.Text) ||
                string.IsNullOrEmpty(textBox_nombreContacto.Text) ||
                Convert.ToInt16(comboBox_rubro.SelectedValue) == 0 ||
                string.IsNullOrEmpty(textBox_tel.Text) ||
                string.IsNullOrEmpty(textBox_mail.Text) ||
                string.IsNullOrEmpty(textBox_direccion.Text) ||
                string.IsNullOrEmpty(textBox_ciudad.Text) ||
                string.IsNullOrEmpty(textBox_cp.Text))
            {
                MessageBox.Show("No puede haber campos sin completar", "Error Alta Proveedor");
                return;
            }

            if (!Util.cuitValido(textBox_cuit.Text))
            {
                MessageBox.Show("El formato del CUIT es de: dos dígitos, un guión, ocho dígitos, un guión y un dígito final. Ejemplo: 20-12345678-1", "Error Alta Proveedor");
                return;
            }

            if (!Util.telefonoValido(textBox_tel.Text))
            {
                MessageBox.Show("El teléfono deben ser sólo números. Por ejemplo: 45671930", "Error Alta Proveedor");
                return;
            }

            if (!Util.codigoPostalValido(textBox_cp.Text))
            {
                MessageBox.Show("El código postal deben ser sólo números. Por ejemplo: 1234", "Error Alta Proveedor");
                return;
            }


            string alta = "INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Proveedor (cuit, razon_soc, nombre_contacto, rubro, telefono, mail, direccion, ciudad, cod_postal) VALUES (@cuit, @rs, @nc, @rubro, @telefono, @mail, @direccion, @ciudad, @cp)";

            SqlConnection conexion = ConexionDB.getConexion();
            SqlCommand comando = new SqlCommand(alta, conexion);

            comando.Parameters.Add("@cuit", SqlDbType.Char);
            comando.Parameters["@cuit"].Value = textBox_cuit.Text;

            comando.Parameters.Add("@rs", SqlDbType.VarChar);
            comando.Parameters["@rs"].Value = textBox_rs.Text;

            comando.Parameters.Add("@nc", SqlDbType.VarChar);
            comando.Parameters["@nc"].Value = textBox_nombreContacto.Text;

            comando.Parameters.Add("@rubro", SqlDbType.Int);
            comando.Parameters["@rubro"].Value = comboBox_rubro.SelectedValue;

            comando.Parameters.Add("@telefono", SqlDbType.Int);
            comando.Parameters["@telefono"].Value = textBox_tel.Text;

            comando.Parameters.Add("@mail", SqlDbType.VarChar);
            comando.Parameters["@mail"].Value = textBox_mail.Text;

            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters["@direccion"].Value = textBox_direccion.Text;

            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters["@ciudad"].Value = textBox_ciudad.Text;

            comando.Parameters.Add("@cp", SqlDbType.Int);
            comando.Parameters["@cp"].Value = textBox_cp.Text;

            conexion.Open();
            try
            {
                if (comando.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Alta realizada con éxito!");
                    this.Close();
                }

            }
            catch (SqlException exc)
            {
                if (exc.Message.Contains("PRIMARY KEY"))
                    MessageBox.Show("No se pudo realizar el alta: ya existe un proveedor con el CUIT \"" + textBox_cuit.Text + "\"");
                else if (exc.Message.Contains("UNIQUE"))
                    MessageBox.Show("No se pudo realizar el alta: ya existe un proveedor con la razón social \"" + textBox_rs.Text + "\"");
                else
                    MessageBox.Show("No se pudo realizar el alta: " + exc.Message);
            }
            conexion.Close();

        }


    }
}
