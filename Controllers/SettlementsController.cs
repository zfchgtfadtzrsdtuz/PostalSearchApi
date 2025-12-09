using Microsoft.AspNetCore.Mvc;
using PostalSearchApi.Data;
using PostalSearchApi.Models;

namespace PostalSearchApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SettlementsController : ControllerBase
    {
        private readonly SettlementRepository _repo;

        public SettlementsController(SettlementRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Settlement>> Get([FromQuery] string? postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode))
                return Ok(_repo.GetAll());

            return Ok(_repo.GetByPostalCode(postalCode));
        }

        [HttpGet("{id:int}")]
        public ActionResult<Settlement> GetById(int id)
        {
            var item = _repo.GetAll().FirstOrDefault(s => s.Id == id);
            if (item == null) return NotFound();
            return Ok(item);
        }
    }
}
