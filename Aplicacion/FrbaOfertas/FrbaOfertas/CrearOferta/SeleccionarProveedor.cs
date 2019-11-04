using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CrearOferta
{
    public partial class SeleccionarProveedor : Form
    {
        public string proveedorSeleccionado { get; set; }

        public SeleccionarProveedor()
        {
            InitializeComponent();
            string query = "SELECT cuit, razon_soc FROM [SELECT_THISGROUP_FROM_APROBADOS].Proveedor WHERE habilitado = 1";
            ConexionDB.llenar_grilla(gridProveedores, query);
        }

        private void btn_seleccionarProv_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.proveedorSeleccionado = gridProveedores.CurrentRow.Cells["cuit"].Value.ToString();
            this.Close();
        }
    }
}
