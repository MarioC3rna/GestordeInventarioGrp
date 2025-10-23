namespace Proyecto_Base_de_Datos
{
    partial class ReportesForm
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
   panelLeft = new Panel();
       buttonAtras = new Button();
    lblTitulo = new Label();
        groupBoxTipoReporte = new GroupBox();
         radioButtonInventario = new RadioButton();
  radioButtonProductos = new RadioButton();
     radioButtonProveedores = new RadioButton();
         radioButtonCategorias = new RadioButton();
 radioButtonVentas = new RadioButton();
    groupBoxFiltros = new GroupBox();
 comboBoxProveedor = new ComboBox();
     comboBoxCategoria = new ComboBox();
        dateTimePickerHasta = new DateTimePicker();
   dateTimePickerDesde = new DateTimePicker();
   checkBoxProveedor = new CheckBox();
checkBoxCategoria = new CheckBox();
  checkBoxFechas = new CheckBox();
checkBoxBodega = new CheckBox();
      comboBoxBodega = new ComboBox();
  buttonGenerar = new Button();
      buttonExportar = new Button();
  dataGridViewReporte = new DataGridView();
     labelInfo = new Label();
  panelLeft.SuspendLayout();
       groupBoxTipoReporte.SuspendLayout();
groupBoxFiltros.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dataGridViewReporte).BeginInit();
         SuspendLayout();
       // 
   // panelLeft
       // 
  panelLeft.BackColor = Color.MediumSlateBlue;
     panelLeft.Controls.Add(buttonAtras);
         panelLeft.Dock = DockStyle.Left;
  panelLeft.Location = new Point(0, 0);
     panelLeft.Name = "panelLeft";
    panelLeft.Size = new Size(120, 600);
        panelLeft.TabIndex = 0;
  // 
       // buttonAtras
        // 
    buttonAtras.Location = new Point(20, 550);
            buttonAtras.Name = "buttonAtras";
            buttonAtras.Size = new Size(80, 30);
       buttonAtras.TabIndex = 0;
      buttonAtras.Text = "Atrás";
          buttonAtras.UseVisualStyleBackColor = true;
 buttonAtras.Click += buttonAtras_Click;
  // 
    // lblTitulo
  // 
   lblTitulo.AutoSize = true;
lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
       lblTitulo.ForeColor = Color.MediumSlateBlue;
    lblTitulo.Location = new Point(400, 20);
    lblTitulo.Name = "lblTitulo";
      lblTitulo.Size = new Size(227, 30);
   lblTitulo.TabIndex = 1;
    lblTitulo.Text = "GENERAR REPORTES";
            // 
   // groupBoxTipoReporte
   // 
  groupBoxTipoReporte.Controls.Add(radioButtonVentas);
            groupBoxTipoReporte.Controls.Add(radioButtonCategorias);
    groupBoxTipoReporte.Controls.Add(radioButtonProveedores);
 groupBoxTipoReporte.Controls.Add(radioButtonProductos);
      groupBoxTipoReporte.Controls.Add(radioButtonInventario);
   groupBoxTipoReporte.Location = new Point(140, 70);
      groupBoxTipoReporte.Name = "groupBoxTipoReporte";
            groupBoxTipoReporte.Size = new Size(300, 200);
  groupBoxTipoReporte.TabIndex = 2;
 groupBoxTipoReporte.TabStop = false;
            groupBoxTipoReporte.Text = "Tipo de Reporte";
     // 
       // radioButtonInventario
  // 
radioButtonInventario.AutoSize = true;
         radioButtonInventario.Location = new Point(20, 30);
      radioButtonInventario.Name = "radioButtonInventario";
        radioButtonInventario.Size = new Size(149, 19);
    radioButtonInventario.TabIndex = 0;
            radioButtonInventario.TabStop = true;
  radioButtonInventario.Text = "Inventario Disponible";
       radioButtonInventario.UseVisualStyleBackColor = true;
        // 
         // radioButtonProductos
      // 
  radioButtonProductos.AutoSize = true;
         radioButtonProductos.Location = new Point(20, 60);
    radioButtonProductos.Name = "radioButtonProductos";
      radioButtonProductos.Size = new Size(129, 19);
     radioButtonProductos.TabIndex = 1;
          radioButtonProductos.TabStop = true;
    radioButtonProductos.Text = "Lista de Productos";
     radioButtonProductos.UseVisualStyleBackColor = true;
        // 
  // radioButtonProveedores
 // 
 radioButtonProveedores.AutoSize = true;
        radioButtonProveedores.Location = new Point(20, 90);
            radioButtonProveedores.Name = "radioButtonProveedores";
      radioButtonProveedores.Size = new Size(139, 19);
       radioButtonProveedores.TabIndex = 2;
  radioButtonProveedores.TabStop = true;
     radioButtonProveedores.Text = "Lista de Proveedores";
          radioButtonProveedores.UseVisualStyleBackColor = true;
