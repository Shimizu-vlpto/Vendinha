using System;

namespace Vendinha.Models
{
    public class ClienteResponseDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Email { get; set; } = string.Empty;
        public decimal TotalDividas { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataUltimoPagamento { get; set; }
    }

    public class ClienteNovoDTO
    {
        public string NomeCompleto { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; } = string.Empty;
        public decimal TotalDividas { get; set; }
    }
}