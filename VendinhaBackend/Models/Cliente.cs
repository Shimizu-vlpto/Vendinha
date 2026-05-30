using System;
using System.Collections.Generic;

namespace VendinhaBackend.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public List<Divida> Dividas { get; set; } = new List<Divida>();
    }
}