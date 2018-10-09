using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestFramework.Pages;


namespace TestFramework.Context
{
    public class FilteringResultPageContext
    {
        private readonly FilteringResultPage __filteringResultPage;
        private readonly IWebDriver _driver;

        public FilteringResultPageContext(IWebDriver driver)
        {
            __filteringResultPage = new FilteringResultPage(driver);
            _driver = driver;
        }

        

        public List<string> GetCPUFilteringResult()
        {
            return  __filteringResultPage.CPUBrandResult.Select(element => element.Text).Where( el => !string.IsNullOrEmpty(el)).ToList();
            
        }

        public List<string> GetProducerFilteringResult()
        {
            return __filteringResultPage.ProducerResult.Select(element => element.Text)
                                                       .Where(el => !string.IsNullOrEmpty(el)).ToList();
        }

        public void WaitForLoaded()
        {
            Thread.Sleep(2000);
        }

        public List<string> GetCoreFilteringResult()
        {
             var returnText =  __filteringResultPage.CoreAmountResult.Select(element => element.Text).ToList();

            var regex = new Regex(@"количество ядер: \d+");
            var regexResult = returnText.Select(n => regex.Match(n).Value);

            var amountCore = regexResult.Select(el => el.Split(' ').Last()).Where(s => !string.IsNullOrEmpty(s)).ToList();

            return amountCore;

        }


    }
}
