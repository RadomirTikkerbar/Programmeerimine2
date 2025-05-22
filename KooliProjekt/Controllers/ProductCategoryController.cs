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
    public class ProductCategoryController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(ApplicationDbContext context, 
            IProductCategoryService productCategoryService)
        {
            //_context = context;
            _productCategoryService = productCategoryService;
        }

        // GET: ProductCategories
        public async Task<IActionResult> Index(int page = 1, ProductCategoryIndexModel model = null)
        {
            model = model ?? new ProductCategoryIndexModel();
            model.Data = await _productCategoryService.List(page, 5, model.Search);

            return View(model);
        }

        // GET: ProductCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _productCategoryService.Get(id.Value);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // GET: ProductCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                await _productCategoryService.Save(productCategory);
                return RedirectToAction(nameof(Index));
            }
            return View(productCategory);
        }

        // GET: ProductCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _productCategoryService.Get(id.Value);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }

        // POST: ProductCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ProductCategory productCategory)
        {
            if (id != productCategory.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(productCategory);
                
            }

            await _productCategoryService.Save(productCategory);

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _productCategoryService.Get(id.Value);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // POST: ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productCategoryService.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
