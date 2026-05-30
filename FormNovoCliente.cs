using System;
using System.Linq;
using System.Windows.Forms;
using Vendinha.Models;
using Vendinha.Services;

namespace Vendinha
{
    public partial class FormNovoCliente : Form
    {
        private readonly ApiService _apiService;
        private int? _clienteId;

        public FormNovoCliente(ClienteResponseDTO clienteExistente = null)
        {
            InitializeComponent();
            _apiService = new ApiService();
            this.StartPosition = FormStartPosition.CenterParent;

            // Bloqueia para não deixar digitar mais de 11 caracteres
            txtCpf.MaxLength = 11;

            if (clienteExistente != null)
            {
                _clienteId = clienteExistente.Id;
                this.Text = "Editar Cliente";
                txtNome.Text = clienteExistente.NomeCompleto;
                txtCpf.Text = clienteExistente.Cpf;
                txtEmail.Text = clienteExistente.Email;
                dtnNascimento.Value = clienteExistente.DataNascimento;
                txtDivida.Text = clienteExistente.TotalDividas.ToString();
                txtDivida.ReadOnly = true;
            }
            else
            {
                this.Text = "Cadastrar Novo Cliente";
                txtDivida.Text = "0";
                txtDivida.ReadOnly = true;
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            // 1. VALIDAÇÃO DO CPF (Exatamente 11 e apenas números)
            string cpfDigitado = txtCpf.Text.Trim();
            if (cpfDigitado.Length != 11 || !cpfDigitado.All(char.IsDigit))
            {
                MessageBox.Show("O CPF deve conter exatamente 11 números, sem pontos ou traços.", "CPF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Para tudo e não deixa salvar!
            }

            // 2. VALIDAÇÃO DE E-MAIL (Tem de ter @ e um ponto)
            string emailDigitado = txtEmail.Text.Trim();
            if (!emailDigitado.Contains("@") || !emailDigitado.Contains("."))
            {
                MessageBox.Show("Por favor, introduza um e-mail válido.", "E-mail Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Para tudo e não deixa salvar!
            }

            var dto = new ClienteNovoDTO
            {
                NomeCompleto = txtNome.Text,
                Cpf = txtCpf.Text,
                Email = txtEmail.Text,
                DataNascimento = dtnNascimento.Value,
                TotalDividas = string.IsNullOrWhiteSpace(txtDivida.Text) ? 0 : Convert.ToDecimal(txtDivida.Text)
            };

            try
            {
                btnSalvar.Enabled = false;

                if (_clienteId.HasValue)
                {
                    await _apiService.AtualizarClienteAsync(_clienteId.Value, dto);
                    MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _apiService.AdicionarClienteAsync(dto);
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSalvar.Enabled = true;
            }
        }
    }
}