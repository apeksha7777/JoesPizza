using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace JoesPizzaTesting.pages
{
    class StripePayPage
    {
        private IWebDriver driver { get; }

        public IWebElement email => driver.FindElement(By.XPath("//input[@id='email']"));
        public IWebElement cardNum => driver.FindElement(By.XPath("//input[@id='card_number']"));
        public IWebElement exp => driver.FindElement(By.XPath("//input[@id='cc-exp']"));
        public IWebElement cvc => driver.FindElement(By.XPath("//input[@id='cc-csc']"));
        public IWebElement pay => driver.FindElement(By.XPath("//span[@class='iconTick']"));
        public StripePayPage(IWebDriver Webdriver)
        {
            driver = Webdriver;
        }
    }
}
