using System;

namespace VendinhaBackend.Models
{
    public class ClienteNovoDTO
    {
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal TotalDividas { get; set; }

    }
}