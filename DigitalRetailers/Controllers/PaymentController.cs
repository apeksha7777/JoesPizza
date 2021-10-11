using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using DigitalRetailers.Models;
using Stripe;

using System.Threading.Tasks;
using DigitalRetailers.Helpers;
using DigitalRetailers.Helpers;

namespace DigitalRetailers.Controllers
{
    public class PaymentController : Controller
    {
        public static string orderId { get; set; }
        public IActionResult OrderStatus()
        {
            
            return View("OrderStatus");
           

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string stripeToken)
        {
            try
            {
                StripeConfiguration.SetApiKey("pk_test_51Jc8eoSChZXLAWtZQhX2hNNqhGXUNQK0udYqXBMmpayUdIdAXMJEVU8IkMs6hiXYltW8DXzJrZcnIc3CsARwJUvA00CL3YY96H");
                StripeConfiguration.ApiKey = "sk_test_51Jc8eoSChZXLAWtZXTYzM1Qne9n5KcZohrTkn7tvzILZKpwVCc8nKYkEBg0xlL4FUREH63t41jK3usJTTbqmNnOO00Kb4aifNL";
                var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
                var amountToPay = cart.Sum(item => item.Product.Price * item.Quantity);
                amountToPay=amountToPay*100;
                var myCharge = new ChargeCreateOptions();
                // always set these properties
               
                myCharge.Amount = ((long?)amountToPay);
                myCharge.Currency = "INR";
                myCharge.ReceiptEmail = "stripeEmail@gmail.com";
                myCharge.Description = "Sample Charge";
                myCharge.Source = stripeToken;
                myCharge.Capture = true;
                var chargeService = new ChargeService();
                Charge stripeCharge = chargeService.Create(myCharge);
             
                var model = new ChangeViewModel();
                model.ChargeId = stripeCharge.Id;
                return View("OrderStatus",model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
