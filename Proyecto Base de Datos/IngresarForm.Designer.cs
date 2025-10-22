namespace Proyecto_Base_de_Datos
{
    partial class IngresarForm
    {
        private System.Windows.Forms.Label lblingresar;
        private System.Windows.Forms.Button buttonAtras;



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblingresar = new Label();
            panelLeft = new Panel();
            buttonAtras = new Button();
            comboBoxCategoria = new ComboBox();
            comboBoxTipoServicioProducto = new ComboBox();
            comboBoxProveedor = new ComboBox();
            comboBoxUnidadMedida = new ComboBox();
            labelCategoria = new Label();
            dateTimePicker1 = new DateTimePicker();
            labelFecha = new Label();
            buttonImagen = new Button();
            pictureBoxImagen = new PictureBox();
            labelImagen = new Label();
            textBoxDescuento = new TextBox();
            labelDescuento = new Label();
            textBoxCostoUnitario = new TextBox();
            labelCostoUnitario = new Label();
            textBoxDescripcion = new TextBox();
            labelDescripcion = new Label();
            lblTipoServicioProducto = new Label();
            lblProveedor = new Label();
            lblUnidadMedida = new Label();
            txtBoxNombreProducto = new TextBox();
            lblNombreProducto = new Label();
            buttonIngresarBD = new Button();
            labelStock = new Label();
            textBoxStock = new TextBox();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImagen).BeginInit();
            SuspendLayout();
            // 
            // lblingresar
            // 
            lblingresar.AutoSize = true;
            lblingresar.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblingresar.ForeColor = Color.MediumSlateBlue;
            lblingresar.ImeMode = ImeMode.NoControl;
            lblingresar.Location = new Point(334, 7);
            lblingresar.Name = "lblingresar";
            lblingresar.Size = new Size(120, 30);
            lblingresar.TabIndex = 3;
            lblingresar.Text = "INGRESAR";
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.MediumSlateBlue;
            panelLeft.Controls.Add(buttonAtras);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Margin = new Padding(3, 2, 3, 2);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(102, 338);
            panelLeft.TabIndex = 1;
            // 
            // buttonAtras
            // 
            buttonAtras.ImeMode = ImeMode.NoControl;
            buttonAtras.Location = new Point(10, 307);
            buttonAtras.Margin = new Padding(3, 2, 3, 2);
            buttonAtras.Name = "buttonAtras";
            buttonAtras.Size = new Size(82, 22);
            buttonAtras.TabIndex = 19;
            buttonAtras.Text = "Atras";
            buttonAtras.UseVisualStyleBackColor = true;
            buttonAtras.Click += buttonAtras_Click;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Location = new Point(305, 271);
            comboBoxCategoria.Margin = new Padding(3, 2, 3, 2);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(133, 23);
            comboBoxCategoria.TabIndex = 95;
            // 
            // comboBoxTipoServicioProducto
            // 
            comboBoxTipoServicioProducto.FormattingEnabled = true;
            comboBoxTipoServicioProducto.Location = new Point(306, 236);
            comboBoxTipoServicioProducto.Margin = new Padding(3, 2, 3, 2);
            comboBoxTipoServicioProducto.Name = "comboBoxTipoServicioProducto";
            comboBoxTipoServicioProducto.Size = new Size(133, 23);
            comboBoxTipoServicioProducto.TabIndex = 94;
            // 
            // comboBoxProveedor
            // 
            comboBoxProveedor.FormattingEnabled = true;
            comboBoxProveedor.Location = new Point(306, 211);
            comboBoxProveedor.Margin = new Padding(3, 2, 3, 2);
            comboBoxProveedor.Name = "comboBoxProveedor";
            comboBoxProveedor.Size = new Size(133, 23);
            comboBoxProveedor.TabIndex = 93;
            // 
            // comboBoxUnidadMedida
            // 
            comboBoxUnidadMedida.FormattingEnabled = true;
            comboBoxUnidadMedida.Location = new Point(305, 185);
            comboBoxUnidadMedida.Margin = new Padding(3, 2, 3, 2);
            comboBoxUnidadMedida.Name = "comboBoxUnidadMedida";
            comboBoxUnidadMedida.Size = new Size(133, 23);
            comboBoxUnidadMedida.TabIndex = 92;
            comboBoxUnidadMedida.SelectedIndexChanged += comboBoxUnidadMedida_SelectedIndexChanged;
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Location = new Point(127, 277);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(58, 15);
            labelCategoria.TabIndex = 91;
            labelCategoria.Text = "Categoria";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(257, 156);
            dateTimePicker1.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(248, 23);
            dateTimePicker1.TabIndex = 90;
            // 
            // labelFecha
            // 
            labelFecha.AutoSize = true;
            labelFecha.Location = new Point(122, 156);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(96, 15);
            labelFecha.TabIndex = 89;
            labelFecha.Text = "Fecha de Ingreso";
            // 
            // buttonImagen
            // 
            buttonImagen.Location = new Point(558, 163);
            buttonImagen.Margin = new Padding(3, 2, 3, 2);
            buttonImagen.Name = "buttonImagen";
            buttonImagen.Size = new Size(103, 31);
            buttonImagen.TabIndex = 88;
            buttonImagen.Text = "Cargar Imagen";
            buttonImagen.UseVisualStyleBackColor = true;
            buttonImagen.Click += buttonImagen_Click;
            // 
            // pictureBoxImagen
            // 
            pictureBoxImagen.Location = new Point(504, 74);
            pictureBoxImagen.Margin = new Padding(3, 2, 3, 2);
            pictureBoxImagen.Name = "pictureBoxImagen";
            pictureBoxImagen.Size = new Size(172, 78);
            pictureBoxImagen.TabIndex = 87;
            pictureBoxImagen.TabStop = false;
            // 
            // labelImagen
            // 
            labelImagen.AutoSize = true;
            labelImagen.Location = new Point(504, 53);
            labelImagen.Name = "labelImagen";
            labelImagen.Size = new Size(47, 15);
            labelImagen.TabIndex = 86;
            labelImagen.Text = "Imagen";
            // 
            // textBoxDescuento
            // 
            textBoxDescuento.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxDescuento.Location = new Point(312, 123);
            textBoxDescuento.Margin = new Padding(3, 2, 3, 2);
            textBoxDescuento.Name = "textBoxDescuento";
            textBoxDescuento.Size = new Size(107, 23);
            textBoxDescuento.TabIndex = 85;
            // 
            // labelDescuento
            // 
            labelDescuento.AutoSize = true;
            labelDescuento.Location = new Point(127, 125);
            labelDescuento.Name = "labelDescuento";
            labelDescuento.Size = new Size(63, 15);
            labelDescuento.TabIndex = 84;
            labelDescuento.Text = "Descuento";
            // 
            // textBoxCostoUnitario
            // 
            textBoxCostoUnitario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCostoUnitario.Location = new Point(312, 98);
            textBoxCostoUnitario.Margin = new Padding(3, 2, 3, 2);
            textBoxCostoUnitario.Name = "textBoxCostoUnitario";
            textBoxCostoUnitario.Size = new Size(107, 23);
            textBoxCostoUnitario.TabIndex = 83;
            // 
            // labelCostoUnitario
            // 
            labelCostoUnitario.AutoSize = true;
            labelCostoUnitario.Location = new Point(127, 98);
            labelCostoUnitario.Name = "labelCostoUnitario";
            labelCostoUnitario.Size = new Size(83, 15);
            labelCostoUnitario.TabIndex = 82;
            labelCostoUnitario.Text = "Costo Unitario";
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxDescripcion.Location = new Point(312, 70);
            textBoxDescripcion.Margin = new Padding(3, 2, 3, 2);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(107, 23);
            textBoxDescripcion.TabIndex = 81;
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(127, 70);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(69, 15);
            labelDescripcion.TabIndex = 80;
            labelDescripcion.Text = "Descripcion";
            // 
            // lblTipoServicioProducto
            // 
            lblTipoServicioProducto.AutoSize = true;
            lblTipoServicioProducto.Location = new Point(122, 242);
            lblTipoServicioProducto.Name = "lblTipoServicioProducto";
            lblTipoServicioProducto.Size = new Size(162, 15);
            lblTipoServicioProducto.TabIndex = 79;
            lblTipoServicioProducto.Text = "Tipo de Servicio del Producto";
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(122, 211);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(61, 15);
            lblProveedor.TabIndex = 78;
            lblProveedor.Text = "Proveedor";
            // 
            // lblUnidadMedida
            // 
            lblUnidadMedida.AutoSize = true;
            lblUnidadMedida.Location = new Point(122, 185);
            lblUnidadMedida.Name = "lblUnidadMedida";
            lblUnidadMedida.Size = new Size(104, 15);
            lblUnidadMedida.TabIndex = 77;
            lblUnidadMedida.Text = "Unidad de Medida";
            // 
            // txtBoxNombreProducto
            // 
            txtBoxNombreProducto.Location = new Point(312, 46);
            txtBoxNombreProducto.Margin = new Padding(3, 2, 3, 2);
            txtBoxNombreProducto.Name = "txtBoxNombreProducto";
            txtBoxNombreProducto.Size = new Size(109, 23);
            txtBoxNombreProducto.TabIndex = 76;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Location = new Point(127, 46);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(122, 15);
            lblNombreProducto.TabIndex = 75;
            lblNombreProducto.Text = "Nombre del Producto";
            // 
            // buttonIngresarBD
            // 
            buttonIngresarBD.Location = new Point(535, 277);
            buttonIngresarBD.Margin = new Padding(3, 2, 3, 2);
            buttonIngresarBD.Name = "buttonIngresarBD";
            buttonIngresarBD.Size = new Size(126, 31);
            buttonIngresarBD.TabIndex = 96;
            buttonIngresarBD.Text = "Ingresar Producto";
            buttonIngresarBD.UseVisualStyleBackColor = true;
            buttonIngresarBD.Click += buttonIngresarBD_Click;
            // 
            // labelStock
            // 
            labelStock.AutoSize = true;
            labelStock.Location = new Point(127, 302);
            labelStock.Name = "labelStock";
            labelStock.Size = new Size(95, 15);
            labelStock.TabIndex = 97;
            labelStock.Text = "Stock Inicial";
            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(305, 300);
            textBoxStock.Margin = new Padding(3, 2, 3, 2);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.Size = new Size(133, 23);
            textBoxStock.TabIndex = 98;
            // 
            // IngresarForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(textBoxStock);
            Controls.Add(labelStock);
            Controls.Add(buttonIngresarBD);
            Controls.Add(comboBoxCategoria);
            Controls.Add(comboBoxTipoServicioProducto);
            Controls.Add(comboBoxProveedor);
            Controls.Add(comboBoxUnidadMedida);
            Controls.Add(labelCategoria);
            Controls.Add(dateTimePicker1);
            Controls.Add(labelFecha);
            Controls.Add(buttonImagen);
            Controls.Add(pictureBoxImagen);
            Controls.Add(labelImagen);
            Controls.Add(textBoxDescuento);
            Controls.Add(labelDescuento);
            Controls.Add(textBoxCostoUnitario);
            Controls.Add(labelCostoUnitario);
            Controls.Add(textBoxDescripcion);
            Controls.Add(labelDescripcion);
            Controls.Add(lblTipoServicioProducto);
            Controls.Add(lblProveedor);
            Controls.Add(lblUnidadMedida);
            Controls.Add(txtBoxNombreProducto);
            Controls.Add(lblNombreProducto);
            Controls.Add(lblingresar);
            Controls.Add(panelLeft);
            Margin = new Padding(3, 2, 3, 2);
            Name = "IngresarForm";
            Text = "Form2";
            Load += IngresarForm_Load;
            panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxImagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panelLeft;
        private Button buttonAtrasING;
        private ComboBox comboBoxCategoria;
        private ComboBox comboBoxTipoServicioProducto;
        private ComboBox comboBoxProveedor;
        private ComboBox comboBoxUnidadMedida;
        private Label labelCategoria;
        private DateTimePicker dateTimePicker1;
        private Label labelFecha;
        private Button buttonImagen;
        private PictureBox pictureBoxImagen;
        private Label labelImagen;
        private TextBox textBoxDescuento;
        private Label labelDescuento;
        private TextBox textBoxCostoUnitario;
        private Label labelCostoUnitario;
        private TextBox textBoxDescripcion;
        private Label labelDescripcion;
        private Label lblTipoServicioProducto;
        private Label lblProveedor;
        private Label lblUnidadMedida;
        private TextBox txtBoxNombreProducto;
        private Label lblNombreProducto;
        private Button buttonIngresarBD;
        private Label labelStock;
        private TextBox textBoxStock;
    }
}