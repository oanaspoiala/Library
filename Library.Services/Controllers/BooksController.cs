﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Library.Services.Controllers
{
    [Route("api/Books")]
    public class BooksController : ApiBaseController<Book, Guid>
    {
        public BooksController(
            IQueryRepository<Book, Guid> queryRepository,
            ICommandRepository<Book, Guid> commandRepository,
            ILogger<BooksController> logger)
            : base(queryRepository, commandRepository, logger)
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