namespace checkpoint1
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNome = new TextBox();
            txtLogradouro = new TextBox();
            txtCep = new TextBox();
            txtPreco = new TextBox();
            txtQuantidade = new TextBox();
            txtBairro = new TextBox();
            txtEstado = new TextBox();
            txtCidade = new TextBox();
            btnCadastrar = new Button();
            btnBuscarCep = new Button();
            btnExcluir = new Button();
            lblStatus = new Label();
            dataGridViewProdutos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutos).BeginInit();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 34);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Nome do produto";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 0;
            txtNome.TabStop = false;
            // 
            // txtLogradouro
            // 
            txtLogradouro.Location = new Point(12, 150);
            txtLogradouro.Name = "txtLogradouro";
            txtLogradouro.PlaceholderText = "Logradouro";
            txtLogradouro.ReadOnly = true;
            txtLogradouro.Size = new Size(100, 23);
            txtLogradouro.TabIndex = 1;
            // 
            // txtCep
            // 
            txtCep.Location = new Point(12, 121);
            txtCep.MaxLength = 9;
            txtCep.Name = "txtCep";
            txtCep.PlaceholderText = "CEP";
            txtCep.Size = new Size(100, 23);
            txtCep.TabIndex = 2;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(12, 63);
            txtPreco.Name = "txtPreco";
            txtPreco.PlaceholderText = "Preço";
            txtPreco.Size = new Size(100, 23);
            txtPreco.TabIndex = 3;
            // 
            // txtQuantidade
            // 
            txtQuantidade.Location = new Point(12, 92);
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.PlaceholderText = "Quantidade";
            txtQuantidade.Size = new Size(100, 23);
            txtQuantidade.TabIndex = 4;
            // 
            // txtBairro
            // 
            txtBairro.Location = new Point(12, 179);
            txtBairro.Name = "txtBairro";
            txtBairro.PlaceholderText = "Bairro";
            txtBairro.ReadOnly = true;
            txtBairro.Size = new Size(100, 23);
            txtBairro.TabIndex = 5;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(12, 237);
            txtEstado.Name = "txtEstado";
            txtEstado.PlaceholderText = "Estado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(100, 23);
            txtEstado.TabIndex = 6;
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(12, 208);
            txtCidade.Name = "txtCidade";
            txtCidade.PlaceholderText = "Cidade";
            txtCidade.ReadOnly = true;
            txtCidade.Size = new Size(100, 23);
            txtCidade.TabIndex = 7;
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(12, 266);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(75, 23);
            btnCadastrar.TabIndex = 8;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnBuscarCep
            // 
            btnBuscarCep.Location = new Point(128, 120);
            btnBuscarCep.Name = "btnBuscarCep";
            btnBuscarCep.Size = new Size(75, 23);
            btnBuscarCep.TabIndex = 9;
            btnBuscarCep.Text = "Buscar";
            btnBuscarCep.UseVisualStyleBackColor = true;
            btnBuscarCep.Click += btnBuscarCep_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(93, 266);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 10;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(291, 71);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status";
            // 
            // dataGridViewProdutos
            // 
            dataGridViewProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProdutos.Location = new Point(8, 304);
            dataGridViewProdutos.Name = "dataGridViewProdutos";
            dataGridViewProdutos.Size = new Size(686, 150);
            dataGridViewProdutos.TabIndex = 13;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewProdutos);
            Controls.Add(lblStatus);
            Controls.Add(btnExcluir);
            Controls.Add(btnBuscarCep);
            Controls.Add(btnCadastrar);
            Controls.Add(txtCidade);
            Controls.Add(txtEstado);
            Controls.Add(txtBairro);
            Controls.Add(txtQuantidade);
            Controls.Add(txtPreco);
            Controls.Add(txtCep);
            Controls.Add(txtLogradouro);
            Controls.Add(txtNome);
            Name = "FormPrincipal";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private TextBox txtLogradouro;
        private TextBox txtCep;
        private TextBox txtPreco;
        private TextBox txtQuantidade;
        private TextBox txtBairro;
        private TextBox txtEstado;
        private TextBox txtCidade;
        private Button btnCadastrar;
        private Button btnBuscarCep;
        private Button btnExcluir;
        private Label lblStatus;
        private DataGridView dataGridViewProdutos;
    }
}
