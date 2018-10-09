using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestFramework.Pages
{
    public class FilteringResultPage
    {
        private readonly IWebDriver _driver;

        public FilteringResultPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IReadOnlyCollection<IWebElement> CPUBrandResult => _driver.FindElements(By.CssSelector("p.h4>a"));

        public IReadOnlyCollection<IWebElement> ProducerResult => _driver.FindElements(By.CssSelector("p.h4>a"));

        public IReadOnlyCollection<IWebElement> CoreAmountResult => _driver.FindElements(By.XPath(".//div[@class='item-info']//div[@data-navigation-id]/div//p"));
        
       

    }
}
