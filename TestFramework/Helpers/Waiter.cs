using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Helpers
{
    public static class Waiter
    {
        private static WebDriverWait _waiter;

        public static void InitializeWaiter(IWebDriver driver, TimeSpan timeSpan)
        {
            _waiter = new WebDriverWait(driver, timeSpan);
        }

        public static void WaitForDisplayed(this IWebElement element)
        {
            _waiter.Until(elem => element.Displayed);
        }
    }
}
