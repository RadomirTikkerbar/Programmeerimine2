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
    public class ProductApi
    {
        private readonly IProductService _productService;

        public ProductApi(ApplicationDbContext context,
                IProductService productService)
        { 
            _productService = productService;
        }

    }
}
