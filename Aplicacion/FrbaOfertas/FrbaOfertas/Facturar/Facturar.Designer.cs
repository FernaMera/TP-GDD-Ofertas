﻿namespace FrbaOfertas.Facturar
{
    partial class Facturar
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
            this.label1 = new System.Windows.Forms.Label();
            this.label_fechaHasta = new System.Windows.Forms.Label();
            this.dateTimePicker_hasta = new System.Windows.Forms.DateTimePicker();
            this.label_fechaDesde = new System.Windows.Forms.Label();
            this.dateTimePicker_desde = new System.Windows.Forms.DateTimePicker();
            this.btn_seleccionarProveedor = new System.Windows.Forms.Button();
            this.textBox_proveedor = new System.Windows.Forms.TextBox();
            this.label_proveedor = new System.Windows.Forms.Label();
            this.btn_facturar = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.dataGridView_ofertasAdquiridas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_factura = new System.Windows.Forms.TextBox();
            this.textBox_importeTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ofertasAdquiridas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Facturación";
            // 
            // label_fechaHasta
            // 
            this.label_fechaHasta.AutoSize = true;
            this.label_fechaHasta.Location = new System.Drawing.Point(48, 203);
            this.label_fechaHasta.Name = "label_fechaHasta";
            this.label_fechaHasta.Size = new System.Drawing.Size(38, 13);
            this.label_fechaHasta.TabIndex = 14;
            this.label_fechaHasta.Text = "Hasta:";
            // 
            // dateTimePicker_hasta
            // 
            this.dateTimePicker_hasta.Location = new System.Drawing.Point(149, 197);
            this.dateTimePicker_hasta.Name = "dateTimePicker_hasta";
            this.dateTimePicker_hasta.Size = new System.Drawing.Size(215, 20);
            this.dateTimePicker_hasta.TabIndex = 13;
            // 
            // label_fechaDesde
            // 
            this.label_fechaDesde.AutoSize = true;
            this.label_fechaDesde.Location = new System.Drawing.Point(28, 175);
            this.label_fechaDesde.Name = "label_fechaDesde";
            this.label_fechaDesde.Size = new System.Drawing.Size(81, 13);
            this.label_fechaDesde.TabIndex = 12;
            this.label_fechaDesde.Text = "Facturar desde:";
            // 
            // dateTimePicker_desde
            // 
            this.dateTimePicker_desde.Location = new System.Drawing.Point(149, 169);
            this.dateTimePicker_desde.Name = "dateTimePicker_desde";
            this.dateTimePicker_desde.Size = new System.Drawing.Size(215, 20);
            this.dateTimePicker_desde.TabIndex = 11;
            this.dateTimePicker_desde.Value = new System.DateTime(2019, 11, 5, 0, 0, 0, 0);
            // 
            // btn_seleccionarProveedor
            // 
            this.btn_seleccionarProveedor.Location = new System.Drawing.Point(254, 138);
            this.btn_seleccionarProveedor.Name = "btn_seleccionarProveedor";
            this.btn_seleccionarProveedor.Size = new System.Drawing.Size(75, 23);
            this.btn_seleccionarProveedor.TabIndex = 10;
            this.btn_seleccionarProveedor.Text = "Seleccionar";
            this.btn_seleccionarProveedor.UseVisualStyleBackColor = true;
            this.btn_seleccionarProveedor.Click += new System.EventHandler(this.btn_seleccionarProveedor_Click);
            // 
            // textBox_proveedor
            // 
            this.textBox_proveedor.Location = new System.Drawing.Point(148, 140);
            this.textBox_proveedor.Name = "textBox_proveedor";
            this.textBox_proveedor.ReadOnly = true;
            this.textBox_proveedor.Size = new System.Drawing.Size(100, 20);
            this.textBox_proveedor.TabIndex = 9;
            // 
            // label_proveedor
            // 
            this.label_proveedor.AutoSize = true;
            this.label_proveedor.Location = new System.Drawing.Point(38, 143);
            this.label_proveedor.Name = "label_proveedor";
            this.label_proveedor.Size = new System.Drawing.Size(59, 13);
            this.label_proveedor.TabIndex = 8;
            this.label_proveedor.Text = "Proveedor:";
            // 
            // btn_facturar
            // 
            this.btn_facturar.Location = new System.Drawing.Point(92, 265);
            this.btn_facturar.Name = "btn_facturar";
            this.btn_facturar.Size = new System.Drawing.Size(216, 35);
            this.btn_facturar.TabIndex = 16;
            this.btn_facturar.Text = "Facturar";
            this.btn_facturar.UseVisualStyleBackColor = true;
            this.btn_facturar.Click += new System.EventHandler(this.btn_facturar_Click);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(163, 306);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(75, 23);
            this.button_limpiar.TabIndex = 17;
            this.button_limpiar.Text = "Limpiar todo";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // dataGridView_ofertasAdquiridas
            // 
            this.dataGridView_ofertasAdquiridas.AllowUserToAddRows = false;
            this.dataGridView_ofertasAdquiridas.AllowUserToDeleteRows = false;
            this.dataGridView_ofertasAdquiridas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ofertasAdquiridas.Location = new System.Drawing.Point(387, 40);
            this.dataGridView_ofertasAdquiridas.Name = "dataGridView_ofertasAdquiridas";
            this.dataGridView_ofertasAdquiridas.ReadOnly = true;
            this.dataGridView_ofertasAdquiridas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ofertasAdquiridas.Size = new System.Drawing.Size(347, 280);
            this.dataGridView_ofertasAdquiridas.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Factura:";
            // 
            // textBox_factura
            // 
            this.textBox_factura.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox_factura.Location = new System.Drawing.Point(438, 12);
            this.textBox_factura.Name = "textBox_factura";
            this.textBox_factura.ReadOnly = true;
            this.textBox_factura.Size = new System.Drawing.Size(100, 20);
            this.textBox_factura.TabIndex = 19;
            // 
            // textBox_importeTotal
            // 
            this.textBox_importeTotal.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox_importeTotal.Location = new System.Drawing.Point(634, 328);
            this.textBox_importeTotal.Name = "textBox_importeTotal";
            this.textBox_importeTotal.ReadOnly = true;
            this.textBox_importeTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_importeTotal.Size = new System.Drawing.Size(100, 20);
            this.textBox_importeTotal.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(556, 331);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Importe Total:";
            // 
            // Facturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 353);
            this.Controls.Add(this.textBox_importeTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_factura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.btn_facturar);
            this.Controls.Add(this.dataGridView_ofertasAdquiridas);
            this.Controls.Add(this.label_fechaHasta);
            this.Controls.Add(this.dateTimePicker_hasta);
            this.Controls.Add(this.label_fechaDesde);
            this.Controls.Add(this.dateTimePicker_desde);
            this.Controls.Add(this.btn_seleccionarProveedor);
            this.Controls.Add(this.textBox_proveedor);
            this.Controls.Add(this.label_proveedor);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Facturar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ofertasAdquiridas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_fechaHasta;
        private System.Windows.Forms.DateTimePicker dateTimePicker_hasta;
        private System.Windows.Forms.Label label_fechaDesde;
        private System.Windows.Forms.DateTimePicker dateTimePicker_desde;
        private System.Windows.Forms.Button btn_seleccionarProveedor;
        private System.Windows.Forms.TextBox textBox_proveedor;
        private System.Windows.Forms.Label label_proveedor;
        private System.Windows.Forms.Button btn_facturar;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.DataGridView dataGridView_ofertasAdquiridas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_factura;
        private System.Windows.Forms.TextBox textBox_importeTotal;
        private System.Windows.Forms.Label label3;

    }
}