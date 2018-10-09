using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestFramework.Pages
{
    public class LandingPage
    {
        private readonly IWebDriver _driver;

        public LandingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement MenuSection => _driver.FindElement(By.CssSelector("a[href=\'/computer/\']"));

        public IWebElement MenuSubSection => _driver.FindElement(By.CssSelector("span.komplektuyuschie-dlya-pk"));

        public IWebElement NestedSubSection => _driver.FindElement(By.CssSelector("a[href=\'/computer/processory/\']"));
    }
}
