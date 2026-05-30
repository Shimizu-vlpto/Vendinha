namespace Vendinha
{
    partial class Form1
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
            txtBusca = new TextBox();
            btnNovoCliente = new Button();
            dgvClientes = new DataGridView();
            lblPagina = new Label();
            lblTotal = new Label();
            btnProximo = new Button();
            btnAnterior = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(511, 62);
            txtBusca.Name = "txtBusca";
            txtBusca.PlaceholderText = "Pesquise por Nome";
            txtBusca.Size = new Size(112, 23);
            txtBusca.TabIndex = 7;
            txtBusca.TextChanged += txtBusca_TextChanged;
            // 
            // btnNovoCliente
            // 
            btnNovoCliente.Location = new Point(3, 62);
            btnNovoCliente.Name = "btnNovoCliente";
            btnNovoCliente.Size = new Size(157, 23);
            btnNovoCliente.TabIndex = 8;
            btnNovoCliente.Text = "Cadastrar novo cliente";
            btnNovoCliente.UseVisualStyleBackColor = true;
            btnNovoCliente.Click += btnNovoCliente_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(3, 91);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(1196, 347);
            dgvClientes.TabIndex = 9;
            dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            dgvClientes.CellFormatting += dgvClientes_CellFormatting;
            dgvClientes.ColumnHeaderMouseClick += dgvClientes_ColumnHeaderMouseClick;
            // 
            // lblPagina
            // 
            lblPagina.AutoSize = true;
            lblPagina.Location = new Point(1122, 423);
            lblPagina.Name = "lblPagina";
            lblPagina.Size = new Size(77, 15);
            lblPagina.TabIndex = 10;
            lblPagina.Text = "Página 1 de 1";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(3, 423);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(45, 15);
            lblTotal.TabIndex = 11;
            lblTotal.Text = "Total: 0";
            // 
            // btnProximo
            // 
            btnProximo.Location = new Point(3, 397);
            btnProximo.Name = "btnProximo";
            btnProximo.Size = new Size(75, 23);
            btnProximo.TabIndex = 12;
            btnProximo.Text = ">";
            btnProximo.UseVisualStyleBackColor = true;
            btnProximo.Click += btnProximo_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(1122, 397);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(75, 23);
            btnAnterior.TabIndex = 13;
            btnAnterior.Text = "<";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 450);
            Controls.Add(btnAnterior);
            Controls.Add(btnProximo);
            Controls.Add(lblTotal);
            Controls.Add(lblPagina);
            Controls.Add(dgvClientes);
            Controls.Add(btnNovoCliente);
            Controls.Add(txtBusca);
            Name = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBusca;
        private Button btnNovoCliente;
        private DataGridView dgvClientes;
        private Label lblPagina;
        private Label lblTotal;
        private Button btnProximo;
        private Button btnAnterior;
    }
}