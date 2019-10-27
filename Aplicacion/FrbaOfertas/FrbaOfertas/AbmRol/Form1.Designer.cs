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
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRol = new System.Windows.Forms.TableLayoutPanel();
            this.nombreRolBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.funcionesBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.guardarButton = new System.Windows.Forms.Button();
            this.panelRol.SuspendLayout();
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
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(170, 109);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Eliminar Rol";
            this.button3.UseVisualStyleBackColor = true;
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
            this.panelRol.Controls.Add(this.funcionesBox, 1, 1);
            this.panelRol.Controls.Add(this.label4, 0, 1);
            this.panelRol.Location = new System.Drawing.Point(300, 51);
            this.panelRol.Name = "panelRol";
            this.panelRol.RowCount = 2;
            this.panelRol.RowStyles.Add(new System.Windows.Forms.RowStyle());
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
            this.funcionesBox.Location = new System.Drawing.Point(93, 66);
            this.funcionesBox.Name = "funcionesBox";
            this.funcionesBox.Size = new System.Drawing.Size(338, 150);
            this.funcionesBox.TabIndex = 4;
            this.funcionesBox.ThreeDCheckBoxes = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.label4.Size = new System.Drawing.Size(84, 53);
            this.label4.TabIndex = 5;
            this.label4.Text = "Funcionalidades";
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(659, 318);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(75, 23);
            this.guardarButton.TabIndex = 6;
            this.guardarButton.Text = "Guardar";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 353);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.panelRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.nuevoRolButton);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelRol.ResumeLayout(false);
            this.panelRol.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button nuevoRolButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel panelRol;
        private System.Windows.Forms.TextBox nombreRolBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox funcionesBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button guardarButton;
    }
}