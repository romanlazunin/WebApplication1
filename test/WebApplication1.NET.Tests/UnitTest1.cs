using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace WebApplication1.NET.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("http://localhost:49512/");
            chrome.Navigate().GoToUrl("http://localhost:49512/App/Contact");
            chrome.FindElementByCssSelector("#Name").SendKeys("User1");
            chrome.FindElementByCssSelector("#Email").SendKeys("abc@example.com");
            chrome.FindElementByCssSelector("#Message").SendKeys("Lorem ipsum");
            chrome.FindElementByCssSelector("input[type='submit']").Click();
        }
    }
}
