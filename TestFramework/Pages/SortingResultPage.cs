using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestFramework.Pages
{
    public class SortingResultPage
    {
        private readonly IWebDriver _driver;

        public SortingResultPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IReadOnlyCollection<IWebElement> ResultSortingByName => _driver.FindElements(By.CssSelector(".h4 a"));

        public IReadOnlyCollection<IWebElement> ResultSortingByPrice => _driver.FindElements(By.CssSelector("div .item-price div .price-md"));

        

    }

}
