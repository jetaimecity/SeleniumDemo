using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Demo
{
    public class DemoTest
    {
        [Fact]
        public void PerformSearch_TextShouldMatch()
        {
            var searchText = "Hello World";
            using (var steps = new DemoSteps())
            {
                steps
                    .GivenIUseChromeWebDriver()
                    .WhenISearch(searchText)
                    .ThenSearchBarShouldMatch(searchText);
            }
        }

        [Fact]
        public void SearchSuggestionsShouldStartWithSearch()
        {
            var searchText = "Hello World";
            using (var steps = new DemoSteps())
            {
                steps
                    .GivenIUseChromeWebDriver()
                    .WhenISearch(searchText)
                    .WhenIClickSearchBar()
                    .ThenSearchSuggestionsShouldStartWith("somethingsearchText");
            }
        }
    }
}