using System.Text.Json;

namespace cp1correcao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtQuantidade.Text))
            {
                MessageBox.Show("Todos os campos são obrigatórios ");
                return;
            }

            var listaProdutos = new List<Produto>();

            var produtoAdicionar = new Produto()
            {
                Nome = txtNome.Text,
                Categoria = txtCategoria.Text,
                Preco = decimal.Parse(txtPreco.Text),
                Quantidade = int.Parse(txtQuantidade.Text)
            };

            listaProdutos.Add(produtoAdicionar);

            if(!File.Exists("produtos.json"))
            {
                string json = JsonSerializer.Serialize(listaProdutos);
                File.WriteAllText("produtos.json", json);
            } else
            {
                string json = File.ReadAllText("produtos.json");
                var listaAntiga = JsonSerializer.Deserialize<List<Produto>>(json);

                foreach(Produto produto in listaAntiga)
                {
                    listaProdutos.Add(produto);
                }

                listaProdutos.Add(produtoAdicionar);

                json = JsonSerializer.Serialize(listaProdutos);
                File.WriteAllText("produtos.json", json);
            }

            MessageBox.Show("Produto cadastrado!");
            txtNome.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtQuantidade.Text = string.Empty;


            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = listaProdutos;
            
        }
    }
}
