using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;
using KooliProjekt.Models;
using KooliProjekt.Services;

namespace KooliProjekt.Controllers
{
    public class OrderLineController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IOrderLineService _orderLineService;

        public OrderLineController(ApplicationDbContext context,
            IOrderLineService orderLineService)
        {
            //_context = context;
            _orderLineService = orderLineService;
        }

        // GET: Product
        public async Task<IActionResult> Index(int page = 1, OrderLineIndexModel model = null)
        {
            model = model ?? new OrderLineIndexModel();
            model.Data = await _orderLineService.List(page, 5, model.Search);

            return View(model);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLine = await _orderLineService.Get(id.Value);
            if (orderLine == null)
            {
                return NotFound();
            }

            return View(orderLine);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] OrderLine orderLine)
        {
            if (ModelState.IsValid)
            {
                await _orderLineService.Save(orderLine);
                return RedirectToAction(nameof(Index));
            }
            return View(orderLine);
        }

        // GET: ProductCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLine = await _orderLineService.Get(id.Value);
            if (orderLine == null)
            {
                return NotFound();
            }
            return View(orderLine);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] OrderLine orderLine)
        {
            if (id != orderLine.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(orderLine);

            }

            await _orderLineService.Save(orderLine);

            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLine = await _orderLineService.Get(id.Value);
            if (orderLine == null)
            {
                return NotFound();
            }

            return View(orderLine);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _orderLineService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
