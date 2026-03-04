namespace Aula2
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
            btnCadastrar = new Button();
            txtCodigo = new TextBox();
            txtNome = new TextBox();
            txtRm = new TextBox();
            lblCodigo = new Label();
            lblNome = new Label();
            lbl = new Label();
            dgvAluno = new DataGridView();
            lblCep = new Label();
            lblRua = new Label();
            lblBairro = new Label();
            txtCep = new TextBox();
            txtRua = new TextBox();
            txtBairro = new TextBox();
            btnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAluno).BeginInit();
            SuspendLayout();
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(268, 224);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(204, 40);
            btnCadastrar.TabIndex = 0;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(372, 34);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 23);
            txtCodigo.TabIndex = 1;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(314, 63);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(158, 23);
            txtNome.TabIndex = 2;
            // 
            // txtRm
            // 
            txtRm.Location = new Point(299, 92);
            txtRm.Name = "txtRm";
            txtRm.Size = new Size(173, 23);
            txtRm.TabIndex = 3;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(268, 37);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(98, 15);
            lblCodigo.TabIndex = 4;
            lblCodigo.Text = "Código do Aluno";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(268, 63);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(40, 15);
            lblNome.TabIndex = 5;
            lblNome.Text = "Nome";
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(268, 95);
            lbl.Name = "lbl";
            lbl.Size = new Size(25, 15);
            lbl.TabIndex = 6;
            lbl.Text = "RM";
            // 
            // dgvAluno
            // 
            dgvAluno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAluno.Location = new Point(268, 288);
            dgvAluno.Name = "dgvAluno";
            dgvAluno.Size = new Size(330, 150);
            dgvAluno.TabIndex = 7;
            // 
            // lblCep
            // 
            lblCep.AutoSize = true;
            lblCep.Location = new Point(268, 127);
            lblCep.Name = "lblCep";
            lblCep.Size = new Size(28, 15);
            lblCep.TabIndex = 8;
            lblCep.Text = "CEP";
            // 
            // lblRua
            // 
            lblRua.AutoSize = true;
            lblRua.Location = new Point(268, 155);
            lblRua.Name = "lblRua";
            lblRua.Size = new Size(27, 15);
            lblRua.TabIndex = 9;
            lblRua.Text = "Rua";
            // 
            // lblBairro
            // 
            lblBairro.AutoSize = true;
            lblBairro.Location = new Point(255, 188);
            lblBairro.Name = "lblBairro";
            lblBairro.Size = new Size(38, 15);
            lblBairro.TabIndex = 10;
            lblBairro.Text = "Bairro";
            // 
            // txtCep
            // 
            txtCep.Location = new Point(299, 127);
            txtCep.Name = "txtCep";
            txtCep.Size = new Size(173, 23);
            txtCep.TabIndex = 11;
            // 
            // txtRua
            // 
            txtRua.Enabled = false;
            txtRua.Location = new Point(299, 156);
            txtRua.Name = "txtRua";
            txtRua.Size = new Size(173, 23);
            txtRua.TabIndex = 12;
            // 
            // txtBairro
            // 
            txtBairro.Enabled = false;
            txtBairro.Location = new Point(299, 185);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(173, 23);
            txtBairro.TabIndex = 13;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(517, 117);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(204, 40);
            btnBuscar.TabIndex = 14;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBuscar);
            Controls.Add(txtBairro);
            Controls.Add(txtRua);
            Controls.Add(txtCep);
            Controls.Add(lblBairro);
            Controls.Add(lblRua);
            Controls.Add(lblCep);
            Controls.Add(dgvAluno);
            Controls.Add(lbl);
            Controls.Add(lblNome);
            Controls.Add(lblCodigo);
            Controls.Add(txtRm);
            Controls.Add(txtNome);
            Controls.Add(txtCodigo);
            Controls.Add(btnCadastrar);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvAluno).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCadastrar;
        private TextBox txtCodigo;
        private TextBox txtNome;
        private TextBox txtRm;
        private Label lblCodigo;
        private Label lblNome;
        private Label lbl;
        private DataGridView dgvAluno;
        private Label lblCep;
        private Label lblRua;
        private Label lblBairro;
        private TextBox txtCep;
        private TextBox txtRua;
        private TextBox txtBairro;
        private Button btnBuscar;
    }
}
