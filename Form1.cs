using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vendinha.Models;
using Vendinha.Services;

namespace Vendinha
{
    public partial class Form1 : Form
    {
        private readonly ApiService _apiService;
        private List<ClienteResponseDTO> _todosClientes;
        private int _paginaAtual = 1;
        private int _tamanhoPagina = 10;
        private bool _ordenarMaiorDivida = false;


        public Form1()
        {
            InitializeComponent();
            _apiService = new ApiService();
            _todosClientes = new List<ClienteResponseDTO>();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await CarregarClientes();
            ConfigurarTabela();
            AdicionarBotoesAcao();
        }

        private async Task CarregarClientes()
        {
            try
            {
                _todosClientes = await _apiService.GetClientesAsync();

                AtualizarTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar: " + ex.Message);
            }
        }

        private void AtualizarGrade()
        {
            var textoBusca = txtBusca.Text.ToLower();
            var clientesFiltrados = _todosClientes;

            if (!string.IsNullOrEmpty(textoBusca))
            {
                clientesFiltrados = _todosClientes
                    .Where(c => c.NomeCompleto.ToLower().Contains(textoBusca) || c.Cpf.Contains(textoBusca))
                    .ToList();
            }

            var clientesPaginados = clientesFiltrados
                .Skip((_paginaAtual - 1) * _tamanhoPagina)
                .Take(_tamanhoPagina)
                .ToList();

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientesPaginados;

            ConfigurarTabela();
        }
        private void AtualizarTela()
        {
            if (_todosClientes == null) return;

            string termo = txtBusca.Text.Trim().ToLower();
            var listaFiltrada = _todosClientes
                .Where(c => string.IsNullOrEmpty(termo) || c.NomeCompleto.ToLower().Contains(termo))
                .ToList();

            if (_ordenarMaiorDivida)
            {
                listaFiltrada = listaFiltrada.OrderByDescending(c => c.TotalDividas).ToList();
            }
            else
            {
                listaFiltrada = listaFiltrada.OrderBy(c => c.NomeCompleto).ToList();
            }

            int totalClientes = listaFiltrada.Count;
            int totalPaginas = (int)Math.Ceiling((double)totalClientes / _tamanhoPagina);

            if (totalPaginas == 0) totalPaginas = 1;
            if (_paginaAtual > totalPaginas) _paginaAtual = totalPaginas;

            var clientesPagina = listaFiltrada
                .Skip((_paginaAtual - 1) * _tamanhoPagina)
                .Take(_tamanhoPagina)
                .ToList();

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientesPagina;
            ConfigurarTabela();

            if (lblTotal != null) lblTotal.Text = $"Total de clientes cadastrados: {totalClientes}";
            if (lblPagina != null) lblPagina.Text = $"Página {_paginaAtual} de {totalPaginas}";

            if (btnAnterior != null) btnAnterior.Enabled = _paginaAtual > 1;
            if (btnProximo != null) btnProximo.Enabled = _paginaAtual < totalPaginas;
        }

        private void AdicionarBotoesAcao()
        {
            if (!dgvClientes.Columns.Contains("btnEditar"))
            {
                DataGridViewButtonColumn colunaEditar = new DataGridViewButtonColumn();
                colunaEditar.Name = "btnEditar";
                colunaEditar.HeaderText = "";
                colunaEditar.Text = "Editar";
                colunaEditar.UseColumnTextForButtonValue = true;
                dgvClientes.Columns.Add(colunaEditar);
            }

            if (!dgvClientes.Columns.Contains("btnExcluir"))
            {
                DataGridViewButtonColumn colunaExcluir = new DataGridViewButtonColumn();
                colunaExcluir.Name = "btnExcluir";
                colunaExcluir.HeaderText = "";
                colunaExcluir.Text = "Excluir";
                colunaExcluir.UseColumnTextForButtonValue = true;
                dgvClientes.Columns.Add(colunaExcluir);
            }

            if (!dgvClientes.Columns.Contains("btnDivida"))
            {
                DataGridViewButtonColumn colunaDivida = new DataGridViewButtonColumn();
                colunaDivida.Name = "btnDivida";
                colunaDivida.HeaderText = "";
                colunaDivida.Text = "+ Dívida";
                colunaDivida.UseColumnTextForButtonValue = true;
                dgvClientes.Columns.Add(colunaDivida);
            }

            if (!dgvClientes.Columns.Contains("btnPagar"))
            {
                DataGridViewButtonColumn colunaPagar = new DataGridViewButtonColumn();
                colunaPagar.Name = "btnPagar";
                colunaPagar.HeaderText = "";
                colunaPagar.Text = "Pagar";
                colunaPagar.UseColumnTextForButtonValue = true;
                dgvClientes.Columns.Add(colunaPagar);
            }

            if (!dgvClientes.Columns.Contains("btnEditar"))
            {
                DataGridViewButtonColumn colunaEditar = new DataGridViewButtonColumn();
                colunaEditar.Name = "btnEditar";
                
            }
        }

