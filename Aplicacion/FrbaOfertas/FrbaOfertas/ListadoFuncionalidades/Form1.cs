using System;
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
        public Ofertas()
        {
            InitializeComponent();
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
    }
}
