using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestFramework.Pages
{
    class SortingOnCoreFilteringPage
    {
        private readonly IWebDriver _driver;

        public SortingOnCoreFilteringPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IReadOnlyCollection<IWebElement> SortingDropDown => _driver.FindElements(By.CssSelector("li[data-sortbox=\'select\'] .field option"));

    }
}
