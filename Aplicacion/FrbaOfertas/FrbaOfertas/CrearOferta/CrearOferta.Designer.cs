namespace FrbaOfertas.CrearOferta
{
    partial class CrearOferta
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
            this.textBox_proveedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_proveedor = new System.Windows.Forms.Label();
            this.btn_seleccionarProveedor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_proveedor
            // 
            this.textBox_proveedor.Location = new System.Drawing.Point(83, 59);
            this.textBox_proveedor.Name = "textBox_proveedor";
            this.textBox_proveedor.ReadOnly = true;
            this.textBox_proveedor.Size = new System.Drawing.Size(100, 20);
            this.textBox_proveedor.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Crear Oferta";
            // 
            // label_proveedor
            // 
            this.label_proveedor.AutoSize = true;
            this.label_proveedor.Location = new System.Drawing.Point(18, 62);
            this.label_proveedor.Name = "label_proveedor";
            this.label_proveedor.Size = new System.Drawing.Size(59, 13);
            this.label_proveedor.TabIndex = 1;
            this.label_proveedor.Text = "Proveedor:";
            // 
            // btn_seleccionarProveedor
            // 
            this.btn_seleccionarProveedor.Location = new System.Drawing.Point(189, 57);
            this.btn_seleccionarProveedor.Name = "btn_seleccionarProveedor";
            this.btn_seleccionarProveedor.Size = new System.Drawing.Size(75, 23);
            this.btn_seleccionarProveedor.TabIndex = 3;
            this.btn_seleccionarProveedor.Text = "Seleccionar";
            this.btn_seleccionarProveedor.UseVisualStyleBackColor = true;
            this.btn_seleccionarProveedor.Click += new System.EventHandler(this.seleccionarProveedor_Click);
            // 
            // CrearOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 353);
            this.Controls.Add(this.btn_seleccionarProveedor);
            this.Controls.Add(this.textBox_proveedor);
            this.Controls.Add(this.label_proveedor);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CrearOferta";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_proveedor;
        private System.Windows.Forms.Button btn_seleccionarProveedor;
        private System.Windows.Forms.TextBox textBox_proveedor;
    }
}