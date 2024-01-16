using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using db.Contexto;
using db.Modelos;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly TiendabdContext _context;

        public MarcaController(TiendabdContext context)
        {
            _context = context;
        }

        // GET: api/Marca
        [HttpGet]
        public async Task<ActionResult<List<marca>>> GetMarcas()
        {
            var marcas = await _context.Marcas.Select(x => new marca
            {
                Id=x.Idmarca,
                nombre = x.Nombre,
                estado = x.Estado,
            }).ToListAsync();
            return Ok(marcas);
        }

        // GET: api/Marca/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarca(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);

            if (marca == null)
            {
                return NotFound();
            }

            return marca;
        }

        // PUT: api/Marca/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarca(int id, Marca marca)
        {
            if (id != marca.Idmarca)
            {
                return BadRequest();
            }

            _context.Entry(marca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(id))
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

        // POST: api/Marca
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Marca>> PostMarca(Marca marca)
        {
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarca", new { id = marca.Idmarca }, marca);
        }

        // DELETE: api/Marca/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarcaExists(int id)
        {
            return _context.Marcas.Any(e => e.Idmarca == id);
        }
    }
    public class marca
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
    }
}
