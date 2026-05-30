using System;

namespace VendinhaBackend.Models
{
    public class Divida
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataPagamento { get; set; }
        public Cliente? Cliente { get; set; }
    }
}