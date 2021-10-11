using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DigitalRetailers.Models;
using DigitalRetailers.Helpers;

namespace DigitalRetailers.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDBContext _context;
        
        public AccountController()
        {
            _context = new ApplicationDBContext();
        }


        public IActionResult Register()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Register(string username,string password,string confirmPassword )
        {
            
               if(password!=confirmPassword)
            {
                ViewBag.Error = "Passowrds do not match";
                return View("Register");
            }
               else
            {
                User userModel=new User
                {
                    UserName=username,
                    Password = password,
                    UserType = "User"


                };


                _context.Users.Add(userModel);
                _context.SaveChanges();
                SessionHelper.setObjectAsJson(HttpContext.Session, "user", userModel);
                return RedirectToAction("Index", "Product");


            }
           



        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            if(username!=null && password!=null)
            {
                if (username.Equals("admin"))
                {
                    if (password.Equals("admin"))
                    {
                        SessionHelper.setObjectAsJson(HttpContext.Session, "admin", "admin");
                        return RedirectToAction("Index", "AdminProducts");
                    }
                    else
                    {
                        ViewBag.Error = "Inavlid credentials";
                        return View("Login");

                    }

                }
                else
                {


                    List<User> userList = _context.Users.ToList();
                   // var flag = 0;
                    for (var i = 0; i < userList.Count; i++)
                    {
                        if(userList[i].UserName.Equals(username)&&userList[i].Password.Equals(password))
                        {
                            User userModel = new User
                            {
                                UserName = username,
                                Password = password,
                                UserType = "User"


                            };

                            SessionHelper.setObjectAsJson(HttpContext.Session, "user", userModel);
                            // flag = 1;
                            return RedirectToAction("Index", "Product");

                        }
                    }

                    ViewBag.Error = "Invalid creadentials";
                    return View("Login");
                }
            }
            else
            {
                ViewBag.Error = "plase enter creadentials";
                return View("Login");

            }
          
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Product");
        }
        
    }
}
