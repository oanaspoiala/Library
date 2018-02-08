using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Core.Entities;
using Library.System.Libs.Interfaces;
using Newtonsoft.Json;

namespace Library.Presentation.Controllers
{
    public class BookExemplariesController : Controller
    {
        private static string apiUrl = "http://localhost:54864/BookExemplaries";
        private static string booksApiUrl = "http://localhost:54864/Books";
        private SelectList _booksSelectList;
        private readonly IWebApiHelper _web;

        public BookExemplariesController(IWebApiHelper web)
        {
            _web = web;
            var task = GetDropDownLists();
            task.Wait();
        }

        // GET: BookExemplaries
        public async Task<IActionResult> Index()
        {
            var response = await _web.Get(apiUrl);
            var items = await response.Content.ReadAsStringAsync();
            return View(JsonConvert.DeserializeObject<IEnumerable<BookExemplary>>(items));
        }

        // GET: BookExemplaries/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _web.Get($"{apiUrl}/{id.Value.ToString()}");
            return View(JsonConvert.DeserializeObject<BookExemplary>(await response.Content.ReadAsStringAsync()));
        }

        // GET: BookExemplaries/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = _booksSelectList;
            return View();
        }

        // POST: BookExemplaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId, Code, Id")] BookExemplary bookExemplary)
        {
            if (ModelState.IsValid)
            {
                bookExemplary.Id = Guid.NewGuid();
                await _web.Post(apiUrl, JsonConvert.SerializeObject(bookExemplary));
                return RedirectToAction(nameof(Index));
            }
            return View(bookExemplary);
        }

        // GET: BookExemplaries/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var response = await _web.Get($"{apiUrl}/{id.Value.ToString()}");
            var bookExemplary = JsonConvert.DeserializeObject<BookExemplary>(await response.Content.ReadAsStringAsync());

            if (bookExemplary == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = _booksSelectList;
            return View(bookExemplary);
        }

        // POST: BookExemplaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Code,BookId,Id")] BookExemplary bookExemplary)
        {
            if (id != bookExemplary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _web.Put(apiUrl, JsonConvert.SerializeObject(bookExemplary));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await BookExemplaryExists(bookExemplary.Id))
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
            ViewData["BookId"] = _booksSelectList;
            return View(bookExemplary);
        }

        // GET: BookExemplaries/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _web.Get($"{apiUrl}/{id.Value.ToString()}");
            var bookExemplary = JsonConvert.DeserializeObject<BookExemplary>(await response.Content.ReadAsStringAsync());

            if (bookExemplary == null)
            {
                return NotFound();
            }

            return View(bookExemplary);
        }

        // POST: BookExemplaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _web.Delete($"{apiUrl}/{id.ToString()}");
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> BookExemplaryExists(Guid id)
        {
            var response = await _web.Get($"{apiUrl}/{id.ToString()}");
            var bookExemplary = JsonConvert.DeserializeObject<BookExemplary>(await response.Content.ReadAsStringAsync());
            return bookExemplary != null;
        }

        private async Task GetDropDownLists()
        {
            var response = await _web.Get(booksApiUrl);
            if (response.IsSuccessStatusCode)
            {
                _booksSelectList = new SelectList(JsonConvert.DeserializeObject<IEnumerable<Book>>(await response.Content.ReadAsStringAsync()), "Id", "FullName");
            }
        }
    }
}
