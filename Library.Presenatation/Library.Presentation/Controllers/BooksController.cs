using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnsureThat;
using Library.Core.Entities;
using Library.System.Libs.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Library.Presentation.Controllers
{
    public class BooksController : Controller
    {
        private static string apiUrl = "http://localhost:54864/Books";
        private readonly IWebApiHelper _web;

        public BooksController(IWebApiHelper web)
        {
            _web = web;
        }

        //GET:Books
        public async Task<IActionResult> Index()
        {
            var response = await _web.Get(apiUrl);
            var items = await response.Content.ReadAsStringAsync();
            EnsureArg.IsNotNullOrEmpty(items);
            return View(JsonConvert.DeserializeObject<IEnumerable<Book>>(items));
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _web.Get($"{apiUrl}/{id.Value.ToString()}");

            return View(JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync()));
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId, Title, Year, Isbn,GenderId, Id")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = Guid.NewGuid();
                await _web.Post(apiUrl, JsonConvert.SerializeObject(book));
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var response = await _web.Get($"{apiUrl}/{id.Value.ToString()}");
            var book = JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync());
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Year, Isbn, Id")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _web.Put(apiUrl, JsonConvert.SerializeObject(book));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await BookExists(book.Id))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _web.Get($"{apiUrl}/{id.Value.ToString()}");
            var book = JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync());

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _web.Delete($"{apiUrl}/{id.ToString()}");
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> BookExists(Guid id)
        {
            var response = await _web.Get($"{apiUrl}/{id.ToString()}");
            var book = JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync());
            return book != null;
        }
    }
}