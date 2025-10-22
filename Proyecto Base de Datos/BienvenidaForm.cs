namespace Proyecto_Base_de_Datos
{
    public partial class BienvenidaForm : Form
    {
        public BienvenidaForm()
        {
            InitializeComponent();

        }
        private void btnGoLogin_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void BienvenidaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
