using System;
using System.Threading.Tasks;
using Library.Domain.Core.Interfaces;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Services.Controllers
{
    [Route("[controller]")]
    public class BooksController : ApiBaseController<Book, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public BooksController(
            IRepository<Book, Guid> repository,
            ILogger<BooksController> logger)
            : base(logger, repository)
        {
        }

        [HttpPost]
        public override async Task<IActionResult> Create([FromBody]Book item)
        {
            return await base.Create(item);
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> Get(Guid id)
        {
            return await base.Get(id);
        }

        [HttpGet]
        public override async Task<IActionResult> GetAll()
        {
            return await base.GetAll();
        }

        [HttpPut]
        public override async Task<IActionResult> Update([FromBody]Book item)
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