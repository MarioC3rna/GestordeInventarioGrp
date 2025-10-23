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
            textBoxNombreProductoBU = new TextBox();
            buttonBuscar = new Button();
            lblCodigoProducto = new Label();
            txtBoxCodigoProducto = new TextBox();
            lblNombreProducto = new Label();
            txtBoxNombreProducto = new TextBox();
            labelDescripcion = new Label();
            textBoxDescripcion = new TextBox();
            labelCostoUnitario = new Label();
            textBoxCostoUnitario = new TextBox();
            labelDescuento = new Label();
            textBoxDescuento = new TextBox();
            labelFecha = new Label();
            dateTimePicker1 = new DateTimePicker();
            lblUnidadMedida = new Label();
            textBoxUnidadMedida = new TextBox();
            lblAbrevLongitud = new Label();
            textBoxAbrevLongitud = new TextBox();
            lblPeso = new Label();
            textBoxPeso = new TextBox();
            lblAbrevPeso = new Label();
            textBoxAbrevPeso = new TextBox();
            lblProveedor = new Label();
            textBoxProveedorNombre = new TextBox();
            lblTipoServicioProducto = new Label();
            textBoxTipoServicioTipo = new TextBox();
            labelCategoria = new Label();
            textBoxCategoria = new TextBox();
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
            panel1.Size = new Size(175, 550);
            panel1.TabIndex = 1;
            // 
            // buttonAtras
            // 
            buttonAtras.ImeMode = ImeMode.NoControl;
            buttonAtras.Location = new Point(37, 510);
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
            btnACTUALIZAR.BackColor = Color.MediumSlateBlue;
            btnACTUALIZAR.ForeColor = Color.White;
            btnACTUALIZAR.Location = new Point(540, 480);
            btnACTUALIZAR.Margin = new Padding(3, 2, 3, 2);
            btnACTUALIZAR.Name = "btnACTUALIZAR";
            btnACTUALIZAR.Size = new Size(120, 35);
            btnACTUALIZAR.TabIndex = 2;
            btnACTUALIZAR.Text = "ACTUALIZAR";
            btnACTUALIZAR.UseVisualStyleBackColor = false;
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
            lblCodigoProductoB.Location = new Point(188, 56);
            lblCodigoProductoB.Name = "lblCodigoProductoB";
            lblCodigoProductoB.Size = new Size(117, 15);
            lblCodigoProductoB.TabIndex = 4;
            lblCodigoProductoB.Text = "Codigo del Producto";
            // 
            // txtBoxCodigoProductoB
            // 
            txtBoxCodigoProductoB.Location = new Point(327, 53);
            txtBoxCodigoProductoB.Margin = new Padding(3, 2, 3, 2);
            txtBoxCodigoProductoB.Name = "txtBoxCodigoProductoB";
            txtBoxCodigoProductoB.Size = new Size(110, 23);
            txtBoxCodigoProductoB.TabIndex = 5;
            txtBoxCodigoProductoB.TextChanged += txtBoxCodigoProductoB_TextChanged;
            // 
            // lblNombreProductoBU
            // 
            lblNombreProductoBU.AutoSize = true;
            lblNombreProductoBU.Location = new Point(188, 81);
            lblNombreProductoBU.Name = "lblNombreProductoBU";
            lblNombreProductoBU.Size = new Size(122, 15);
            lblNombreProductoBU.TabIndex = 6;
            lblNombreProductoBU.Text = "Nombre del Producto";
            // 
            // textBoxNombreProductoBU
            // 
            textBoxNombreProductoBU.Location = new Point(327, 78);
            textBoxNombreProductoBU.Margin = new Padding(3, 2, 3, 2);
            textBoxNombreProductoBU.Name = "textBoxNombreProductoBU";
            textBoxNombreProductoBU.Size = new Size(110, 23);
            textBoxNombreProductoBU.TabIndex = 7;
            // 
            // buttonBuscar
            // 
            buttonBuscar.Location = new Point(341, 108);
            buttonBuscar.Margin = new Padding(3, 2, 3, 2);
            buttonBuscar.Name = "buttonBuscar";
            buttonBuscar.Size = new Size(82, 22);
            buttonBuscar.TabIndex = 10;
            buttonBuscar.Text = "BUSCAR";
            buttonBuscar.UseVisualStyleBackColor = true;
            buttonBuscar.Click += buttonBuscar_Click;
            // 
            // lblCodigoProducto
            // 
            lblCodigoProducto.AutoSize = true;
            lblCodigoProducto.Location = new Point(188, 148);
            lblCodigoProducto.Name = "lblCodigoProducto";
            lblCodigoProducto.Size = new Size(117, 15);
            lblCodigoProducto.TabIndex = 11;
            lblCodigoProducto.Text = "Codigo del Producto";
            // 
            // txtBoxCodigoProducto
            // 
            txtBoxCodigoProducto.Location = new Point(394, 148);
            txtBoxCodigoProducto.Margin = new Padding(3, 2, 3, 2);
            txtBoxCodigoProducto.Name = "txtBoxCodigoProducto";
            txtBoxCodigoProducto.Size = new Size(110, 23);
            txtBoxCodigoProducto.TabIndex = 12;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Location = new Point(188, 173);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(122, 15);
            lblNombreProducto.TabIndex = 13;
            lblNombreProducto.Text = "Nombre del Producto";
            // 
            // txtBoxNombreProducto
            // 
            txtBoxNombreProducto.Location = new Point(394, 173);
            txtBoxNombreProducto.Margin = new Padding(3, 2, 3, 2);
            txtBoxNombreProducto.Name = "txtBoxNombreProducto";
            txtBoxNombreProducto.Size = new Size(110, 23);
            txtBoxNombreProducto.TabIndex = 14;
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(188, 259);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(69, 15);
            labelDescripcion.TabIndex = 15;
            labelDescripcion.Text = "Descripcion";
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(290, 256);
            textBoxDescripcion.Margin = new Padding(3, 2, 3, 2);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(214, 23);
            textBoxDescripcion.TabIndex = 16;
            // 
            // labelCostoUnitario
            // 
            labelCostoUnitario.AutoSize = true;
            labelCostoUnitario.Location = new Point(188, 200);
            labelCostoUnitario.Name = "labelCostoUnitario";
            labelCostoUnitario.Size = new Size(83, 15);
            labelCostoUnitario.TabIndex = 17;
            labelCostoUnitario.Text = "Costo Unitario";
            // 
            // textBoxCostoUnitario
            // 
            textBoxCostoUnitario.Location = new Point(394, 200);
            textBoxCostoUnitario.Margin = new Padding(3, 2, 3, 2);
            textBoxCostoUnitario.Name = "textBoxCostoUnitario";
            textBoxCostoUnitario.Size = new Size(110, 23);
            textBoxCostoUnitario.TabIndex = 18;
            // 
            // labelDescuento
            // 
            labelDescuento.AutoSize = true;
            labelDescuento.Location = new Point(188, 234);
            labelDescuento.Name = "labelDescuento";
            labelDescuento.Size = new Size(63, 15);
            labelDescuento.TabIndex = 19;
            labelDescuento.Text = "Descuento";
            // 
            // textBoxDescuento
            // 
            textBoxDescuento.Location = new Point(394, 226);
            textBoxDescuento.Margin = new Padding(3, 2, 3, 2);
            textBoxDescuento.Name = "textBoxDescuento";
            textBoxDescuento.Size = new Size(110, 23);
            textBoxDescuento.TabIndex = 20;
            // 
            // labelFecha
            // 
            labelFecha.AutoSize = true;
            labelFecha.Location = new Point(188, 285);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(96, 15);
            labelFecha.TabIndex = 21;
            labelFecha.Text = "Fecha de Ingreso";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(290, 283);
            dateTimePicker1.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(214, 23);
            dateTimePicker1.TabIndex = 22;
            // 
            // lblUnidadMedida
            // 
            lblUnidadMedida.AutoSize = true;
            lblUnidadMedida.Location = new Point(188, 328);
            lblUnidadMedida.Name = "lblUnidadMedida";
            lblUnidadMedida.Size = new Size(95, 15);
            lblUnidadMedida.TabIndex = 23;
            lblUnidadMedida.Text = "Longitud (valor):";
            // 
            // textBoxUnidadMedida
            // 
            textBoxUnidadMedida.Location = new Point(294, 325);
            textBoxUnidadMedida.Margin = new Padding(3, 2, 3, 2);
            textBoxUnidadMedida.Name = "textBoxUnidadMedida";
            textBoxUnidadMedida.PlaceholderText = "Ej: 10.5";
            textBoxUnidadMedida.Size = new Size(80, 23);
            textBoxUnidadMedida.TabIndex = 24;
            // 
            // lblAbrevLongitud
            // 
            lblAbrevLongitud.AutoSize = true;
            lblAbrevLongitud.Location = new Point(380, 328);
            lblAbrevLongitud.Name = "lblAbrevLongitud";
            lblAbrevLongitud.Size = new Size(41, 15);
            lblAbrevLongitud.TabIndex = 25;
            lblAbrevLongitud.Text = "Abrev:";
            // 
            // textBoxAbrevLongitud
            // 
            textBoxAbrevLongitud.Location = new Point(424, 325);
            textBoxAbrevLongitud.Margin = new Padding(3, 2, 3, 2);
            textBoxAbrevLongitud.Name = "textBoxAbrevLongitud";
            textBoxAbrevLongitud.PlaceholderText = "Ej: cm";
            textBoxAbrevLongitud.Size = new Size(80, 23);
            textBoxAbrevLongitud.TabIndex = 26;
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Location = new Point(188, 354);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(72, 15);
            lblPeso.TabIndex = 27;
            lblPeso.Text = "Peso (valor):";
            // 
            // textBoxPeso
            // 
            textBoxPeso.Location = new Point(294, 351);
            textBoxPeso.Margin = new Padding(3, 2, 3, 2);
            textBoxPeso.Name = "textBoxPeso";
            textBoxPeso.PlaceholderText = "Ej: 2.5";
            textBoxPeso.Size = new Size(80, 23);
            textBoxPeso.TabIndex = 28;
            // 
            // lblAbrevPeso
            // 
            lblAbrevPeso.AutoSize = true;
            lblAbrevPeso.Location = new Point(380, 354);
            lblAbrevPeso.Name = "lblAbrevPeso";
            lblAbrevPeso.Size = new Size(41, 15);
            lblAbrevPeso.TabIndex = 29;
            lblAbrevPeso.Text = "Abrev:";
            // 
            // textBoxAbrevPeso
            // 
            textBoxAbrevPeso.Location = new Point(424, 351);
            textBoxAbrevPeso.Margin = new Padding(3, 2, 3, 2);
            textBoxAbrevPeso.Name = "textBoxAbrevPeso";
            textBoxAbrevPeso.PlaceholderText = "Ej: kg";
            textBoxAbrevPeso.Size = new Size(80, 23);
            textBoxAbrevPeso.TabIndex = 30;
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(188, 380);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(119, 15);
            lblProveedor.TabIndex = 31;
            lblProveedor.Text = "Proveedor (Nombre):";
            // 
            // textBoxProveedorNombre
            // 
            textBoxProveedorNombre.Location = new Point(300, 376);
            textBoxProveedorNombre.Margin = new Padding(3, 2, 3, 2);
            textBoxProveedorNombre.Name = "textBoxProveedorNombre";
            textBoxProveedorNombre.PlaceholderText = "Ej: Distribuidora XYZ";
            textBoxProveedorNombre.Size = new Size(210, 23);
            textBoxProveedorNombre.TabIndex = 32;
            // 
            // lblTipoServicioProducto
            // 
            lblTipoServicioProducto.AutoSize = true;
            lblTipoServicioProducto.Location = new Point(188, 406);
            lblTipoServicioProducto.Name = "lblTipoServicioProducto";
            lblTipoServicioProducto.Size = new Size(63, 15);
            lblTipoServicioProducto.TabIndex = 33;
            lblTipoServicioProducto.Text = "Tipo (S/B):";
            // 
            // textBoxTipoServicioTipo
            // 
            textBoxTipoServicioTipo.Location = new Point(294, 403);
            textBoxTipoServicioTipo.Margin = new Padding(3, 2, 3, 2);
            textBoxTipoServicioTipo.Name = "textBoxTipoServicioTipo";
            textBoxTipoServicioTipo.PlaceholderText = "Servicio o Bien";
            textBoxTipoServicioTipo.Size = new Size(120, 23);
            textBoxTipoServicioTipo.TabIndex = 34;
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Location = new Point(188, 432);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(58, 15);
            labelCategoria.TabIndex = 35;
            labelCategoria.Text = "Categoria";
            // 
            // textBoxCategoria
            // 
            textBoxCategoria.Location = new Point(294, 429);
            textBoxCategoria.Margin = new Padding(3, 2, 3, 2);
            textBoxCategoria.Name = "textBoxCategoria";
            textBoxCategoria.PlaceholderText = "Ej: Electrónicos";
            textBoxCategoria.Size = new Size(150, 23);
            textBoxCategoria.TabIndex = 36;
            // 
            // labelStock
            // 
            labelStock.AutoSize = true;
            labelStock.Location = new Point(188, 458);
            labelStock.Name = "labelStock";
            labelStock.Size = new Size(95, 15);
            labelStock.TabIndex = 37;
            labelStock.Text = "Stock Disponible";
            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(294, 455);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.PlaceholderText = "Ej: 100";
            textBoxStock.Size = new Size(80, 23);
            textBoxStock.TabIndex = 38;
            // 
            // labelImagen
            // 
            labelImagen.AutoSize = true;
            labelImagen.Location = new Point(546, 125);
            labelImagen.Name = "labelImagen";
            labelImagen.Size = new Size(47, 15);
            labelImagen.TabIndex = 39;
            labelImagen.Text = "Imagen";
            // 
            // pictureBoxImagen
            // 
            pictureBoxImagen.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxImagen.Location = new Point(546, 149);
            pictureBoxImagen.Margin = new Padding(3, 2, 3, 2);
            pictureBoxImagen.Name = "pictureBoxImagen";
            pictureBoxImagen.Size = new Size(134, 120);
            pictureBoxImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImagen.TabIndex = 40;
            pictureBoxImagen.TabStop = false;
            // 
            // buttonImagen
            // 
            buttonImagen.Location = new Point(546, 280);
            buttonImagen.Margin = new Padding(3, 2, 3, 2);
            buttonImagen.Name = "buttonImagen";
            buttonImagen.Size = new Size(125, 32);
            buttonImagen.TabIndex = 41;
            buttonImagen.Text = "Cargar Imagen";
            buttonImagen.UseVisualStyleBackColor = true;
            buttonImagen.Click += buttonImagen_Click;
            // 
            // ActualizarForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 550);
            Controls.Add(buttonImagen);
            Controls.Add(pictureBoxImagen);
            Controls.Add(labelImagen);
            Controls.Add(textBoxStock);
            Controls.Add(labelStock);
            Controls.Add(textBoxCategoria);
            Controls.Add(labelCategoria);
            Controls.Add(textBoxTipoServicioTipo);
            Controls.Add(lblTipoServicioProducto);
            Controls.Add(textBoxProveedorNombre);
            Controls.Add(lblProveedor);
            Controls.Add(textBoxAbrevPeso);
            Controls.Add(lblAbrevPeso);
            Controls.Add(textBoxPeso);
            Controls.Add(lblPeso);
            Controls.Add(textBoxAbrevLongitud);
            Controls.Add(lblAbrevLongitud);
            Controls.Add(textBoxUnidadMedida);
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
            Controls.Add(txtBoxCodigoProducto);
            Controls.Add(lblCodigoProducto);
            Controls.Add(buttonBuscar);
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
        private TextBox textBoxNombreProductoBU;
        private Button buttonBuscar;
        private Label lblCodigoProducto;
        private TextBox txtBoxCodigoProducto;
        private Label lblNombreProducto;
        private TextBox txtBoxNombreProducto;
        private Label labelDescripcion;
        private TextBox textBoxDescripcion;
        private Label labelCostoUnitario;
        private TextBox textBoxCostoUnitario;
        private Label labelDescuento;
        private TextBox textBoxDescuento;
        private Label labelFecha;
        private DateTimePicker dateTimePicker1;
        private Label lblUnidadMedida;
        private TextBox textBoxUnidadMedida; // ✅ TEXTBOX
        private Label lblAbrevLongitud;
        private TextBox textBoxAbrevLongitud;
        private Label lblPeso;
        private TextBox textBoxPeso;
        private Label lblAbrevPeso;
        private TextBox textBoxAbrevPeso;
        private Label lblProveedor;
        private TextBox textBoxProveedorNombre; // ✅ TEXTBOX
        private Label lblTipoServicioProducto;
        private TextBox textBoxTipoServicioTipo; // ✅ TEXTBOX
        private Label labelCategoria;
        private TextBox textBoxCategoria; // ✅ TEXTBOX
        private Label labelStock;
        private TextBox textBoxStock;
        private Label labelImagen;
        private PictureBox pictureBoxImagen;
        private Button buttonImagen;
    }
}