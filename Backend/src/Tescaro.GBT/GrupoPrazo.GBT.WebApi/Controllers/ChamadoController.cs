using Microsoft.AspNetCore.Mvc;
using Tescaro.GBT.Domain.Models;
using Tescaro.GBT.Persistence;

namespace Tescaro.GBT.API.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class ChamadoController : ControllerBase
    {
        private readonly GBTContext _GBTDbContext;

        public ChamadoController(GBTContext GBTContext)
        {
            _GBTDbContext = GBTContext;
        }


        [HttpGet]
        public IEnumerable<Chamado> Get()
        {
            var resultado = _GBTDbContext.Chamado;
            return resultado ;
        }

        [HttpGet("id")]
        public IEnumerable<Chamado> GetById(int id)
        {

            return _GBTDbContext.Chamado.Where(x => x.Id == id);
        }
    }

}
