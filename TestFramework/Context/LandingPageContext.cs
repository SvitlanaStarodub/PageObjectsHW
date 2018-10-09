using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestFramework.Helpers;
using TestFramework.Pages;

namespace TestFramework.Context
{
    public class LandingPageContext
    {
        private readonly LandingPage _landingPage;
        private readonly IWebDriver _webDriver;


        public LandingPageContext(IWebDriver driver)
        {
            _landingPage = new LandingPage(driver);
            _webDriver = driver;
            Waiter.InitializeWaiter(_webDriver, TimeSpan.FromSeconds(5));
        }

        public void ClickOnMenuSubSection()
        {
            var action = new Actions(_webDriver);
            action.MoveToElement(_landingPage.MenuSection).Perform();

            _landingPage.MenuSubSection.WaitForDisplayed();
            _landingPage.MenuSubSection.Click();

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var a = _landingPage.NestedSubSection;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Thread.Sleep(2000);
                }
            }       
            
            _landingPage.NestedSubSection.WaitForDisplayed();
            _landingPage.NestedSubSection.Click();
        }


    }
}
