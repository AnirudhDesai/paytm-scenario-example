using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace UnitTestProject4
{
    public class PaytmHomePagePOM
    {
         public IWebDriver driver = new ChromeDriver();

        public void NavigateToHomePageOfPaytm()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(PaytmUrl.homePageUrl);
            driver.Manage().Window.Maximize();
        }

        public void ClickOnMobileButton()
        {
            driver.FindElement(By.ClassName(XpathClass.mobileButton)).Click();
           
        }

        public void EnterMobileNumberAndAmount()
        {
            driver.FindElement(By.XPath(XpathClass.mobileNumber)).SendKeys(MobilefieldsClass.mobileNumber);
            driver.FindElement(By.XPath(XpathClass.amount)).SendKeys(MobilefieldsClass.amount);
        }

        public void ClickOnProceedRechargeButton()
        {
            driver.FindElement(By.XPath(XpathClass.proceedRechargeButton)).SendKeys(Keys.Return);
            int milliseconds = 2000;
            System.Threading.Thread.Sleep(milliseconds);





        }

        internal string GetCurrentUrl()
        {
            return driver.Url;
        }

        internal object GetXpathOfCoupnPage()
        {
            return driver.FindElement(By.XPath(XpathClass.couponPage));
        }

        internal string GetPaytmRechargeURl()
        {
             return PaytmUrl.RechargeUrl;
        }

        internal string GetPaytmCouponsURl()
        {
            return PaytmUrl.CouponsUrl;
        }
    }
}
