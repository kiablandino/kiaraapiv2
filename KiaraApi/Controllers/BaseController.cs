using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CUR.Api.Repositories;

namespace CUR.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<T> : ControllerBase where T : class
    {
        protected readonly IGenericRepository<T> _repo;
        protected BaseController(IGenericRepository<T> repo) => _repo = repo;

        [HttpGet]
        public virtual async Task<IActionResult> GetAll() =>
            Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] T model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _repo.CreateAsync(model);
            return CreatedAtAction(nameof(Get), new { id = GetId(created) }, created);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] T model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!MatchId(model, id)) return BadRequest("Id mismatch");
            await _repo.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }

        // Métodos auxiliares que esperan que la entidad tenga una propiedad {Tipo}Id
        private object GetId(T entity)
        {
            var prop = typeof(T).GetProperty($"{typeof(T).Name}Id");
            return prop?.GetValue(entity)!;
        }
        private bool MatchId(T model, int id)
        {
            var prop = typeof(T).GetProperty($"{typeof(T).Name}Id");
            var val = prop?.GetValue(model);
            return val is not null && (int)val == id;
        }
    }
}
