namespace FrbaOfertas.AbmRol
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.nuevoRolButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRol = new System.Windows.Forms.TableLayoutPanel();
            this.nombreRolBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.funcionesBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.estadoRolLabel = new System.Windows.Forms.Label();
            this.guardarButton = new System.Windows.Forms.Button();
            this.guardarModButton = new System.Windows.Forms.Button();
            this.inhabilitarButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelRol.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 51);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(152, 290);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // nuevoRolButton
            // 
            this.nuevoRolButton.Location = new System.Drawing.Point(170, 51);
            this.nuevoRolButton.Name = "nuevoRolButton";
            this.nuevoRolButton.Size = new System.Drawing.Size(123, 23);
            this.nuevoRolButton.TabIndex = 1;
            this.nuevoRolButton.Text = "Nuevo Rol";
            this.nuevoRolButton.UseVisualStyleBackColor = true;
            this.nuevoRolButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(170, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Modificar Rol";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "ABM Rol";
            // 
            // panelRol
            // 
            this.panelRol.ColumnCount = 2;
            this.panelRol.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelRol.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelRol.Controls.Add(this.nombreRolBox, 1, 0);
            this.panelRol.Controls.Add(this.label2, 0, 0);
            this.panelRol.Controls.Add(this.funcionesBox, 1, 2);
            this.panelRol.Controls.Add(this.label4, 0, 2);
            this.panelRol.Controls.Add(this.label3, 0, 1);
            this.panelRol.Controls.Add(this.estadoRolLabel, 1, 1);
            this.panelRol.Location = new System.Drawing.Point(300, 51);
            this.panelRol.Name = "panelRol";
            this.panelRol.RowCount = 3;
            this.panelRol.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelRol.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelRol.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelRol.Size = new System.Drawing.Size(434, 257);
            this.panelRol.TabIndex = 5;
            this.panelRol.Visible = false;
            // 
            // nombreRolBox
            // 
            this.nombreRolBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nombreRolBox.Enabled = false;
            this.nombreRolBox.Location = new System.Drawing.Point(93, 3);
            this.nombreRolBox.Name = "nombreRolBox";
            this.nombreRolBox.Size = new System.Drawing.Size(169, 20);
            this.nombreRolBox.TabIndex = 0;
            this.nombreRolBox.Text = "asfaagdagsdg";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // funcionesBox
            // 
            this.funcionesBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.funcionesBox.BackColor = System.Drawing.SystemColors.Control;
            this.funcionesBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.funcionesBox.Enabled = false;
            this.funcionesBox.FormattingEnabled = true;
            this.funcionesBox.Items.AddRange(new object[] {
            "ABM Cliente",
            "ABM Proveedor",
            "ABM Rol",
            "Carga Credito",
            "Comprar Oferta",
            "Crear Oferta",
            "Consumir Oferta",
            "Facturacion",
            "Listado Estadistico"});
            this.funcionesBox.Location = new System.Drawing.Point(93, 76);
            this.funcionesBox.Name = "funcionesBox";
            this.funcionesBox.Size = new System.Drawing.Size(338, 150);
            this.funcionesBox.TabIndex = 4;
            this.funcionesBox.ThreeDCheckBoxes = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 46);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.label4.Size = new System.Drawing.Size(84, 53);
            this.label4.TabIndex = 5;
            this.label4.Text = "Funcionalidades";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Habilitado";
            // 
            // estadoRolLabel
            // 
            this.estadoRolLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.estadoRolLabel.AutoSize = true;
            this.estadoRolLabel.Location = new System.Drawing.Point(93, 29);
            this.estadoRolLabel.Name = "estadoRolLabel";
            this.estadoRolLabel.Size = new System.Drawing.Size(36, 13);
            this.estadoRolLabel.TabIndex = 7;
            this.estadoRolLabel.Text = "Si--No";
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(4, 3);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(75, 23);
            this.guardarButton.TabIndex = 6;
            this.guardarButton.Text = "Guardar";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Visible = false;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // guardarModButton
            // 
            this.guardarModButton.Location = new System.Drawing.Point(85, 3);
            this.guardarModButton.Name = "guardarModButton";
            this.guardarModButton.Size = new System.Drawing.Size(75, 23);
            this.guardarModButton.TabIndex = 7;
            this.guardarModButton.Text = "Guardar";
            this.guardarModButton.UseVisualStyleBackColor = true;
            this.guardarModButton.Visible = false;
            this.guardarModButton.Click += new System.EventHandler(this.guardarModButton_Click);
            // 
            // inhabilitarButton
            // 
            this.inhabilitarButton.Enabled = false;
            this.inhabilitarButton.Location = new System.Drawing.Point(170, 109);
            this.inhabilitarButton.Name = "inhabilitarButton";
            this.inhabilitarButton.Size = new System.Drawing.Size(122, 23);
            this.inhabilitarButton.TabIndex = 8;
            this.inhabilitarButton.Text = "Habilitar/Inhabilitar";
            this.inhabilitarButton.UseVisualStyleBackColor = true;
            this.inhabilitarButton.Click += new System.EventHandler(this.inhabilitarButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.guardarModButton);
            this.flowLayoutPanel1.Controls.Add(this.guardarButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(571, 314);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(163, 27);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 353);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.inhabilitarButton);
            this.Controls.Add(this.panelRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.nuevoRolButton);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelRol.ResumeLayout(false);
            this.panelRol.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button nuevoRolButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel panelRol;
        private System.Windows.Forms.TextBox nombreRolBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox funcionesBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button guardarModButton;
        private System.Windows.Forms.Button inhabilitarButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label estadoRolLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}