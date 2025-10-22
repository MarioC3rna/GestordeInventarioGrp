namespace Proyecto_Base_de_Datos
{
    partial class BienvenidaForm
    {
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnGoLogin;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.PictureBox logo;

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            lblSubtitle = new Label();
            btnGoLogin = new Button();
            topPanel = new Panel();
            logo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.Top;
            lblWelcome.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.MediumSlateBlue;
            lblWelcome.Location = new Point(88, 202);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(525, 38);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Bienvenido al Inventario";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Anchor = AnchorStyles.Top;
            lblSubtitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.DimGray;
            lblSubtitle.Location = new Point(175, 248);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(350, 22);
            lblSubtitle.TabIndex = 3;
            lblSubtitle.Text = "Sistema de Base de Datos";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnGoLogin
            // 
            btnGoLogin.Anchor = AnchorStyles.Top;
            btnGoLogin.BackColor = Color.MediumSlateBlue;
            btnGoLogin.FlatStyle = FlatStyle.Flat;
            btnGoLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGoLogin.ForeColor = Color.White;
            btnGoLogin.Location = new Point(219, 285);
            btnGoLogin.Margin = new Padding(3, 2, 3, 2);
            btnGoLogin.Name = "btnGoLogin";
            btnGoLogin.Size = new Size(262, 38);
            btnGoLogin.TabIndex = 4;
            btnGoLogin.Text = "Ir al Inicio de Sesión";
            btnGoLogin.UseVisualStyleBackColor = false;
            btnGoLogin.Click += btnGoLogin_Click;
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.MediumSlateBlue;
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(3, 2, 3, 2);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(700, 60);
            topPanel.TabIndex = 0;
            // 
            // logo
            // 
            logo.Image = Properties.Resources.Imagen1;
            logo.ImageLocation = "";
            logo.Location = new Point(284, 75);
            logo.Margin = new Padding(3, 2, 3, 2);
            logo.Name = "logo";
            logo.Size = new Size(149, 125);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 1;
            logo.TabStop = false;
            // 
            // BienvenidaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(700, 338);
            Controls.Add(btnGoLogin);
            Controls.Add(lblSubtitle);
            Controls.Add(lblWelcome);
            Controls.Add(logo);
            Controls.Add(topPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            Name = "BienvenidaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bienvenida";
            Load += BienvenidaForm_Load;
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
        }
    }
}