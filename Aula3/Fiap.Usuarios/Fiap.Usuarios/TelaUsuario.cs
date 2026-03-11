using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fiap.Usuarios
{
    public partial class TelaUsuario : Form
    {
        public TelaUsuario()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            List<Usuario> usuarios = CarregarUsuarios();

            Usuario usuarioCadastrar = new Usuario();

            usuarioCadastrar.Nome = txtNome.Text;
            usuarioCadastrar.Senha = txtSenha.Text;
            usuarioCadastrar.Email = txtEmail.Text;

            usuarios.Add(usuarioCadastrar);

            MessageBox.Show("Cadastro realizado");

            SalvarUsuarios(usuarios);

            txtEmail.Text = "";
        }

        public List<Usuario> CarregarUsuarios()
        {

            if (!File.Exists("usuarios.json"))
                return new List<Usuario>();

            string json = File.ReadAllText("usuarios.json");

            return JsonSerializer.Deserialize<List<Usuario>>(json);
        }

        public void SalvarUsuarios(List<Usuario> lista)
        {
            string json = JsonSerializer.Serialize(lista);
            File.WriteAllText("usuarios.json", json);

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = CarregarUsuarios();
        }

        private void TelaUsuario_Load(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = CarregarUsuarios();
            
        }
    }
}
