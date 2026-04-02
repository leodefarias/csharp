namespace cp1correcao
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtNome = new TextBox();
            txtPreco = new TextBox();
            txtQuantidade = new TextBox();
            txtCep = new TextBox();
            btnBuscarCep = new Button();
            txtLogradouro = new TextBox();
            txtBairro = new TextBox();
            txtCidade = new TextBox();
            txtEstado = new TextBox();
            btnCadastrar = new Button();
            btnExcluir = new Button();
            lblStatus = new Label();
            dgvProdutos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            SuspendLayout();
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Preco";
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Location = new Point(12, 73);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 2;
            label3.Text = "Quantidade";
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Location = new Point(12, 102);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 3;
            label4.Text = "CEP";
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Location = new Point(12, 131);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 4;
            label5.Text = "Logradouro";
            //
            // label6
            //
            label6.AutoSize = true;
            label6.Location = new Point(12, 160);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 5;
            label6.Text = "Bairro";
            //
            // label7
            //
            label7.AutoSize = true;
            label7.Location = new Point(12, 189);
            label7.Name = "label7";
            label7.Size = new Size(43, 15);
            label7.TabIndex = 6;
            label7.Text = "Cidade";
            //
            // label8
            //
            label8.AutoSize = true;
            label8.Location = new Point(12, 218);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 7;
            label8.Text = "Estado";
            //
            // txtNome
            //
            txtNome.Location = new Point(100, 12);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(200, 23);
            txtNome.TabIndex = 8;
            //
            // txtPreco
            //
            txtPreco.Location = new Point(100, 41);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(200, 23);
            txtPreco.TabIndex = 9;
            //
            // txtQuantidade
            //
            txtQuantidade.Location = new Point(100, 70);
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.Size = new Size(200, 23);
            txtQuantidade.TabIndex = 10;
            //
            // txtCep
            //
            txtCep.Location = new Point(100, 99);
            txtCep.MaxLength = 9;
            txtCep.Name = "txtCep";
            txtCep.Size = new Size(100, 23);
            txtCep.TabIndex = 11;
            //
            // btnBuscarCep
            //
            btnBuscarCep.Location = new Point(210, 99);
            btnBuscarCep.Name = "btnBuscarCep";
            btnBuscarCep.Size = new Size(90, 23);
            btnBuscarCep.TabIndex = 12;
            btnBuscarCep.Text = "Buscar CEP";
            btnBuscarCep.UseVisualStyleBackColor = true;
            btnBuscarCep.Click += btnBuscarCep_Click;
            //
            // txtLogradouro
            //
            txtLogradouro.Location = new Point(100, 128);
            txtLogradouro.Name = "txtLogradouro";
            txtLogradouro.ReadOnly = true;
            txtLogradouro.Size = new Size(200, 23);
            txtLogradouro.TabIndex = 13;
            //
            // txtBairro
            //
            txtBairro.Location = new Point(100, 157);
            txtBairro.Name = "txtBairro";
            txtBairro.ReadOnly = true;
            txtBairro.Size = new Size(200, 23);
            txtBairro.TabIndex = 14;
            //
            // txtCidade
            //
            txtCidade.Location = new Point(100, 186);
            txtCidade.Name = "txtCidade";
            txtCidade.ReadOnly = true;
            txtCidade.Size = new Size(200, 23);
            txtCidade.TabIndex = 15;
            //
            // txtEstado
            //
            txtEstado.Location = new Point(100, 215);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(200, 23);
            txtEstado.TabIndex = 16;
            //
            // btnCadastrar
            //
            btnCadastrar.Location = new Point(100, 250);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(120, 30);
            btnCadastrar.TabIndex = 17;
            btnCadastrar.Text = "Cadastrar Produto";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            //
            // btnExcluir
            //
            btnExcluir.Location = new Point(230, 250);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(120, 30);
            btnExcluir.TabIndex = 18;
            btnExcluir.Text = "Excluir Selecionado";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            //
            // lblStatus
            //
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(100, 290);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 19;
            lblStatus.Text = "";
            //
            // dgvProdutos
            //
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Location = new Point(12, 320);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.Size = new Size(760, 200);
            dgvProdutos.TabIndex = 20;
            //
            // FormPrincipal
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 531);
            Controls.Add(dgvProdutos);
            Controls.Add(lblStatus);
            Controls.Add(btnExcluir);
            Controls.Add(btnCadastrar);
            Controls.Add(txtEstado);
            Controls.Add(txtCidade);
            Controls.Add(txtBairro);
            Controls.Add(txtLogradouro);
            Controls.Add(btnBuscarCep);
            Controls.Add(txtCep);
            Controls.Add(txtQuantidade);
            Controls.Add(txtPreco);
            Controls.Add(txtNome);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormPrincipal";
            Text = "Cadastro de Produtos";
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtNome;
        private TextBox txtPreco;
        private TextBox txtQuantidade;
        private TextBox txtCep;
        private Button btnBuscarCep;
        private TextBox txtLogradouro;
        private TextBox txtBairro;
        private TextBox txtCidade;
        private TextBox txtEstado;
        private Button btnCadastrar;
        private Button btnExcluir;
        private Label lblStatus;
        private DataGridView dgvProdutos;
    }
}
