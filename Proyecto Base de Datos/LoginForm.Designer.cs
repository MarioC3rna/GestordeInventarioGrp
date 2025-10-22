namespace Proyecto_Base_de_Datos
{
    partial class LoginForm
    {
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;

        private void InitializeComponent()
        {
            panelLeft = new Panel();
            lblTitle = new Label();
            txtUser = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.MediumSlateBlue;
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(200, 426);
            panelLeft.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.MediumSlateBlue;
            lblTitle.Location = new Point(250, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(244, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "INICIO DE SESIÓN";
            // 
            // txtUser
            // 
            txtUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUser.Font = new Font("Segoe UI", 12F);
            txtUser.Location = new Point(250, 100);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Usuario";
            txtUser.Size = new Size(300, 34);
            txtUser.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(250, 150);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Contraseña";
            txtPassword.Size = new Size(300, 34);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.BackColor = Color.MediumSlateBlue;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(250, 210);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(300, 44);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Ingresar";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnExit.BackColor = Color.LightGray;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 12F);
            btnExit.Location = new Point(250, 260);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(300, 50);
            btnExit.TabIndex = 5;
            btnExit.Text = "Salir";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 426);
            Controls.Add(panelLeft);
            Controls.Add(lblTitle);
            Controls.Add(txtUser);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}