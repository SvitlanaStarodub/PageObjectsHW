using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using TestFramework.Context;
using Tests.Core;
using Assert = NUnit.Framework.Assert;
using CollectionAssert = NUnit.Framework.CollectionAssert;


namespace Tests
{
    [TestFixture]
    public class UnitTest1
    {

        private IWebDriver _driver;
        private string _url = "https://hotline.ua/";
        private string _urlForSorting = "https://hotline.ua/computer/processory/582094/";

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = SeleniumDriver.Driver;
            _driver.Manage().Window.Maximize();
            
           
        }

        [Test]

        public void FilteringByCPU()
        {
            //arrange
            _driver.Url = _url;
            var landingPageContext = new LandingPageContext(_driver);
            var cpuPageContext = new CPUPageContext(_driver);
            var filteringResultPageContext = new FilteringResultPageContext(_driver);
            var expectedResult = "Intel Core i7";

            //act
            landingPageContext.ClickOnMenuSubSection();
            cpuPageContext.SelectBrand();
            filteringResultPageContext.WaitForLoaded();
            var actualResult = filteringResultPageContext.GetCPUFilteringResult();
            
            //assert
            foreach (var listElement in actualResult)
            {
                Assert.True(listElement.Contains(expectedResult), $"{listElement} should contain {expectedResult}");
            }
            


        }

        [Test]

        public void FilterByProducer()
        {
            //arrange
            _driver.Url = _url;
            var landingPageContext = new LandingPageContext(_driver);
            var cpuPageContext = new CPUPageContext(_driver);
            var filteringResultPageContext = new FilteringResultPageContext(_driver);
            var expectedResult = "Intel";

            //act
            landingPageContext.ClickOnMenuSubSection();
            cpuPageContext.SelectProducer();
            filteringResultPageContext.WaitForLoaded();
            var actualResult = filteringResultPageContext.GetProducerFilteringResult();

            //assert
            
            foreach (var listElement in actualResult)
            {
                Console.WriteLine(listElement);
                Assert.True(listElement.Contains(expectedResult), $"{listElement} should contain {actualResult}");
            }

        }

        [Test]

        public void FilterByCore()
        {
            // arrange 
            _driver.Url = _url;
            var landingPageContext = new LandingPageContext(_driver);
            var cpuPageContext = new CPUPageContext(_driver);
            var filteringResultPageContext = new FilteringResultPageContext(_driver);
           
            //act
            landingPageContext.ClickOnMenuSubSection();
            cpuPageContext.SelectCore();
            filteringResultPageContext.WaitForLoaded();
            var actualResult = filteringResultPageContext.GetCoreFilteringResult().Select(a => int.Parse(a) >= 16).ToList();

            //assert
            foreach (var listElement in actualResult)
            {
                Assert.True(listElement, "Expected that cores amount are more or equal to 16");
            }

        }

        [Test]

        public void SortingByName()
        {
            //arrange
            _driver.Url = _urlForSorting;
            var sortingOnCoreFilteringContext = new SortingOnCoreFilteringContext(_driver);
            var sortingResultContext = new SortingResultContext(_driver);


            //act
            sortingOnCoreFilteringContext.SelectSortingByName();
            var actualResult = sortingResultContext.GetSortingResultByName();

            //assert
            CollectionAssert.IsOrdered(actualResult, "The sorting result should be in alphabetical order.");
        }

        [Test]

        public void PriceSortingIncrease()
        {
            //arrange
            _driver.Url = _urlForSorting;
            var sortingOnCoreFilteringContext = new SortingOnCoreFilteringContext(_driver);
            var sortingResultContext = new SortingResultContext(_driver);

            //act
            sortingOnCoreFilteringContext.SelectSortingByIncreasedPrice();
            var actualResult = sortingResultContext.GetSortingResultByPrice();
            var actualPrices = actualResult.Select(s => double.Parse(s.Replace("грн", string.Empty)
                                                         .Replace(" ", string.Empty)
                                                         .Replace(",", ".")));
            
            //assert
            CollectionAssert.IsOrdered(actualPrices, "The sorted prices should be increased.");

        }

        [Test]

        public void PriceSortingDecrease()
        {
            //arrange
            _driver.Url = _urlForSorting;
            var sortingOnCoreFilteringContext = new SortingOnCoreFilteringContext(_driver);
            var sortingResultContex = new SortingResultContext(_driver);

            //act
            sortingOnCoreFilteringContext.SelectSortingByDecreasedPrice();
            var actualResult = sortingResultContex.GetSortingResultByPrice();
            actualResult.Reverse();
            var actualPrices = actualResult.Select(x => double.Parse(x.Replace("грн", string.Empty)
                                                                      .Replace(" ", string.Empty)
                                                                      .Replace(",", ".")));

            //assert
            CollectionAssert.IsOrdered(actualPrices, "The sorted prices should be decreased.");
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}

