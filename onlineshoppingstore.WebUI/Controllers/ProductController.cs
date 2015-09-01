using onlineshoppingstore.Domain.Abstract;
using onlineshoppingstore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onlineshoppingstore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repositroy;
        public int PageSize = 2;

        public ProductController(IProductRepository repo)
        {
            repositroy = repo;
        }

        public ViewResult list(string category,int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repositroy.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repositroy.Products.Count() : repositroy.Products.Where(p => p.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}