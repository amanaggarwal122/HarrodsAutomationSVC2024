using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using TAF_Web.Scripted.Web;


namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.FF
{
    class ScayleUserCommPrefPage
    {
        public IWebDriver driver;
        private Configuration config = null;        
        List<string> consentselection = new List<string>();
        List<string> interestselection = new List<string>();

        #region  Constructor
        public ScayleUserCommPrefPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements

        [FindsBy(How = How.XPath, Using = "//span[text()='Manage Communication Preferences']")]
        private IWebElement CommunicationPreferences;
        [FindsBy(How = How.XPath, Using = "//div[@data-test='notification-confirmation']/div")]
        private IWebElement AddressConfirmation;
        [FindsBy(How = How.XPath, Using = "//h2[text()='Channel']")]
        private IWebElement UserChannelsHeader;
        [FindsBy(How = How.XPath, Using = "//div[@data-test='account-sidebar']//span[text()='Communication Preferences']")]
        private IWebElement lnkCommunicationPreferences;
        [FindsBy(How = How.XPath, Using = "//button[@data-test='communication-preferences-updateButton']")]
        private IWebElement btnUpdateComPref;

        
        [FindsBy(How = How.XPath, Using = "//span[text()='Add an address']")]
        private IWebElement AddAnAddress;
        
        #endregion
        public By FFInterestCheckBoxBtn(string SelectItem) { return By.XPath("//span[text()='" + SelectItem + "']//preceding-sibling::input"); }
        public By MiniHarrodsField(string miniHarrods) { return By.XPath("//h3[text()='" + miniHarrods + "']"); }
        public By FFInterestSelectionButton(string SelectItem) { return By.XPath("//button[text()='" + SelectItem + "']"); }
        public By FFInterestSelectionBtn(string SelectItem) { return By.XPath("//span[text()='" + SelectItem + "']"); }
        public By ScayleChannelConsentField(string ChannelName) { return By.XPath("//button[@id='" + ChannelName + "']"); }

       // public By FFChannelConsentField(string ChannelName) { return By.XPath("//input[@id='" + ChannelName + "']"); }
        #region Events
        public void NavigateToScayleCommunicationPreferences()
        {
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.ClickByJsExecutor(Register, "Register");
            WebHandlers.Instance.Click(CommunicationPreferences);
            BrowserDriver.Sleep(3000);
            //driver.Navigate().Refresh();
            WebWaitHelper.Instance.WaitForElementPresence(UserChannelsHeader);
        }
        //TC_96,TC_100
        public void ValidateMiniHarrodsInterestRemoved()
        {
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.XPath("//h2[text()='Your child(ren)']")).Displayed, "User Not Enrolled in MiniHarrods");
           // NavigateToHarrodsCommunicationPreferences();
           // if (driver.FindElement(FFInterestCheckBoxBtn("Mini Harrods")).Selected)
             if(driver.FindElement(By.XPath("//h2[text()='Your child(ren)']")).Displayed)
            {
                //Remove Mini harrods Interest
                driver.FindElement(By.XPath("//span[text()='Remove']//preceding::input")).Click();
                //WebHandlers.Instance.Click(driver.FindElement(FFInterestCheckBoxBtn("Mini Harrods")));
                WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Changes")));
                BrowserDriver.Sleep(3000);
                driver.FindElement(By.XPath("//button[text()='Leave Mini Harrods']")).Click();
                BrowserDriver.Sleep(3000);
            }
            else
            {
                Assert.Fail("User not opted Mini Harrods Interest ");
            }
           // WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
        }


        public void InvokeCommunicationDetails()
        {
            BrowserDriver.Sleep(5000);
            Console.WriteLine("********Entered Comm Pereferences Page");
            WebHandlers.Instance.Click(lnkCommunicationPreferences);
            Console.WriteLine("Comm Pereferences got clicked");
            BrowserDriver.Sleep(3000);
        }

        public void ConfirmStatus(string confirmMsg)
        {
            BrowserDriver.Sleep(7000);
            WebHandlers.Instance.VerifyText(AddressConfirmation, confirmMsg);
        }

        public void validateCommunicationPrefLoyaltyUserInterestOpted()
        {
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Womenswear")).Selected, "Womenswear :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Menswear")).Selected, "Menswear :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Beauty & Grooming")).Selected, "Beauty & Grooming :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Salon & Wellness Services")).Selected, "Salon & Wellness Services :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Jewellery")).Selected, "Fine Jewellery :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Watches")).Selected, "Fine Watches :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Home & Technology")).Selected, "Home & Technology :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Food & Restaurants")).Selected, "Food & Restaurants :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Wine & Spirits")).Selected, "Wine & Spirits :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Kids & Toys")).Selected, "Kids & Toys :IS NOT OPTED");
            //Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Father’s Day")).Selected, "Fathers day is selected");
           // Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Mother’s Day")).Selected, "Mothers day is selected");
            bool MiniHarrodspresent = WebHandlers.Instance.isElementPresent(MiniHarrodsField("Mini Harrods"));
            Assert.IsTrue(MiniHarrodspresent, "Mini Harrods should be Displayed for rewards user");

        }        

        public void PerformPartialInterestSelection()
        {
            WebHandlers.Instance.Click(driver.FindElement(FFInterestCheckBoxBtn("Fine Watches")));
            WebHandlers.Instance.Click(driver.FindElement(FFInterestCheckBoxBtn("Mother’s Day")));
            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
            
        }

        public void MiniHarrodsInterestSelection()
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(FFInterestCheckBoxBtn("Mini Harrods")));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
            BrowserDriver.Sleep(3000);
        }

        public void ValidateOptChannel(By ChannelField, bool OptValue)
        {

            Console.WriteLine("Opt value --> " + ChannelField.ToString());
            if (OptValue)
                Assert.AreEqual("true", driver.FindElement(ChannelField).GetAttribute("aria-checked"), "Opt value for channel not showing as expected");
            else if (OptValue == false)
                Assert.AreEqual("false", driver.FindElement(ChannelField).GetAttribute("aria-checked"), "Opt value for channel not showing as expected");
            //Assert.IsEmpty(driver.FindElement(ChannelField).GetAttribute("checked"), "Opt value for channel not showing as expected");
        }

        //TC-35
        public void validateAllInterestOpted()
        {
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Womenswear")).Selected, "Womenswear :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Menswear")).Selected, "Menswear :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Beauty & Grooming")).Selected, "Beauty & Grooming :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Salon & Wellness Services")).Selected, "Salon & Wellness Services :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Jewellery")).Selected, "Fine Jewellery :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Watches")).Selected, "Fine Watches :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Home & Technology")).Selected, "Home & Technology :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Food & Restaurants")).Selected, "Food & Restaurants :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Wine & Spirits")).Selected, "Wine & Spirits :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Kids & Toys")).Selected, "Kids & Toys :IS NOT OPTED");
            //Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Father’s Day")).Selected, "Fathers day is not selected");
           // Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Mother’s Day")).Selected, "Mothers day is not selected");
            //bool HarrodsMagazine = WebHandlers.Instance.isElementPresent(ScayleChannelConsentField("publications"));
            //bool MiniHarrodspresent = WebHandlers.Instance.isElementPresent(MiniHarrodsField("Mini Harrods"));
            //Assert.IsFalse(HarrodsMagazine, "Harrods magazines channel should not be displayed ");
           // Assert.IsFalse(MiniHarrodspresent, "Mini Harrods should not be Displayed for non rewards user");
        }

        public void validateAllInterestOptedOut()
        {
            Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Womenswear")).Selected, "Womenswear :IS OPTED");
            Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Menswear")).Selected, "Menswear :IS OPTED");
            Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Beauty & Grooming")).Selected, "Beauty & Grooming :IS OPTED");
            Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Salon & Wellness Services")).Selected, "Salon & Wellness Services :IS OPTED");
            Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Fine Jewellery")).Selected, "Fine Jewellery :IS OPTED");
            Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Fine Watches")).Selected, "Fine Watches :IS OPTED");
            Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Home & Technology")).Selected, "Home & Technology :IS OPTED");
            Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Food & Restaurants")).Selected, "Food & Restaurants :IS OPTED");
            Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Wine & Spirits")).Selected, "Wine & Spirits :IS OPTED");
            Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Kids & Toys")).Selected, "Kids & Toys :IS OPTED");
            Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Father’s Day")).Selected, "Fathers day is selected");
            Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Mother’s Day")).Selected, "Mothers day is selected");

        }

        public void validateAllInterestOptedForRewardsCust()
        {
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Womenswear")).Selected, "Womenswear :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Menswear")).Selected, "Menswear :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Beauty & Grooming")).Selected, "Beauty & Grooming :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Salon & Wellness Services")).Selected, "Salon & Wellness Services :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Watches")).Selected, "Fine Watches :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Jewellery")).Selected, "Fine Jewellery :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Home & Technology")).Selected, "Home & Technology :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Food & Restaurants")).Selected, "Food & Restaurants :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Wine & Spirits")).Selected, "Wine & Spirits :IS NOT OPTED");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Kids & Toys")).Selected, "Kids & Toys :IS NOT OPTED");
            Assert.IsFalse(driver.FindElement(FFInterestCheckBoxBtn("Mother’s Day")).Selected, "Mothers day is selected");
            Assert.IsFalse(driver.FindElement(FFInterestCheckBoxBtn("Father’s Day")).Selected, "Fathers day is selected");
           // Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Harrods Rewards")).Selected, "Harrods Rewards is not selected");

        }

        public void PerformMixedSelectionOnInterest(string OptStatus)
        {
            PerformOptChannel(ScayleChannelConsentField("email"), false);
            PerformOptChannel(ScayleChannelConsentField("sms"), false);
            PerformOptChannel(ScayleChannelConsentField("postal"), false);
            PerformOptChannel(ScayleChannelConsentField("phone"), false);
            //Assert.AreEqual("true", driver.FindElement(FFInterestSelectionButton("Unselect all")).GetAttribute("disabled"), "All interests not showing as opted out");
            BrowserDriver.Sleep(3000);
            driver.FindElement(By.XPath("//*[text()='Select all']")).Click();
            BrowserDriver.Sleep(2000);
            //driver.FindElement(By.XPath("//*[text()='Mother’s Day']")).Click();
            BrowserDriver.Sleep(2000);
            //driver.FindElement(By.XPath("//*[text()='Father’s Day']")).Click();
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
            BrowserDriver.Sleep(3000);
        }

        public void PerformHarrodsCommunicationPreferencesOptingChannelForRewardsCust(string OptStatus, string channel)
        {
            if (OptStatus == "Opt-In")
            {
                switch (channel)
                {
                    case "email":
                        PerformOptChannel(ScayleChannelConsentField("email"), true);
                        //validateAllInterestOptedForRewardsCust();
                        ValidateOptChannel(ScayleChannelConsentField("email"), true);
                        //JoinMiniHarrodsViaCommunicationPreference();
                        break;
                    case "sms":
                        PerformOptChannel(ScayleChannelConsentField("sms"), true);
                        //validateAllInterestOpted();
                        ValidateOptChannel(ScayleChannelConsentField("sms"), true);
                        break;
                    case "postal":
                        PerformOptChannel(ScayleChannelConsentField("postal"), true);
                        //validateAllInterestOptedForRewardsCust();
                        ValidateOptChannel(ScayleChannelConsentField("postal"), true);
                        //JoinMiniHarrodsViaCommunicationPreference();
                        break;
                    case "phone":
                        PerformOptChannel(ScayleChannelConsentField("phone"), true);
                        ValidateOptChannel(ScayleChannelConsentField("phone"), true);
                        //validateAllInterestOpted();
                        break;
                    case "publications":
                        PerformOptChannel(ScayleChannelConsentField("publications"), true);
                        ValidateOptChannel(ScayleChannelConsentField("publications"), true);
                        //JoinMiniHarrodsViaCommunicationPreference();
                        break;
                        //default:
                        //    // code block
                        //    break;
                }

            }

            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
            BrowserDriver.Sleep(3000);
        }

        public void ValidateInterestOpted(List<string> interest, bool isopted)
        {
            if (isopted == true)
            {
                foreach (var item in interest)
                {
                    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn(item)).Selected, item + ":IS NOT OPTED");
                }

            }
            else
            {
                foreach (var item in interest)
                {
                    Assert.IsFalse(driver.FindElement(FFInterestCheckBoxBtn(item)).Selected, item + ":IS OPTED");
                }
            }

        }
        public void performChannelOpting(string channel, bool opted)
        {
            if (opted == true)
            {
                PerformOptChannel(ScayleChannelConsentField(channel), true);
            }
            else
            {
                PerformOptChannel(ScayleChannelConsentField(channel), false);
            }
            if (channel == "All")
            {
                PerformOptChannel(ScayleChannelConsentField("email"), true);
            }
        }
        public void PerformInterestOpting(List<string> interest, bool isopted)
        {


            foreach (var item in interest)
            {

                try
                {
                    driver.FindElement(FFInterestCheckBoxBtn(item)).Click();
                }
                catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", driver.FindElement(FFInterestCheckBoxBtn(item))); }

                BrowserDriver.Sleep(1000);
                
            }
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
            BrowserDriver.Sleep(3000);

        }

        public void PerformOptChannel(By ChannelField, bool OptValue)
        {
            string checkstatus = driver.FindElement(ChannelField).GetAttribute("aria-checked");
            Console.WriteLine("check status " + checkstatus);
            Console.WriteLine("optvalue " + OptValue);

            if (OptValue && string.IsNullOrEmpty(checkstatus))
            {
                WebHandlers.Instance.Click(driver.FindElement(ChannelField));
            }
            else if (OptValue && string.Equals(checkstatus,"false"))
            {
                WebHandlers.Instance.Click(driver.FindElement(ChannelField));
            }
            else if ((OptValue.ToString() == "False") && checkstatus == "true")
            //else if (!OptValue && string.IsNullOrEmpty(driver.FindElement(ChannelField).GetAttribute("checked")))
            {

                WebHandlers.Instance.Click(driver.FindElement(ChannelField));
            }
            BrowserDriver.Sleep(1000);
        }

        public void PerformHarrodsCommunicationPreferencesOpting(string OptStatus)
        {
            if (OptStatus == "Opt-In All")
            {
                PerformOptChannel(ScayleChannelConsentField("email"), true);
                PerformOptChannel(ScayleChannelConsentField("postal"), true);
                PerformOptChannel(ScayleChannelConsentField("sms"), true);
                PerformOptChannel(ScayleChannelConsentField("phone"), true);
                PerformOptChannel(ScayleChannelConsentField("publications"), true);

                if (driver.FindElement(FFInterestSelectionButton("Select all")).GetAttribute("disabled") == "False")
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Unselect all")));
                WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Select all")));
            }
            else if (OptStatus == "Opt-Out All")
            {
                PerformOptChannel(ScayleChannelConsentField("EMail"), false);
                PerformOptChannel(ScayleChannelConsentField("Postal"), false);
                PerformOptChannel(ScayleChannelConsentField("SMS"), false);
                PerformOptChannel(ScayleChannelConsentField("Phone"), false);
                }
            else if (OptStatus == "Opt-Some")
            {
                PerformOptChannel(ScayleChannelConsentField("email"), true);
                consentselection.Add("email");
                PerformOptChannel(ScayleChannelConsentField("postal"), true);
                consentselection.Add("postal");
                PerformOptChannel(ScayleChannelConsentField("sms"), false);
                PerformOptChannel(ScayleChannelConsentField("phone"), false);
                PerformOptChannel(ScayleChannelConsentField("publications"), true);
                consentselection.Add("publications");
                Boolean selectstatus = driver.FindElement(FFInterestSelectionButton("Select all")).GetAttribute("disabled") == "True";

                if (selectstatus)
                {
                    //WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Unselect all")));
                    //BrowserDriver.Sleep(3000);
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Womenswear")));
                    interestselection.Add("Womenswear");
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Home & Technology")));
                    interestselection.Add("Home & Technology");
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Kids & Toys")));
                    interestselection.Add("Kids & Toys");
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Salon & Wellness Services")));
                    interestselection.Add("Salon & Wellness Services");
                }
                else if (!selectstatus)
                {
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Unselect all")));
                    BrowserDriver.Sleep(3000);
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Womenswear")));
                    interestselection.Add("Womenswear");
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Home & Technology")));
                    interestselection.Add("Home & Technology");
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Kids & Toys")));
                    interestselection.Add("Kids & Toys");
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Salon & Wellness Services")));
                    interestselection.Add("Salon & Wellness Services");

                }
            }

            else if (OptStatus == "Opt-In-SMS")
            {

                PerformOptChannel(ScayleChannelConsentField("Postal"), false);
                //consentselection.Add("postal");
                PerformOptChannel(ScayleChannelConsentField("SMS"), true);
                PerformOptChannel(ScayleChannelConsentField("Phone"), false);

                Boolean selectIntereststatus = driver.FindElement(FFInterestSelectionButton("Select all")).GetAttribute("disabled") == "True";

                if (!selectIntereststatus)
                {
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Unselect all")));
                    BrowserDriver.Sleep(3000);
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Womenswear")));
                    interestselection.Add("Womenswear");
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Home & Technology")));
                    interestselection.Add("Home & Technology");
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Kids & Toys")));
                    interestselection.Add("Kids & Toys");
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Salon & Wellness Services")));
                    interestselection.Add("Salon & Wellness Services");

                }
            }

            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
        }

        //TC-38 Specifi
        public void PerformScayleOptOutToValidateInterestGreyedOut(string OptStatus, string channel)
        {
            if (OptStatus == "Opt-Out-All")
            {
                switch (channel)
                {
                    case "EMail":
                        PerformOptChannel(ScayleChannelConsentField("EMail"), false);
                        break;
                    case "SMS":
                        PerformOptChannel(ScayleChannelConsentField("SMS"), false);
                        break;
                }

                Assert.IsTrue(driver.FindElement(By.XPath("//span[text()='Select a channel first to register your interests']")).Displayed, "Interest Not greyed Out");


            }
        }

        public void VallidateTAndCAvailableAfterOptingForHarrodsMagazine()
        {

            //Terms and Consition not avaialble during test transition to scayle as on 20 Nov 2024
            Assert.IsTrue(driver.FindElement(By.XPath("//*[text()='Terms and Condition']/preceding::input")).Displayed, "Terms and Condition is not available");
            
            BrowserDriver.Sleep(1000);
        }

        public void ValidateScayleConsentsOpted(string Consents, bool isopted)
        {
            string[] Consent_List = Consents.Split(',');
            if (isopted == true)
            {
                foreach (var item in Consent_List)
                {
                    string channelStatus = driver.FindElement(ScayleChannelConsentField(item)).GetAttribute("aria-checked");
                    Assert.IsTrue(string.Equals(channelStatus, "true"), item + ":IS NOT OPTED");

                }
            }
        }

        public void ValidateScayleConsentsOptedOut(string Consents, bool isopted)
        {
            string[] Consent_List = Consents.Split(',');
            if (isopted == false)
            {
                foreach (var item in Consent_List)
                {
                    string channelStatus = driver.FindElement(ScayleChannelConsentField(item)).GetAttribute("aria-checked");
                    Assert.IsTrue(string.Equals(channelStatus, "false"), item + ":IS OPTED");

                }
            }
        }

        public void ValidateScayleCommunicationPreferencesOpting(string OptStatus)
        {
            if (OptStatus == "Opt-In All")
            {
                ValidateOptChannel(ScayleChannelConsentField("email"), true);
                ValidateOptChannel(ScayleChannelConsentField("postal"), true);
                ValidateOptChannel(ScayleChannelConsentField("sms"), true);
                ValidateOptChannel(ScayleChannelConsentField("phone"), true);
               
                Assert.AreEqual("true", driver.FindElement(FFInterestSelectionButton("Select all")).GetAttribute("disabled"), "All interests not showing as opted in");
            }
            else if (OptStatus == "Opt-Out All")
            {
                ValidateOptChannel(ScayleChannelConsentField("email"), false);
                ValidateOptChannel(ScayleChannelConsentField("postal"), false);
                ValidateOptChannel(ScayleChannelConsentField("sms"), false);
                ValidateOptChannel(ScayleChannelConsentField("phone"), false);
                ValidateOptChannel(ScayleChannelConsentField("publications"), false);
                Assert.AreEqual("true", driver.FindElement(FFInterestSelectionButton("Unselect all")).GetAttribute("disabled"), "All interests not showing as opted out");
            }
            else if (OptStatus == "Opt-Some")
            {
                ValidateOptChannel(ScayleChannelConsentField("email"), true);
                ValidateOptChannel(ScayleChannelConsentField("postal"), true);
                ValidateOptChannel(ScayleChannelConsentField("sms"), false);
                ValidateOptChannel(ScayleChannelConsentField("phone"), false);
                ValidateOptChannel(ScayleChannelConsentField("publications"), true);
            }
            else if (OptStatus == "Opt-email")
            {
                PerformOptChannel(ScayleChannelConsentField("EMail"), true);
            }
            else if (OptStatus == "Opt-In-EMail")
            {
                ValidateOptChannel(ScayleChannelConsentField("EMail"), true);
            }

        }

       
                public void updateCommunicationPref(Dictionary<string, string> customerData)
        {
            string email = customerData["TypeEmail"];
            string sms = customerData["TypeSMS"];
            string postal = customerData["TypePostal"];
            string phone = customerData["TypePhone"];
            string FW = customerData["CP_Food_and_Wine"];
            string Promotions = customerData["CP_Promotions"];
            string MiniHarrods = customerData["CP_Mini_Harrods"];
            string Beauty = customerData["CP_Beauty"];

            foreach (string key in customerData.Keys)
            {
                if (key.StartsWith("CP_"))
                {
                    string needCP = customerData[key];
                    string category = key.Substring(3, key.Length - 3);
                    try
                    {
                        IWebElement inputEmailEle = WebHandlers.Instance.GetElement(driver, By.XPath("//span[contains(text(),'Email')]/preceding-sibling::input[@data-test='" + category + "-subscribeVia-email']"));
                        SelectCommunicationPreference(email, needCP, inputEmailEle);
                        if (category == "Latest_News" && customerData["RewardCardNo"] == "")
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        string exception = e.StackTrace;
                        Console.WriteLine(exception);
                    }

                    try
                    {
                        if (category == "Promotions" || category == "Mini_Harrods" || category == "Beauty")
                        {
                            //sms
                            IWebElement inputEleSMS = WebHandlers.Instance.GetElement(driver, By.XPath("//span[contains(text(),'SMS')]/preceding-sibling::input[@data-test='" + category + "-subscribeVia-sms']"));
                            SelectCommunicationPreference(sms, needCP, inputEleSMS);
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (category == "Promotions")
                        {
                            //phone
                            IWebElement inputElePhone = WebHandlers.Instance.GetElement(driver, By.XPath("//span[contains(text(),'Phone')]/preceding-sibling::input[@data-test='" + category + "-subscribeVia-phone']"));
                            SelectCommunicationPreference(phone, needCP, inputElePhone);
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (category == "Promotions" || category == "Mini_Harrods")
                        {
                            //postal
                            IWebElement inputElePostal = WebHandlers.Instance.GetElement(driver, By.XPath("//span[contains(text(),'Post')]/preceding-sibling::input[@data-test='" + category + "-subscribeVia-postal']"));
                            SelectCommunicationPreference(postal, needCP, inputElePostal);
                        }
                    }
                    catch
                    {

                    }

                }
            }

            WebHandlers.Instance.Click(btnUpdateComPref);


        }

        public void SelectCommunicationPreference(string category, string catType, IWebElement ele)
        {
            if (category.ToUpper() == "YES" && catType.ToUpper() == "YES")
            {
                if (!WebHandlers.Instance.ChkboxIsChecked(ele))
                    WebHandlers.Instance.ClickByJsExecutor(ele);
            }
            else
            {
                if (WebHandlers.Instance.ChkboxIsChecked(ele))
                    WebHandlers.Instance.ClickByJsExecutor(ele);
            }

        }

        public void VallidateEmailOptedInHarrods()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//*[text()='Email']/preceding::input")).Selected, "Email is Checked as expected");
            Console.WriteLine(driver.FindElement(By.XPath("//*[text()='Email']/preceding::input")).Text);
            BrowserDriver.Sleep(3000);
        }
//TC-109
        public void PerformHarrodsCommunicationPreferencesOptingChannelAfterscenario(string OptStatus, string channel)
        {
            if (OptStatus == "Opt-In-postal")
            {
                switch (channel)
                {
                    case "postal":
                        PerformOptChannel(ScayleChannelConsentField("postal"), false);
                        ValidateOptChannel(ScayleChannelConsentField("postal"), false);
                        //validateAllInterestOpted();
                        break;

                        break;
                }
                BrowserDriver.Sleep(3000);
                WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
                BrowserDriver.Sleep(3000);
            }
        }

            public void PerformHarrodsCommunicationPreferencesOptingChannel()
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(CommunicationPreferences);
            BrowserDriver.Sleep(3000);
            BrowserDriver.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='womensWear']")).Click();
            {
                driver.FindElement(By.XPath("//*[text()='Select all']")).Click();
                BrowserDriver.Sleep(2000);
            }
            //if (driver.FindElement(By.XPath("//*[@id='communication -preferences-unselectAllButton']")).Displayed)
            {
                driver.FindElement(By.XPath("//*[text()='Harrods Rewards']")).Click();
                BrowserDriver.Sleep(2000);
            }
            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
            BrowserDriver.Sleep(3000);


        }

        public void PerformScayleCommunicationOptOutChannels(string OptStatus, string channel)
        {
            if (OptStatus == "Opt-Out")
            {
                switch (channel)
                {
                    case "EMail":
                        PerformOptChannel(ScayleChannelConsentField("EMail"), false);
                        ValidateOptChannel(ScayleChannelConsentField("EMail"), false);
                        //validateAllInterestOpted();

                        break;
                    case "SMS":
                        PerformOptChannel(ScayleChannelConsentField("SMS"), false);
                        ValidateOptChannel(ScayleChannelConsentField("SMS"), false);
                        //validateAllInterestOpted();
                        break;
                    case "Postal":
                        PerformOptChannel(ScayleChannelConsentField("Postal"), false);
                        ValidateOptChannel(ScayleChannelConsentField("Postal"), false);
                        //validateAllInterestOpted();
                        break;
                    case "Phone":
                        PerformOptChannel(ScayleChannelConsentField("Phone"), false);
                        ValidateOptChannel(ScayleChannelConsentField("Phone"), false);
                        //validateAllInterestOpted();
                        break;
                    case "magazine":
                        //PerformOptChannel(ScayleChannelConsentField("Publications"), false);
                        ValidateOptChannel(ScayleChannelConsentField("Publications"), false);
                        break;
                        //default:
                        //    // code block
                        //    break;
                }

            }
        }


        public void ValidateScayleCommunicationOptOutChannels(string OptStatus, string channel)
        {
            if (OptStatus == "Opt-Out")
            {
                switch (channel)
                {
                    case "EMail":
                        
                        ValidateOptChannel(ScayleChannelConsentField("EMail"), false);
                        //validateAllInterestOpted();

                        break;
                    case "SMS":
                      
                        ValidateOptChannel(ScayleChannelConsentField("SMS"), false);
                        //validateAllInterestOpted();
                        break;
                    case "Postal":
                        
                        ValidateOptChannel(ScayleChannelConsentField("Postal"), false);
                        //validateAllInterestOpted();
                        break;
                    case "Phone":
                       
                        ValidateOptChannel(ScayleChannelConsentField("Phone"), false);
                        //validateAllInterestOpted();
                        break;
                    case "Magazine":
                        
                        ValidateOptChannel(ScayleChannelConsentField("Publications"), false);
                        break;
                        
                }

            }
        }


        public void PerformScayleCommunicationPreferencesOptingChannel(string OptStatus, string channel)
        {
            if (OptStatus == "Opt-In")
            {
                switch (channel)
                {
                    case "EMail":
                        PerformOptChannel(ScayleChannelConsentField("EMail"), true);
                        ValidateOptChannel(ScayleChannelConsentField("EMail"), true);
                        //validateAllInterestOpted();

                        break;
                    case "SMS":
                        PerformOptChannel(ScayleChannelConsentField("SMS"), true);
                        ValidateOptChannel(ScayleChannelConsentField("SMS"), true);
                        //validateAllInterestOpted();
                        break;
                    case "Postal":
                        PerformOptChannel(ScayleChannelConsentField("Postal"), true);
                        ValidateOptChannel(ScayleChannelConsentField("Postal"), true);
                        //validateAllInterestOpted();
                        break;
                    case "Phone":
                        PerformOptChannel(ScayleChannelConsentField("Phone"), true);
                        ValidateOptChannel(ScayleChannelConsentField("Phone"), true);
                        //validateAllInterestOpted();
                        break;
                    case "Harrods Magazine":
                        PerformOptChannel(ScayleChannelConsentField("Publications"), true);
                        ValidateOptChannel(ScayleChannelConsentField("Publications"), true);
                        break;
                        //default:
                        //    // code block
                        //    break;
                }

            }


            if (OptStatus == "Opt-In-All")
            {
                PerformOptChannel(ScayleChannelConsentField("EMail"), true);
                if (!driver.FindElement(ScayleChannelConsentField("SMS")).Selected)
                {
                    PerformOptChannel(ScayleChannelConsentField("SMS"), true);
                }
                PerformOptChannel(ScayleChannelConsentField("Postal"), true);
                PerformOptChannel(ScayleChannelConsentField("Phone"), true);
                // validateAllInterestOpted();
            }
            if (OptStatus == "Opt-In-email")
            {
                PerformOptChannel(ScayleChannelConsentField("EMail"), true);

            }
            if (OptStatus == "Opt-In-sms")
            {
                PerformOptChannel(ScayleChannelConsentField("SMS"), true);

            }
            
            if (OptStatus == "Opt-In-postal")
            {
                PerformOptChannel(ScayleChannelConsentField("Postal"), true);
                PerformOptChannel(ScayleChannelConsentField("Publications"), true);

            }
            if (OptStatus == "No consent")
            {     //condition for no consent and select all interest
                Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Womenswear")).Selected, "Womenswear :IS NOT OPTED");
                Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Menswear")).Selected, "Menswear :IS NOT OPTED");
                Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Beauty & Grooming")).Selected, "Beauty & Grooming :IS NOT OPTED");
                Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Salon & Wellness Services")).Selected, "Salon & Wellness Services :IS NOT OPTED");
                Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Jewellery")).Selected, "Fine Jewellery :IS NOT OPTED");
                Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Watches")).Selected, "Fine Watches :IS NOT OPTED");
                Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Home & Technology")).Selected, "Home & Technology :IS NOT OPTED");
                Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Food & Restaurants")).Selected, "Food & Restaurants :IS NOT OPTED");
                Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Wine & Spirits")).Selected, "Wine & Spirits :IS NOT OPTED");
                Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Kids & Toys")).Selected, "Kids & Toys :IS NOT OPTED");
                Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Father’s Day")).Selected, "Fathers day is not selected");
                Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Mother’s Day")).Selected, "Mothers day is not selected");
                //Unselecting all 
                WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Unselect all")));
                WebHandlers.Instance.Click(driver.FindElement(FFInterestCheckBoxBtn("Mother’s Day")));
                WebHandlers.Instance.Click(driver.FindElement(FFInterestCheckBoxBtn("Father’s Day")));
                WebHandlers.Instance.Click(driver.FindElement(FFInterestCheckBoxBtn("Harrods Rewards")));
                WebHandlers.Instance.Click(driver.FindElement(FFInterestCheckBoxBtn("Mini Harrods")));
            }
            if (OptStatus == "All consent")
            {
                ValidateOptChannel(ScayleChannelConsentField("email"), true);
                ValidateOptChannel(ScayleChannelConsentField("sms"), true);
                ValidateOptChannel(ScayleChannelConsentField("postal"), true);
                ValidateOptChannel(ScayleChannelConsentField("phone"), true);
                ValidateOptChannel(ScayleChannelConsentField("publications"), true);
                //unselect all consent 
                PerformOptChannel(ScayleChannelConsentField("email"), false);
                PerformOptChannel(ScayleChannelConsentField("sms"), false);
                PerformOptChannel(ScayleChannelConsentField("postal"), false);
                PerformOptChannel(ScayleChannelConsentField("phone"), false);
                PerformOptChannel(ScayleChannelConsentField("publications"), false);
                //validate all interest are greyed out
                Assert.AreEqual("true", driver.FindElement(FFInterestSelectionButton("Unselect all")).GetAttribute("disabled"), "All interests not showing as opted out");
                Assert.AreEqual("true", driver.FindElement(FFInterestSelectionButton("Select all")).GetAttribute("disabled"), "All interests not showing as opted out");
                Assert.AreEqual("true", driver.FindElement(FFInterestCheckBoxBtn("Harrods Rewards")).GetAttribute("disabled"), "All interests not showing as opted out");
                //Assert.AreEqual("true", driver.FindElement(FFInterestCheckBoxBtn("Mini Harrods")).GetAttribute("disabled"), "All interests not showing as opted out");
            }
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
            BrowserDriver.Sleep(3000);
       }

        public void ValidateAddAddressOnPostCommunicationChannel()
        {
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.XPath("//a[text()='add your address']")).Displayed, "Comm prefrence not updated");
           
            if (driver.FindElement(By.XPath("//a[text()='add your address']")).Displayed)
            {
                
                driver.FindElement(By.XPath("//a[text()='add your address']")).Click();
                BrowserDriver.Sleep(3000);
            }
            else
            {
                Assert.Fail("Error while updating communication prefrence ");
            }
            
        }

        public void PerformAddAddress()
        {
            BrowserDriver.Sleep(3000);
            
            WebWaitHelper.Instance.WaitForElementPresence(AddAnAddress);
            WebHandlers.Instance.Click(AddAnAddress);


            
        }

    }
    #endregion
}
