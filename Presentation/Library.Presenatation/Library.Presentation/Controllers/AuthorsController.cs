using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Core.Entities;
using Library.System.Libs.Interfaces;
using Newtonsoft.Json;

namespace Library.Presentation.Controllers
{
    public class AuthorsController : Controller
    {
        private static string apiUrl = "http://localhost:54864/Authors";
        private readonly IWebApiHelper _web;

        public AuthorsController(
            IWebApiHelper web)
        {
            _web = web;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            var response = await _web.Get(apiUrl);
            var items = await response.Content.ReadAsStringAsync();
            return View(JsonConvert.DeserializeObject<IEnumerable<Author>>(items));
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _web.Get($"{apiUrl}/{id.Value.ToString()}");
            var model = JsonConvert.DeserializeObject<Author>(await response.Content.ReadAsStringAsync());
            return View(model);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName, LastName, Id, BirthDate, DeathDate")] Author author)
        {
            if (ModelState.IsValid)
            {
                author.Id = Guid.NewGuid();
                await _web.Post(apiUrl, JsonConvert.SerializeObject(author));
                //await _commandRepository.Add(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var response = await _web.Get($"{apiUrl}/{id.Value.ToString()}");
            var author = JsonConvert.DeserializeObject<Author>(await response.Content.ReadAsStringAsync());
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FirstName, LastName, Id, BirthDate, DeathDate")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _web.Put(apiUrl, JsonConvert.SerializeObject(author));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await AuthorExists(author.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _web.Get($"{apiUrl}/{id.Value.ToString()}");
            var author = JsonConvert.DeserializeObject<Author>(await response.Content.ReadAsStringAsync());

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _web.Delete($"{apiUrl}/{id.ToString()}");
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AuthorExists(Guid id)
        {
            var response = await _web.Get($"{apiUrl}/{id.ToString()}");
            var author = JsonConvert.DeserializeObject<Author>(await response.Content.ReadAsStringAsync());
            return author != null;
        }
    }
}