        private void ConfigurarTabela()
        {
           
            if (dgvClientes.Columns["Id"] != null)
                dgvClientes.Columns["Id"].Visible = false;

            int posicao = 0; 

            if (dgvClientes.Columns["NomeCompleto"] != null)
            {
                dgvClientes.Columns["NomeCompleto"].HeaderText = "Nome";
                dgvClientes.Columns["NomeCompleto"].DisplayIndex = posicao++;
            }

            if (dgvClientes.Columns["Cpf"] != null)
            {
                dgvClientes.Columns["Cpf"].HeaderText = "CPF";
                dgvClientes.Columns["Cpf"].DisplayIndex = posicao++;
            }

            if (dgvClientes.Columns["Idade"] != null)
            {
                dgvClientes.Columns["Idade"].HeaderText = "Idade";
                dgvClientes.Columns["Idade"].DisplayIndex = posicao++;
            }

            if (dgvClientes.Columns["Email"] != null)
            {
                dgvClientes.Columns["Email"].HeaderText = "E-mail";
                dgvClientes.Columns["Email"].DisplayIndex = posicao++;
            }

            if (dgvClientes.Columns["TotalDividas"] != null)
            {
                dgvClientes.Columns["TotalDividas"].HeaderText = "Dívida";
                dgvClientes.Columns["TotalDividas"].DefaultCellStyle.Format = "C2";
                dgvClientes.Columns["TotalDividas"].DisplayIndex = posicao++;
            }

            if (dgvClientes.Columns["DataNascimento"] != null)
            {
                dgvClientes.Columns["DataNascimento"].HeaderText = "Data de Nascimento";
                dgvClientes.Columns["DataNascimento"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvClientes.Columns["DataNascimento"].DisplayIndex = posicao++;
            }

            if (dgvClientes.Columns["DataCriacao"] != null)
            {
                dgvClientes.Columns["DataCriacao"].HeaderText = "Data que foi criado";
                dgvClientes.Columns["DataCriacao"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvClientes.Columns["DataCriacao"].DisplayIndex = posicao++;
            }

            if (dgvClientes.Columns["DataUltimoPagamento"] != null)
            {
                dgvClientes.Columns["DataUltimoPagamento"].HeaderText = "Último Pagamento";
                dgvClientes.Columns["DataUltimoPagamento"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvClientes.Columns["DataUltimoPagamento"].DisplayIndex = posicao++;
            }

            
            if (dgvClientes.Columns["btnDivida"] != null)
                dgvClientes.Columns["btnDivida"].DisplayIndex = posicao++;

            if (dgvClientes.Columns["btnPagar"] != null)
                dgvClientes.Columns["btnPagar"].DisplayIndex = posicao++;

            if (dgvClientes.Columns["btnEditar"] != null)
                dgvClientes.Columns["btnEditar"].DisplayIndex = posicao++;

            if (dgvClientes.Columns["btnExcluir"] != null)
                dgvClientes.Columns["btnExcluir"].DisplayIndex = posicao++;
        }



        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            _paginaAtual = 1; 
            AtualizarTela();  
        }

        private async void btnNovoCliente_Click(object sender, EventArgs e)
        {
            using (var popup = new FormNovoCliente())
            {
                var resultado = popup.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    await CarregarClientes();
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (_paginaAtual > 1)
            {
                _paginaAtual--;
                AtualizarTela();
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            _paginaAtual++;
            AtualizarTela();
        }

        private async void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
               
                if (dgvClientes.Columns[e.ColumnIndex].Name == "btnExcluir")
                {
                    int id = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["Id"].Value);
                    var confirmacao = MessageBox.Show("Deseja realmente excluir este cliente?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmacao == DialogResult.Yes)
                    {
                        try
                        {
                            await _apiService.ExcluirClienteAsync(id);
                            MessageBox.Show("Cliente excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            await CarregarClientes(); 
                        }
                        catch (Exception ex)
                        {
                            
                            MessageBox.Show("Não foi possível excluir: " + ex.Message, "Erro na API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (dgvClientes.Columns[e.ColumnIndex].Name == "btnEditar")
                {
                    int id = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["Id"].Value);
                    var clienteSelecionado = _todosClientes.FirstOrDefault(c => c.Id == id);

                    if (clienteSelecionado != null)
                    {
                        using (var popup = new FormNovoCliente(clienteSelecionado))
                        {
                            var resultado = popup.ShowDialog();

                            if (resultado == DialogResult.OK)
                            {
                                await CarregarClientes();
                            }
                        }
                    }
                }
                else if (dgvClientes.Columns[e.ColumnIndex].Name == "btnDivida")
                {
                    int id = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["Id"].Value);
                    string nome = dgvClientes.Rows[e.RowIndex].Cells["NomeCompleto"].Value.ToString();

                    Form formDivida = new Form()
                    {
                        Width = 350,
                        Height = 150,
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        Text = $"Nova Compra - {nome}",
                        StartPosition = FormStartPosition.CenterParent,
                        MaximizeBox = false,
                        MinimizeBox = false
                    };

                    Label lblValor = new Label() { Left = 20, Top = 20, Text = "Valor da compra (R$):", Width = 150 };
                    TextBox txtValor = new TextBox() { Left = 20, Top = 45, Width = 120 };
                    Button btnConfirmar = new Button() { Text = "Lançar Dívida", Left = 160, Top = 43, Width = 120 };

                    btnConfirmar.Click += async (s, args) =>
                    {
                        if (decimal.TryParse(txtValor.Text.Replace(".", ","), out decimal valorCompra))
                        {
                            btnConfirmar.Enabled = false;
                            try
                            {
                                await _apiService.LancarDividaAsync(id, valorCompra);
                                MessageBox.Show("Dívida lançada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                formDivida.DialogResult = DialogResult.OK; // Fecha a janelinha
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro ao lançar dívida: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                btnConfirmar.Enabled = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, digite um valor numérico válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    };

                    formDivida.Controls.Add(lblValor);
                    formDivida.Controls.Add(txtValor);
                    formDivida.Controls.Add(btnConfirmar);

                    if (formDivida.ShowDialog() == DialogResult.OK)
                    {
                        await CarregarClientes(); 
                    }
                }
                // ...
                else if (dgvClientes.Columns[e.ColumnIndex].Name == "btnPagar")
                {
                    int id = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["Id"].Value);
                    string nome = dgvClientes.Rows[e.RowIndex].Cells["NomeCompleto"].Value.ToString();

                    Form formPagamento = new Form()
                    {
                        Width = 350,
                        Height = 150,
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        Text = $"Receber Pagamento - {nome}",
                        StartPosition = FormStartPosition.CenterParent,
                        MaximizeBox = false,
                        MinimizeBox = false
                    };

                    Label lblValor = new Label() { Left = 20, Top = 20, Text = "Valor pago (R$):", Width = 150 };
                    TextBox txtValor = new TextBox() { Left = 20, Top = 45, Width = 120 };
                    Button btnConfirmar = new Button() { Text = "Confirmar Pagamento", Left = 160, Top = 43, Width = 140 };

                    btnConfirmar.Click += async (s, args) =>
                    {
                        if (decimal.TryParse(txtValor.Text.Replace(".", ","), out decimal valorPago) && valorPago > 0)
                        {
                            btnConfirmar.Enabled = false;
                            try
                            {
                                await _apiService.PagarDividaAsync(id, valorPago);
                                MessageBox.Show("Pagamento registado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                formPagamento.DialogResult = DialogResult.OK;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro ao registar pagamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                btnConfirmar.Enabled = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, digite um valor numérico válido e maior que zero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    };

                    formPagamento.Controls.Add(lblValor);
                    formPagamento.Controls.Add(txtValor);
                    formPagamento.Controls.Add(btnConfirmar);

                    if (formPagamento.ShowDialog() == DialogResult.OK)
                    {
                        await CarregarClientes();
                    }
                }
            }

        }
        
        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClientes.Columns[e.ColumnIndex].Name == "TotalDividas")
            {
                if (e.Value != null)
                {
                    decimal divida = Convert.ToDecimal(e.Value);

                    if (divida == 0)
                    {
                        e.Value = "em dia";
                        e.FormattingApplied = true; 
                    }
                }
            }
        }
        private void dgvClientes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvClientes.Columns[e.ColumnIndex].Name == "TotalDividas")
            {
                _ordenarMaiorDivida = !_ordenarMaiorDivida; 
                _paginaAtual = 1; 
                AtualizarTela();
            }
        }


    }
}