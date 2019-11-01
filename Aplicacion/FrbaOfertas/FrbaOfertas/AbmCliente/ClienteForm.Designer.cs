namespace FrbaOfertas.AbmCliente
{
    partial class ClienteForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nombreBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.apellidoBox = new System.Windows.Forms.TextBox();
            this.dniBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mailBox = new System.Windows.Forms.TextBox();
            this.telefonoBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.direccionBox = new System.Windows.Forms.TextBox();
            this.ciudadBox = new System.Windows.Forms.TextBox();
            this.codPostalBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.fechaNac = new System.Windows.Forms.DateTimePicker();
            this.guardarButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.titulo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.05785F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.94215F));
            this.tableLayoutPanel1.Controls.Add(this.nombreBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.apellidoBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dniBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.mailBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.telefonoBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.direccionBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.ciudadBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.codPostalBox, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.fechaNac, 1, 8);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(364, 235);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // nombreBox
            // 
            this.nombreBox.Location = new System.Drawing.Point(123, 3);
            this.nombreBox.Name = "nombreBox";
            this.nombreBox.Size = new System.Drawing.Size(238, 20);
            this.nombreBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido";
            // 
            // apellidoBox
            // 
            this.apellidoBox.Location = new System.Drawing.Point(123, 29);
            this.apellidoBox.Name = "apellidoBox";
            this.apellidoBox.Size = new System.Drawing.Size(238, 20);
            this.apellidoBox.TabIndex = 3;
            // 
            // dniBox
            // 
            this.dniBox.Location = new System.Drawing.Point(123, 55);
            this.dniBox.Name = "dniBox";
            this.dniBox.Size = new System.Drawing.Size(238, 20);
            this.dniBox.TabIndex = 4;
            this.dniBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dniBox_KeyDown);
            this.dniBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dniBox_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "DNI";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mail";
            // 
            // mailBox
            // 
            this.mailBox.Location = new System.Drawing.Point(123, 81);
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(238, 20);
            this.mailBox.TabIndex = 7;
            // 
            // telefonoBox
            // 
            this.telefonoBox.Location = new System.Drawing.Point(123, 107);
            this.telefonoBox.Name = "telefonoBox";
            this.telefonoBox.Size = new System.Drawing.Size(238, 20);
            this.telefonoBox.TabIndex = 8;
            this.telefonoBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.telefonoBox_KeyDown);
            this.telefonoBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telefonoBox_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Telefono";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Direccion";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Ciudad";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Cod. Postal";
            // 
            // direccionBox
            // 
            this.direccionBox.Location = new System.Drawing.Point(123, 133);
            this.direccionBox.Name = "direccionBox";
            this.direccionBox.Size = new System.Drawing.Size(238, 20);
            this.direccionBox.TabIndex = 13;
            // 
            // ciudadBox
            // 
            this.ciudadBox.Location = new System.Drawing.Point(123, 159);
            this.ciudadBox.Name = "ciudadBox";
            this.ciudadBox.Size = new System.Drawing.Size(238, 20);
            this.ciudadBox.TabIndex = 14;
            // 
            // codPostalBox
            // 
            this.codPostalBox.Location = new System.Drawing.Point(123, 185);
            this.codPostalBox.MaxLength = 5;
            this.codPostalBox.Name = "codPostalBox";
            this.codPostalBox.Size = new System.Drawing.Size(83, 20);
            this.codPostalBox.TabIndex = 15;
            this.codPostalBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codPostalBox_KeyDown);
            this.codPostalBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codPostalBox_KeyPress);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Fecha de Nacimiento";
            // 
            // fechaNac
            // 
            this.fechaNac.Location = new System.Drawing.Point(123, 211);
            this.fechaNac.MaxDate = new System.DateTime(2019, 11, 1, 0, 0, 0, 0);
            this.fechaNac.Name = "fechaNac";
            this.fechaNac.Size = new System.Drawing.Size(238, 20);
            this.fechaNac.TabIndex = 17;
            this.fechaNac.Value = new System.DateTime(2019, 11, 1, 0, 0, 0, 0);
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(274, 277);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(103, 23);
            this.guardarButton.TabIndex = 1;
            this.guardarButton.Text = "Guardar Cambios";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.Location = new System.Drawing.Point(10, 9);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(136, 17);
            this.titulo.TabIndex = 3;
            this.titulo.Text = "Modificar Cliente";
            // 
            // ClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 312);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ClienteForm";
            this.Text = "Cliente";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox nombreBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox apellidoBox;
        private System.Windows.Forms.TextBox dniBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mailBox;
        private System.Windows.Forms.TextBox telefonoBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox direccionBox;
        private System.Windows.Forms.TextBox ciudadBox;
        private System.Windows.Forms.TextBox codPostalBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker fechaNac;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label titulo;
    }
}