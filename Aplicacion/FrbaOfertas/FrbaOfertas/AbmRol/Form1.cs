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

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
        }
    }
}
