using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Pages;

namespace TestFramework.Context
{
    public class CPUPageContext
    { 

        private readonly CPUPage _cpuPage;

        public CPUPageContext(IWebDriver driver)
        {
            _cpuPage = new CPUPage(driver);

        }

        public void SelectBrand()
        {

            _cpuPage.CPUBrandFilter.Single(el => el.GetAttribute("data-eventlabel").Contains("Core i7-8")).Click();


        }

        public void SelectProducer()
        {
            _cpuPage.ProducerFilter.Single(el => el.GetAttribute("data-eventlabel").Contains("Intel")).Click();
        }

        public void SelectCore()
        {
            _cpuPage.CoreAmountFilter.Single(el => el.GetAttribute("data-eventlabel").Contains("16 и более")).Click();
        }
    
    }
}
