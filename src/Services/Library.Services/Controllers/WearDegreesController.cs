using System;
using System.Threading.Tasks;
using Library.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Library.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Library.Services.Controllers
{
    [Route("v1/[controller]")]
    public class WearDegreesController : ApiBaseController<WearDegree, Guid>
    {
        public WearDegreesController(
            IRepository<WearDegree, Guid> repository,
            ILogger<WearDegreesController> logger)
            :base(logger, repository)
        {
        }

        // GET: api/WearDegrees
        [HttpGet]
        public override async Task<IActionResult> GetAll()
        {
            return await base.GetAll();
        }

        // GET: api/WearDegrees/5
        [HttpGet("{id}")]
        public override async Task<IActionResult> Get([FromRoute] Guid id)
        {
            return await base.Get(id);
        }

        // POST: api/WearDegrees
        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] WearDegree item)
        {
            return await base.Create(item);
        }

        // PUT: api/WearDegrees/5
        [HttpPut("{id}")]
        public override async Task<IActionResult> Update([FromBody] WearDegree item)
        {
            return await base.Update(item);
        }

        // DELETE: api/WearDegrees/5
        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await base.Delete(id);
        }
    }
}