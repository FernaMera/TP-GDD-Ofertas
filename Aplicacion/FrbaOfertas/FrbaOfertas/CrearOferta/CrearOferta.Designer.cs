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
            this.dateTimePicker_publi = new System.Windows.Forms.DateTimePicker();
            this.label_fechaPubli = new System.Windows.Forms.Label();
            this.label_fechaVenc = new System.Windows.Forms.Label();
            this.dateTimePicker_venc = new System.Windows.Forms.DateTimePicker();
            this.label_precioLista = new System.Windows.Forms.Label();
            this.label_precioOferta = new System.Windows.Forms.Label();
            this.label_cantDisp = new System.Windows.Forms.Label();
            this.label_maxPorCliente = new System.Windows.Forms.Label();
            this.btn_crearOferta = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.numericUpDown_precioLista = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_precioOferta = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_cantDisp = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_cantMax = new System.Windows.Forms.NumericUpDown();
            this.richTextBox_descripcion = new System.Windows.Forms.RichTextBox();
            this.label_descripcion = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_precioLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_precioOferta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cantDisp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cantMax)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_proveedor
            // 
            this.textBox_proveedor.Location = new System.Drawing.Point(164, 63);
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
            this.label_proveedor.Location = new System.Drawing.Point(54, 66);
            this.label_proveedor.Name = "label_proveedor";
            this.label_proveedor.Size = new System.Drawing.Size(59, 13);
            this.label_proveedor.TabIndex = 1;
            this.label_proveedor.Text = "Proveedor:";
            // 
            // btn_seleccionarProveedor
            // 
            this.btn_seleccionarProveedor.Location = new System.Drawing.Point(270, 61);
            this.btn_seleccionarProveedor.Name = "btn_seleccionarProveedor";
            this.btn_seleccionarProveedor.Size = new System.Drawing.Size(75, 23);
            this.btn_seleccionarProveedor.TabIndex = 3;
            this.btn_seleccionarProveedor.Text = "Seleccionar";
            this.btn_seleccionarProveedor.UseVisualStyleBackColor = true;
            this.btn_seleccionarProveedor.Click += new System.EventHandler(this.seleccionarProveedor_Click);
            // 
            // dateTimePicker_publi
            // 
            this.dateTimePicker_publi.Location = new System.Drawing.Point(164, 91);
            this.dateTimePicker_publi.Name = "dateTimePicker_publi";
            this.dateTimePicker_publi.Size = new System.Drawing.Size(215, 20);
            this.dateTimePicker_publi.TabIndex = 4;
            this.dateTimePicker_publi.Value = new System.DateTime(2019, 11, 5, 0, 0, 0, 0);
            // 
            // label_fechaPubli
            // 
            this.label_fechaPubli.AutoSize = true;
            this.label_fechaPubli.Location = new System.Drawing.Point(27, 97);
            this.label_fechaPubli.Name = "label_fechaPubli";
            this.label_fechaPubli.Size = new System.Drawing.Size(112, 13);
            this.label_fechaPubli.TabIndex = 5;
            this.label_fechaPubli.Text = "Fecha de publicación:";
            // 
            // label_fechaVenc
            // 
            this.label_fechaVenc.AutoSize = true;
            this.label_fechaVenc.Location = new System.Drawing.Point(27, 125);
            this.label_fechaVenc.Name = "label_fechaVenc";
            this.label_fechaVenc.Size = new System.Drawing.Size(115, 13);
            this.label_fechaVenc.TabIndex = 7;
            this.label_fechaVenc.Text = "Fecha de vencimiento:";
            // 
            // dateTimePicker_venc
            // 
            this.dateTimePicker_venc.Location = new System.Drawing.Point(164, 119);
            this.dateTimePicker_venc.Name = "dateTimePicker_venc";
            this.dateTimePicker_venc.Size = new System.Drawing.Size(215, 20);
            this.dateTimePicker_venc.TabIndex = 6;
            // 
            // label_precioLista
            // 
            this.label_precioLista.AutoSize = true;
            this.label_precioLista.Location = new System.Drawing.Point(54, 157);
            this.label_precioLista.Name = "label_precioLista";
            this.label_precioLista.Size = new System.Drawing.Size(76, 13);
            this.label_precioLista.TabIndex = 8;
            this.label_precioLista.Text = "Precio de lista:";
            // 
            // label_precioOferta
            // 
            this.label_precioOferta.AutoSize = true;
            this.label_precioOferta.Location = new System.Drawing.Point(45, 183);
            this.label_precioOferta.Name = "label_precioOferta";
            this.label_precioOferta.Size = new System.Drawing.Size(85, 13);
            this.label_precioOferta.TabIndex = 9;
            this.label_precioOferta.Text = "Precio de oferta:";
            // 
            // label_cantDisp
            // 
            this.label_cantDisp.AutoSize = true;
            this.label_cantDisp.Location = new System.Drawing.Point(40, 212);
            this.label_cantDisp.Name = "label_cantDisp";
            this.label_cantDisp.Size = new System.Drawing.Size(102, 13);
            this.label_cantDisp.TabIndex = 10;
            this.label_cantDisp.Text = "Cantidad disponible:";
            // 
            // label_maxPorCliente
            // 
            this.label_maxPorCliente.AutoSize = true;
            this.label_maxPorCliente.Location = new System.Drawing.Point(18, 243);
            this.label_maxPorCliente.Name = "label_maxPorCliente";
            this.label_maxPorCliente.Size = new System.Drawing.Size(142, 13);
            this.label_maxPorCliente.TabIndex = 11;
            this.label_maxPorCliente.Text = "Cantidad máxima por cliente:";
            // 
            // btn_crearOferta
            // 
            this.btn_crearOferta.Location = new System.Drawing.Point(270, 291);
            this.btn_crearOferta.Name = "btn_crearOferta";
            this.btn_crearOferta.Size = new System.Drawing.Size(75, 23);
            this.btn_crearOferta.TabIndex = 16;
            this.btn_crearOferta.Text = "Crear oferta";
            this.btn_crearOferta.UseVisualStyleBackColor = true;
            this.btn_crearOferta.Click += new System.EventHandler(this.btn_crearOferta_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(351, 291);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(75, 23);
            this.btn_limpiar.TabIndex = 17;
            this.btn_limpiar.Text = "Limpiar todo";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // numericUpDown_precioLista
            // 
            this.numericUpDown_precioLista.DecimalPlaces = 2;
            this.numericUpDown_precioLista.Location = new System.Drawing.Point(165, 155);
            this.numericUpDown_precioLista.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.numericUpDown_precioLista.Name = "numericUpDown_precioLista";
            this.numericUpDown_precioLista.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_precioLista.TabIndex = 18;
            this.numericUpDown_precioLista.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_precioOferta
            // 
            this.numericUpDown_precioOferta.DecimalPlaces = 2;
            this.numericUpDown_precioOferta.Location = new System.Drawing.Point(165, 181);
            this.numericUpDown_precioOferta.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.numericUpDown_precioOferta.Name = "numericUpDown_precioOferta";
            this.numericUpDown_precioOferta.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_precioOferta.TabIndex = 19;
            this.numericUpDown_precioOferta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_cantDisp
            // 
            this.numericUpDown_cantDisp.Location = new System.Drawing.Point(165, 210);
            this.numericUpDown_cantDisp.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.numericUpDown_cantDisp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_cantDisp.Name = "numericUpDown_cantDisp";
            this.numericUpDown_cantDisp.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_cantDisp.TabIndex = 20;
            this.numericUpDown_cantDisp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_cantMax
            // 
            this.numericUpDown_cantMax.Location = new System.Drawing.Point(165, 240);
            this.numericUpDown_cantMax.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.numericUpDown_cantMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_cantMax.Name = "numericUpDown_cantMax";
            this.numericUpDown_cantMax.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_cantMax.TabIndex = 21;
            this.numericUpDown_cantMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // richTextBox_descripcion
            // 
            this.richTextBox_descripcion.Location = new System.Drawing.Point(436, 79);
            this.richTextBox_descripcion.MaxLength = 255;
            this.richTextBox_descripcion.Name = "richTextBox_descripcion";
            this.richTextBox_descripcion.Size = new System.Drawing.Size(240, 181);
            this.richTextBox_descripcion.TabIndex = 23;
            this.richTextBox_descripcion.Text = "";
            // 
            // label_descripcion
            // 
            this.label_descripcion.AutoSize = true;
            this.label_descripcion.Location = new System.Drawing.Point(433, 63);
            this.label_descripcion.Name = "label_descripcion";
            this.label_descripcion.Size = new System.Drawing.Size(66, 13);
            this.label_descripcion.TabIndex = 24;
            this.label_descripcion.Text = "Descripción:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(226, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(247, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Todos los campos en esta pantalla son obligatorios";
            // 
            // CrearOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 353);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label_descripcion);
            this.Controls.Add(this.richTextBox_descripcion);
            this.Controls.Add(this.numericUpDown_cantMax);
            this.Controls.Add(this.numericUpDown_cantDisp);
            this.Controls.Add(this.numericUpDown_precioOferta);
            this.Controls.Add(this.numericUpDown_precioLista);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_crearOferta);
            this.Controls.Add(this.label_maxPorCliente);
            this.Controls.Add(this.label_cantDisp);
            this.Controls.Add(this.label_precioOferta);
            this.Controls.Add(this.label_precioLista);
            this.Controls.Add(this.label_fechaVenc);
            this.Controls.Add(this.dateTimePicker_venc);
            this.Controls.Add(this.label_fechaPubli);
            this.Controls.Add(this.dateTimePicker_publi);
            this.Controls.Add(this.btn_seleccionarProveedor);
            this.Controls.Add(this.textBox_proveedor);
            this.Controls.Add(this.label_proveedor);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CrearOferta";
            this.Text = "Descripción:";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_precioLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_precioOferta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cantDisp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cantMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_proveedor;
        private System.Windows.Forms.Button btn_seleccionarProveedor;
        private System.Windows.Forms.TextBox textBox_proveedor;
        private System.Windows.Forms.DateTimePicker dateTimePicker_publi;
        private System.Windows.Forms.Label label_fechaPubli;
        private System.Windows.Forms.Label label_fechaVenc;
        private System.Windows.Forms.DateTimePicker dateTimePicker_venc;
        private System.Windows.Forms.Label label_precioLista;
        private System.Windows.Forms.Label label_precioOferta;
        private System.Windows.Forms.Label label_cantDisp;
        private System.Windows.Forms.Label label_maxPorCliente;
        private System.Windows.Forms.Button btn_crearOferta;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.NumericUpDown numericUpDown_precioLista;
        private System.Windows.Forms.NumericUpDown numericUpDown_precioOferta;
        private System.Windows.Forms.NumericUpDown numericUpDown_cantDisp;
        private System.Windows.Forms.NumericUpDown numericUpDown_cantMax;
        private System.Windows.Forms.RichTextBox richTextBox_descripcion;
        private System.Windows.Forms.Label label_descripcion;
        private System.Windows.Forms.Label label10;
    }
}