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

        PaytmHomePagePOM paytmPom = new PaytmHomePagePOM();

        [Given(@"I have entered Paytm website")]
        public void GivenIHaveEnteredPaytmWebsite()
        {
            paytmPom.NavigateToHomePageOfPaytm();
        }


        [Given(@"I click on Mobile option")]
        public void GivenIClickOnMobileOption()
        {
            paytmPom.ClickOnMobileButton();
        }

        [Given(@"also I have entered Mobile number and Amount")]
        public void GivenAlsoIHaveEnteredMobileNumberAndAmount()
        {
            paytmPom.EnterMobileNumberAndAmount();
        }

        [When(@"I click on Proceed Recharge Button")]
        public void WhenIClickOnProceedRechargeButton()
        {
            paytmPom.ClickOnProceedRechargeButton();
        }

        [When(@"fields like Mobile,Electricity,DTH,Metro are pesent")]
        public void WhenFieldsLikeMobileElectricityDTHMetroArePesent()
        {
            try
            {
                paytmPom.driver.FindElement(By.XPath(XpathClass.mobile));//Mobile 
                paytmPom.driver.FindElement(By.XPath(XpathClass.electricity));//electricity
                paytmPom.driver.FindElement(By.XPath(XpathClass.dth));//DTH
                paytmPom.driver.FindElement(By.XPath(XpathClass.metro));//Metro
            }
            catch (Exception Exp)
            {
                ElementNotFound = true;
            }
        }

        [Then(@"check all the corresponding fields are present or not")]
        public void ThenCheckAllTheCorrespondingFieldsArePresentOrNot()
        {
            Assert.IsFalse(ElementNotFound);
        }


        [Then(@"Page should navigate to Url https://paytm\.com/recharge")]
        public void ThenPageShouldNavigateToUrlHttpsPaytm_ComRecharge()
        {
            Assert.AreEqual(paytmPom.GetPaytmRechargeURl(), paytmPom.GetCurrentUrl());
        }

        [Then(@"Page should Navigate to Proceed to Pay and Url should be https://paytm\.com/coupons")]
        public void ThenPageShouldNavigateToProceedToPayAndUrlShouldBeHttpsPaytm_ComCoupons()
        {
            Assert.AreEqual(paytmPom.GetPaytmCouponsURl(), paytmPom.GetCurrentUrl());

           
           // Assert.IsNotNull(paytmPom.GetXpathOfCoupnPage());
        }
    }
}

