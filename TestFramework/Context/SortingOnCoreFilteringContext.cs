using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestFramework.Pages;

namespace TestFramework.Context
{
    public class SortingOnCoreFilteringContext
    {
        private readonly SortingOnCoreFilteringPage _sortingOnCoreFilteringPage;

        private readonly IWebDriver _driver;

        public SortingOnCoreFilteringContext(IWebDriver driver)
        {
            _sortingOnCoreFilteringPage = new SortingOnCoreFilteringPage(driver);
        }

        public void SelectSortingByName()
        {
            _sortingOnCoreFilteringPage.SortingDropDown.Single(el => el.Text.Contains("наименованию")).Click();
        }

        public void SelectSortingByIncreasedPrice()
        {
            _sortingOnCoreFilteringPage.SortingDropDown.Single(el => el.Text.Contains("возрастанию цены")).Click();
        }

        public void SelectSortingByDecreasedPrice()
        {
            _sortingOnCoreFilteringPage.SortingDropDown.Single(el => el.Text.Contains("убыванию цены")).Click();
        }

    }
}
