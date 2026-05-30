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
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteResponseDTO>>> GetClientes()
        {
            var clientes = await _context.Clientes
                .Include(c => c.Dividas)
                .Select(c => new ClienteResponseDTO
                {
                    Id = c.Id,
                    NomeCompleto = c.NomeCompleto,
                    Cpf = c.Cpf,
                    DataNascimento = c.DataNascimento,
                    Email = c.Email,
                    DataCriacao = c.DataCriacao,
                    TotalDividas = c.Dividas.Where(d => d.DataPagamento == null).Sum(d => d.Valor),
                    DataUltimoPagamento = c.Dividas.Where(d => d.Valor < 0).OrderByDescending(d => d.DataCriacao).Select(d => (DateTime?)d.DataCriacao).FirstOrDefault()
                })
                .ToListAsync();

            return Ok(clientes);
        }

        [HttpPost]
        public async Task<ActionResult> PostCliente(ClienteNovoDTO dto)
        {
            var cliente = new Cliente
            {
                NomeCompleto = dto.NomeCompleto,
                Cpf = dto.Cpf,
                DataNascimento = dto.DataNascimento,
                Email = dto.Email,
                DataCriacao = DateTime.Now
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCliente(int id, [FromBody] ClienteNovoDTO clienteDTO)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            cliente.NomeCompleto = clienteDTO.NomeCompleto;
            cliente.Cpf = clienteDTO.Cpf;
            cliente.Email = clienteDTO.Email;
            cliente.DataNascimento = clienteDTO.DataNascimento;


            await _context.SaveChangesAsync();

            return Ok();
        }

            [HttpPost("{id}/dividas")]
            public async Task<IActionResult> LancarDivida(int id, [FromBody] NovaDividaRequest request)
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null) return NotFound("Cliente não encontrado.");

                var novaDivida = new VendinhaBackend.Models.Divida
                {
                    ClienteId = id,
                    Valor = request.Valor,
                    DataCriacao = DateTime.Now
                };

                _context.Dividas.Add(novaDivida);
                await _context.SaveChangesAsync();

                return Ok();
            }
        [HttpPost("{id}/pagamentos")]
        public async Task<IActionResult> PagarDivida(int id, [FromBody] NovaDividaRequest request)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound("Cliente não encontrado.");

            var pagamento = new VendinhaBackend.Models.Divida
            {
                ClienteId = id,
                Valor = -request.Valor,
                DataCriacao = DateTime.Now
            };

            _context.Dividas.Add(pagamento);
            await _context.SaveChangesAsync();

            return Ok();
        }

        public class NovaDividaRequest
        {
            public decimal Valor { get; set; }
        }

      }
    } 
 
