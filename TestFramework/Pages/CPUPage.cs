using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestFramework.Pages
{
    class CPUPage
    {
        private readonly IWebDriver _driver;

        public CPUPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IReadOnlyCollection<IWebElement> CPUBrandFilter => _driver.FindElements(By.XPath(".//div[contains(text(),'Марка процессора')]/following-sibling::div//a[contains(@href,'/computer/processory')]"));

        public IReadOnlyCollection<IWebElement> ProducerFilter => _driver.FindElements(By.XPath(".//div[contains(text(),'Производитель')]/following-sibling::div[2]//li//a"));

        public IReadOnlyCollection<IWebElement> CoreAmountFilter => _driver.FindElements(By.XPath(".//div[contains(text(),\'Количество ядер\')]/following-sibling::div//a"));
    }
}