// 
 // radioButtonCategorias
     // 
 radioButtonCategorias.AutoSize = true;
          radioButtonCategorias.Location = new Point(20, 120);
    radioButtonCategorias.Name = "radioButtonCategorias";
          radioButtonCategorias.Size = new Size(131, 19);
      radioButtonCategorias.TabIndex = 3;
     radioButtonCategorias.TabStop = true;
         radioButtonCategorias.Text = "Lista de Categorías";
      radioButtonCategorias.UseVisualStyleBackColor = true;
    // 
    // radioButtonVentas
  // 
            radioButtonVentas.AutoSize = true;
    radioButtonVentas.Location = new Point(20, 150);
 radioButtonVentas.Name = "radioButtonVentas";
    radioButtonVentas.Size = new Size(166, 19);
 radioButtonVentas.TabIndex = 4;
    radioButtonVentas.TabStop = true;
            radioButtonVentas.Text = "Productos por Bodega";
        radioButtonVentas.UseVisualStyleBackColor = true;
     // 
       // groupBoxFiltros
   // 
          groupBoxFiltros.Controls.Add(comboBoxProveedor);
            groupBoxFiltros.Controls.Add(comboBoxCategoria);
 groupBoxFiltros.Controls.Add(dateTimePickerHasta);
      groupBoxFiltros.Controls.Add(dateTimePickerDesde);
 groupBoxFiltros.Controls.Add(checkBoxProveedor);
   groupBoxFiltros.Controls.Add(checkBoxCategoria);
 groupBoxFiltros.Controls.Add(checkBoxBodega);
        groupBoxFiltros.Controls.Add(comboBoxBodega);
 groupBoxFiltros.Controls.Add(checkBoxFechas);
       groupBoxFiltros.Location = new Point(460, 70);
      groupBoxFiltros.Name = "groupBoxFiltros";
 groupBoxFiltros.Size = new Size(350, 230);
    groupBoxFiltros.TabIndex = 3;
     groupBoxFiltros.TabStop = false;
groupBoxFiltros.Text = "Filtros";
      // 
    // checkBoxFechas
         // 
            checkBoxFechas.AutoSize = true;
     checkBoxFechas.Location = new Point(20, 30);
    checkBoxFechas.Name = "checkBoxFechas";
     checkBoxFechas.Size = new Size(125, 19);
      checkBoxFechas.TabIndex = 0;
checkBoxFechas.Text = "Filtrar por fechas:";
  checkBoxFechas.UseVisualStyleBackColor = true;
     checkBoxFechas.CheckedChanged += checkBoxFechas_CheckedChanged;
   // 
 // checkBoxCategoria
  // 
  checkBoxCategoria.AutoSize = true;
      checkBoxCategoria.Location = new Point(20, 100);
        checkBoxCategoria.Name = "checkBoxCategoria";
 checkBoxCategoria.Size = new Size(140, 19);
checkBoxCategoria.TabIndex = 1;
 checkBoxCategoria.Text = "Filtrar por categoría:";
  checkBoxCategoria.UseVisualStyleBackColor = true;
        checkBoxCategoria.CheckedChanged += checkBoxCategoria_CheckedChanged;
     // 
   // checkBoxProveedor
         // 
      checkBoxProveedor.AutoSize = true;
      checkBoxProveedor.Location = new Point(20, 150);
      checkBoxProveedor.Name = "checkBoxProveedor";
          checkBoxProveedor.Size = new Size(143, 19);
          checkBoxProveedor.TabIndex = 2;
checkBoxProveedor.Text = "Filtrar por proveedor:";
      checkBoxProveedor.UseVisualStyleBackColor = true;
    checkBoxProveedor.CheckedChanged += checkBoxProveedor_CheckedChanged;
      // 
    // checkBoxBodega
  // 
            checkBoxBodega.AutoSize = true;
         checkBoxBodega.Location = new Point(20, 190);
  checkBoxBodega.Name = "checkBoxBodega";
          checkBoxBodega.Size = new Size(133, 19);
     checkBoxBodega.TabIndex = 7;
checkBoxBodega.Text = "Filtrar por bodega:";
       checkBoxBodega.UseVisualStyleBackColor = true;
            checkBoxBodega.CheckedChanged += checkBoxBodega_CheckedChanged;
     // 
     // dateTimePickerDesde
 // 
  dateTimePickerDesde.Enabled = false;
       dateTimePickerDesde.Location = new Point(20, 55);
      dateTimePickerDesde.Name = "dateTimePickerDesde";
     dateTimePickerDesde.Size = new Size(150, 23);
      dateTimePickerDesde.TabIndex = 3;
            // 
       // dateTimePickerHasta
    // 
       dateTimePickerHasta.Enabled = false;
       dateTimePickerHasta.Location = new Point(180, 55);
   dateTimePickerHasta.Name = "dateTimePickerHasta";
     dateTimePickerHasta.Size = new Size(150, 23);
     dateTimePickerHasta.TabIndex = 4;
     // 
// comboBoxCategoria
       // 
        comboBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
   comboBoxCategoria.Enabled = false;
     comboBoxCategoria.FormattingEnabled = true;
  comboBoxCategoria.Location = new Point(170, 100);
 comboBoxCategoria.Name = "comboBoxCategoria";
    comboBoxCategoria.Size = new Size(160, 23);
     comboBoxCategoria.TabIndex = 5;
     // 
   // comboBoxProveedor
     // 
    comboBoxProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
    comboBoxProveedor.Enabled = false;
