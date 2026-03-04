using System.Text.Json;
using System.Threading.Tasks;

namespace Aula2
{
    public partial class Form1 : Form
    {
        List<Aluno> listaAlunos = new List<Aluno>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            aluno.id = int.Parse(txtCodigo.Text);
            aluno.nome = txtNome.Text;

            listaAlunos.Add(aluno);

            txtCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;

            dgvAluno.DataSource = null;
            dgvAluno.DataSource = listaAlunos;

            MessageBox.Show("Aluno cadastrado com sucesso!", "Fiap");
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string url = $"https://viacep.com.br/ws/{txtCep.Text}/json";
            HttpClient httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);

            AlunoEndereco alunoEndereco = new AlunoEndereco();
            alunoEndereco = JsonSerializer.Deserialize<AlunoEndereco>(json);

            txtBairro.Text = alunoEndereco.BairroAluno;
            txtRua.Text = alunoEndereco.RuaAluno;
        }
    }
}
