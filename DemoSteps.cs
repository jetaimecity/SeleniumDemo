using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Demo
{
    public class DemoSteps : IDisposable
    {
        private IWebDriver driver;
        private DemoPage page;

        public DemoSteps GivenIUseChromeWebDriver()
        {
            driver = new ChromeDriver(Directory.GetCurrentDirectory());
            return this;
        }

        public DemoSteps WhenISearch(string text)
        {
            driver.Navigate().GoToUrl(@"https://www.google.com/");
            page = new DemoPage(driver);
            page.Search("Hello World");
            return this;
        }

        public DemoSteps WhenIClickSearchBar()
        {
            page.ClickSearchBar();
            return this;
        }

        public void ThenSearchBarShouldMatch(string result)
        {
            Assert.Equal(result, actual: page.SearchText);
        }

        public void ThenSearchSuggestionsShouldStartWith(string result)
        {
            var suggestions = page.GetSearchSuggestions();
            foreach(var suggestion in suggestions)
            {
                Console.WriteLine(suggestion);
                Assert.StartsWith(result, suggestion);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    driver.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DemoSteps() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

}