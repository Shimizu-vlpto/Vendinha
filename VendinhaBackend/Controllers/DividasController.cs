using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendinhaBackend.Data;
using VendinhaBackend.Models;
using VendinhaBackend.DTOs;


namespace VendinhaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DividasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DividasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostDivida(DividaNovaDTO dto)
        {
            var divida = new Divida
            {
                ClienteId = dto.ClienteId,
                Valor = dto.Valor,
                DataCriacao = DateTime.Now
            };

            _context.Dividas.Add(divida);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("{id}/pagar")]
        public async Task<ActionResult> PagarDivida(int id)
        {
            var divida = await _context.Dividas.FindAsync(id);
            if (divida == null)
            {
                return NotFound();
            }

            divida.DataPagamento = DateTime.Now;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}