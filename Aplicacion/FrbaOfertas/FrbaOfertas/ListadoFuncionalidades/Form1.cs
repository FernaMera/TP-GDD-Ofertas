﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ListadoFuncionalidades
{
    public partial class Ofertas : Form
    {
        Rol unRol;
        HashSet<string> funciones;

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
            botones.Add(listadoEstadisticoButton);

            funciones = new HashSet<string>();
            funciones.Add("Comprar Oferta");
            funciones.Add("Carga Credito");
            funciones.Add("ABM Rol");

            unRol = new Rol(1, "cliente", funciones);

            foreach(Button button in botones)
            {
                if (!unRol.TieneFuncion(button.Text))
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
            AbrirFormEnPanel(new AbmProveedor.Form1());
        }

        private void cargarCreditoButton_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new CargaCredito.Form1());
        }
    }
}