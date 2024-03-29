﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FrbaOfertas.ListadoFuncionalidades
{
    public partial class Ofertas : Form
    {
        public Ofertas()
        {
            InitializeComponent();

            List<Button> botones = new List<Button>();
            botones.Add(abmClienteButton);
            botones.Add(abmProveedorButton);
            botones.Add(abmRolButton);
            botones.Add(comprarOfertaButton);
            botones.Add(cargarCreditoButton);
            botones.Add(crearOfertaButton);
            botones.Add(consumirOfertaButton);
            botones.Add(listadoEstadisticoButton);
            botones.Add(facturacionButton);

            foreach(Button button in botones)
            {
                if (!Usuario.usuario.TieneFuncion(button.Text))
                    button.Visible = false;
            }
        }

        private void AbrirFormEnPanel(object form)
        {
            if (this.panelFunciones.Controls.Count > 0)
                this.panelFunciones.Controls.RemoveAt(0);
            Form fh = form as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelFunciones.Controls.Add(fh);
            this.panelFunciones.Tag = fh;
            fh.Show();

        }

        //ABM Rol
        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new AbmRol.Form1());
        }

        //ABM Cliente
        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new AbmCliente.Form1());
        }

        //ABM Proveedor
        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new AbmProveedor.VentanaProveedor());
        }

        private void cargarCreditoButton_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new CargaCredito.CargaCredito());
        }

        private void crearOfertaButton_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new CrearOferta.CrearOferta());
        }

        private void comprarOfertaButton_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new ComprarOferta.Form1());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new CambiarContraseña.CambiarContrasena());
        }

        private void consumirOfertaButton_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new ConsumirOferta.ConsumirOferta());
        }

        private void facturacionButton_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Facturar.Facturar());
        }

        private void listadoEstadisticoButton_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new ListadoEstadistico.ListadoEstadistico());
        }
    }
}
