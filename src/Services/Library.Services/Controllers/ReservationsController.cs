using System;
using System.Threading.Tasks;
using Library.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Library.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Library.Services.Controllers
{

    [Route("v1/[controller]")]
    public class ReservationsController : ApiBaseController<Reservation, Guid>
    {
        public ReservationsController(
            IRepository<Reservation, Guid> repository,
            ILogger<ReservationsController> logger)
            : base(logger, repository)
        {
        }

        // GET: api/Reservations/5
        [HttpGet]
        public override async Task<IActionResult> GetAll()
        {
            return await base.GetAll();
        }

        // GET: api/Reservations
        [HttpGet("{id}")]
        public override async Task<IActionResult> Get(Guid id)
        {
            return await base.Get(id);
        }

        // Post: api/Reservations/5
        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] Reservation item)
        {
            return await base.Create(item);
        }

        // POST: api/Reservations
        [HttpPut]
        public override async Task<IActionResult> Update([FromBody] Reservation item)
        {
            return await base.Update(item);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await base.Delete(id);
        }
    }
}