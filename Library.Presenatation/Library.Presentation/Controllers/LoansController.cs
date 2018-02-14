using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Core.Entities;
using Library.System.Libs.Interfaces;
using Newtonsoft.Json;

namespace Library.Presentation.Controllers
{
    public class LoansController : Controller
    {
        private static string apiUrl = "http://localhost:54864/Loans";
        private static string bookExemplariesApiUrl = "http://localhost:54864/BookExemplaries";
        private static string peopleApiUrl = "http://localhost:54864/People";
        private SelectList _bookExemplariesSelectList;
        private SelectList _peopleSelectList;
        private readonly IWebApiHelper _web;

        public LoansController(IWebApiHelper web)
        {
            _web = web;
            var task = GetDropDownLists();
            task.Wait();
        }

        // GET: Loans
        public async Task<IActionResult> Index()
        {
            var response = await _web.Get(apiUrl);
            var items = await response.Content.ReadAsStringAsync();
            return View(JsonConvert.DeserializeObject<IEnumerable<Loan>>(items));
        }

        // GET: Loans/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _web.Get($"{apiUrl}/{id.Value.ToString()}");

            return View(JsonConvert.DeserializeObject<Loan>(await response.Content.ReadAsStringAsync()));
        }

        // GET: Loans/Create
        public IActionResult Create()
        {
            ViewData["BookExemplaryId"] = _bookExemplariesSelectList;
            ViewData["PersonId"] = _peopleSelectList;
            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookExemplaryId,PersonId,FromDate,ToDate,ReturnDate,Id")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                loan.Id = Guid.NewGuid();
                await _web.Post(apiUrl, JsonConvert.SerializeObject(loan));
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookExemplaryId"] = _bookExemplariesSelectList;
            ViewData["PersonId"] = _peopleSelectList;
            return View(loan);
        }

        // GET: Loans/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _web.Get($"{apiUrl}/{id.Value.ToString()}");
            var loan = JsonConvert.DeserializeObject<Loan>(await response.Content.ReadAsStringAsync());

            if (loan == null)
            {
                return NotFound();
            }
            ViewData["BookExemplaryId"] = _bookExemplariesSelectList;
            ViewData["PersonId"] = _peopleSelectList;
            return View(loan);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BookExemplaryId,PersonId,FromDate,ToDate,ReturnDate,Id")] Loan loan)
        {
            if (id != loan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _web.Put(apiUrl, JsonConvert.SerializeObject(loan));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await LoanExists(loan.Id))
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
            ViewData["BookExemplaryId"] = _bookExemplariesSelectList;
            ViewData["PersonId"] = _peopleSelectList;
            return View(loan);
        }

        // GET: Loans/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _web.Get($"{apiUrl}/{id.Value.ToString()}");
            var loan = JsonConvert.DeserializeObject<Loan>(await response.Content.ReadAsStringAsync());

            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _web.Delete($"{apiUrl}/{id.ToString()}");
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LoanExists(Guid id)
        {
            var response = await _web.Get($"{apiUrl}/{id.ToString()}");
            var loan = JsonConvert.DeserializeObject<Loan>(await response.Content.ReadAsStringAsync());
            return loan != null;
        }

        private async Task GetDropDownLists()
        {
            var response = await _web.Get(bookExemplariesApiUrl);
            if (response.IsSuccessStatusCode)
            {
                _bookExemplariesSelectList = new SelectList(JsonConvert.DeserializeObject<IEnumerable<BookExemplary>>(await response.Content.ReadAsStringAsync()), "Id", "Title");
            }

            response = await _web.Get(peopleApiUrl);
            if (response.IsSuccessStatusCode)
            {
                _peopleSelectList = new SelectList(JsonConvert.DeserializeObject<IEnumerable<Person>>(await response.Content.ReadAsStringAsync()), "Id", "FullName");
            }
        }
    }
}
