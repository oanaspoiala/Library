using System.Threading.Tasks;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Services.Controllers
{
    public abstract class ApiBaseController<T, TId> : Controller where T: EntityWithId<TId>
    {
        protected readonly IQueryRepository<T, TId> QueryRepository;
        protected readonly ICommandRepository<T, TId> CommandRepository;
        protected readonly ILogger logger;

        protected ApiBaseController(
            IQueryRepository<T, TId> queryRepository,
            ICommandRepository<T, TId> commandRepository,
            ILogger<ApiBaseController<T, TId>> logger)
        {
            QueryRepository = queryRepository;
            CommandRepository = commandRepository;
            this.logger = logger;
            this.logger.LogInformation("ApiBaseController constructed");
        }

        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual async Task<IActionResult> Create(T item)
        {
            var response = await CommandRepository.Add(item);
            return Ok(response);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual async Task<IActionResult> Get(TId id)
        {
            var response = await QueryRepository.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual async Task<IActionResult> GetAll()
        {
            var response = await QueryRepository.GetAll();
            return Ok(response);
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual async Task<IActionResult> Update(T item)
        {
            await CommandRepository.Update(item);
            return Ok();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual async Task<IActionResult> Delete(TId id)
        {
            await CommandRepository.Delete(id);
            return Ok();
        }
    }
}
