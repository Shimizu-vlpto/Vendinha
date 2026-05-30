using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Vendinha.Models;

namespace Vendinha.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5179/api/") };
        }

        public async Task<List<ClienteResponseDTO>> GetClientesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ClienteResponseDTO>>("clientes") ?? new List<ClienteResponseDTO>();
        }

        public async Task AdicionarClienteAsync(ClienteNovoDTO cliente)
        {
            var response = await _httpClient.PostAsJsonAsync("clientes", cliente);
            response.EnsureSuccessStatusCode();
        }

        public async Task AtualizarClienteAsync(int id, ClienteNovoDTO cliente)
        {
            var response = await _httpClient.PutAsJsonAsync($"clientes/{id}", cliente);

            response.EnsureSuccessStatusCode();
        }

        public async Task ExcluirClienteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"clientes/{id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task LancarDividaAsync(int clienteId, decimal valor)
        {
            var request = new { Valor = valor };
            var response = await _httpClient.PostAsJsonAsync($"clientes/{clienteId}/dividas", request);

            response.EnsureSuccessStatusCode();
        }

        public async Task PagarDividaAsync(int clienteId, decimal valor)
        {
            var request = new { Valor = valor };
            var response = await _httpClient.PostAsJsonAsync($"clientes/{clienteId}/pagamentos", request);

            response.EnsureSuccessStatusCode();
        }
    }
}