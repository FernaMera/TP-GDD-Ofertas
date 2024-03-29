﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaOfertas.CrearUsuario
{
    public partial class ClienteNuevoForm : Form
    {
        private String usuario;
        private String contrasena;
        private int id_rol;
        private bool nonNumberEntered;

        public ClienteNuevoForm(String username, String password, int idRol)
        {
            InitializeComponent();

            usuario = username;
            contrasena = password;
            id_rol = idRol;
            fechaNac.MaxDate = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);
        }

        //Cancelar
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //nuevo cliente
        private void button1_Click(object sender, EventArgs e)
        {
            int id_cliente;
            int id_usuario;
            var conexion = ConexionDB.getConexion();
            conexion.Open();

            SqlCommand comando = conexion.CreateCommand();

            SqlTransaction transaccion = conexion.BeginTransaction("Crear_Usuario_Cliente");
            
            comando.Connection = conexion;
            comando.Transaction = transaccion;
            
            //nuevo cliente
            comando.CommandText = "[SELECT_THISGROUP_FROM_APROBADOS].nuevo_cliente";
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
            
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                id_cliente = (int)comando.Parameters["@ReturnVal"].Value;
            }

            switch(id_cliente)
            {
                case -1:
                    {
                        MessageBox.Show("Cliente ya existe");
                        conexion.Close();
                        return;
                    }
                case -2:
                    {
                        MessageBox.Show("Error al actualizar datos", "ERROR");
                        transaccion.Rollback();
                        conexion.Close();
                        this.Close();
                        break;
                    }
                default:
                    {
                        comando.Parameters.Clear();

                        //nuevo usuario
                        comando.CommandText = "[SELECT_THISGROUP_FROM_APROBADOS].nuevo_usuario";

                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.Add("@username", SqlDbType.VarChar);
                        comando.Parameters["@username"].Value = usuario;
                        comando.Parameters.Add("@password", SqlDbType.VarChar);
                        comando.Parameters["@password"].Value = contrasena;
                        comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            id_usuario = (int)comando.Parameters["@ReturnVal"].Value;
                        }

                        if (id_usuario < 0)
                        {
                            MessageBox.Show("Error");
                            transaccion.Rollback();
                            conexion.Close();
                            this.Close();
                        }

                        //asociar usuario con cliente
                        comando.CommandText = @"UPDATE SELECT_THISGROUP_FROM_APROBADOS.Cliente
                                  SET id_usuario = " + id_usuario + "WHERE id = " + id_cliente;
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Clear();

                        if (comando.ExecuteNonQuery() != 1)
                        {
                            MessageBox.Show("Error al asociar usuario y cliente");
                            transaccion.Rollback();
                            conexion.Close();
                            this.Close();
                        }

                        //asociar usuario con su rol
                        comando.CommandText = @"[SELECT_THISGROUP_FROM_APROBADOS].nuevo_rol_usuario";

                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.Add("@id_user", SqlDbType.VarChar);
                        comando.Parameters["@id_user"].Value = id_usuario;
                        comando.Parameters.Add("@id_rol", SqlDbType.VarChar);
                        comando.Parameters["@id_rol"].Value = id_rol;
                        comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;
                        
                        int resultado;
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            resultado = (int)comando.Parameters["@ReturnVal"].Value;
                        }

                        if (resultado == 0)
                        {
                            transaccion.Commit();
                            MessageBox.Show("Cliente creado con éxito", "Nuevo Cliente");
                        }
                        else
                        {
                            transaccion.Rollback();
                            MessageBox.Show("Error al cargar Datos");
                        }
                        
                        conexion.Close();
                        this.Close();
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
