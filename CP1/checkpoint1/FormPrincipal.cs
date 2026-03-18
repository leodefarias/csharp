using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace checkpoint1
{
    public partial class FormPrincipal : Form
    {
        private readonly string caminhoArquivo = "produtos.json";

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            dataGridViewProdutos.DataSource = CarregarProdutos();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Nome do produto não pode estar vazio.";
                return;
            }

            if (!decimal.TryParse(txtPreco.Text, out decimal preco) || preco <= 0)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Preço inválido.";
                return;
            }

            if (!int.TryParse(txtQuantidade.Text, out int quantidade) || quantidade <= 0)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Quantidade inválida.";
                return;
            }

            if (string.IsNullOrEmpty(txtCep.Text))
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "CEP obrigatório.";
                return;
            }

            List<Produto> produtos = CarregarProdutos();

            Endereco endereco = new Endereco();
            endereco.Cep = txtCep.Text;

            Produto produto = new Produto()
            {
                Nome = txtNome.Text,
                Preco = preco,
                Quantidade = quantidade,
                CepFornecedor = endereco.Cep,
                Logradouro = endereco.Logradouro,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado
            };

            produtos.Add(produto);

            SalvarProdutos(produtos);

            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Produto cadastrado com sucesso!";
        }

        private List<Produto> CarregarProdutos()
        {
            if (!File.Exists(caminhoArquivo))
                return new List<Produto>();

            string json = File.ReadAllText(caminhoArquivo);

            return JsonSerializer.Deserialize<List<Produto>>(json)
                   ?? new List<Produto>();
        }

        private void SalvarProdutos(List<Produto> lista)
        {
            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(caminhoArquivo, json);

            dataGridViewProdutos.DataSource = null;
            dataGridViewProdutos.DataSource = CarregarProdutos();
        }

        private void btnBuscarCep_Click(object sender, EventArgs e)
        {
            Endereco endereco = new Endereco();
            endereco.Cep = txtCep.Text;

            txtLogradouro.Text = endereco.Logradouro;
            txtBairro.Text = endereco.Bairro;
            txtCidade.Text = endereco.Cidade;
            txtEstado.Text = endereco.Estado;
        }
    }
}