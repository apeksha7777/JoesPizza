using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;

namespace JoesPizzaTesting.pages
{
    class Home
    {
        private IWebDriver driver { get; }
        public int MyProperty { set; get; }
        public Home(IWebDriver Webdriver)
        {
            driver = Webdriver;
        }
        public IWebElement login => driver.FindElement(By.Id("Login"));
        public IWebElement PImage => driver.FindElement(By.Name("ProductImage"));
        public IWebElement PName => driver.FindElement(By.Name("ProductName"));
        public IWebElement PPrice => driver.FindElement(By.Name("ProductPrice"));
        public IWebElement PDesc => driver.FindElement(By.Name("ProductDesc"));
        public IWebElement AddToCart => driver.FindElement(By.XPath("//a[@href='/Cart/AddItem/1']"));

        public void clickLogin()
        {
            login.Click();
        }

        public void addCart()
        {
            AddToCart.Click();

        }
       

    }
}
