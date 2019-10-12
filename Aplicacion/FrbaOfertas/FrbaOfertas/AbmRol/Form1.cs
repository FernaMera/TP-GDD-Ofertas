using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmRol
{
    public partial class Form1 : Form, Funcionalidad
    {
        public static Form1 ABMRol;

        public Form1()
        {
            ABMRol = this;
            InitializeComponent();
        }

        //nuevo ROL
        private void button1_Click(object sender, EventArgs e)
        {
            panelRol.Show();
            nombreRolBox.Enabled = true;
            nombreRolBox.Text = "";
            descripcionBox.Enabled = true;
            descripcionBox.Text = "";
            funcionesBox.Enabled = true;
            foreach (int i in funcionesBox.CheckedIndices)
            {
                funcionesBox.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;

            //TODO: buscar en base de datos el rol seleccionado
        }
    }
}
