namespace FrbaOfertas.CrearOferta
{
    partial class SeleccionarProveedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridProveedores = new System.Windows.Forms.DataGridView();
            this.btn_seleccionarProv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // gridProveedores
            // 
            this.gridProveedores.AllowUserToAddRows = false;
            this.gridProveedores.AllowUserToDeleteRows = false;
            this.gridProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProveedores.Location = new System.Drawing.Point(12, 12);
            this.gridProveedores.MultiSelect = false;
            this.gridProveedores.Name = "gridProveedores";
            this.gridProveedores.ReadOnly = true;
            this.gridProveedores.RowTemplate.ReadOnly = true;
            this.gridProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProveedores.Size = new System.Drawing.Size(802, 411);
            this.gridProveedores.TabIndex = 6;
            // 
            // btn_seleccionarProv
            // 
            this.btn_seleccionarProv.Location = new System.Drawing.Point(373, 443);
            this.btn_seleccionarProv.Name = "btn_seleccionarProv";
            this.btn_seleccionarProv.Size = new System.Drawing.Size(108, 53);
            this.btn_seleccionarProv.TabIndex = 7;
            this.btn_seleccionarProv.Text = "Seleccionar";
            this.btn_seleccionarProv.UseVisualStyleBackColor = true;
            // 
            // SeleccionarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 517);
            this.Controls.Add(this.btn_seleccionarProv);
            this.Controls.Add(this.gridProveedores);
            this.Name = "SeleccionarProveedor";
            this.Text = "Seleccionar Proveedor";
            ((System.ComponentModel.ISupportInitialize)(this.gridProveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridProveedores;
        private System.Windows.Forms.Button btn_seleccionarProv;
    }
}