comboBoxProveedor.FormattingEnabled = true;
       comboBoxProveedor.Location = new Point(170, 150);
   comboBoxProveedor.Name = "comboBoxProveedor";
            comboBoxProveedor.Size = new Size(160, 23);
     comboBoxProveedor.TabIndex = 6;
    // 
  // comboBoxBodega
    // 
    comboBoxBodega.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBodega.Enabled = false;
 comboBoxBodega.FormattingEnabled = true;
      comboBoxBodega.Location = new Point(170, 190);
    comboBoxBodega.Name = "comboBoxBodega";
    comboBoxBodega.Size = new Size(160, 23);
   comboBoxBodega.TabIndex = 8;
  // 
// buttonGenerar
  // 
        buttonGenerar.BackColor = Color.LightSteelBlue;
buttonGenerar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
    buttonGenerar.Location = new Point(140, 320);
 buttonGenerar.Name = "buttonGenerar";
 buttonGenerar.Size = new Size(120, 40);
      buttonGenerar.TabIndex = 4;
        buttonGenerar.Text = "Generar Reporte";
         buttonGenerar.UseVisualStyleBackColor = false;
   buttonGenerar.Click += buttonGenerar_Click;
   // 
       // buttonExportar
   // 
     buttonExportar.BackColor = Color.LightGreen;
     buttonExportar.Enabled = false;
    buttonExportar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
       buttonExportar.Location = new Point(280, 320);
    buttonExportar.Name = "buttonExportar";
 buttonExportar.Size = new Size(120, 40);
   buttonExportar.TabIndex = 5;
      buttonExportar.Text = "Exportar a Excel";
    buttonExportar.UseVisualStyleBackColor = false;
     buttonExportar.Click += buttonExportar_Click;
         // 
   // dataGridViewReporte
            // 
     dataGridViewReporte.AllowUserToAddRows = false;
      dataGridViewReporte.AllowUserToDeleteRows = false;
     dataGridViewReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
     dataGridViewReporte.BackgroundColor = Color.White;
 dataGridViewReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    dataGridViewReporte.Location = new Point(140, 380);
   dataGridViewReporte.Name = "dataGridViewReporte";
  dataGridViewReporte.ReadOnly = true;
    dataGridViewReporte.RowHeadersVisible = false;
  dataGridViewReporte.Size = new Size(670, 200);
     dataGridViewReporte.TabIndex = 6;
      // 
// labelInfo
      // 
  labelInfo.AutoSize = true;
    labelInfo.ForeColor = Color.Gray;
 labelInfo.Location = new Point(420, 320);
     labelInfo.Name = "labelInfo";
 labelInfo.Size = new Size(300, 15);
       labelInfo.TabIndex = 7;
        labelInfo.Text = "Selecciona un tipo de reporte y haz clic en 'Generar'";
 // 
            // ReportesForm
 // 
      AutoScaleDimensions = new SizeF(7F, 15F);
AutoScaleMode = AutoScaleMode.Font;
   ClientSize = new Size(830, 600);
            Controls.Add(labelInfo);
          Controls.Add(dataGridViewReporte);
  Controls.Add(buttonExportar);
            Controls.Add(buttonGenerar);
   Controls.Add(groupBoxFiltros);
      Controls.Add(groupBoxTipoReporte);
   Controls.Add(lblTitulo);
    Controls.Add(panelLeft);
      Name = "ReportesForm";
      Text = "Generador de Reportes";
     Load += ReportesForm_Load;
      panelLeft.ResumeLayout(false);
 groupBoxTipoReporte.ResumeLayout(false);
      groupBoxTipoReporte.PerformLayout();
    groupBoxFiltros.ResumeLayout(false);
          groupBoxFiltros.PerformLayout();
       ((System.ComponentModel.ISupportInitialize)dataGridViewReporte).EndInit();
    ResumeLayout(false);
  PerformLayout();
     }

        #endregion

private Panel panelLeft;
    private Button buttonAtras;
        private Label lblTitulo;
        private GroupBox groupBoxTipoReporte;
        private RadioButton radioButtonInventario;
    private RadioButton radioButtonProductos;
        private RadioButton radioButtonProveedores;
      private RadioButton radioButtonCategorias;
        private RadioButton radioButtonVentas;
  private GroupBox groupBoxFiltros;
 private CheckBox checkBoxFechas;
        private CheckBox checkBoxCategoria;
   private CheckBox checkBoxProveedor;
        private CheckBox checkBoxBodega;
     private DateTimePicker dateTimePickerDesde;
        private DateTimePicker dateTimePickerHasta;
     private ComboBox comboBoxCategoria;
   private ComboBox comboBoxProveedor;
        private ComboBox comboBoxBodega;
     private Button buttonGenerar;
   private Button buttonExportar;
    private DataGridView dataGridViewReporte;
        private Label labelInfo;
    }
}