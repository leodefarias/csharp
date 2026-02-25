namespace Aula1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if(txtNome.Text == "leo")
            {
                Menu telaMenu = new Menu();

                telaMenu.Show();
            } else
            {
                MessageBox.Show("usuario errado", "ERRO");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Olá", "FIAP");
        }
    }
}
