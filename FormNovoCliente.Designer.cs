namespace Vendinha
{
    partial class FormNovoCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNome = new TextBox();
            txtCpf = new TextBox();
            txtEmail = new TextBox();
            label1 = new Label();
            dtaNascimento = new Label();
            dtnNascimento = new DateTimePicker();
            btnSalvar = new Button();
            label2 = new Label();
            txtDivida = new TextBox();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(208, 97);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "NOME";
            txtNome.Size = new Size(421, 23);
            txtNome.TabIndex = 0;
            txtNome.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(208, 156);
            txtCpf.Name = "txtCpf";
            txtCpf.PlaceholderText = "CPF";
            txtCpf.Size = new Size(421, 23);
            txtCpf.TabIndex = 1;
            txtCpf.TextAlign = HorizontalAlignment.Center;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(208, 213);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-MAIL";
            txtEmail.Size = new Size(421, 23);
            txtEmail.TabIndex = 2;
            txtEmail.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(323, 36);
            label1.Name = "label1";
            label1.Size = new Size(179, 30);
            label1.TabIndex = 5;
            label1.Text = "Cadastrar Cliente";
            // 
            // dtaNascimento
            // 
            dtaNascimento.AutoSize = true;
            dtaNascimento.Location = new Point(208, 272);
            dtaNascimento.Name = "dtaNascimento";
            dtaNascimento.Size = new Size(114, 15);
            dtaNascimento.TabIndex = 6;
            dtaNascimento.Text = "Data de Nascimento";
            // 
            // dtnNascimento
            // 
            dtnNascimento.Location = new Point(338, 266);
            dtnNascimento.Name = "dtnNascimento";
            dtnNascimento.Size = new Size(291, 23);
            dtnNascimento.TabIndex = 7;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(323, 395);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 8;
            btnSalvar.Text = "Salvar Cadastro";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 321);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 9;
            label2.Text = "Dívida R$";
            // 
            // txtDivida
            // 
            txtDivida.Location = new Point(338, 313);
            txtDivida.Name = "txtDivida";
            txtDivida.ReadOnly = true;
            txtDivida.Size = new Size(291, 23);
            txtDivida.TabIndex = 10;
            // 
            // FormNovoCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtDivida);
            Controls.Add(label2);
            Controls.Add(btnSalvar);
            Controls.Add(dtnNascimento);
            Controls.Add(dtaNascimento);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(txtCpf);
            Controls.Add(txtNome);
            Name = "FormNovoCliente";
            Text = "b";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private TextBox txtCpf;
        private TextBox txtEmail;
        private Label label1;
        private Label dtaNascimento;
        private DateTimePicker dtnNascimento;
        private Button btnSalvar;
        private Label label2;
        private TextBox txtDivida;
    }
}