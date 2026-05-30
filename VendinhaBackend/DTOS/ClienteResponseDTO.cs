using System;

namespace VendinhaBackend.DTOs
{
    public class ClienteResponseDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal TotalDividas { get; set; }
        public DateTime? DataUltimoPagamento { get; set; }

        public int Idade => DateTime.Now.Year - DataNascimento.Year - (DateTime.Now.DayOfYear < DataNascimento.DayOfYear ? 1 : 0);
    }
}