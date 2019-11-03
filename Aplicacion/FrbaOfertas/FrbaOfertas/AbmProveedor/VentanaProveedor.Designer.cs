namespace FrbaOfertas.AbmProveedor
{
    partial class VentanaProveedor
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
            this.label_cuit = new System.Windows.Forms.Label();
            this.label_rs = new System.Windows.Forms.Label();
            this.textBox_cuit = new System.Windows.Forms.TextBox();
            this.textBox_rs = new System.Windows.Forms.TextBox();
            this.gridProveedores = new System.Windows.Forms.DataGridView();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label_nombreContacto = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.textBox_nombreContacto = new System.Windows.Forms.TextBox();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.checkBox_mostrarDeshabilitados = new System.Windows.Forms.CheckBox();
            this.btn_alta = new System.Windows.Forms.Button();
            this.btn_habDeshab = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.comboBox_Rubro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "ABM Proveedor";
            // 
            // label_cuit
            // 
            this.label_cuit.AutoSize = true;
            this.label_cuit.Location = new System.Drawing.Point(119, 54);
            this.label_cuit.Name = "label_cuit";
            this.label_cuit.Size = new System.Drawing.Size(35, 13);
            this.label_cuit.TabIndex = 1;
            this.label_cuit.Text = "CUIT:";
            // 
            // label_rs
            // 
            this.label_rs.AutoSize = true;
            this.label_rs.Location = new System.Drawing.Point(103, 78);
            this.label_rs.Name = "label_rs";
            this.label_rs.Size = new System.Drawing.Size(73, 13);
            this.label_rs.TabIndex = 2;
            this.label_rs.Text = "Razón Social:";
            // 
            // textBox_cuit
            // 
            this.textBox_cuit.Location = new System.Drawing.Point(198, 47);
            this.textBox_cuit.Name = "textBox_cuit";
            this.textBox_cuit.Size = new System.Drawing.Size(111, 20);
            this.textBox_cuit.TabIndex = 3;
            // 
            // textBox_rs
            // 
            this.textBox_rs.Location = new System.Drawing.Point(198, 73);
            this.textBox_rs.Name = "textBox_rs";
            this.textBox_rs.Size = new System.Drawing.Size(111, 20);
            this.textBox_rs.TabIndex = 4;
            // 
            // gridProveedores
            // 
            this.gridProveedores.AllowUserToAddRows = false;
            this.gridProveedores.AllowUserToDeleteRows = false;
            this.gridProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProveedores.Location = new System.Drawing.Point(414, 9);
            this.gridProveedores.MultiSelect = false;
            this.gridProveedores.Name = "gridProveedores";
            this.gridProveedores.ReadOnly = true;
            this.gridProveedores.RowTemplate.ReadOnly = true;
            this.gridProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProveedores.Size = new System.Drawing.Size(304, 297);
            this.gridProveedores.TabIndex = 5;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(128, 207);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 7;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // label_nombreContacto
            // 
            this.label_nombreContacto.AutoSize = true;
            this.label_nombreContacto.Location = new System.Drawing.Point(84, 102);
            this.label_nombreContacto.Name = "label_nombreContacto";
            this.label_nombreContacto.Size = new System.Drawing.Size(108, 13);
            this.label_nombreContacto.TabIndex = 8;
            this.label_nombreContacto.Text = "Nombre de Contacto:";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(119, 128);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(35, 13);
            this.label_email.TabIndex = 9;
            this.label_email.Text = "Email:";
            // 
            // textBox_nombreContacto
            // 
            this.textBox_nombreContacto.Location = new System.Drawing.Point(198, 99);
            this.textBox_nombreContacto.Name = "textBox_nombreContacto";
            this.textBox_nombreContacto.Size = new System.Drawing.Size(111, 20);
            this.textBox_nombreContacto.TabIndex = 10;
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(198, 125);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(111, 20);
            this.textBox_email.TabIndex = 11;
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(219, 207);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(75, 23);
            this.btn_limpiar.TabIndex = 12;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // checkBox_mostrarDeshabilitados
            // 
            this.checkBox_mostrarDeshabilitados.AutoSize = true;
            this.checkBox_mostrarDeshabilitados.Location = new System.Drawing.Point(135, 184);
            this.checkBox_mostrarDeshabilitados.Name = "checkBox_mostrarDeshabilitados";
            this.checkBox_mostrarDeshabilitados.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox_mostrarDeshabilitados.Size = new System.Drawing.Size(131, 17);
            this.checkBox_mostrarDeshabilitados.TabIndex = 13;
            this.checkBox_mostrarDeshabilitados.Text = "Mostrar deshabilitados";
            this.checkBox_mostrarDeshabilitados.UseVisualStyleBackColor = true;
            // 
            // btn_alta
            // 
            this.btn_alta.Location = new System.Drawing.Point(26, 247);
            this.btn_alta.Name = "btn_alta";
            this.btn_alta.Size = new System.Drawing.Size(105, 59);
            this.btn_alta.TabIndex = 14;
            this.btn_alta.Text = "Dar Alta";
            this.btn_alta.UseVisualStyleBackColor = true;
            this.btn_alta.Click += new System.EventHandler(this.btn_alta_Click);
            // 
            // btn_habDeshab
            // 
            this.btn_habDeshab.Location = new System.Drawing.Point(137, 247);
            this.btn_habDeshab.Name = "btn_habDeshab";
            this.btn_habDeshab.Size = new System.Drawing.Size(119, 59);
            this.btn_habDeshab.TabIndex = 15;
            this.btn_habDeshab.Text = "Habilitar/Deshabilitar";
            this.btn_habDeshab.UseVisualStyleBackColor = true;
            this.btn_habDeshab.Click += new System.EventHandler(this.btn_habDeshab_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.Location = new System.Drawing.Point(262, 247);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(105, 59);
            this.btn_modificar.TabIndex = 16;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // comboBox_Rubro
            // 
            this.comboBox_Rubro.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_Rubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Rubro.FormattingEnabled = true;
            this.comboBox_Rubro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_Rubro.Location = new System.Drawing.Point(198, 151);
            this.comboBox_Rubro.Name = "comboBox_Rubro";
            this.comboBox_Rubro.Size = new System.Drawing.Size(111, 21);
            this.comboBox_Rubro.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Rubro:";
            // 
            // VentanaProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 314);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_Rubro);
            this.Controls.Add(this.btn_modificar);
            this.Controls.Add(this.btn_habDeshab);
            this.Controls.Add(this.btn_alta);
            this.Controls.Add(this.checkBox_mostrarDeshabilitados);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.textBox_nombreContacto);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_nombreContacto);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.gridProveedores);
            this.Controls.Add(this.textBox_rs);
            this.Controls.Add(this.textBox_cuit);
            this.Controls.Add(this.label_rs);
            this.Controls.Add(this.label_cuit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VentanaProveedor";
            this.Text = "ABM Proveedores";
            this.Load += new System.EventHandler(this.VentanaProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_cuit;
        private System.Windows.Forms.Label label_rs;
        private System.Windows.Forms.TextBox textBox_cuit;
        private System.Windows.Forms.TextBox textBox_rs;
        private System.Windows.Forms.DataGridView gridProveedores;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label_nombreContacto;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.TextBox textBox_nombreContacto;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.CheckBox checkBox_mostrarDeshabilitados;
        private System.Windows.Forms.Button btn_alta;
        private System.Windows.Forms.Button btn_habDeshab;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.ComboBox comboBox_Rubro;
        private System.Windows.Forms.Label label2;
    }
}