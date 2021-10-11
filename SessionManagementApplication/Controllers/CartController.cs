using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalRetailers.Helpers;
using DigitalRetailers.Models;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Authorization;

namespace DigitalRetailers.Controllers
{
    public class CartController : Controller
    {
        ApplicationDBContext _context;
        public CartController()
        {
            _context = new ApplicationDBContext();
        }
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            if (cart == null || cart.Count == 0)
            {
                ViewBag.cart = null;
                return View();
            }
            else
            {
                // var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
                return View();
            }
        }

       
        public IActionResult Additem(int id)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                return RedirectToAction("Login", "Account");

            }
            else
            {
                if (SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
                {
                    List<CartItem> cart = new List<CartItem>();
                    cart.Add(new CartItem { Product = _context.Products.Find(id), Quantity = 1 });
                    SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
                }
                else
                {
                    List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
                    int index = isExists(id);
                    if (index != -1)
                    {
                        cart[index].Quantity++;
                    }
                    else
                    {
                        cart.Add(new CartItem { Product = _context.Products.Find(id), Quantity = 1 });
                    }
                    SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
                }
                return RedirectToAction("Index");
            }

            
               
        }

        public int isExists(int id)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult Remove(int id)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            int index = isExists(id);
            cart.RemoveAt(index);
            SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");

        }

        //public IActionResult Pay()
        //{
        //    return View();
        //}
    }
}
