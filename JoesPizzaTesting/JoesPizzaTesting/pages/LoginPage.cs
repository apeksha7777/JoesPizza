using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace JoesPizzaTesting.pages
{
    class LoginPage
    {
        private IWebDriver driver { get; }
        public int MyProperty { set; get; }
        public LoginPage(IWebDriver Webdriver)
        {
            driver = Webdriver;
        }
        public IWebElement txtUsername => driver.FindElement(By.Name("username"));
        public IWebElement password=> driver.FindElement(By.Name("password"));
        public IWebElement submit => driver.FindElement(By.Name("submit"));

        public void Login(string name, string pass)
        {
            txtUsername.SendKeys(name);
            password.SendKeys(pass);
            submit.Click();
        }
    }
}
