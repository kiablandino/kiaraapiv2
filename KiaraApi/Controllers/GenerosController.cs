using Microsoft.AspNetCore.Mvc;
using CUR.Api.Models;
using CUR.Api.Repositories;
using System.Threading.Tasks;

namespace CUR.Api.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly IGenericRepository<Genero> _repo;
        public GenerosController(IGenericRepository<Genero> repo) => _repo = repo;

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());
        [HttpGet("{id}")] public async Task<IActionResult> Get(int id) { var item = await _repo.GetByIdAsync(id); return item == null ? NotFound() : Ok(item); }
        [HttpPost] public async Task<IActionResult> Create([FromBody] Genero m) { if (!ModelState.IsValid) return BadRequest(ModelState); var c = await _repo.CreateAsync(m); return Created($"/api/generos/{c.GeneroId}", c); }
        [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] Genero m) { if (!ModelState.IsValid) return BadRequest(ModelState); if (id != m.GeneroId) return BadRequest("Id mismatch"); await _repo.UpdateAsync(m); return NoContent(); }
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _repo.DeleteAsync(id); return NoContent(); }
    }
}
