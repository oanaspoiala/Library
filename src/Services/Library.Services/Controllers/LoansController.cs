using System;
using System.Threading.Tasks;
using Library.Domain.Core.Interfaces;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Services.Controllers
{
    [Route("[controller]")]
    public class LoansController : ApiBaseController<Loan, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoansController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public LoansController(
            IRepository<Loan, Guid> repository,
            ILogger<LoansController> logger
        ) : base(logger, repository)
        { }

        [HttpPost]
        public override async Task<IActionResult> Create([FromBody]Loan item)
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
        public override async Task<IActionResult> Update([FromBody]Loan item)
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