using Microsoft.AspNetCore.Mvc;
using CUR.Api.Models;
using CUR.Api.Repositories;
using System.Threading.Tasks;

namespace CUR.Api.Controllers
{
    [ApiController]
    [Route("api/planes-estudio")]
    public class PlanesEstudioController : ControllerBase
    {
        private readonly IGenericRepository<PlanEstudio> _repo;
        public PlanesEstudioController(IGenericRepository<PlanEstudio> repo) => _repo = repo;

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());
        [HttpGet("{id}")] public async Task<IActionResult> Get(int id) { var item = await _repo.GetByIdAsync(id); return item == null ? NotFound() : Ok(item); }
        [HttpPost] public async Task<IActionResult> Create([FromBody] PlanEstudio m) { if (!ModelState.IsValid) return BadRequest(ModelState); var c = await _repo.CreateAsync(m); return Created($"/api/planes-estudio/{c.PlanEstudioId}", c); }
        [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] PlanEstudio m) { if (!ModelState.IsValid) return BadRequest(ModelState); if (id != m.PlanEstudioId) return BadRequest("Id mismatch"); await _repo.UpdateAsync(m); return NoContent(); }
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _repo.DeleteAsync(id); return NoContent(); }
    }
}
