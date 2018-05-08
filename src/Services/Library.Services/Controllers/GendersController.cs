using System;
using System.Threading.Tasks;
using Library.Domain.Core.Interfaces;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Services.Controllers
{
    /// <summary>
    /// GendersController
    /// </summary>
    /// <seealso>
    ///     <cref>Library.Services.Controllers.ApiBaseController{Library.Core.Entities.Gender, System.Guid}</cref>
    /// </seealso>
    [Route("[controller]")]
    public class GendersController : ApiBaseController<Gender, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GendersController" /> class.
        /// </summary>
        /// <param name="queryRepository">The query repository.</param>
        /// <param name="commandRepository">The command repository.</param>
        /// <param name="logger">The logger.</param>
        public GendersController(
            IQueryRepository<Gender, Guid> queryRepository,
            ICommandRepository<Gender, Guid> commandRepository,
            ILogger<GendersController> logger)
            : base(queryRepository, commandRepository, logger)
        {
        }

        [HttpPost]
        public override async Task<IActionResult> Create([FromBody]Gender item)
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
        public override async Task<IActionResult> Update([FromBody]Gender item)
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
