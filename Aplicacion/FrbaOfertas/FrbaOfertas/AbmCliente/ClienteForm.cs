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

namespace FrbaOfertas.AbmCliente
{
    public partial class ClienteForm : Form
    {
        private int cliente_id;
        private string accion;
        private bool nonNumberEntered;

        public ClienteForm()
        {
            InitializeComponent();
        }

        public ClienteForm(string modo, int idCliente)
        {
            InitializeComponent();
            accion = modo;
            
            switch (modo)
            {
                case "Nuevo":
                    {
                        titulo.Text = "Nuevo Cliente";
                        guardarButton.Text = "Guardar";
                        break;
                    }
                case "Modificar":
                    {
                        titulo.Text = "Modificar Cliente";
                        cliente_id = idCliente;

                        var conexion = ConexionDB.getConexion();

                        SqlCommand idQuery = new SqlCommand(@"SELECT nombre, apellido, dni, mail, telefono, direccion, ciudad, cod_postal, fecha_nac 
                                                            FROM SELECT_THISGROUP_FROM_APROBADOS.Cliente C
                                                            where C.id = " + idCliente, conexion);

                        conexion.Open();
                        using (SqlDataReader reader = idQuery.ExecuteReader())
                        {
                            reader.Read();

                            nombreBox.Text = reader["nombre"].ToString();
                            apellidoBox.Text = reader["apellido"].ToString();
                            dniBox.Text = reader["dni"].ToString();
                            mailBox.Text = reader["mail"].ToString();
                            telefonoBox.Text = reader["telefono"].ToString();
                            direccionBox.Text = reader["direccion"].ToString();
                            ciudadBox.Text = reader["ciudad"].ToString();
                            codPostalBox.Text = reader["cod_postal"].ToString();
                            fechaNac.Value = Convert.ToDateTime(reader["fecha_nac"]);

                            reader.Close();
                        }
                        conexion.Close();

                        break;
                    }
            }
        }

        //Cancelar
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //guardar cambios o nuevo cliente
        private void button1_Click(object sender, EventArgs e)
        {
            switch(accion)
            {
                case "Nuevo":
                    {
                        var conexion = ConexionDB.getConexion();

                        SqlCommand comando = new SqlCommand("[SELECT_THISGROUP_FROM_APROBADOS].nuevo_cliente", conexion);

                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.Add("@nombre_nuevo", SqlDbType.VarChar);
                        comando.Parameters["@nombre_nuevo"].Value = nombreBox.Text;
                        comando.Parameters.Add("@apellido_nuevo", SqlDbType.VarChar);
                        comando.Parameters["@apellido_nuevo"].Value = apellidoBox.Text;
                        comando.Parameters.Add("@dni_nuevo", SqlDbType.Int);
                        comando.Parameters["@dni_nuevo"].Value = Convert.ToInt32(dniBox.Text);
                        comando.Parameters.Add("@mail", SqlDbType.VarChar);
                        comando.Parameters["@mail"].Value = mailBox.Text;
                        comando.Parameters.Add("@telefono", SqlDbType.Int);
                        comando.Parameters["@telefono"].Value = Convert.ToInt32(telefonoBox.Text);
                        comando.Parameters.Add("@direccion", SqlDbType.VarChar);
                        comando.Parameters["@direccion"].Value = direccionBox.Text;
                        comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
                        comando.Parameters["@ciudad"].Value = ciudadBox.Text;
                        comando.Parameters.Add("@cod_postal", SqlDbType.SmallInt);
                        if (codPostalBox.Text.Equals(""))
                            comando.Parameters["@cod_postal"].Value = DBNull.Value;
                        else
                        {
                            int cod_postal = Convert.ToInt32(codPostalBox.Text);

                            comando.Parameters["@cod_postal"].Value = cod_postal;
                        }

                        comando.Parameters.Add("@fecha_nac", SqlDbType.DateTime);
                        comando.Parameters["@fecha_nac"].Value = fechaNac.Value;
                        comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

                        conexion.Open();
                        SqlDataReader reader = comando.ExecuteReader();
                        int resultado = (int)comando.Parameters["@ReturnVal"].Value;
                        conexion.Close();

                        if (resultado < 0)
                        {
                            MessageBox.Show("Error al actualizar datos", "ERROR");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Cliente creado con éxito", "Nuevo Cliente");
                            this.Close();
                        }
                        
                        break;
                    }
                case "Modificar":
                    {
                        var conexion = ConexionDB.getConexion();

                        SqlCommand comando = new SqlCommand("[SELECT_THISGROUP_FROM_APROBADOS].mod_cliente", conexion);

                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.Add("@id", SqlDbType.VarChar);
                        comando.Parameters["@id"].Value = cliente_id;
                        comando.Parameters.Add("@nombre_nuevo", SqlDbType.VarChar);
                        comando.Parameters["@nombre_nuevo"].Value = nombreBox.Text;
                        comando.Parameters.Add("@apellido_nuevo", SqlDbType.VarChar);
                        comando.Parameters["@apellido_nuevo"].Value = apellidoBox.Text;
                        comando.Parameters.Add("@dni_nuevo", SqlDbType.Int);
                        comando.Parameters["@dni_nuevo"].Value = Convert.ToInt32(dniBox.Text);
                        comando.Parameters.Add("@mail", SqlDbType.VarChar);
                        comando.Parameters["@mail"].Value = mailBox.Text;
                        comando.Parameters.Add("@telefono", SqlDbType.Int);
                        comando.Parameters["@telefono"].Value = Convert.ToInt32(telefonoBox.Text);
                        comando.Parameters.Add("@direccion", SqlDbType.VarChar);
                        comando.Parameters["@direccion"].Value = direccionBox.Text;
                        comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
                        comando.Parameters["@ciudad"].Value = ciudadBox.Text;
                        comando.Parameters.Add("@cod_postal", SqlDbType.SmallInt);
                        if (codPostalBox.Text.Equals(""))
                            comando.Parameters["@cod_postal"].Value = DBNull.Value;
                        else
                        {
                            int cod_postal = Convert.ToInt32(codPostalBox.Text);

                            comando.Parameters["@cod_postal"].Value = cod_postal;
                        }

                        comando.Parameters.Add("@fecha_nac", SqlDbType.DateTime);
                        comando.Parameters["@fecha_nac"].Value = fechaNac.Value;
                        comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

                        conexion.Open();
                        SqlDataReader reader = comando.ExecuteReader();
                        int resultado = (int)comando.Parameters["@ReturnVal"].Value;
                        conexion.Close();

                        if (resultado < 0)
                        {
                            MessageBox.Show("Error al actualizar datos", "ERROR");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Datos actualizados con éxito", "Modificar Cliente");
                            this.Close();
                        }

                        break;
                    }
            }
        }

        private void codPostalBox_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;

            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void codPostalBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void dniBox_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;

            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void dniBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void telefonoBox_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;

            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void telefonoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }
    }
}
