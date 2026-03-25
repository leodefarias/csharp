namespace cp1correcao
{
    partial class Form1
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
            txtNome = new TextBox();
            txtCategoria = new TextBox();
            txtQuantidade = new TextBox();
            txtPreco = new TextBox();
            btnCadastrar = new Button();
            dgvProdutos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 41);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Preço";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 78);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 2;
            label3.Text = "Quantidade";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(0, 110);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 3;
            label4.Text = "Categoria";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(81, 0);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 4;
            // 
            // txtCategoria
            // 
            txtCategoria.Location = new Point(81, 110);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.Size = new Size(100, 23);
            txtCategoria.TabIndex = 5;
            // 
            // txtQuantidade
            // 
            txtQuantidade.Location = new Point(81, 75);
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.Size = new Size(100, 23);
            txtQuantidade.TabIndex = 6;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(81, 38);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(100, 23);
            txtPreco.TabIndex = 7;
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(81, 139);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(77, 23);
            btnCadastrar.TabIndex = 8;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // dgvProdutos
            // 
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Location = new Point(381, 41);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.Size = new Size(300, 188);
            dgvProdutos.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvProdutos);
            Controls.Add(btnCadastrar);
            Controls.Add(txtPreco);
            Controls.Add(txtQuantidade);
            Controls.Add(txtCategoria);
            Controls.Add(txtNome);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtNome;
        private TextBox txtCategoria;
        private TextBox txtQuantidade;
        private TextBox txtPreco;
        private Button btnCadastrar;
        private DataGridView dgvProdutos;
    }
}
