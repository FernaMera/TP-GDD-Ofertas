namespace FrbaOfertas.CargaCredito
{
    partial class CargaCredito
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
            this.montoBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tipoPagoBox = new System.Windows.Forms.ComboBox();
            this.clienteLabel = new System.Windows.Forms.Label();
            this.clienteBox = new System.Windows.Forms.TextBox();
            this.panelTarjeta = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numeroBox = new System.Windows.Forms.TextBox();
            this.codigoBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.titularBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.fechaVencimientoPicker = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTarjeta.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cargar Credito";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.65704F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.34296F));
            this.tableLayoutPanel1.Controls.Add(this.montoBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tipoPagoBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.clienteLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.clienteBox, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(277, 82);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // montoBox
            // 
            this.montoBox.Location = new System.Drawing.Point(98, 3);
            this.montoBox.Name = "montoBox";
            this.montoBox.Size = new System.Drawing.Size(176, 20);
            this.montoBox.TabIndex = 0;
            this.montoBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.montoBox_KeyDown);
            this.montoBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeroBox_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Monto";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de Pago";
            // 
            // tipoPagoBox
            // 
            this.tipoPagoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoPagoBox.FormattingEnabled = true;
            this.tipoPagoBox.Items.AddRange(new object[] {
            "Tarj. Credito",
            "Tarj. Debito",
            "Efectivo"});
            this.tipoPagoBox.Location = new System.Drawing.Point(98, 29);
            this.tipoPagoBox.Name = "tipoPagoBox";
            this.tipoPagoBox.Size = new System.Drawing.Size(176, 21);
            this.tipoPagoBox.TabIndex = 3;
            this.tipoPagoBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // clienteLabel
            // 
            this.clienteLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clienteLabel.AutoSize = true;
            this.clienteLabel.Location = new System.Drawing.Point(28, 61);
            this.clienteLabel.Name = "clienteLabel";
            this.clienteLabel.Size = new System.Drawing.Size(39, 13);
            this.clienteLabel.TabIndex = 4;
            this.clienteLabel.Text = "Cliente";
            // 
            // clienteBox
            // 
            this.clienteBox.Enabled = false;
            this.clienteBox.Location = new System.Drawing.Point(98, 56);
            this.clienteBox.Name = "clienteBox";
            this.clienteBox.Size = new System.Drawing.Size(176, 20);
            this.clienteBox.TabIndex = 5;
            // 
            // panelTarjeta
            // 
            this.panelTarjeta.ColumnCount = 2;
            this.panelTarjeta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.27103F));
            this.panelTarjeta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.72897F));
            this.panelTarjeta.Controls.Add(this.label7, 0, 0);
            this.panelTarjeta.Controls.Add(this.label8, 0, 1);
            this.panelTarjeta.Controls.Add(this.label9, 0, 2);
            this.panelTarjeta.Controls.Add(this.numeroBox, 1, 0);
            this.panelTarjeta.Controls.Add(this.codigoBox, 1, 2);
            this.panelTarjeta.Controls.Add(this.label11, 0, 3);
            this.panelTarjeta.Controls.Add(this.titularBox, 1, 3);
            this.panelTarjeta.Controls.Add(this.fechaVencimientoPicker, 1, 1);
            this.panelTarjeta.Location = new System.Drawing.Point(3, 3);
            this.panelTarjeta.Name = "panelTarjeta";
            this.panelTarjeta.RowCount = 4;
            this.panelTarjeta.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelTarjeta.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelTarjeta.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelTarjeta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelTarjeta.Size = new System.Drawing.Size(428, 104);
            this.panelTarjeta.TabIndex = 3;
            this.panelTarjeta.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Numero Tarjeta";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Fecha de Vencimiento";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Cod. Seguridad";
            // 
            // numeroBox
            // 
            this.numeroBox.Location = new System.Drawing.Point(124, 3);
            this.numeroBox.Name = "numeroBox";
            this.numeroBox.Size = new System.Drawing.Size(301, 20);
            this.numeroBox.TabIndex = 3;
            this.numeroBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numeroBox_KeyDown);
            this.numeroBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeroBox_KeyPress);
            // 
            // codigoBox
            // 
            this.codigoBox.Location = new System.Drawing.Point(124, 55);
            this.codigoBox.Name = "codigoBox";
            this.codigoBox.Size = new System.Drawing.Size(301, 20);
            this.codigoBox.TabIndex = 5;
            this.codigoBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numeroBox_KeyDown);
            this.codigoBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeroBox_KeyPress);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Nombre Titular";
            // 
            // titularBox
            // 
            this.titularBox.Location = new System.Drawing.Point(124, 81);
            this.titularBox.Name = "titularBox";
            this.titularBox.Size = new System.Drawing.Size(301, 20);
            this.titularBox.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(656, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cargar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panelTarjeta);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(296, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(438, 262);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(149, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Seleccionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fechaVencimientoPicker
            // 
            this.fechaVencimientoPicker.Location = new System.Drawing.Point(124, 29);
            this.fechaVencimientoPicker.Name = "fechaVencimientoPicker";
            this.fechaVencimientoPicker.Size = new System.Drawing.Size(301, 20);
            this.fechaVencimientoPicker.TabIndex = 8;
            // 
            // CargaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 353);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CargaCredito";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelTarjeta.ResumeLayout(false);
            this.panelTarjeta.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox montoBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox tipoPagoBox;
        private System.Windows.Forms.TableLayoutPanel panelTarjeta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox numeroBox;
        private System.Windows.Forms.TextBox codigoBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label clienteLabel;
        private System.Windows.Forms.TextBox clienteBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox titularBox;
        private System.Windows.Forms.DateTimePicker fechaVencimientoPicker;
    }
}