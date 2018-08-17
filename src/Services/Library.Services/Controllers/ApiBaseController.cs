using System;
using System.Threading.Tasks;
using Library.Domain.Core.Entities;
using Library.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Services.Controllers
{
    /// <summary>
    /// ApiBaseController
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public abstract class ApiBaseController<T, TId> : Controller where T: EntityWithId<TId>
    {
        protected readonly IRepository<T, TId> Repository;
        protected readonly ILogger Logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiBaseController{T, TId}" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repository">The repository.</param>
        protected ApiBaseController(
            ILogger<ApiBaseController<T, TId>> logger, IRepository<T, TId> repository)
        {
            Logger = logger;
            Repository = repository;
        }

        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<IActionResult> Create(T item)
        {
            var response = await Repository.Add(item);
            return Ok(response);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<IActionResult> Get(TId id)
        {
            var response = await Repository.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<IActionResult> GetAll()
        {
            var response = await Repository.GetAll();
            return Ok(response);
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<IActionResult> Update(T item)
        {
            await Repository.Update(item);
            return Ok();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<IActionResult> Delete(TId id)
        {
            await Repository.Delete(id);
            return Ok();
        }
    }
}
