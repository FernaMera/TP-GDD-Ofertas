namespace FrbaOfertas.ListadoEstadistico
{
    partial class ListadoEstadistico
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
            this.labelAño = new System.Windows.Forms.Label();
            this.textBoxAño = new System.Windows.Forms.TextBox();
            this.labelSemestre = new System.Windows.Forms.Label();
            this.comboSemestre = new System.Windows.Forms.ComboBox();
            this.labelConsulta = new System.Windows.Forms.Label();
            this.comboConsulta = new System.Windows.Forms.ComboBox();
            this.buscar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.listado = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.listado)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAño
            // 
            this.labelAño.AutoSize = true;
            this.labelAño.Location = new System.Drawing.Point(31, 12);
            this.labelAño.Name = "labelAño";
            this.labelAño.Size = new System.Drawing.Size(29, 13);
            this.labelAño.TabIndex = 0;
            this.labelAño.Text = "Año:";
            // 
            // textBoxAño
            // 
            this.textBoxAño.Location = new System.Drawing.Point(90, 7);
            this.textBoxAño.Name = "textBoxAño";
            this.textBoxAño.Size = new System.Drawing.Size(149, 20);
            this.textBoxAño.TabIndex = 1;
            // 
            // labelSemestre
            // 
            this.labelSemestre.AutoSize = true;
            this.labelSemestre.Location = new System.Drawing.Point(30, 46);
            this.labelSemestre.Name = "labelSemestre";
            this.labelSemestre.Size = new System.Drawing.Size(54, 13);
            this.labelSemestre.TabIndex = 2;
            this.labelSemestre.Text = "Semestre:";
            // 
            // comboSemestre
            // 
            this.comboSemestre.FormattingEnabled = true;
            this.comboSemestre.Location = new System.Drawing.Point(90, 43);
            this.comboSemestre.Name = "comboSemestre";
            this.comboSemestre.Size = new System.Drawing.Size(149, 21);
            this.comboSemestre.TabIndex = 3;
            // 
            // labelConsulta
            // 
            this.labelConsulta.AutoSize = true;
            this.labelConsulta.Location = new System.Drawing.Point(30, 87);
            this.labelConsulta.Name = "labelConsulta";
            this.labelConsulta.Size = new System.Drawing.Size(51, 13);
            this.labelConsulta.TabIndex = 4;
            this.labelConsulta.Text = "Consulta:";
            // 
            // comboConsulta
            // 
            this.comboConsulta.FormattingEnabled = true;
            this.comboConsulta.Location = new System.Drawing.Point(90, 84);
            this.comboConsulta.Name = "comboConsulta";
            this.comboConsulta.Size = new System.Drawing.Size(371, 21);
            this.comboConsulta.TabIndex = 5;
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(133, 111);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(106, 22);
            this.buscar.TabIndex = 6;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(33, 111);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(94, 22);
            this.limpiar.TabIndex = 7;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // listado
            // 
            this.listado.AllowUserToAddRows = false;
            this.listado.AllowUserToDeleteRows = false;
            this.listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listado.Location = new System.Drawing.Point(34, 139);
            this.listado.Name = "listado";
            this.listado.ReadOnly = true;
            this.listado.RowHeadersVisible = false;
            this.listado.Size = new System.Drawing.Size(438, 137);
            this.listado.TabIndex = 8;
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 291);
            this.Controls.Add(this.listado);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.comboConsulta);
            this.Controls.Add(this.labelConsulta);
            this.Controls.Add(this.comboSemestre);
            this.Controls.Add(this.labelSemestre);
            this.Controls.Add(this.textBoxAño);
            this.Controls.Add(this.labelAño);
            this.Name = "ListadoEstadistico";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.listado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAño;
        private System.Windows.Forms.TextBox textBoxAño;
        private System.Windows.Forms.Label labelSemestre;
        private System.Windows.Forms.ComboBox comboSemestre;
        private System.Windows.Forms.Label labelConsulta;
        private System.Windows.Forms.ComboBox comboConsulta;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.DataGridView listado;
    }
}