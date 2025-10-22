namespace Proyecto_Base_de_Datos
{
    partial class ActualizarForm
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
            panel1 = new Panel();
            buttonAtras = new Button();
            btnACTUALIZAR = new Button();
            lblTitulo = new Label();
            lblCodigoProductoB = new Label();
            txtBoxCodigoProductoB = new TextBox();
            lblNombreProductoBU = new Label();
            textBoxNombreProductoBU = new TextBox(); // ✅ CAMPO DE BÚSQUEDA POR NOMBRE
            lblCategoriaProductoBU = new Label();
            textBoxCategoriaProductoBU = new TextBox();
            buttonBuscar = new Button();
            lblNombreProducto = new Label(); // Campo de RESULTADO
            txtBoxNombreProducto = new TextBox(); // Campo de RESULTADO
            labelDescripcion = new Label();
            textBoxDescripcion = new TextBox();
            labelCostoUnitario = new Label();
            textBoxCostoUnitario = new TextBox();
            labelDescuento = new Label();
            textBoxDescuento = new TextBox();
            labelFecha = new Label();
            dateTimePicker1 = new DateTimePicker();
            lblUnidadMedida = new Label();
            comboBoxUnidadMedida = new ComboBox();
            lblProveedor = new Label();
            comboBoxProveedor = new ComboBox();
            lblTipoServicioProducto = new Label();
            comboBoxTipoServicioProducto = new ComboBox();
            labelCategoria = new Label();
            comboBoxCategoria = new ComboBox();
            labelStock = new Label();
            textBoxStock = new TextBox();
            labelImagen = new Label();
            pictureBoxImagen = new PictureBox();
            buttonImagen = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImagen).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumSlateBlue;
            panel1.Controls.Add(buttonAtras);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(175, 450);
            panel1.TabIndex = 1;
            // 
            // buttonAtras
            // 
            buttonAtras.ImeMode = ImeMode.NoControl;
            buttonAtras.Location = new Point(37, 410);
            buttonAtras.Margin = new Padding(3, 2, 3, 2);
            buttonAtras.Name = "buttonAtras";
            buttonAtras.Size = new Size(82, 22);
            buttonAtras.TabIndex = 20;
            buttonAtras.Text = "Atras";
            buttonAtras.UseVisualStyleBackColor = true;
            buttonAtras.Click += buttonAtras_Click;
            // 
            // btnACTUALIZAR
            // 
            btnACTUALIZAR.Location = new Point(540, 350);
            btnACTUALIZAR.Margin = new Padding(3, 2, 3, 2);
            btnACTUALIZAR.Name = "btnACTUALIZAR";
            btnACTUALIZAR.Size = new Size(120, 35);
            btnACTUALIZAR.TabIndex = 2;
            btnACTUALIZAR.Text = "ACTUALIZAR";
            btnACTUALIZAR.UseVisualStyleBackColor = true;
            btnACTUALIZAR.Click += btnACTUALIZAR_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.MediumSlateBlue;
            lblTitulo.ImeMode = ImeMode.NoControl;
            lblTitulo.Location = new Point(300, 7);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(257, 30);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "ACTUALIZAR REGISTRO";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // lblCodigoProductoB
            // 
            lblCodigoProductoB.AutoSize = true;
            lblCodigoProductoB.Location = new Point(188, 80);
            lblCodigoProductoB.Name = "lblCodigoProductoB";
            lblCodigoProductoB.Size = new Size(117, 15);
            lblCodigoProductoB.TabIndex = 4;
            lblCodigoProductoB.Text = "Codigo del Producto";
            // 
            // txtBoxCodigoProductoB
            // 
            txtBoxCodigoProductoB.Location = new Point(327, 78);
            txtBoxCodigoProductoB.Margin = new Padding(3, 2, 3, 2);
            txtBoxCodigoProductoB.Name = "txtBoxCodigoProductoB";
            txtBoxCodigoProductoB.Size = new Size(110, 23);
            txtBoxCodigoProductoB.TabIndex = 5;
            txtBoxCodigoProductoB.TextChanged += txtBoxCodigoProductoB_TextChanged;
            // 
            // lblNombreProductoBU
            // 
            lblNombreProductoBU.AutoSize = true;
            lblNombreProductoBU.Location = new Point(188, 56);
            lblNombreProductoBU.Name = "lblNombreProductoBU";
            lblNombreProductoBU.Size = new Size(122, 15);
            lblNombreProductoBU.TabIndex = 6;
            lblNombreProductoBU.Text = "Nombre del Producto";
            // 
            // textBoxNombreProductoBU
            // 
            textBoxNombreProductoBU.Location = new Point(327, 53);
            textBoxNombreProductoBU.Margin = new Padding(3, 2, 3, 2);
            textBoxNombreProductoBU.Name = "textBoxNombreProductoBU";
            textBoxNombreProductoBU.Size = new Size(110, 23);
            textBoxNombreProductoBU.TabIndex = 7;
            // 
            // lblCategoriaProductoBU
            // 
            lblCategoriaProductoBU.AutoSize = true;
            lblCategoriaProductoBU.Location = new Point(180, 105);
            lblCategoriaProductoBU.Name = "lblCategoriaProductoBU";
            lblCategoriaProductoBU.Size = new Size(129, 15);
            lblCategoriaProductoBU.TabIndex = 8;
            lblCategoriaProductoBU.Text = "Categoria del Producto";
            // 
            // textBoxCategoriaProductoBU
            // 
            textBoxCategoriaProductoBU.Location = new Point(327, 103);
            textBoxCategoriaProductoBU.Margin = new Padding(3, 2, 3, 2);
            textBoxCategoriaProductoBU.Name = "textBoxCategoriaProductoBU";
            textBoxCategoriaProductoBU.Size = new Size(110, 23);
            textBoxCategoriaProductoBU.TabIndex = 9;
            // 
            // buttonBuscar
            // 
            buttonBuscar.Location = new Point(341, 133);
            buttonBuscar.Margin = new Padding(3, 2, 3, 2);
            buttonBuscar.Name = "buttonBuscar";
            buttonBuscar.Size = new Size(82, 22);
            buttonBuscar.TabIndex = 10;
            buttonBuscar.Text = "BUSCAR";
            buttonBuscar.UseVisualStyleBackColor = true;
            buttonBuscar.Click += buttonBuscar_Click;
            // 
            // lblNombreProducto - ETIQUETA PARA RESULTADO
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Location = new Point(188, 173);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(122, 15);
            lblNombreProducto.TabIndex = 11;
            lblNombreProducto.Text = "Nombre del Producto";
            // 
            // txtBoxNombreProducto - CAMPO DE RESULTADO
            // 
            txtBoxNombreProducto.Location = new Point(394, 173);
            txtBoxNombreProducto.Margin = new Padding(3, 2, 3, 2);
            txtBoxNombreProducto.Name = "txtBoxNombreProducto";
            txtBoxNombreProducto.Size = new Size(110, 23);
            txtBoxNombreProducto.TabIndex = 12;
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(188, 198);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(69, 15);
            labelDescripcion.TabIndex = 13;
            labelDescripcion.Text = "Descripcion";
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(394, 198);
            textBoxDescripcion.Margin = new Padding(3, 2, 3, 2);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(110, 23);
            textBoxDescripcion.TabIndex = 14;
            // 
            // labelCostoUnitario
            // 
            labelCostoUnitario.AutoSize = true;
            labelCostoUnitario.Location = new Point(188, 224);
            labelCostoUnitario.Name = "labelCostoUnitario";
            labelCostoUnitario.Size = new Size(83, 15);
            labelCostoUnitario.TabIndex = 15;
            labelCostoUnitario.Text = "Costo Unitario";
            // 
            // textBoxCostoUnitario
            // 
            textBoxCostoUnitario.Location = new Point(394, 224);
            textBoxCostoUnitario.Margin = new Padding(3, 2, 3, 2);
            textBoxCostoUnitario.Name = "textBoxCostoUnitario";
            textBoxCostoUnitario.Size = new Size(110, 23);
            textBoxCostoUnitario.TabIndex = 16;
            // 
            // labelDescuento
            // 
            labelDescuento.AutoSize = true;
            labelDescuento.Location = new Point(188, 250);
            labelDescuento.Name = "labelDescuento";
            labelDescuento.Size = new Size(63, 15);
            labelDescuento.TabIndex = 17;
            labelDescuento.Text = "Descuento";
            // 
            // textBoxDescuento
            // 
            textBoxDescuento.Location = new Point(394, 250);
            textBoxDescuento.Margin = new Padding(3, 2, 3, 2);
            textBoxDescuento.Name = "textBoxDescuento";
            textBoxDescuento.Size = new Size(110, 23);
            textBoxDescuento.TabIndex = 18;
            // 
            // labelFecha
            // 
            labelFecha.AutoSize = true;
            labelFecha.Location = new Point(188, 274);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(96, 15);
            labelFecha.TabIndex = 19;
            labelFecha.Text = "Fecha de Ingreso";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(290, 272);
            dateTimePicker1.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(214, 23);
            dateTimePicker1.TabIndex = 20;
            // 
            // lblUnidadMedida
            // 
            lblUnidadMedida.AutoSize = true;
            lblUnidadMedida.Location = new Point(188, 298);
            lblUnidadMedida.Name = "lblUnidadMedida";
            lblUnidadMedida.Size = new Size(104, 15);
            lblUnidadMedida.TabIndex = 21;
            lblUnidadMedida.Text = "Unidad de Medida";
            // 
            // comboBoxUnidadMedida
            // 
            comboBoxUnidadMedida.FormattingEnabled = true;
            comboBoxUnidadMedida.Location = new Point(394, 296);
            comboBoxUnidadMedida.Margin = new Padding(3, 2, 3, 2);
            comboBoxUnidadMedida.Name = "comboBoxUnidadMedida";
            comboBoxUnidadMedida.Size = new Size(110, 23);
            comboBoxUnidadMedida.TabIndex = 22;
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(188, 322);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(61, 15);
            lblProveedor.TabIndex = 23;
            lblProveedor.Text = "Proveedor";
            // 
            // comboBoxProveedor
            // 
            comboBoxProveedor.FormattingEnabled = true;
            comboBoxProveedor.Location = new Point(394, 320);
            comboBoxProveedor.Margin = new Padding(3, 2, 3, 2);
            comboBoxProveedor.Name = "comboBoxProveedor";
            comboBoxProveedor.Size = new Size(110, 23);
            comboBoxProveedor.TabIndex = 24;
            // 
            // lblTipoServicioProducto
            // 
            lblTipoServicioProducto.AutoSize = true;
            lblTipoServicioProducto.Location = new Point(188, 348);
            lblTipoServicioProducto.Name = "lblTipoServicioProducto";
            lblTipoServicioProducto.Size = new Size(162, 15);
            lblTipoServicioProducto.TabIndex = 25;
            lblTipoServicioProducto.Text = "Tipo de Servicio del Producto";
            // 
            // comboBoxTipoServicioProducto
            // 
            comboBoxTipoServicioProducto.FormattingEnabled = true;
            comboBoxTipoServicioProducto.Location = new Point(394, 346);
            comboBoxTipoServicioProducto.Margin = new Padding(3, 2, 3, 2);
            comboBoxTipoServicioProducto.Name = "comboBoxTipoServicioProducto";
            comboBoxTipoServicioProducto.Size = new Size(110, 23);
            comboBoxTipoServicioProducto.TabIndex = 26;
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Location = new Point(188, 374);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(58, 15);
            labelCategoria.TabIndex = 27;
            labelCategoria.Text = "Categoria";
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Location = new Point(394, 372);
            comboBoxCategoria.Margin = new Padding(3, 2, 3, 2);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(110, 23);
            comboBoxCategoria.TabIndex = 28;
            comboBoxCategoria.SelectedIndexChanged += comboBoxCategoria_SelectedIndexChanged;
            // 
            // labelStock
            // 
            labelStock.AutoSize = true;
            labelStock.Location = new Point(188, 398);
            labelStock.Name = "labelStock";
            labelStock.Size = new Size(95, 15);
            labelStock.TabIndex = 29;
            labelStock.Text = "Stock Disponible";
            // 
            // textBoxStock
            // 
            textBoxStock.BackColor = SystemColors.Window;
            textBoxStock.Enabled = true;
            textBoxStock.Location = new Point(394, 396);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.ReadOnly = false;
            textBoxStock.Size = new Size(110, 23);
            textBoxStock.TabIndex = 30;
            // 
            // labelImagen
            // 
            labelImagen.AutoSize = true;
            labelImagen.Location = new Point(546, 125);
            labelImagen.Name = "labelImagen";
            labelImagen.Size = new Size(47, 15);
            labelImagen.TabIndex = 31;
            labelImagen.Text = "Imagen";
            // 
            // pictureBoxImagen
            // 
            pictureBoxImagen.Location = new Point(546, 149);
            pictureBoxImagen.Margin = new Padding(3, 2, 3, 2);
            pictureBoxImagen.Name = "pictureBoxImagen";
            pictureBoxImagen.Size = new Size(134, 120);
            pictureBoxImagen.TabIndex = 32;
            pictureBoxImagen.TabStop = false;
            // 
            // buttonImagen
            // 
            buttonImagen.Location = new Point(546, 280);
            buttonImagen.Margin = new Padding(3, 2, 3, 2);
            buttonImagen.Name = "buttonImagen";
            buttonImagen.Size = new Size(125, 32);
            buttonImagen.TabIndex = 33;
            buttonImagen.Text = "Cargar Imagen";
            buttonImagen.UseVisualStyleBackColor = true;
            buttonImagen.Click += buttonImagen_Click;
            // 
            // ActualizarForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 450);
            Controls.Add(buttonImagen);
            Controls.Add(pictureBoxImagen);
            Controls.Add(labelImagen);
            Controls.Add(textBoxStock);
            Controls.Add(labelStock);
            Controls.Add(comboBoxCategoria);
            Controls.Add(labelCategoria);
            Controls.Add(comboBoxTipoServicioProducto);
            Controls.Add(lblTipoServicioProducto);
            Controls.Add(comboBoxProveedor);
            Controls.Add(lblProveedor);
            Controls.Add(comboBoxUnidadMedida);
            Controls.Add(lblUnidadMedida);
            Controls.Add(dateTimePicker1);
            Controls.Add(labelFecha);
            Controls.Add(textBoxDescuento);
            Controls.Add(labelDescuento);
            Controls.Add(textBoxCostoUnitario);
            Controls.Add(labelCostoUnitario);
            Controls.Add(textBoxDescripcion);
            Controls.Add(labelDescripcion);
            Controls.Add(txtBoxNombreProducto);
            Controls.Add(lblNombreProducto);
            Controls.Add(buttonBuscar);
            Controls.Add(textBoxCategoriaProductoBU);
            Controls.Add(lblCategoriaProductoBU);
            Controls.Add(textBoxNombreProductoBU);
            Controls.Add(lblNombreProductoBU);
            Controls.Add(txtBoxCodigoProductoB);
            Controls.Add(lblCodigoProductoB);
            Controls.Add(lblTitulo);
            Controls.Add(btnACTUALIZAR);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ActualizarForm";
            Text = "ActualizarForm";
            Load += ActualizarForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxImagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button buttonAtras;
        private Button btnACTUALIZAR;
        private Label lblTitulo;
        private Label lblCodigoProductoB;
        private TextBox txtBoxCodigoProductoB;
        private Label lblNombreProductoBU;
        private TextBox textBoxNombreProductoBU; // ✅ CAMPO DE BÚSQUEDA
        private Label lblCategoriaProductoBU;
        private TextBox textBoxCategoriaProductoBU;
        private Button buttonBuscar;
        private Label lblNombreProducto; // Campo de RESULTADO
        private TextBox txtBoxNombreProducto; // Campo de RESULTADO
        private Label labelDescripcion;
        private TextBox textBoxDescripcion;
        private Label labelCostoUnitario;
        private TextBox textBoxCostoUnitario;
        private Label labelDescuento;
        private TextBox textBoxDescuento;
        private Label labelFecha;
        private DateTimePicker dateTimePicker1;
        private Label lblUnidadMedida;
        private ComboBox comboBoxUnidadMedida;
        private Label lblProveedor;
        private ComboBox comboBoxProveedor;
        private Label lblTipoServicioProducto;
        private ComboBox comboBoxTipoServicioProducto;
        private Label labelCategoria;
        private ComboBox comboBoxCategoria;
        private Label labelStock;
        private TextBox textBoxStock;
        private Label labelImagen;
        private PictureBox pictureBoxImagen;
        private Button buttonImagen;
    }
}