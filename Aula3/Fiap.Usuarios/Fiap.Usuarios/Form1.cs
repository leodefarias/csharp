namespace Fiap.Usuarios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            TelaUsuario telaUsuario = new TelaUsuario();
            telaUsuario.Show();

        }
    }
}
