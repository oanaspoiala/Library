using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsureThat;
using Library.Core.Entities;
using Library.System.Libs.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Library.Presentation.Controllers
{
    public class BooksController : Controller
    {
        private static string apiUrl = "http://localhost:54864/Books";
        private static string gendersApiUrl = "http://localhost:54864/Genders";
        private static string authorsApiUrl = "http://localhost:54864/Authors";
        private SelectList _gendersSelectList;
        private SelectList _authorsSelectList;
        private readonly IWebApiHelper _web;

        public BooksController(IWebApiHelper web)
        {
            _web = web;
            var task = GetDropDownLists();
            task.Wait();
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
            ViewData["GenderId"] = _gendersSelectList;
            ViewData["AuthorId"] = _authorsSelectList;
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
            ViewData["GenderId"] = _gendersSelectList;
            ViewData["AuthorId"] = _authorsSelectList;
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AuthorId,Title,Year, Isbn, GenderId, Id")] Book book)
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

        private async Task GetDropDownLists()
        {
            var response = await _web.Get(gendersApiUrl);
            if (response.IsSuccessStatusCode)
            {
                _gendersSelectList = new SelectList(JsonConvert.DeserializeObject<IEnumerable<Gender>>(await response.Content.ReadAsStringAsync()), "Id", "Name");
            }

            response = await _web.Get(authorsApiUrl);
            if (response.IsSuccessStatusCode)
            {
                _authorsSelectList = new SelectList(JsonConvert.DeserializeObject<IEnumerable<Author>>(await response.Content.ReadAsStringAsync()), "Id", "FullName");
            }
        }
    }
}