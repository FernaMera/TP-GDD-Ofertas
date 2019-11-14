using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();

            //Lleno la lista de semestres
            comboSemestre.Items.Add("1º Semestre");
            comboSemestre.Items.Add("2º Semestre");
            //lleno la lista de consultas
            comboConsulta.Items.Add("Proveedores con mayor porcentaje de descuentos ofrecido en sus ofertas");
            comboConsulta.Items.Add("Proveedores con mayor facturacion");

        }

        public bool validar() 
        {
            bool noHayError = true;

            if (comboConsulta.Text=="")
            {
                noHayError = false;
            }
            return noHayError;
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            this.listado.DataSource = "";

            string año = Convert.ToString(textBoxAño.Text);
            string semestre = Convert.ToString(comboSemestre.Text);
            string consulta = Convert.ToString(comboConsulta.Text);

            string sqlBase;
            string query;

            if (this.validar()==false)
            {
                MessageBox.Show("Tiene que seleccionar una consulta");
                return;
            }

            if (consulta == "Proveedores con mayor facturacion")
            {

                if (año != "" && semestre != "")
                {
                    sqlBase = "SELECT TOP 5 p.cuit, YEAR(f.fecha_desde) AS año, (CASE DATEPART(QUARTER,f.fecha_desde) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) AS semestre, SUM(f.total) AS total_facturado FROM [SELECT_THISGROUP_FROM_APROBADOS].Proveedor p JOIN [SELECT_THISGROUP_FROM_APROBADOS].Facturacion f ON (p.cuit = f.cuit_proveedor) WHERE p.habilitado = 1 AND YEAR(f.fecha_desde) = '{0}' AND (CASE DATEPART(QUARTER,f.fecha_desde) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) = '{1}' GROUP BY p.cuit, YEAR(f.fecha_desde), (CASE DATEPART(QUARTER,f.fecha_desde) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) ORDER BY 4 DESC";
                    query = String.Format(sqlBase, año, semestre);
                    ConexionDB.llenar_grilla(listado, query);
                    return;
                }
                 
                if (año == "" && semestre != "")
                {
                    sqlBase = "SELECT TOP 5 p.cuit, YEAR(f.fecha_desde) AS año, (CASE DATEPART(QUARTER,f.fecha_desde) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) AS semestre, SUM(f.total) AS total_facturado FROM [SELECT_THISGROUP_FROM_APROBADOS].Proveedor p JOIN [SELECT_THISGROUP_FROM_APROBADOS].Facturacion f ON (p.cuit = f.cuit_proveedor) WHERE p.habilitado = 1 AND (CASE DATEPART(QUARTER,f.fecha_desde) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) = '{0}' GROUP BY p.cuit, YEAR(f.fecha_desde), (CASE DATEPART(QUARTER,f.fecha_desde) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) ORDER BY 4 DESC";
                    query = String.Format(sqlBase, semestre);
                    ConexionDB.llenar_grilla(listado, query);
                    return;
                }
                
                if (semestre == "" && año != "")
	            {   
		            sqlBase = "SELECT TOP 5 p.cuit, YEAR(f.fecha_desde) AS año, (CASE DATEPART(QUARTER,f.fecha_desde) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) AS semestre, SUM(f.total) AS total_facturado FROM [SELECT_THISGROUP_FROM_APROBADOS].Proveedor p JOIN [SELECT_THISGROUP_FROM_APROBADOS].Facturacion f ON (p.cuit = f.cuit_proveedor) WHERE p.habilitado = 1 AND YEAR(f.fecha_desde) = '{0}' GROUP BY p.cuit, YEAR(f.fecha_desde), (CASE DATEPART(QUARTER,f.fecha_desde) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) ORDER BY 4 DESC";
                    query = String.Format(sqlBase, año);
                    ConexionDB.llenar_grilla(listado, query);
                    return;
	            }

                sqlBase = "SELECT TOP 5 p.cuit, YEAR(f.fecha_desde) AS año, (CASE DATEPART(QUARTER,f.fecha_desde) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) AS semestre, SUM(f.total) AS total_facturado FROM [SELECT_THISGROUP_FROM_APROBADOS].Proveedor p JOIN [SELECT_THISGROUP_FROM_APROBADOS].Facturacion f ON (p.cuit = f.cuit_proveedor) WHERE p.habilitado = 1 GROUP BY p.cuit, YEAR(f.fecha_desde), (CASE DATEPART(QUARTER,f.fecha_desde) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) ORDER BY 4 DESC";
                query = String.Format(sqlBase, año);
                ConexionDB.llenar_grilla(listado, query);
                return;

            }

            if (consulta == "Proveedores con mayor porcentaje de descuentos ofrecido en sus ofertas")
            {

                if (año != "" && semestre != "")
                {
                    sqlBase = "SELECT TOP 5 p.cuit, YEAR(o.fec_public) AS año, (CASE DATEPART(QUARTER,o.fec_public) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) AS 'Semestre', SUM((o.precio_oferta*100)/o.precio_lista) AS porcentajes_acumulados FROM [SELECT_THISGROUP_FROM_APROBADOS].Proveedor p JOIN [SELECT_THISGROUP_FROM_APROBADOS].Oferta o ON (p.cuit = o.cuit_prov) WHERE p.habilitado = 1 AND YEAR(o.fec_public) = '{0}' AND (CASE DATEPART(QUARTER,o.fec_public) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) = '{1}' GROUP BY p.cuit, YEAR(o.fec_public), (CASE DATEPART(QUARTER,o.fec_public) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) ORDER BY 4 DESC";
                    query = String.Format(sqlBase, año, semestre);
                    ConexionDB.llenar_grilla(listado, query);
                    return;
                }
                 
                if (año == "" && semestre != "")
                {
                    sqlBase = "SELECT TOP 5 p.cuit, YEAR(o.fec_public) AS año, (CASE DATEPART(QUARTER,o.fec_public) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) AS 'Semestre', SUM((o.precio_oferta*100)/o.precio_lista) AS porcentajes_acumulados FROM [SELECT_THISGROUP_FROM_APROBADOS].Proveedor p JOIN [SELECT_THISGROUP_FROM_APROBADOS].Oferta o ON (p.cuit = o.cuit_prov) WHERE p.habilitado = 1 AND (CASE DATEPART(QUARTER,o.fec_public) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) = '{0}' GROUP BY p.cuit, YEAR(o.fec_public), (CASE DATEPART(QUARTER,o.fec_public) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) ORDER BY 4 DESC";
                    query = String.Format(sqlBase, semestre);
                    ConexionDB.llenar_grilla(listado, query);
                    return;
                }
                
                if (semestre == "" && año != "")
	            {   
		            sqlBase = "SELECT TOP 5 p.cuit, YEAR(o.fec_public) AS año, (CASE DATEPART(QUARTER,o.fec_public) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) AS 'Semestre', SUM((o.precio_oferta*100)/o.precio_lista) AS porcentajes_acumulados FROM [SELECT_THISGROUP_FROM_APROBADOS].Proveedor p JOIN [SELECT_THISGROUP_FROM_APROBADOS].Oferta o ON (p.cuit = o.cuit_prov) WHERE p.habilitado = 1 AND YEAR(o.fec_public) = '{0}' GROUP BY p.cuit, YEAR(o.fec_public), (CASE DATEPART(QUARTER,o.fec_public) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) ORDER BY 4 DESC";
                    query = String.Format(sqlBase, año);
                    ConexionDB.llenar_grilla(listado, query);
                    return;
	            }
                
                sqlBase = "SELECT TOP 5 p.cuit, YEAR(o.fec_public) AS año, (CASE DATEPART(QUARTER,o.fec_public) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) AS 'Semestre', SUM((o.precio_oferta*100)/o.precio_lista) AS porcentajes_acumulados FROM [SELECT_THISGROUP_FROM_APROBADOS].Proveedor p JOIN [SELECT_THISGROUP_FROM_APROBADOS].Oferta o ON (p.cuit = o.cuit_prov) WHERE p.habilitado = 1 GROUP BY p.cuit, YEAR(o.fec_public), (CASE DATEPART(QUARTER,o.fec_public) WHEN 1 THEN '1º Semestre' WHEN 2 THEN '1º Semestre' ELSE '2º Semestre' END) ORDER BY 4 DESC";
                query = String.Format(sqlBase, año, semestre);
                ConexionDB.llenar_grilla(listado, query);
                return;
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            this.textBoxAño.Text = "";
            this.comboSemestre.Text = "";
            this.comboConsulta.Text = "";
            this.listado.DataSource = "";
        }
       
    }
}
