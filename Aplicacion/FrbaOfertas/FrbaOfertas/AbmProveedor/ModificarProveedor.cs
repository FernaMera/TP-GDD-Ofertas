using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Clases;
using FrbaOfertas.AbmProveedor;
using System.Data.SqlClient;


namespace FrbaOfertas.AbmProveedor
{
    public partial class ModificarProveedor : Form
    {

        public ModificarProveedor(Proveedor p)
        {
            InitializeComponent();
            ConexionDB.cargar_comboRubro(comboBox_rubro);

            textBox_cuit.Text = p.cuit;
            textBox_rs.Text = p.razon_social;
            textBox_nombreContacto.Text = p.nombre_contacto;
            comboBox_rubro.SelectedValue = p.rubro;
            textBox_tel.Text = p.telefono.ToString();
            textBox_mail.Text = p.mail;
            textBox_direccion.Text = p.direccion;
            textBox_ciudad.Text = p.ciudad;
            if (p.codigoPostal == -1)
            {
                textBox_cp.Text = "";
            }
            else
            {
                textBox_cp.Text = p.codigoPostal.ToString();
            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_guardarCambios_Click(object sender, EventArgs e)
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
                MessageBox.Show("No puede haber campos sin completar", "Error Modificar Proveedor");
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

            string update = "UPDATE [SELECT_THISGROUP_FROM_APROBADOS].Proveedor SET razon_soc=@rs, nombre_contacto=@nombreContacto, rubro=@rubro, telefono=@telefono, mail=@mail, direccion=@direccion, ciudad=@ciudad, cod_postal=@cp WHERE cuit=@cuit";
            SqlConnection conexion = ConexionDB.getConexion();
            SqlCommand comando = new SqlCommand(update, conexion);

            comando.Parameters.Add("@rs", SqlDbType.VarChar);
            comando.Parameters.Add("@nombreContacto", SqlDbType.VarChar);
            comando.Parameters.Add("@rubro", SqlDbType.Int);
            comando.Parameters.Add("@telefono", SqlDbType.Int);
            comando.Parameters.Add("@mail", SqlDbType.VarChar);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@cp", SqlDbType.Int);

            comando.Parameters["@rs"].Value = textBox_rs.Text;
            comando.Parameters["@nombreContacto"].Value = textBox_nombreContacto.Text;
            comando.Parameters["@rubro"].Value = comboBox_rubro.SelectedValue;
            comando.Parameters["@telefono"].Value = textBox_tel.Text;
            comando.Parameters["@mail"].Value = textBox_mail.Text;
            comando.Parameters["@direccion"].Value = textBox_direccion.Text;
            comando.Parameters["@ciudad"].Value = textBox_ciudad.Text;
            comando.Parameters["@cp"].Value = textBox_cp.Text;
            comando.Parameters.Add("@cuit", SqlDbType.Char);
            comando.Parameters["@cuit"].Value = textBox_cuit.Text;

            conexion.Open();
            try
            {
                if (comando.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Actualización realizada con éxito!");
                    this.Close();
                }

            }
            catch (SqlException exc)
            {
                if (exc.Message.Contains("UNIQUE"))
                    MessageBox.Show("No se pudo realizar el alta: ya existe un proveedor con la razón social \"" + textBox_rs.Text + "\"");
                else
                    MessageBox.Show("No se pudo realizar el alta: " + exc.Message);
            }
            conexion.Close();


        }
    }
}
