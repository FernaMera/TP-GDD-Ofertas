using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas;
using FrbaOfertas.Clases;
using System.Data.SqlClient;

namespace FrbaOfertas.AbmProveedor
{
    public partial class VentanaProveedor : Form
    {

        public VentanaProveedor()
        {
            InitializeComponent();
            ConexionDB.cargar_comboRubro(comboBox_Rubro);
            comboBox_Rubro.SelectedItem = comboBox_Rubro.Items[0];
        }

        private void VentanaProveedor_Load(object sender, EventArgs e)
        {

        }


        private void buscar_Click(object sender, EventArgs e)
        {
            string where = " WHERE ";
            string condicion1 = "1=1";
            string condicion2 = "1=1";
            string condicion3 = "1=1";
            string condicion4 = "1=1";
            string condicion5 = "1=1";
            string condicion6 = "1=1";

            if (!string.IsNullOrEmpty(textBox_cuit.Text.ToString()))
            {
                condicion1 = "cuit = '" + textBox_cuit.Text.ToString() + "'";
            }

            if (!string.IsNullOrEmpty(textBox_rs.Text.ToString()))
            {
                condicion2 = "UPPER(razon_soc) LIKE UPPER('%" + textBox_rs.Text.ToString() + "%')";
            }

            if (!string.IsNullOrEmpty(textBox_nombreContacto.Text.ToString()))
            {
                condicion3 = "UPPER(nombre_contacto) LIKE UPPER('%" + textBox_nombreContacto.Text.ToString() + "%')";
            }

            if (!string.IsNullOrEmpty(textBox_email.Text.ToString()))
            {
                condicion4 = "UPPER(mail) LIKE UPPER('%" + textBox_email.Text.ToString() + "%')";
            }

            if (Convert.ToInt16(comboBox_Rubro.SelectedValue) != 0)
            {
                condicion5 = "rubro = " + comboBox_Rubro.SelectedValue;
            }

            if (!checkBox_mostrarDeshabilitados.Checked)
            {
                condicion6 = "habilitado = 1";
            }

            where = where + condicion1 + " AND " + condicion2 + " AND " + condicion3 + " AND " + condicion4 + " AND " + condicion5 + " AND " + condicion6;

            string query = "SELECT cuit, razon_soc, nombre_contacto, rubro, descripcion, telefono, mail, direccion, ciudad, cod_postal, habilitado FROM [SELECT_THISGROUP_FROM_APROBADOS].[Proveedor] JOIN [SELECT_THISGROUP_FROM_APROBADOS].[Rubro] r ON rubro = r.id" + where;

            ConexionDB.llenar_grilla(gridProveedores, query);

        }


        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            textBox_cuit.Clear();
            textBox_email.Clear();
            textBox_nombreContacto.Clear();
            textBox_rs.Clear();
            comboBox_Rubro.SelectedItem = null;
            if (checkBox_mostrarDeshabilitados.Checked)
            {
                checkBox_mostrarDeshabilitados.Checked = false;
            }
        }

        // Modificacion
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (gridProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Se debe seleccionar algun proveedor para modificar.");
                return;
            }

            string razon_social = gridProveedores.CurrentRow.Cells["razon_soc"].Value.ToString();
            string mail = gridProveedores.CurrentRow.Cells["mail"].Value.ToString();
            int telefono = Convert.ToInt32(gridProveedores.CurrentRow.Cells["telefono"].Value.ToString());
            string direccion = gridProveedores.CurrentRow.Cells["direccion"].Value.ToString();
            int codigoPostal = -1;
            if (!string.IsNullOrEmpty(gridProveedores.CurrentRow.Cells[9].Value.ToString()))
            {
                codigoPostal = Convert.ToInt32(gridProveedores.CurrentRow.Cells["cod_postal"].Value.ToString());
            }
            string ciudad = gridProveedores.CurrentRow.Cells["ciudad"].Value.ToString();
            string cuit = gridProveedores.CurrentRow.Cells["cuit"].Value.ToString();
            int rubro = Convert.ToInt16(gridProveedores.CurrentRow.Cells["rubro"].Value.ToString());
            string nombre_contacto = gridProveedores.CurrentRow.Cells["nombre_contacto"].Value.ToString();

            Proveedor provParaModificar = new Proveedor(razon_social, mail, telefono, direccion, codigoPostal, ciudad, cuit, rubro, nombre_contacto);

            var modificarProv = new ModificarProveedor(provParaModificar);
            modificarProv.Show();
            gridProveedores.DataSource = null;
        }

        // Baja
        private void btn_habDeshab_Click(object sender, EventArgs e)
        {

            if (gridProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Se debe seleccionar algun proveedor habilitar/deshabilitar");
                return;
            }

            string update = "UPDATE [SELECT_THISGROUP_FROM_APROBADOS].Proveedor SET habilitado=@contrario WHERE cuit=@cuit";
            SqlConnection conexion = ConexionDB.getConexion();
            SqlCommand comando = new SqlCommand(update, conexion);

            comando.Parameters.Add("@contrario", SqlDbType.Bit);
            string msg;
            if ((Convert.ToInt16(gridProveedores.CurrentRow.Cells["habilitado"].Value) == 0))
            {
                msg = "El usuario fue habilitado!";
                comando.Parameters["@contrario"].Value = 1;
            }
            else
            {
                msg = "El usuario fue deshabilitado!";
                comando.Parameters["@contrario"].Value = 0;
            }

            comando.Parameters.Add("@cuit", SqlDbType.Char);
            comando.Parameters["@cuit"].Value = gridProveedores.CurrentRow.Cells["cuit"].Value.ToString();
            
            conexion.Open();

            try
            {
                if (comando.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(msg);
                    gridProveedores.DataSource = null;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("No se pudo actualizar:\n" + exc.Message);
            }
            conexion.Close();
        }

        // Alta
        private void btn_alta_Click(object sender, EventArgs e)
        {
            var altaProv = new AltaProveedor();
            altaProv.Show();
            gridProveedores.DataSource = null;
        }

    }
}

