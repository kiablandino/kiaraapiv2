using Microsoft.AspNetCore.Mvc;              
using CUR.Api.Models;
using CUR.Api.Repositories;

namespace CUR.Api.Controllers
{
    [ApiController]                              
    [Route("api/[controller]")]                
    public class DepartamentosController : BaseController<Departamento>
    {
        public DepartamentosController(IGenericRepository<Departamento> repo)
            : base(repo)
        { }
    }
}
