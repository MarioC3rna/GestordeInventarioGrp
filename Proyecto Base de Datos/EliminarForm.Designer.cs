namespace Proyecto_Base_de_Datos
{
    partial class EliminarForm
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
            lblTitulo = new Label();
            buttonBuscar = new Button();
            lblCodigoProductoB = new Label();
            txtBoxCodigoProductoBusqueda = new TextBox();
            lblinfoProveedores = new Label();
            lblinfoTipoServicio = new Label();
            lblinfoCantidades = new Label();
            lblinfoProductoNombre = new Label();
            panel1 = new Panel();
            buttonAtras = new Button();
            txtBoxProveedor = new TextBox();
            txtBoxTipoServicio = new TextBox();
            txtBoxCodigoProducto = new TextBox();
            txtBoxNombreProducto = new TextBox();
            PanelListado = new Panel();
            btnELIMINAR = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.MediumSlateBlue;
            lblTitulo.ImeMode = ImeMode.NoControl;
            lblTitulo.Location = new Point(106, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(283, 37);
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = "ELIMINAR REGISTRO";
            lblTitulo.Click += lblopciones_Click;
            // 
            // buttonBuscar
            // 
            buttonBuscar.Location = new Point(416, 53);
            buttonBuscar.Name = "buttonBuscar";
            buttonBuscar.Size = new Size(112, 29);
            buttonBuscar.TabIndex = 12;
            buttonBuscar.Text = "BUSCAR";
            buttonBuscar.UseVisualStyleBackColor = true;
            buttonBuscar.Click += buttonBuscar_Click;
            // 
            // lblCodigoProductoB
            // 
            lblCodigoProductoB.AutoSize = true;
            lblCodigoProductoB.Location = new Point(80, 56);
            lblCodigoProductoB.Name = "lblCodigoProductoB";
            lblCodigoProductoB.Size = new Size(147, 20);
            lblCodigoProductoB.TabIndex = 11;
            lblCodigoProductoB.Text = "Codigo del Producto";
            // 
            // txtBoxCodigoProductoBusqueda
            // 
            txtBoxCodigoProductoBusqueda.Location = new Point(242, 53);
            txtBoxCodigoProductoBusqueda.Name = "txtBoxCodigoProductoBusqueda";
            txtBoxCodigoProductoBusqueda.Size = new Size(125, 27);
            txtBoxCodigoProductoBusqueda.TabIndex = 10;
            // 
            // lblinfoProveedores
            // 
            lblinfoProveedores.AutoSize = true;
            lblinfoProveedores.Location = new Point(22, 190);
            lblinfoProveedores.Name = "lblinfoProveedores";
            lblinfoProveedores.Size = new Size(77, 20);
            lblinfoProveedores.TabIndex = 18;
            lblinfoProveedores.Text = "Proveedor";
            // 
            // lblinfoTipoServicio
            // 
            lblinfoTipoServicio.AutoSize = true;
            lblinfoTipoServicio.Location = new Point(22, 226);
            lblinfoTipoServicio.Name = "lblinfoTipoServicio";
            lblinfoTipoServicio.Size = new Size(205, 20);
            lblinfoTipoServicio.TabIndex = 17;
            lblinfoTipoServicio.Text = "Tipo de Servicio del Producto";
            // 
            // lblinfoCantidades
            // 
            lblinfoCantidades.AutoSize = true;
            lblinfoCantidades.Location = new Point(22, 150);
            lblinfoCantidades.Name = "lblinfoCantidades";
            lblinfoCantidades.Size = new Size(128, 20);
            lblinfoCantidades.TabIndex = 16;
            lblinfoCantidades.Text = "Nombre Producto";
            // 
            // lblinfoProductoNombre
            // 
            lblinfoProductoNombre.AutoSize = true;
            lblinfoProductoNombre.Location = new Point(22, 114);
            lblinfoProductoNombre.Name = "lblinfoProductoNombre";
            lblinfoProductoNombre.Size = new Size(122, 20);
            lblinfoProductoNombre.TabIndex = 15;
            lblinfoProductoNombre.Text = "Codigo Producto";
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumSlateBlue;
            panel1.Controls.Add(buttonAtras);
            panel1.Location = new Point(549, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 450);
            panel1.TabIndex = 23;
            // 
            // buttonAtras
            // 
            buttonAtras.ImeMode = ImeMode.NoControl;
            buttonAtras.Location = new Point(84, 395);
            buttonAtras.Name = "buttonAtras";
            buttonAtras.Size = new Size(94, 29);
            buttonAtras.TabIndex = 20;
            buttonAtras.Text = "Atras";
            buttonAtras.UseVisualStyleBackColor = true;
            buttonAtras.Click += buttonAtras_Click;
            // 
            // txtBoxProveedor
            // 
            txtBoxProveedor.Location = new Point(265, 184);
            txtBoxProveedor.Name = "txtBoxProveedor";
            txtBoxProveedor.Size = new Size(124, 27);
            txtBoxProveedor.TabIndex = 27;
            // 
            // txtBoxTipoServicio
            // 
            txtBoxTipoServicio.Location = new Point(265, 219);
            txtBoxTipoServicio.Name = "txtBoxTipoServicio";
            txtBoxTipoServicio.Size = new Size(124, 27);
            txtBoxTipoServicio.TabIndex = 26;
            // 
            // txtBoxCodigoProducto
            // 
            txtBoxCodigoProducto.Location = new Point(265, 111);
            txtBoxCodigoProducto.Name = "txtBoxCodigoProducto";
            txtBoxCodigoProducto.Size = new Size(124, 27);
            txtBoxCodigoProducto.TabIndex = 25;
            // 
            // txtBoxNombreProducto
            // 
            txtBoxNombreProducto.Location = new Point(265, 147);
            txtBoxNombreProducto.Name = "txtBoxNombreProducto";
            txtBoxNombreProducto.Size = new Size(124, 27);
            txtBoxNombreProducto.TabIndex = 24;
            // 
            // PanelListado
            // 
            PanelListado.Location = new Point(28, 275);
            PanelListado.Name = "PanelListado";
            PanelListado.Size = new Size(500, 163);
            PanelListado.TabIndex = 28;
            // 
            // btnELIMINAR
            // 
            btnELIMINAR.Location = new Point(416, 150);
            btnELIMINAR.Name = "btnELIMINAR";
            btnELIMINAR.Size = new Size(112, 61);
            btnELIMINAR.TabIndex = 29;
            btnELIMINAR.Text = "ELMINAR";
            btnELIMINAR.UseVisualStyleBackColor = true;
            btnELIMINAR.Click += button1_Click;
            // 
            // EliminarForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtBoxTipoServicio);
            Controls.Add(btnELIMINAR);
            Controls.Add(PanelListado);
            Controls.Add(txtBoxProveedor);
            Controls.Add(txtBoxCodigoProducto);
            Controls.Add(txtBoxNombreProducto);
            Controls.Add(panel1);
            Controls.Add(lblinfoProveedores);
            Controls.Add(lblinfoTipoServicio);
            Controls.Add(lblinfoCantidades);
            Controls.Add(lblinfoProductoNombre);
            Controls.Add(buttonBuscar);
            Controls.Add(lblCodigoProductoB);
            Controls.Add(txtBoxCodigoProductoBusqueda);
            Controls.Add(lblTitulo);
            Name = "EliminarForm";
            Text = "EliminarForm1";
            Load += EliminarForm_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTitulo;
        private Button buttonBuscar;
        private Label lblCodigoProductoB;
        private TextBox txtBoxCodigoProductoBusqueda;
        private Label lblinfoProveedores;
        private Label lblinfoTipoServicio;
        private Label lblinfoCantidades;
        private Label lblinfoProductoNombre;
        private Panel panel1;
        private TextBox txtBoxProveedor;
        private TextBox txtBoxTipoServicio;
        private TextBox txtBoxCodigoProducto;
        private TextBox txtBoxNombreProducto;
        private Panel PanelListado;
        private Button btnELIMINAR;
        private Button buttonAtras;
    }
}