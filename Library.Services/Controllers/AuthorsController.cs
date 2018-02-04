using System;
using System.Threading.Tasks;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Services.Controllers
{
    [Route("[controller]")]
    //[Authorize(Policy = "Authenticated")]
    public class AuthorsController : ApiBaseController<Author, Guid>
    {
        public AuthorsController(
            IQueryRepository<Author, Guid> queryRepository,
            ICommandRepository<Author, Guid> commandRepository,
            ILogger<AuthorsController> logger)
            : base(queryRepository, commandRepository, logger)
        {
        }

        [HttpPost]
        public override async Task<IActionResult> Create([FromBody]Author item)
        {
            return await base.Create(item);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("{id}")]
        public override async Task<IActionResult> Get(Guid id)
        {
            return await base.Get(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public override async Task<IActionResult> GetAll()
        {
            return await base.GetAll();
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPut]
        public override async Task<IActionResult> Update([FromBody]Author item)
        {
            return await base.Update(item);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(Guid id)
        {
            return await base.Delete(id);
        }
    }
}
