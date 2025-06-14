using Microsoft.AspNetCore.Mvc;
using CUR.Api.Models;
using CUR.Api.Repositories;
using System.Threading.Tasks;

namespace CUR.Api.Controllers
{
    [ApiController]
    [Route("api/direcciones")]
    public class DireccionesController : ControllerBase
    {
        private readonly IGenericRepository<Direccion> _repo;
        public DireccionesController(IGenericRepository<Direccion> repo) => _repo = repo;

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());
        [HttpGet("{id}")] public async Task<IActionResult> Get(int id) { var item = await _repo.GetByIdAsync(id); return item == null ? NotFound() : Ok(item); }
        [HttpPost] public async Task<IActionResult> Create([FromBody] Direccion m) { if (!ModelState.IsValid) return BadRequest(ModelState); var c = await _repo.CreateAsync(m); return Created($"/api/direcciones/{c.DireccionId}", c); }
        [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] Direccion m) { if (!ModelState.IsValid) return BadRequest(ModelState); if (id != m.DireccionId) return BadRequest("Id mismatch"); await _repo.UpdateAsync(m); return NoContent(); }
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _repo.DeleteAsync(id); return NoContent(); }
    }
}
