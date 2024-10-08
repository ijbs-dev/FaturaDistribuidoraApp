using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using DistribuidoraAPI.Data;
using DistribuidoraAPI.Models;

namespace DistribuidoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturamentoController : ControllerBase
    {
        private readonly FaturamentoContext _context;

        public FaturamentoController(FaturamentoContext context)
        {
            _context = context;
        }

        // GET: api/faturamento
        [HttpGet]
        public async Task<ActionResult> GetFaturamentoResumo()
        {
            try
            {

                var faturamentos = await _context.Faturamentos
                                                .Where(f => f.Valor > 0)
                                                .ToListAsync();

                if (!faturamentos.Any())
                {
                    return NotFound("Nenhum faturamento encontrado.");
                }

                double menorValor = faturamentos.Min(f => f.Valor);
                double maiorValor = faturamentos.Max(f => f.Valor);

                double mediaMensal = faturamentos.Average(f => f.Valor);
                int diasAcimaDaMedia = faturamentos.Count(f => f.Valor > mediaMensal);

                return Ok(new
                {
                    MenorValor = menorValor,
                    MaiorValor = maiorValor,
                    DiasAcimaDaMedia = diasAcimaDaMedia,
                    Faturamentos = faturamentos
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro no servidor. Detalhes: " + ex.Message);
            }
        }


        // GET: api/faturamento/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Faturamento>> GetFaturamento(int id)
        {
            var faturamento = await _context.Faturamentos.FindAsync(id);

            if (faturamento == null)
            {
                return NotFound();
            }

            return faturamento;
        }

        // POST: api/faturamento
        [HttpPost]
        public async Task<ActionResult> PostFaturamento(Faturamento faturamento)
        {
            Console.WriteLine("Recebida requisição POST para adicionar faturamento.");

            if (faturamento == null)
            {
                Console.WriteLine("Faturamento inválido.");
                return BadRequest("Faturamento inválido.");
            }

            _context.Faturamentos.Add(faturamento);
            await _context.SaveChangesAsync();

            Console.WriteLine("Faturamento adicionado com sucesso.");
            return CreatedAtAction(nameof(GetFaturamentoResumo), new { id = faturamento.Id }, faturamento);
        }



        // PUT: api/faturamento/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFaturamento(int id, Faturamento faturamento)
        {
            if (id != faturamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(faturamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaturamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/faturamento/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaturamento(int id)
        {
            var faturamento = await _context.Faturamentos.FindAsync(id);
            if (faturamento == null)
            {
                return NotFound();
            }

            _context.Faturamentos.Remove(faturamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FaturamentoExists(int id)
        {
            return _context.Faturamentos.Any(e => e.Id == id);
        }
    }
}
