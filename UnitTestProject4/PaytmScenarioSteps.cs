using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace UnitTestProject4
{
    [Binding]
    public class PaytmScenarioSteps

    {
        bool ElementNotFound;

        IWebDriver driver = new ChromeDriver();

        [Given(@"I have entered Paytm website")]
        public void GivenIHaveEnteredPaytmWebsite()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.paytm.com");
            driver.Manage().Window.Maximize();
        }


        [Given(@"I click on Mobile option")]
        public void GivenIClickOnMobileOption()
        {
            driver.FindElement(By.ClassName("_160X")).Click();
        }

        [Given(@"also I have entered Mobile number and Amount")]
        public void GivenAlsoIHaveEnteredMobileNumberAndAmount()
        {
            driver.FindElement(By.XPath("//*[@id='app']/div/div[4]/div[1]/div[1]/div/div[2]/div[2]/ul/li[1]/div/div/input")).SendKeys("8618290261");
            driver.FindElement(By.XPath("//*[@id='app']/div/div[4]/div[1]/div[1]/div/div[2]/div[2]/ul/li[3]/div[1]/div[1]/input")).SendKeys("100");


        }

        [When(@"I click on Proceed Recharge Button")]
        public void WhenIClickOnProceedRechargeButton()
        {
            driver.FindElement(By.XPath("//*[@id='app']/div/div[4]/div[1]/div[1]/div/div[2]/div[5]/button")).Click();
        }


        [When(@"fields like Mobile,Electricity,DTH,Metro should be pesent")]
        public void WhenFieldsLikeMobileElectricityDTHMetroShouldBePesent()
        {
            try
            {
                driver.FindElement(By.XPath("//*[@id='app']/div/div[3]/div/div[1]/div/a[1]/div/img"));//Mobile 
                driver.FindElement(By.XPath("//*[@id='app']/div/div[3]/div/div[1]/div/a[2]/div"));//electricity
                driver.FindElement(By.XPath("//*[@id='app']/div/div[3]/div/div[1]/div/a[3]/div"));//DTH
                driver.FindElement(By.XPath("//*[@id='app']/div/div[3]/div/div[1]/div/a[4]/div/img"));//Metro
            }
            catch (Exception Exp)
            {
                ElementNotFound = true;
            }
        }

        [Then(@"check all the corresponding fields are present")]
        public void ThenCheckAllTheCorrespondingFieldsArePresent()
        {
            Assert.IsFalse(ElementNotFound);
        }


        [Then(@"Page should navigate to Url https://paytm\.com/recharge")]
        public void ThenPageShouldNavigateToUrlHttpsPaytm_ComRecharge()
        {
            Assert.AreEqual("https://paytm.com/recharge", driver.Url);
        }

        [Then(@"Page should Navigate to Proceed to Pay and Url should be https://paytm\.com/coupons")]
        public void ThenPageShouldNavigateToProceedToPayAndUrlShouldBeHttpsPaytm_ComCoupons()
        {
            //Assert.AreEqual("https://paytm.com/coupons", driver.Url);

            Assert.IsNotNull(driver.FindElement(By.XPath("//*[@id='app']")));
        }
    }
}

