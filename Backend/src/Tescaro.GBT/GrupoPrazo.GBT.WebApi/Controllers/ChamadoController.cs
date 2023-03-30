using Tescaro.GBT.WebAPI.DataContext;
using Tescaro.GBT.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tescaro.GBT.WebAPI.Controllers
{
   

    [ApiController]
    [Route("api/[controller]")]
    public class ChamadoController : ControllerBase
    {
        private readonly GBTDbContext _GBTDbContext;

        public ChamadoController(GBTDbContext GBTDbContext)
        {
            _GBTDbContext = GBTDbContext;
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
