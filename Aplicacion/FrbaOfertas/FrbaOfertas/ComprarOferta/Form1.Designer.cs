namespace FrbaOfertas.ComprarOferta
{
    partial class Form1
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
            this.saldoLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.clienteBox = new System.Windows.Forms.TextBox();
            this.seleccionarClienteButton = new System.Windows.Forms.Button();
            this.comprarButton = new System.Windows.Forms.Button();
            this.cantidad = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panelComprar = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidad)).BeginInit();
            this.panelComprar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 15.75F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comprar Oferta";
            // 
            // saldoLabel
            // 
            this.saldoLabel.AutoSize = true;
            this.saldoLabel.Location = new System.Drawing.Point(3, 10);
            this.saldoLabel.Name = "saldoLabel";
            this.saldoLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.saldoLabel.Size = new System.Drawing.Size(37, 23);
            this.saldoLabel.TabIndex = 1;
            this.saldoLabel.Text = "Saldo:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(219, 54);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(515, 254);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel1.Controls.Add(this.saldoLabel);
            this.flowLayoutPanel1.Controls.Add(this.clienteBox);
            this.flowLayoutPanel1.Controls.Add(this.seleccionarClienteButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 81);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(195, 110);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // clienteBox
            // 
            this.clienteBox.Enabled = false;
            this.clienteBox.Location = new System.Drawing.Point(3, 36);
            this.clienteBox.Name = "clienteBox";
            this.clienteBox.Size = new System.Drawing.Size(187, 20);
            this.clienteBox.TabIndex = 3;
            this.clienteBox.Text = "Seleccione un Cliente";
            this.clienteBox.TextChanged += new System.EventHandler(this.clienteBox_TextChanged);
            // 
            // seleccionarClienteButton
            // 
            this.seleccionarClienteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.seleccionarClienteButton.Location = new System.Drawing.Point(40, 62);
            this.seleccionarClienteButton.Name = "seleccionarClienteButton";
            this.seleccionarClienteButton.Size = new System.Drawing.Size(112, 23);
            this.seleccionarClienteButton.TabIndex = 2;
            this.seleccionarClienteButton.Text = "Seleccionar Cliente";
            this.seleccionarClienteButton.UseVisualStyleBackColor = true;
            this.seleccionarClienteButton.Click += new System.EventHandler(this.seleccionarClienteButton_Click);
            // 
            // comprarButton
            // 
            this.comprarButton.Location = new System.Drawing.Point(59, 75);
            this.comprarButton.Name = "comprarButton";
            this.comprarButton.Size = new System.Drawing.Size(75, 23);
            this.comprarButton.TabIndex = 4;
            this.comprarButton.Text = "Comprar";
            this.comprarButton.UseVisualStyleBackColor = true;
            this.comprarButton.Click += new System.EventHandler(this.comprarButton_Click);
            // 
            // cantidad
            // 
            this.cantidad.Location = new System.Drawing.Point(61, 34);
            this.cantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cantidad.Name = "cantidad";
            this.cantidad.Size = new System.Drawing.Size(131, 20);
            this.cantidad.TabIndex = 5;
            this.cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cantidad:";
            // 
            // panelComprar
            // 
            this.panelComprar.Controls.Add(this.cantidad);
            this.panelComprar.Controls.Add(this.comprarButton);
            this.panelComprar.Controls.Add(this.label2);
            this.panelComprar.Location = new System.Drawing.Point(18, 198);
            this.panelComprar.Name = "panelComprar";
            this.panelComprar.Size = new System.Drawing.Size(195, 110);
            this.panelComprar.TabIndex = 7;
            this.panelComprar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 353);
            this.Controls.Add(this.panelComprar);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidad)).EndInit();
            this.panelComprar.ResumeLayout(false);
            this.panelComprar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label saldoLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox clienteBox;
        private System.Windows.Forms.Button seleccionarClienteButton;
        private System.Windows.Forms.Button comprarButton;
        private System.Windows.Forms.NumericUpDown cantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelComprar;
    }
}