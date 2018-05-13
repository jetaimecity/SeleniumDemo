using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace Demo
{    
    public class DemoPage
    {
        private IWebDriver driver;

        public DemoPage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        public DemoPage Search(string text) {
            // Page encapsulation to manage profile functionality
            var searchInputBox = driver.FindElement(By.CssSelector("input[title=\"Search\"]"));
            searchInputBox.SendKeys(text);
            var searchBtn = driver.FindElement(By.CssSelector("input[type=\"Submit\"][value=\"Google Search\"]"));
            searchBtn.Click();
            return this;
        }

        public DemoPage ClickSearchBar() 
        {
            // Page encapsulation to manage profile functionality
            var searchField = driver.FindElement(By.CssSelector("input[title=\"Search\"]"));
            searchField.Click();
            return this;
        }

        public IEnumerable<string> GetSearchSuggestions() 
        {
            // Page encapsulation to manage profile functionality
            var searchList = driver.FindElements(By.CssSelector("ul[role=\"listbox\"] > li >[role=\"presentation\"]"));
            // yup fix this
            return searchList.Select(x => x.Text);
            //searchField.Click();
            //return this;
        }

        public string SearchText
        {
            get 
            {
                var searchField = driver.FindElement(By.CssSelector("input[title=\"Search\"]"));
                return searchField.GetAttribute("value").ToString();
            }
        }
    }
}