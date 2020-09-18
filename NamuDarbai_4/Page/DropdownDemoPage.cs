using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;


namespace NamuDarbai_4.Page
{
    class DropdownDemoPage : BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private IWebElement Responce => Driver.FindElement(By.ClassName("getall-selected"));
        private IWebElement FirstResultButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement AllResultsButton => Driver.FindElement(By.Id("printAll"));
        private SelectElement MultipleDropdown => new SelectElement(Driver.FindElement(By.Id("multi-select")));


        public DropdownDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }
        public DropdownDemoPage SelectFromMultipleDropDownByValue(List<string> value)
        {
            if (value.Count() > 1)
            {
                Actions act = new Actions(Driver); //visiskai nesuveikia neaisku kodel
                act.KeyDown(Keys.Control).B‌​uild().Perform();
                foreach (string element in value)
                {
                    
                    MultipleDropdown.SelectByValue(element);
                    
                }
                act.KeyUp(Keys.Control).B‌​uild().Perform();
            }
            else
            {
                MultipleDropdown.SelectByValue(value[0]);
            }
            return this;
        }
        public DropdownDemoPage CheckFirstSelectedResult(List<string> value)
        {
            FirstResultButton.Click();
            List<string> onevalue = new List<string>
                { value[0] };
            string stateValue = FromListToString(onevalue);
            string fullText = "First selected option is : " + stateValue;
            Assert.AreEqual(fullText, Responce.Text, $"Tekstai nesutampa, nerodo {fullText}");

            return this;
        }
        public DropdownDemoPage CheckAlSelectedResult(List<string> value)
        {
            AllResultsButton.Click();
            string stateValue = FromListToString(value);
            string fullText = "Options selected are : " + stateValue;
            Assert.AreEqual(fullText, Responce.Text, $"Tekstai nesutampa, nerodo {fullText}");

            return this;
        }
        private string FromListToString(List<string> value)
        {
            string stateValue = "";
            int i = 0;
            foreach (string element in value)
            { 
                if(i == 0) 
                {
                    stateValue +=  element.ToString();
                }
                else 
                {
                    stateValue += " " + element.ToString();
                }
                i++;
            }
            return stateValue;
        }
    }
}
