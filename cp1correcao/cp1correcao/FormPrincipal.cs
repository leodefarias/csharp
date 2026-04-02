using System.Text.Json;
using System.Net.Http;

namespace cp1correcao
{
    public partial class FormPrincipal : Form
    {
        private List<Produto> produtos = new List<Produto>();
        private readonly string caminhoArquivo = "produtos.json";

        public FormPrincipal()
        {
            InitializeComponent();
            CarregarDados();
        }

        private async void btnBuscarCep_Click(object sender, EventArgs e)
        {
            string cep = txtCep.Text.Replace("-", "").Replace(" ", "");

            if (cep.Length != 8)
            {
                lblStatus.Text = "CEP deve ter 8 digitos.";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            try
            {
                string url = $"https://viacep.com.br/ws/{cep}/json/";
                HttpClient httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(url);

                Endereco endereco = JsonSerializer.Deserialize<Endereco>(json);

                txtLogradouro.Text = endereco.Logradouro;
                txtBairro.Text = endereco.Bairro;
                txtCidade.Text = endereco.Cidade;
                txtEstado.Text = endereco.Estado;

                lblStatus.Text = "CEP encontrado!";
                lblStatus.ForeColor = Color.Green;
            }
            catch (HttpRequestException)
            {
                lblStatus.Text = "Erro ao buscar CEP.";
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                lblStatus.Text = "Nome e obrigatorio.";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            if (!decimal.TryParse(txtPreco.Text, out decimal preco) || preco <= 0)
            {
                lblStatus.Text = "Preco deve ser um numero decimal maior que zero.";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            if (!int.TryParse(txtQuantidade.Text, out int quantidade) || quantidade <= 0)
            {
                lblStatus.Text = "Quantidade deve ser um numero inteiro maior que zero.";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            if (string.IsNullOrEmpty(txtCidade.Text))
            {
                lblStatus.Text = "Busque o CEP antes de cadastrar.";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            Produto produto = new Produto();
            produto.Nome = txtNome.Text;
            produto.Preco = preco;
            produto.Quantidade = quantidade;
            produto.CepFornecedor = txtCep.Text;
            produto.Logradouro = txtLogradouro.Text;
            produto.Bairro = txtBairro.Text;
            produto.Cidade = txtCidade.Text;
            produto.Estado = txtEstado.Text;

            produtos.Add(produto);
            SalvarDados();

            txtNome.Text = "";
            txtPreco.Text = "";
            txtQuantidade.Text = "";
            txtCep.Text = "";
            txtLogradouro.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";

            lblStatus.Text = "Produto cadastrado com sucesso!";
            lblStatus.ForeColor = Color.Green;

            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = produtos;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count == 0)
            {
                lblStatus.Text = "Selecione um produto para excluir.";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            int index = dgvProdutos.SelectedRows[0].Index;
            produtos.RemoveAt(index);
            SalvarDados();

            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = produtos;

            lblStatus.Text = "Produto excluido com sucesso!";
            lblStatus.ForeColor = Color.Green;
        }

        private void SalvarDados()
        {
            string json = JsonSerializer.Serialize(produtos);
            File.WriteAllText(caminhoArquivo, json);
        }

        private void CarregarDados()
        {
            if (!File.Exists(caminhoArquivo))
                return;

            string json = File.ReadAllText(caminhoArquivo);
            produtos = JsonSerializer.Deserialize<List<Produto>>(json);

            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = produtos;
        }
    }
}
