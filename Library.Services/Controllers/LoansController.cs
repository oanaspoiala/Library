using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Library.Services.Controllers
{
    [Route("[controller]")]
    public class LoansController : ApiBaseController<Loan, Guid>
    {
        public LoansController(
            IQueryRepository<Loan, Guid> readRepository,
            ICommandRepository<Loan, Guid> writeRepository,
            ILogger<LoansController> logger
        ) : base(readRepository, writeRepository, logger)
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