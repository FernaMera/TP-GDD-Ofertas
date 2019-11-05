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

namespace FrbaOfertas.CrearUsuario
{
    public partial class ProveedorNuevoForm : Form
    {
        private string username;
        private string password;
        private int id_rol;

        public ProveedorNuevoForm(string user, string contra, int idRol)
        {
            InitializeComponent();
            ConexionDB.cargar_comboRubro(comboBox_rubro);

            username = user;
            password = contra;
            id_rol = idRol;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_alta_Click(object sender, EventArgs e)
        {
            List<string> errores = new List<string>();

            if (string.IsNullOrEmpty(textBox_cuit.Text) ||
                string.IsNullOrEmpty(textBox_rs.Text) ||
                string.IsNullOrEmpty(textBox_nombreContacto.Text) ||
                Convert.ToInt16(comboBox_rubro.SelectedValue) == 0 ||
                string.IsNullOrEmpty(textBox_tel.Text) ||
                string.IsNullOrEmpty(textBox_mail.Text) ||
                string.IsNullOrEmpty(textBox_direccion.Text) ||
                string.IsNullOrEmpty(textBox_ciudad.Text) ||
                string.IsNullOrEmpty(textBox_cp.Text))
                    errores.Add("No puede haber campos sin completar");


            if (!Util.cuitValido(textBox_cuit.Text))
                errores.Add("El formato del CUIT es de: dos dígitos, un guión, ocho dígitos, un guión y un dígito final. Ejemplo: 20-12345678-1");

            if (!Util.telefonoValido(textBox_tel.Text))
                errores.Add("El teléfono deben ser sólo números. Por ejemplo: 45671930");

            if (!Util.codigoPostalValido(textBox_cp.Text))
                errores.Add("El código postal deben ser sólo números. Por ejemplo: 1234");

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

            if (errores.Count == 0)
            {
                conexion.Open();
                try
                {
                    if (comando.ExecuteNonQuery() == 1)
                    {
                        comando = new SqlCommand("[SELECT_THISGROUP_FROM_APROBADOS].nuevo_usuario", conexion);

                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.Add("@username", SqlDbType.VarChar);
                        comando.Parameters["@username"].Value = username;
                        comando.Parameters.Add("@password", SqlDbType.VarChar);
                        comando.Parameters["@password"].Value = password;
                        comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

                        SqlDataReader reader = comando.ExecuteReader();
                        int id_usuario = (int)comando.Parameters["@ReturnVal"].Value;
                        reader.Close();
                        if (id_usuario < 0)
                        {
                            MessageBox.Show("Error");
                            conexion.Close();
                            this.Close();
                        }

                        //asociar usuario con cliente
                        comando = new SqlCommand(@"UPDATE SELECT_THISGROUP_FROM_APROBADOS.Proveedor
                                                    SET id_usuario = " + id_usuario + "WHERE cuit like '" + textBox_cuit.Text + "'", conexion);

                        if (comando.ExecuteNonQuery() != 1)
                        {
                            MessageBox.Show("Error al asociar usuario y cliente");
                            conexion.Close();
                            this.Close();
                        }

                        //asociar usuario con su rol
                        comando = new SqlCommand(@"[SELECT_THISGROUP_FROM_APROBADOS].nuevo_rol_usuario", conexion);

                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.Add("@id_user", SqlDbType.VarChar);
                        comando.Parameters["@id_user"].Value = id_usuario;
                        comando.Parameters.Add("@id_rol", SqlDbType.VarChar);
                        comando.Parameters["@id_rol"].Value = id_rol;
                        comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;
                        
                        reader = comando.ExecuteReader();
                        conexion.Close();

                        int resultado = (int)comando.Parameters["@ReturnVal"].Value;
                        if (resultado == 0)
                            MessageBox.Show("Proveedor creado con éxito", "Nuevo Proveedor");
                        else
                            MessageBox.Show("Error al cargar Datos");
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
            }
            else
            {
                Util.mostrarListaErrores(errores, "Alta Proveedor");
            }
            
            conexion.Close();
        }
    }
}
