namespace FrbaOfertas.CambiarContraseña
{
    partial class CambiarContrasena
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
            this.panelContrasenas = new System.Windows.Forms.Panel();
            this.cambiarContraButton = new System.Windows.Forms.Button();
            this.cambiarContraUsuarioButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.viejaPassBox = new System.Windows.Forms.TextBox();
            this.nuevaPassBox = new System.Windows.Forms.TextBox();
            this.repetidaPassBox = new System.Windows.Forms.TextBox();
            this.usuarioBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.seleccionUsuarioButton = new System.Windows.Forms.Button();
            this.panelSeleccionUsuario = new System.Windows.Forms.Panel();
            this.guardarCambiosButton = new System.Windows.Forms.Button();
            this.panelContrasenas.SuspendLayout();
            this.panelSeleccionUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 15.75F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuracion";
            // 
            // panelContrasenas
            // 
            this.panelContrasenas.Controls.Add(this.guardarCambiosButton);
            this.panelContrasenas.Controls.Add(this.panelSeleccionUsuario);
            this.panelContrasenas.Controls.Add(this.repetidaPassBox);
            this.panelContrasenas.Controls.Add(this.nuevaPassBox);
            this.panelContrasenas.Controls.Add(this.viejaPassBox);
            this.panelContrasenas.Controls.Add(this.label4);
            this.panelContrasenas.Controls.Add(this.label3);
            this.panelContrasenas.Controls.Add(this.label2);
            this.panelContrasenas.Location = new System.Drawing.Point(262, 57);
            this.panelContrasenas.Name = "panelContrasenas";
            this.panelContrasenas.Size = new System.Drawing.Size(371, 284);
            this.panelContrasenas.TabIndex = 1;
            this.panelContrasenas.Visible = false;
            // 
            // cambiarContraButton
            // 
            this.cambiarContraButton.Location = new System.Drawing.Point(35, 70);
            this.cambiarContraButton.Name = "cambiarContraButton";
            this.cambiarContraButton.Size = new System.Drawing.Size(129, 23);
            this.cambiarContraButton.TabIndex = 2;
            this.cambiarContraButton.Text = "Cambiar Contraseña";
            this.cambiarContraButton.UseVisualStyleBackColor = true;
            this.cambiarContraButton.Click += new System.EventHandler(this.cambiarContraButton_Click);
            // 
            // cambiarContraUsuarioButton
            // 
            this.cambiarContraUsuarioButton.Location = new System.Drawing.Point(35, 111);
            this.cambiarContraUsuarioButton.Name = "cambiarContraUsuarioButton";
            this.cambiarContraUsuarioButton.Size = new System.Drawing.Size(129, 37);
            this.cambiarContraUsuarioButton.TabIndex = 3;
            this.cambiarContraUsuarioButton.Text = "Cambiar Contraseña a otro Usuario";
            this.cambiarContraUsuarioButton.UseVisualStyleBackColor = true;
            this.cambiarContraUsuarioButton.Click += new System.EventHandler(this.cambiarContraUsuarioButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Contraseña Actual:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Contraseña Nueva:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Repetir Contraseña Nueva:";
            // 
            // viejaPassBox
            // 
            this.viejaPassBox.Location = new System.Drawing.Point(173, 15);
            this.viejaPassBox.Name = "viejaPassBox";
            this.viejaPassBox.Size = new System.Drawing.Size(165, 20);
            this.viejaPassBox.TabIndex = 3;
            this.viejaPassBox.UseSystemPasswordChar = true;
            // 
            // nuevaPassBox
            // 
            this.nuevaPassBox.Location = new System.Drawing.Point(173, 66);
            this.nuevaPassBox.Name = "nuevaPassBox";
            this.nuevaPassBox.Size = new System.Drawing.Size(165, 20);
            this.nuevaPassBox.TabIndex = 4;
            this.nuevaPassBox.UseSystemPasswordChar = true;
            // 
            // repetidaPassBox
            // 
            this.repetidaPassBox.Location = new System.Drawing.Point(173, 95);
            this.repetidaPassBox.Name = "repetidaPassBox";
            this.repetidaPassBox.Size = new System.Drawing.Size(165, 20);
            this.repetidaPassBox.TabIndex = 5;
            this.repetidaPassBox.UseSystemPasswordChar = true;
            // 
            // usuarioBox
            // 
            this.usuarioBox.Enabled = false;
            this.usuarioBox.Location = new System.Drawing.Point(139, 3);
            this.usuarioBox.Name = "usuarioBox";
            this.usuarioBox.Size = new System.Drawing.Size(165, 20);
            this.usuarioBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Usuario:";
            // 
            // seleccionUsuarioButton
            // 
            this.seleccionUsuarioButton.Location = new System.Drawing.Point(139, 29);
            this.seleccionUsuarioButton.Name = "seleccionUsuarioButton";
            this.seleccionUsuarioButton.Size = new System.Drawing.Size(165, 23);
            this.seleccionUsuarioButton.TabIndex = 8;
            this.seleccionUsuarioButton.Text = "Seleccionar Usuario";
            this.seleccionUsuarioButton.UseVisualStyleBackColor = true;
            this.seleccionUsuarioButton.Click += new System.EventHandler(this.seleccionUsuarioButton_Click);
            // 
            // panelSeleccionUsuario
            // 
            this.panelSeleccionUsuario.Controls.Add(this.usuarioBox);
            this.panelSeleccionUsuario.Controls.Add(this.label5);
            this.panelSeleccionUsuario.Controls.Add(this.seleccionUsuarioButton);
            this.panelSeleccionUsuario.Location = new System.Drawing.Point(34, 136);
            this.panelSeleccionUsuario.Name = "panelSeleccionUsuario";
            this.panelSeleccionUsuario.Size = new System.Drawing.Size(313, 61);
            this.panelSeleccionUsuario.TabIndex = 9;
            this.panelSeleccionUsuario.Visible = false;
            // 
            // guardarCambiosButton
            // 
            this.guardarCambiosButton.Location = new System.Drawing.Point(104, 216);
            this.guardarCambiosButton.Name = "guardarCambiosButton";
            this.guardarCambiosButton.Size = new System.Drawing.Size(152, 23);
            this.guardarCambiosButton.TabIndex = 10;
            this.guardarCambiosButton.Text = "Guardar Cambios";
            this.guardarCambiosButton.UseVisualStyleBackColor = true;
            this.guardarCambiosButton.Click += new System.EventHandler(this.guardarCambiosButton_Click);
            // 
            // CambiarContrasena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 353);
            this.Controls.Add(this.cambiarContraUsuarioButton);
            this.Controls.Add(this.cambiarContraButton);
            this.Controls.Add(this.panelContrasenas);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CambiarContrasena";
            this.Text = "CambiarContrasena";
            this.panelContrasenas.ResumeLayout(false);
            this.panelContrasenas.PerformLayout();
            this.panelSeleccionUsuario.ResumeLayout(false);
            this.panelSeleccionUsuario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelContrasenas;
        private System.Windows.Forms.Button cambiarContraButton;
        private System.Windows.Forms.Button cambiarContraUsuarioButton;
        private System.Windows.Forms.TextBox repetidaPassBox;
        private System.Windows.Forms.TextBox nuevaPassBox;
        private System.Windows.Forms.TextBox viejaPassBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox usuarioBox;
        private System.Windows.Forms.Panel panelSeleccionUsuario;
        private System.Windows.Forms.Button seleccionUsuarioButton;
        private System.Windows.Forms.Button guardarCambiosButton;
    }
}