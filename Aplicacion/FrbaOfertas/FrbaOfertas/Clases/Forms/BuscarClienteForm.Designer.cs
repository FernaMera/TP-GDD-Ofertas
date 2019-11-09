namespace FrbaOfertas.Clases.Forms
{
    partial class BuscarCliente
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nombreBox = new System.Windows.Forms.TextBox();
            this.apellidoBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dniBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mailBox = new System.Windows.Forms.TextBox();
            this.buscarButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.seleccionarButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccionar Cliente";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.nombreBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.apellidoBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dniBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.mailBox, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 44);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(189, 106);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // nombreBox
            // 
            this.nombreBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nombreBox.Location = new System.Drawing.Point(57, 3);
            this.nombreBox.Name = "nombreBox";
            this.nombreBox.Size = new System.Drawing.Size(125, 20);
            this.nombreBox.TabIndex = 0;
            // 
            // apellidoBox
            // 
            this.apellidoBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.apellidoBox.Location = new System.Drawing.Point(57, 29);
            this.apellidoBox.Name = "apellidoBox";
            this.apellidoBox.Size = new System.Drawing.Size(125, 20);
            this.apellidoBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "DNI";
            // 
            // dniBox
            // 
            this.dniBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dniBox.Location = new System.Drawing.Point(57, 55);
            this.dniBox.Name = "dniBox";
            this.dniBox.Size = new System.Drawing.Size(125, 20);
            this.dniBox.TabIndex = 5;
            this.dniBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dniBox_KeyDown);
            this.dniBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dniBox_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Mail";
            // 
            // mailBox
            // 
            this.mailBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mailBox.Location = new System.Drawing.Point(56, 82);
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(126, 20);
            this.mailBox.TabIndex = 7;
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(116, 169);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(91, 23);
            this.buscarButton.TabIndex = 4;
            this.buscarButton.Text = "Buscar Cliente";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(213, 44);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(521, 268);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.Location = new System.Drawing.Point(18, 169);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(92, 23);
            this.LimpiarButton.TabIndex = 6;
            this.LimpiarButton.Text = "Limpiar";
            this.LimpiarButton.UseVisualStyleBackColor = true;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // seleccionarButton
            // 
            this.seleccionarButton.Enabled = false;
            this.seleccionarButton.Location = new System.Drawing.Point(45, 279);
            this.seleccionarButton.Name = "seleccionarButton";
            this.seleccionarButton.Size = new System.Drawing.Size(123, 23);
            this.seleccionarButton.TabIndex = 7;
            this.seleccionarButton.Text = "Seleccionar";
            this.seleccionarButton.UseVisualStyleBackColor = true;
            this.seleccionarButton.Click += new System.EventHandler(this.seleccionarButton_Click);
            // 
            // BuscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 324);
            this.Controls.Add(this.seleccionarButton);
            this.Controls.Add(this.LimpiarButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buscarButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BuscarCliente";
            this.Text = "Seleccionar Cliente";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox nombreBox;
        private System.Windows.Forms.TextBox apellidoBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dniBox;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button LimpiarButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mailBox;
        private System.Windows.Forms.Button seleccionarButton;
    }
}