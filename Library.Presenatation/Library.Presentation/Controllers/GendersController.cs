using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Entities;
using Library.System.Libs.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Library.Presentation.Controllers
{
    public class GendersController : Controller
    {
        private static string apiUrl = "http://localhost:54864/Genders";
        private readonly IWebApiHelper _web;

        public GendersController(IWebApiHelper web)
        {
            _web = web;
        }

        // GET: Genders
        public async Task<IActionResult> Index()
        {
            var response = await _web.Get(apiUrl);
            var items = await response.Content.ReadAsStringAsync();
            return View(JsonConvert.DeserializeObject<IEnumerable<Gender>>(items));
        }

        // GET: Genders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _web.Get($"{apiUrl}/{id.Value.ToString()}");

            return View(JsonConvert.DeserializeObject<Gender>(await response.Content.ReadAsStringAsync()));
        }

        // GET: Genders/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Genders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] Gender gender)
        {
            if (ModelState.IsValid)
            {
                gender.Id = Guid.NewGuid();
                await _web.Post(apiUrl, JsonConvert.SerializeObject(gender));
                return RedirectToAction(nameof(Index));
            }
            return View(gender);
        }

        // GET: Genders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var response = await _web.Get($"{apiUrl}/{id.Value.ToString()}");
            var gender = JsonConvert.DeserializeObject<Gender>(await response.Content.ReadAsStringAsync());
            if (gender == null)
            {
                return NotFound();
            }
            return View(gender);
        }

        // POST: Genders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id")] Gender gender)
        {
            if (id != gender.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _web.Put(apiUrl, JsonConvert.SerializeObject(gender));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await GenderExists(gender.Id))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gender);
        }

        // GET: Genders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _web.Get($"{apiUrl}/{id.Value.ToString()}");
            var gender = JsonConvert.DeserializeObject<Gender>(await response.Content.ReadAsStringAsync());

            if (gender == null)
            {
                return NotFound();
            }

            return View(gender);
        }

        // POST: Genders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _web.Delete($"{apiUrl}/{id.ToString()}");
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> GenderExists(Guid id)
        {
            var response = await _web.Get($"{apiUrl}/{id.ToString()}");
            var gender = JsonConvert.DeserializeObject<Gender>(await response.Content.ReadAsStringAsync());
            return gender != null;
        }
    }
}