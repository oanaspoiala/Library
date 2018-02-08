using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Library.Services.Controllers
{
    [Route("[controller]")]
    public class BookExemplariesController : ApiBaseController<BookExemplary, Guid>
    {

        public BookExemplariesController(
            IQueryRepository<BookExemplary, Guid> queryRepository,
            ICommandRepository<BookExemplary, Guid> commandRepository,
            ILogger<BookExemplariesController> logger)
            : base(queryRepository, commandRepository, logger)
        {
        }

        [HttpPost]
        public override async Task<IActionResult> Create([FromBody]BookExemplary item)
        {
            return await base.Create(item);
        }

        // GET: api/BookExemplaries
        [HttpGet]
        public override async Task<IActionResult> GetAll()
        {
            return await base.GetAll();
        }

        // GET: api/BookExemplaries/5
        [HttpGet("{id}")]
        public override async Task<IActionResult> Get(Guid id)
        {
            return await base.Get(id);
        }

        // PUT: api/BookExemplaries/5
        [HttpPut]
        public override async Task<IActionResult> Update([FromBody]BookExemplary item)
        {
            return await base.Update(item);
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(Guid id)
        {
            return await base.Delete(id);
        }
    }
}