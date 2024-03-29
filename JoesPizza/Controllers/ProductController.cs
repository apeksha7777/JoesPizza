﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoesPizza.Models;


namespace JoesPizza.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDBContext context;
        public ProductController()
        {
            context = new ApplicationDBContext();
        }

        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = context.Products.Find(id);
            return View(product);

        }
    }
}
