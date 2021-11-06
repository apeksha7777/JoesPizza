using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace JoePizzaTesting
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {

            driver = new ChromeDriver();
            string url = "http://localhost:51841/";
            driver.Navigate().GoToUrl(url);

            driver.Close();


        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}