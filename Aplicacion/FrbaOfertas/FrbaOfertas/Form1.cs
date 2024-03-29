﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaOfertas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void iniciar_sesion_Click(object sender, EventArgs e)
        {
            if (usuario.Text.Equals(""))
            {
                MessageBox.Show("Ingrese Usuario", "Login");
                return;
            }
            if (contrasenia.Text.Equals(""))
            {
                MessageBox.Show("Ingrese Contraseña", "Login");
                return;
            }

            var conexion = ConexionDB.getConexion();

            SqlCommand comando = new SqlCommand("[SELECT_THISGROUP_FROM_APROBADOS].sp_validar_login", conexion);

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@username", SqlDbType.VarChar);
            comando.Parameters.Add("@password", SqlDbType.VarChar);
            comando.Parameters["@username"].Value = usuario.Text;
            comando.Parameters["@password"].Value = contrasenia.Text;
            comando.Parameters.Add("@ReturnVal", SqlDbType.Int);
            comando.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;

            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            int retorno = (int)comando.Parameters["@ReturnVal"].Value;
            conexion.Close();

            if (retorno == -3)
            {
                MessageBox.Show("Usuario/Contraseña inexistente o incorrecto", "Resultado Login");
            } else if (retorno == -1 || retorno == -2) 
            {
                MessageBox.Show("El usuario se encuentra inhabilitado", "Resultado Login");
            }

            else
            {
                Usuario.usuario.crear_usuario(retorno);
                if (Usuario.usuario.esCliente())
                    Clases.Cliente.cliente.Crear_Cliente(retorno);
                this.Hide();
                var form = new ListadoFuncionalidades.Ofertas();
                form.Closed += (s, args) => this.Close();
                form.Show();              
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this.Hide();
            var form = new CrearUsuario.Form1();
            //form.Closed += (s, args) => this.Show();
            form.Show();
        }
    }
}
