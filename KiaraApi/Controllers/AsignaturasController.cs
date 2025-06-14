using Microsoft.AspNetCore.Mvc;
using CUR.Api.Models;
using CUR.Api.Repositories;
using System.Threading.Tasks;

namespace CUR.Api.Controllers
{
    [ApiController]
    [Route("api/asignaturas")]
    public class AsignaturasController : ControllerBase
    {
        private readonly IGenericRepository<Asignatura> _repo;
        public AsignaturasController(IGenericRepository<Asignatura> repo) => _repo = repo;

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());
        [HttpGet("{id}")] public async Task<IActionResult> Get(int id) { var item = await _repo.GetByIdAsync(id); return item == null ? NotFound() : Ok(item); }
        [HttpPost] public async Task<IActionResult> Create([FromBody] Asignatura m) { if (!ModelState.IsValid) return BadRequest(ModelState); var c = await _repo.CreateAsync(m); return Created($"/api/asignaturas/{c.AsignaturaId}", c); }
        [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] Asignatura m) { if (!ModelState.IsValid) return BadRequest(ModelState); if (id != m.AsignaturaId) return BadRequest("Id mismatch"); await _repo.UpdateAsync(m); return NoContent(); }
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _repo.DeleteAsync(id); return NoContent(); }
    }
}
