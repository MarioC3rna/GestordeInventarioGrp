using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // ✅ Usar el nuevo namespace

namespace Proyecto_Base_de_Datos
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Mostrar puntos en la contraseña
            txtPassword.PasswordChar = '●';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUser.Text.Trim();
            string contraseña = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Ingrese usuario y contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔹 Cadena de conexión usando SQL Server Authentication
            string connectionString = $"Data Source=SRV-BD\\MYISTANCE;Initial Catalog=Db_EmpresaDev;User ID={usuario};Password={contraseña};Encrypt=True;TrustServerCertificate=True;";



            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open(); // Login válido

                    // 🔹 Guardar usuario activo global
                    UsuarioActivo.NombreUsuario = usuario;

                    MessageBox.Show($"Bienvenido {usuario}.", "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abrir formulario de opciones
                    OpcionesForm opcionesForm = new OpcionesForm();
                    opcionesForm.Show();
                    this.Hide();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos, o sin permisos de acceso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            BienvenidaForm bienvenidaForm = new BienvenidaForm();
            bienvenidaForm.Show();
            this.Hide();
        }
    }
}
