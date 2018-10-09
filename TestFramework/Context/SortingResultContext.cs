using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestFramework.Pages;

namespace TestFramework.Context
{
    public class SortingResultContext
    {
        private readonly SortingResultPage _sortingResultPage;

        private readonly IWebDriver _driver;

        public SortingResultContext(IWebDriver driver)
        {
            _sortingResultPage = new SortingResultPage(driver);
        }

        public List<string> GetSortingResultByName()
        {
            return _sortingResultPage.ResultSortingByName.Select(el => el.Text).ToList();
        }

        public List<string> GetSortingResultByPrice()
        {
            return _sortingResultPage.ResultSortingByPrice.Select(el => el.Text).ToList();
        }

    }
}
