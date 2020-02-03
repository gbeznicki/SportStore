using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult List(int productPage = 1) => 
            View(repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((PageSize - 1) * productPage)
                .Take(PageSize));
    }
}