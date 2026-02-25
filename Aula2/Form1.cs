namespace Aula2
{
    public partial class Form1 : Form
    {
        List<Aluno> listaAlunos = new List<Aluno>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            aluno.id = int.Parse(txtCodigo.Text);
            aluno.nome = txtNome.Text;

            listaAlunos.Add( aluno );

            txtCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;

            MessageBox.Show("Aluno cadastrado com sucesso!", "Fiap");
        }
    }
}
