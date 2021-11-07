using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace JoesPizzaTesting.pages
{
    class Cart
    {
        private IWebDriver driver { get; }

        public string prodName => driver.FindElement(By.Name("PName")).Text;
        public IWebElement payButton=> driver.FindElement(By.XPath("//*[text()='Pay with Card']"));
        public Cart(IWebDriver Webdriver)
        {
            driver = Webdriver;
        }

    }
}
