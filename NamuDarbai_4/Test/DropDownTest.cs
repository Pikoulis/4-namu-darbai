
using NamuDarbai_4.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace NamuDarbai_4.Test
{
    class DropDownTest
    {
        private static DropdownDemoPage _page;
        [SetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _page = new DropdownDemoPage(driver);
        }
        [Test]
        public static void CheckFirstSelectedResult()
        {
            List<string> States = new List<string>
            {
                "California",
                "New York",
                "Texas"
            };
            _page.SelectFromMultipleDropDownByValue(States).CheckFirstSelectedResult(States);
        }
        [Test]
        public static void CheckAlSelectedResult()
        {
            List<string> States = new List<string>
            {
                "California",
                "New York",
                "Texas",
                "Ohio"
            };
            _page.SelectFromMultipleDropDownByValue(States).CheckAlSelectedResult(States);
        }
        [TearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }
    }
}
