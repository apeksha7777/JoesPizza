using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JoesPizzaTesting.pages;
using System.Threading;


namespace JoesPizzaTesting
{
    public class Tests
    {
        IWebDriver driver = new ChromeDriver(@"C:\DoverCorp");
        //string url = "http://localhost:51841/";
        string url= "http://joespizzaapp.azurewebsites.net/";
        // IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl(url);
            // driver.Close();

        }

        [Test, Order(1)]
        public void Login()
        {
            driver.Navigate().GoToUrl(url);
            Home home = new Home(driver);
            home.clickLogin();
            LoginPage loginPage = new LoginPage(driver);

            //admin login
            loginPage.Login("admin", "admin");
            IWebElement addNew = driver.FindElement(By.Name("addNew"));
            Assert.That(addNew.Displayed, Is.True);

            Thread.Sleep(2000);

            //user login
            driver.Navigate().GoToUrl(url+"/Account/Login");
            loginPage.Login("appe", "appe");
            string expectedUrl = url;
            string actualUrl = driver.Url;
            Assert.AreEqual(actualUrl, expectedUrl);
        }

        [Test, Order(2)]
        public void ProductDetails()
        {
            driver.Navigate().GoToUrl(url);
            Home home = new Home(driver);
            Assert.That(home.PImage.Displayed, Is.True);
            Assert.That(home.PName.Displayed, Is.True);
            Assert.That(home.PPrice.Displayed, Is.True);
            Assert.That(home.PDesc.Displayed, Is.True);

        }
        [Test, Order(3)]
        public void AddToCart()
        {
            driver.Navigate().GoToUrl(url+"/Account/Login");
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("appe", "appe");
            Thread.Sleep(2000);

            Home home = new Home(driver);
            home.addCart();

            Cart cart = new Cart(driver);
            Assert.AreEqual(cart.prodName, "The Unthinkable Pizza");

        }

        [Test,Order(4)]
        public void Payment()
        {
            AddToCart();

            Cart cart = new Cart(driver);
            cart.payButton.Click();
            Thread.Sleep(3000);

            driver.SwitchTo().Frame("stripe_checkout_app");

            
            Thread.Sleep(3000);

            //IWebElement emailId = driver.FindElement(By.Id("email"));

            StripePayPage stripePay = new StripePayPage(driver);
           
            stripePay.email.SendKeys("apekshavreddy@gmail.com");

            for(int i=0;i<4;i++)
                 stripePay.cardNum.SendKeys("4242");
   
             stripePay.exp.SendKeys("09");
             stripePay.exp.SendKeys("22");
             stripePay.cvc.SendKeys("123");
             stripePay.pay.Click();

            Thread.Sleep(6000);
            string expectedUrl = url+"Payment/Create";
            string actualUrl = driver.Url;
            Assert.AreEqual(actualUrl, expectedUrl);


        }
    }
}