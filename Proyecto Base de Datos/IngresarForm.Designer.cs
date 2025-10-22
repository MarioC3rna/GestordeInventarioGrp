namespace Proyecto_Base_de_Datos
{
    partial class IngresarForm
    {
        private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
        {
    if (disposing && (components != null))
     {
            components.Dispose();
            }
        base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panel1 = new Panel();
            buttonAtras = new Button();
            lblTitulo = new Label();
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
            lblAbrevPeso = new Label();
            textBoxAbrevPeso = new TextBox();
            lblPeso = new Label();
            textBoxPeso = new TextBox();
            lblProveedor = new Label();
            textBoxProveedorNombre = new TextBox();
            lblTipoServicioProducto = new Label();
            textBoxTipoServicioTipo = new TextBox();
            labelCategoria = new Label();
            textBoxCategoria = new TextBox();
            labelStock = new Label();
            textBoxStock = new TextBox();
            buttonIngresarBD = new Button();
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
            panel1.Name = "panel1";
            panel1.Size = new Size(175, 550);
            panel1.TabIndex = 0;
            // 
            // buttonAtras
            // 
            buttonAtras.BackColor = Color.White;
            buttonAtras.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonAtras.ForeColor = Color.Black;
            buttonAtras.Location = new Point(37, 511);
            buttonAtras.Name = "buttonAtras";
            buttonAtras.Size = new Size(92, 27);
            buttonAtras.TabIndex = 0;
            buttonAtras.Text = "Atras";
            buttonAtras.UseVisualStyleBackColor = false;
            buttonAtras.Click += buttonAtras_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.MediumSlateBlue;
            lblTitulo.Location = new Point(300, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(246, 30);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "INGRESAR PRODUCTO";
            // 
            // lblCodigoProducto
            // 
            lblCodigoProducto.AutoSize = true;
            lblCodigoProducto.Location = new Point(190, 60);
            lblCodigoProducto.Name = "lblCodigoProducto";
            lblCodigoProducto.Size = new Size(120, 15);
            lblCodigoProducto.TabIndex = 2;
            lblCodigoProducto.Text = "Código del Producto:";
            // 
            // txtBoxCodigoProducto
            // 
            txtBoxCodigoProducto.Location = new Point(340, 57);
            txtBoxCodigoProducto.Name = "txtBoxCodigoProducto";
            txtBoxCodigoProducto.PlaceholderText = "Ej: PRD-001";
            txtBoxCodigoProducto.Size = new Size(150, 23);
            txtBoxCodigoProducto.TabIndex = 3;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Location = new Point(190, 90);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(125, 15);
            lblNombreProducto.TabIndex = 4;
            lblNombreProducto.Text = "Nombre del Producto:";
            // 
            // txtBoxNombreProducto
            // 
            txtBoxNombreProducto.Location = new Point(340, 87);
            txtBoxNombreProducto.Name = "txtBoxNombreProducto";
            txtBoxNombreProducto.Size = new Size(200, 23);
            txtBoxNombreProducto.TabIndex = 5;
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(190, 120);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(72, 15);
            labelDescripcion.TabIndex = 6;
            labelDescripcion.Text = "Descripción:";
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(340, 117);
            textBoxDescripcion.Multiline = true;
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(200, 40);
            textBoxDescripcion.TabIndex = 7;
            // 
            // labelCostoUnitario
            // 
            labelCostoUnitario.AutoSize = true;
            labelCostoUnitario.Location = new Point(190, 170);
            labelCostoUnitario.Name = "labelCostoUnitario";
            labelCostoUnitario.Size = new Size(86, 15);
            labelCostoUnitario.TabIndex = 8;
            labelCostoUnitario.Text = "Costo Unitario:";
            // 
            // textBoxCostoUnitario
            // 
            textBoxCostoUnitario.Location = new Point(340, 167);
            textBoxCostoUnitario.Name = "textBoxCostoUnitario";
            textBoxCostoUnitario.Size = new Size(120, 23);
            textBoxCostoUnitario.TabIndex = 9;
            // 
            // labelDescuento
            // 
            labelDescuento.AutoSize = true;
            labelDescuento.Location = new Point(190, 200);
            labelDescuento.Name = "labelDescuento";
            labelDescuento.Size = new Size(66, 15);
            labelDescuento.TabIndex = 10;
            labelDescuento.Text = "Descuento:";
            // 
            // textBoxDescuento
            // 
            textBoxDescuento.Location = new Point(340, 197);
            textBoxDescuento.Name = "textBoxDescuento";
            textBoxDescuento.Size = new Size(120, 23);
            textBoxDescuento.TabIndex = 11;
            // 
            // labelFecha
            // 
            labelFecha.AutoSize = true;
            labelFecha.Location = new Point(190, 230);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(99, 15);
            labelFecha.TabIndex = 12;
            labelFecha.Text = "Fecha de Ingreso:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(340, 227);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 13;
            // 
            // lblUnidadMedida
            // 
            lblUnidadMedida.AutoSize = true;
            lblUnidadMedida.Location = new Point(190, 260);
            lblUnidadMedida.Name = "lblUnidadMedida";
            lblUnidadMedida.Size = new Size(128, 15);
            lblUnidadMedida.TabIndex = 14;
            lblUnidadMedida.Text = "Longitud (m, cm, etc.):";
            // 
            // textBoxUnidadMedida
            // 
            textBoxUnidadMedida.Location = new Point(340, 257);
            textBoxUnidadMedida.Name = "textBoxUnidadMedida";
            textBoxUnidadMedida.PlaceholderText = "Ej: 10.5";
            textBoxUnidadMedida.Size = new Size(80, 23);
            textBoxUnidadMedida.TabIndex = 15;
            // 
            // lblAbrevLongitud
            // 
            lblAbrevLongitud.AutoSize = true;
            lblAbrevLongitud.Location = new Point(430, 260);
            lblAbrevLongitud.Name = "lblAbrevLongitud";
            lblAbrevLongitud.Size = new Size(41, 15);
            lblAbrevLongitud.TabIndex = 16;
            lblAbrevLongitud.Text = "Abrev:";
            // 
            // textBoxAbrevLongitud
            // 
            textBoxAbrevLongitud.Location = new Point(475, 257);
            textBoxAbrevLongitud.Name = "textBoxAbrevLongitud";
            textBoxAbrevLongitud.PlaceholderText = "Ej: cm";
            textBoxAbrevLongitud.Size = new Size(65, 23);
            textBoxAbrevLongitud.TabIndex = 17;
            // 
            // lblAbrevPeso
            // 
            lblAbrevPeso.AutoSize = true;
            lblAbrevPeso.Location = new Point(430, 290);
            lblAbrevPeso.Name = "lblAbrevPeso";
            lblAbrevPeso.Size = new Size(41, 15);
            lblAbrevPeso.TabIndex = 20;
            lblAbrevPeso.Text = "Abrev:";
            // 
            // textBoxAbrevPeso
            // 
            textBoxAbrevPeso.Location = new Point(475, 287);
            textBoxAbrevPeso.Name = "textBoxAbrevPeso";
            textBoxAbrevPeso.PlaceholderText = "Ej: kg";
            textBoxAbrevPeso.Size = new Size(65, 23);
            textBoxAbrevPeso.TabIndex = 21;
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Location = new Point(190, 290);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(97, 15);
            lblPeso.TabIndex = 18;
            lblPeso.Text = "Peso (kg, g, etc.):";
            // 
            // textBoxPeso
            // 
            textBoxPeso.Location = new Point(340, 287);
            textBoxPeso.Name = "textBoxPeso";
            textBoxPeso.PlaceholderText = "Ej: 2.5";
            textBoxPeso.Size = new Size(80, 23);
            textBoxPeso.TabIndex = 19;
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(190, 320);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(119, 15);
            lblProveedor.TabIndex = 22;
            lblProveedor.Text = "Proveedor (Nombre):";
            // 
            // textBoxProveedorNombre
            // 
            textBoxProveedorNombre.Location = new Point(340, 317);
            textBoxProveedorNombre.Name = "textBoxProveedorNombre";
            textBoxProveedorNombre.PlaceholderText = "Ej: Distribuidora XYZ";
            textBoxProveedorNombre.Size = new Size(200, 23);
            textBoxProveedorNombre.TabIndex = 23;
            // 
            // lblTipoServicioProducto
            // 
            lblTipoServicioProducto.AutoSize = true;
            lblTipoServicioProducto.Location = new Point(190, 350);
            lblTipoServicioProducto.Name = "lblTipoServicioProducto";
            lblTipoServicioProducto.Size = new Size(114, 15);
            lblTipoServicioProducto.TabIndex = 24;
            lblTipoServicioProducto.Text = "Tipo (Servicio/Bien):";
            // 
            // textBoxTipoServicioTipo
            // 
            textBoxTipoServicioTipo.Location = new Point(340, 347);
            textBoxTipoServicioTipo.Name = "textBoxTipoServicioTipo";
            textBoxTipoServicioTipo.PlaceholderText = "Servicio o Bien";
            textBoxTipoServicioTipo.Size = new Size(120, 23);
            textBoxTipoServicioTipo.TabIndex = 25;
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Location = new Point(190, 380);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(61, 15);
            labelCategoria.TabIndex = 26;
            labelCategoria.Text = "Categoría:";
            // 
            // textBoxCategoria
            // 
            textBoxCategoria.Location = new Point(340, 377);
            textBoxCategoria.Name = "textBoxCategoria";
            textBoxCategoria.PlaceholderText = "Ej: Electrónicos";
            textBoxCategoria.Size = new Size(150, 23);
            textBoxCategoria.TabIndex = 27;
            // 
            // labelStock
            // 
            labelStock.AutoSize = true;
            labelStock.Location = new Point(190, 410);
            labelStock.Name = "labelStock";
            labelStock.Size = new Size(98, 15);
            labelStock.TabIndex = 28;
            labelStock.Text = "Stock Disponible:";
            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(340, 407);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.PlaceholderText = "Ej: 100";
            textBoxStock.Size = new Size(80, 23);
            textBoxStock.TabIndex = 29;
            // 
            // buttonIngresarBD
            // 
            buttonIngresarBD.BackColor = Color.MediumSlateBlue;
            buttonIngresarBD.ForeColor = Color.White;
            buttonIngresarBD.Location = new Point(340, 450);
            buttonIngresarBD.Name = "buttonIngresarBD";
            buttonIngresarBD.Size = new Size(150, 40);
            buttonIngresarBD.TabIndex = 33;
            buttonIngresarBD.Text = "INGRESAR PRODUCTO";
            buttonIngresarBD.UseVisualStyleBackColor = false;
            buttonIngresarBD.Click += buttonIngresarBD_Click;
            // 
            // labelImagen
            // 
            labelImagen.AutoSize = true;
            labelImagen.Location = new Point(600, 60);
            labelImagen.Name = "labelImagen";
            labelImagen.Size = new Size(50, 15);
            labelImagen.TabIndex = 30;
            labelImagen.Text = "Imagen:";
            // 
            // pictureBoxImagen
            // 
            pictureBoxImagen.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxImagen.Location = new Point(600, 85);
            pictureBoxImagen.Name = "pictureBoxImagen";
            pictureBoxImagen.Size = new Size(150, 150);
            pictureBoxImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImagen.TabIndex = 31;
            pictureBoxImagen.TabStop = false;
            // 
            // buttonImagen
            // 
            buttonImagen.Location = new Point(600, 245);
            buttonImagen.Name = "buttonImagen";
            buttonImagen.Size = new Size(150, 30);
            buttonImagen.TabIndex = 32;
            buttonImagen.Text = "Cargar Imagen";
            buttonImagen.UseVisualStyleBackColor = true;
            buttonImagen.Click += buttonImagen_Click;
            // 
            // IngresarForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(buttonIngresarBD);
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
            Controls.Add(lblTitulo);
            Controls.Add(panel1);
            Name = "IngresarForm";
            Text = "Ingresar Producto";
            Load += IngresarForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxImagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button buttonAtras;
        private Label lblTitulo;
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
        private TextBox textBoxUnidadMedida;
     private Label lblAbrevLongitud;
        private TextBox textBoxAbrevLongitud;
      private Label lblAbrevPeso;
        private TextBox textBoxAbrevPeso;
private Label lblPeso;
        private TextBox textBoxPeso;
        private Label lblProveedor;
  private TextBox textBoxProveedorNombre;
        private Label lblTipoServicioProducto;
        private TextBox textBoxTipoServicioTipo;
        private Label labelCategoria;
      private TextBox textBoxCategoria;
        private Label labelStock;
        private TextBox textBoxStock;
     private Label labelImagen;
    private PictureBox pictureBoxImagen;
        private Button buttonImagen;
        private Button buttonIngresarBD;
    }
}