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
            lblRm = new Label();
            SuspendLayout();
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(268, 121);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(204, 40);
            btnCadastrar.TabIndex = 0;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += button1_Click;
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
            // lblRm
            // 
            lblRm.AutoSize = true;
            lblRm.Location = new Point(268, 95);
            lblRm.Name = "lblRm";
            lblRm.Size = new Size(25, 15);
            lblRm.TabIndex = 6;
            lblRm.Text = "RM";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblRm);
            Controls.Add(lblNome);
            Controls.Add(lblCodigo);
            Controls.Add(txtRm);
            Controls.Add(txtNome);
            Controls.Add(txtCodigo);
            Controls.Add(btnCadastrar);
            Name = "Form1";
            Text = "Form1";
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
        private Label lblRm;
    }
}
