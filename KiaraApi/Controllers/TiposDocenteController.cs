using Microsoft.AspNetCore.Mvc;
using CUR.Api.Models;
using CUR.Api.Repositories;
using System.Threading.Tasks;

namespace CUR.Api.Controllers
{
    [ApiController]
    [Route("api/tipos-docente")]
    public class TiposDocenteController : ControllerBase
    {
        private readonly IGenericRepository<TipoDocente> _repo;
        public TiposDocenteController(IGenericRepository<TipoDocente> repo) => _repo = repo;

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());
        [HttpGet("{id}")] public async Task<IActionResult> Get(int id) { var item = await _repo.GetByIdAsync(id); return item == null ? NotFound() : Ok(item); }
        [HttpPost] public async Task<IActionResult> Create([FromBody] TipoDocente m) { if (!ModelState.IsValid) return BadRequest(ModelState); var c = await _repo.CreateAsync(m); return Created($"/api/tipos-docente/{c.TipoDocenteId}", c); }
        [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] TipoDocente m) { if (!ModelState.IsValid) return BadRequest(ModelState); if (id != m.TipoDocenteId) return BadRequest("Id mismatch"); await _repo.UpdateAsync(m); return NoContent(); }
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _repo.DeleteAsync(id); return NoContent(); }
    }
}
