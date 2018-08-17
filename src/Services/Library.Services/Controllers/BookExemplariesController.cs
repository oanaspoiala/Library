using System;
using System.Threading.Tasks;
using Library.Domain.Core.Interfaces;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Services.Controllers
{
    [Route("[controller]")]
    public class BookExemplariesController : ApiBaseController<BookExemplary, Guid>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BookExemplariesController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public BookExemplariesController(
            IRepository<BookExemplary, Guid> repository,
            ILogger<BookExemplariesController> logger)
            : base(logger, repository)
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