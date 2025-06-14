using Microsoft.AspNetCore.Mvc;
using CUR.Api.Models;
using CUR.Api.Repositories;
using System.Threading.Tasks;

namespace CUR.Api.Controllers
{
    [ApiController]
    [Route("api/modalidades")]
    public class ModalidadesController : ControllerBase
    {
        private readonly IGenericRepository<Modalidad> _repo;
        public ModalidadesController(IGenericRepository<Modalidad> repo) => _repo = repo;

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());
        [HttpGet("{id}")] public async Task<IActionResult> Get(int id) { var item = await _repo.GetByIdAsync(id); return item == null ? NotFound() : Ok(item); }
        [HttpPost] public async Task<IActionResult> Create([FromBody] Modalidad m) { if (!ModelState.IsValid) return BadRequest(ModelState); var c = await _repo.CreateAsync(m); return Created($"/api/modalidades/{c.ModalidadId}", c); }
        [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] Modalidad m) { if (!ModelState.IsValid) return BadRequest(ModelState); if (id != m.ModalidadId) return BadRequest("Id mismatch"); await _repo.UpdateAsync(m); return NoContent(); }
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _repo.DeleteAsync(id); return NoContent(); }
    }
}
