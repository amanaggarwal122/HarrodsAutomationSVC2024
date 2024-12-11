using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using TAF_Web.Scripted.Web;


namespace TAF_Scripting.Test.Scripted.PageObjects.SCAYLE
{
    class ScayleUserCommunicationPreferencesPage
    {
        public IWebDriver driver;
        private Configuration config = null;        
        List<string> consentselection = new List<string>();
        List<string> interestselection = new List<string>();

        #region  Constructor
        public ScayleUserCommunicationPreferencesPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements

        [FindsBy(How = How.XPath, Using = "//span[text()='Communication Preferences']")]
        private IWebElement CommunicationPreferences;
        [FindsBy(How = How.XPath, Using = "(//div[@class='text-harrods-green-success grow'])[1]")]
        private IWebElement AddressConfirmation;
        [FindsBy(How = How.XPath, Using = "//h2[text()='Channel']")]
        private IWebElement UserChannelsHeader;
        [FindsBy(How = How.XPath, Using = "//div[@data-test='account-sidebar']//span[text()='Communication Preferences']")]
        private IWebElement lnkCommunicationPreferences;
        [FindsBy(How = How.XPath, Using = "//button[@data-test='communication-preferences-updateButton']")]
        private IWebElement btnUpdateComPref;
        #endregion
        public By FFInterestCheckBoxBtn(string SelectItem) { return By.XPath("//span[text()='" + SelectItem + "']//preceding-sibling::input"); }
        public By MiniHarrodsField(string miniHarrods) { return By.XPath("//h3[text()='" + miniHarrods + "']"); }
        public By FFInterestSelectionButton(string SelectItem) { return By.XPath("//button[text()='" + SelectItem + "']"); }
        public By FFInterestSelectionBtn(string SelectItem) { return By.XPath("//span[text()='" + SelectItem + "']"); }
        public By FFChannelConsentField(string ChannelName) { return By.XPath("//label[text()='" + ChannelName + "']"); }
        
        #region Events
        public void NavigateToHarrodsCommunicationPreferences()
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
                Assert.AreEqual("true", driver.FindElement(ChannelField).GetAttribute("checked"), "Opt value for channel not showing as expected");
            else if (OptValue == false)
                Assert.AreEqual(null, driver.FindElement(ChannelField).GetAttribute("checked"), "Opt value for channel not showing as expected");
            //Assert.IsEmpty(driver.FindElement(ChannelField).GetAttribute("checked"), "Opt value for channel not showing as expected");
        }

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
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Father’s Day")).Selected, "Fathers day is not selected");
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Mother’s Day")).Selected, "Mothers day is not selected");
            bool HarrodsMagazine = WebHandlers.Instance.isElementPresent(FFChannelConsentField("publications"));
            bool MiniHarrodspresent = WebHandlers.Instance.isElementPresent(MiniHarrodsField("Mini Harrods"));
            Assert.IsFalse(HarrodsMagazine, "Harrods magazines channel should not be displayed ");
            Assert.IsFalse(MiniHarrodspresent, "Mini Harrods should not be Displayed for non rewards user");
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
            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Harrods Rewards")).Selected, "Harrods Rewards is not selected");

        }

        public void PerformMixedSelectionOnInterest(string OptStatus)
        {
            PerformOptChannel(FFChannelConsentField("email"), false);
            PerformOptChannel(FFChannelConsentField("sms"), false);
            PerformOptChannel(FFChannelConsentField("postal"), false);
            PerformOptChannel(FFChannelConsentField("phone"), false);
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
                        PerformOptChannel(FFChannelConsentField("email"), true);
                        //validateAllInterestOptedForRewardsCust();
                        ValidateOptChannel(FFChannelConsentField("email"), true);
                        //JoinMiniHarrodsViaCommunicationPreference();
                        break;
                    case "sms":
                        PerformOptChannel(FFChannelConsentField("sms"), true);
                        //validateAllInterestOpted();
                        ValidateOptChannel(FFChannelConsentField("sms"), true);
                        break;
                    case "postal":
                        PerformOptChannel(FFChannelConsentField("postal"), true);
                        //validateAllInterestOptedForRewardsCust();
                        ValidateOptChannel(FFChannelConsentField("postal"), true);
                        //JoinMiniHarrodsViaCommunicationPreference();
                        break;
                    case "phone":
                        PerformOptChannel(FFChannelConsentField("phone"), true);
                        ValidateOptChannel(FFChannelConsentField("phone"), true);
                        //validateAllInterestOpted();
                        break;
                    case "publications":
                        PerformOptChannel(FFChannelConsentField("publications"), true);
                        ValidateOptChannel(FFChannelConsentField("publications"), true);
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
                PerformOptChannel(FFChannelConsentField(channel), true);
            }
            else
            {
                PerformOptChannel(FFChannelConsentField(channel), false);
            }
            if (channel == "All")
            {
                PerformOptChannel(FFChannelConsentField("email"), true);
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
            string checkstatus = driver.FindElement(ChannelField).GetAttribute("checked");
            Console.WriteLine("check status " + checkstatus);
            Console.WriteLine("optvalue " + OptValue);

            if (OptValue && string.IsNullOrEmpty(checkstatus))
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
                PerformOptChannel(FFChannelConsentField("email"), true);
                PerformOptChannel(FFChannelConsentField("postal"), true);
                PerformOptChannel(FFChannelConsentField("sms"), true);
                PerformOptChannel(FFChannelConsentField("phone"), true);
                PerformOptChannel(FFChannelConsentField("publications"), true);

                if (driver.FindElement(FFInterestSelectionButton("Select all")).GetAttribute("disabled") == "False")
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Unselect all")));
                WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Select all")));
            }
            else if (OptStatus == "Opt-Out All")
            {
                PerformOptChannel(FFChannelConsentField("email"), false);
                PerformOptChannel(FFChannelConsentField("postal"), false);
                PerformOptChannel(FFChannelConsentField("sms"), false);
                PerformOptChannel(FFChannelConsentField("phone"), false);
                PerformOptChannel(FFChannelConsentField("publications"), false);
                if (driver.FindElement(FFInterestSelectionButton("Unselect all")).GetAttribute("disabled") == "False")
                    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Unselect all")));
            }
            else if (OptStatus == "Opt-Some")
            {
                PerformOptChannel(FFChannelConsentField("email"), true);
                consentselection.Add("email");
                PerformOptChannel(FFChannelConsentField("postal"), true);
                consentselection.Add("postal");
                PerformOptChannel(FFChannelConsentField("sms"), false);
                PerformOptChannel(FFChannelConsentField("phone"), false);
                PerformOptChannel(FFChannelConsentField("publications"), true);
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

            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
        }

        public void ValidateHarrodsCommunicationPreferencesOpting(string OptStatus)
        {
            if (OptStatus == "Opt-In All")
            {
                ValidateOptChannel(FFChannelConsentField("email"), true);
                ValidateOptChannel(FFChannelConsentField("postal"), true);
                ValidateOptChannel(FFChannelConsentField("sms"), true);
                ValidateOptChannel(FFChannelConsentField("phone"), true);
                ValidateOptChannel(FFChannelConsentField("publications"), true);
                Assert.AreEqual("true", driver.FindElement(FFInterestSelectionButton("Select all")).GetAttribute("disabled"), "All interests not showing as opted in");
            }
            else if (OptStatus == "Opt-Out All")
            {
                ValidateOptChannel(FFChannelConsentField("email"), false);
                ValidateOptChannel(FFChannelConsentField("postal"), false);
                ValidateOptChannel(FFChannelConsentField("sms"), false);
                ValidateOptChannel(FFChannelConsentField("phone"), false);
                ValidateOptChannel(FFChannelConsentField("publications"), false);
                Assert.AreEqual("true", driver.FindElement(FFInterestSelectionButton("Unselect all")).GetAttribute("disabled"), "All interests not showing as opted out");
            }
            else if (OptStatus == "Opt-Some")
            {
                ValidateOptChannel(FFChannelConsentField("email"), true);
                ValidateOptChannel(FFChannelConsentField("postal"), true);
                ValidateOptChannel(FFChannelConsentField("sms"), false);
                ValidateOptChannel(FFChannelConsentField("phone"), false);
                ValidateOptChannel(FFChannelConsentField("publications"), true);
            }
            else if (OptStatus == "Opt-email")
            {
                PerformOptChannel(FFChannelConsentField("email"), true);
            }
            else if (OptStatus == "Opt-In-email")
            {
                ValidateOptChannel(FFChannelConsentField("email"), true);
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
                        PerformOptChannel(FFChannelConsentField("postal"), false);
                        ValidateOptChannel(FFChannelConsentField("postal"), false);
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
            driver.FindElement(By.XPath("//span[text()='Womenswear']")).Click();
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

            public void PerformHarrodsCommunicationPreferencesOptingChannel(string OptStatus, string channel)
        {
            if (OptStatus == "Opt-In")
            {
                switch (channel)
                {
                    case "email":
                        PerformOptChannel(FFChannelConsentField("email"), true);
                        ValidateOptChannel(FFChannelConsentField("email"), true);
                        //validateAllInterestOpted();

                        break;
                    case "sms":
                        PerformOptChannel(FFChannelConsentField("sms"), true);
                        ValidateOptChannel(FFChannelConsentField("sms"), true);
                        //validateAllInterestOpted();
                        break;
                    case "postal":
                        PerformOptChannel(FFChannelConsentField("postal"), true);
                        ValidateOptChannel(FFChannelConsentField("postal"), true);
                        //validateAllInterestOpted();
                        break;
                    case "phone":
                        PerformOptChannel(FFChannelConsentField("phone"), true);
                        ValidateOptChannel(FFChannelConsentField("phone"), true);
                        //validateAllInterestOpted();
                        break;
                    case "publications":
                        PerformOptChannel(FFChannelConsentField("publications"), true);
                        ValidateOptChannel(FFChannelConsentField("publications"), true);
                        break;
                        //default:
                        //    // code block
                        //    break;
                }

            }


            if (OptStatus == "Opt-In-All")
            {
                PerformOptChannel(FFChannelConsentField("email"), true);
                if (!driver.FindElement(FFChannelConsentField("sms")).Selected)
                    PerformOptChannel(FFChannelConsentField("sms"), true);
                PerformOptChannel(FFChannelConsentField("postal"), true);
                PerformOptChannel(FFChannelConsentField("phone"), true);
                // validateAllInterestOpted();
            }
            if (OptStatus == "Opt-In-email")
            {
                PerformOptChannel(FFChannelConsentField("email"), true);

            }
            if (OptStatus == "Opt-In-sms")
            {
                PerformOptChannel(FFChannelConsentField("sms"), true);

            }
            if (OptStatus == "Opt-In-sms")
            {
                PerformOptChannel(FFChannelConsentField("sms"), true);

            }
            if (OptStatus == "Opt-In-postal")
            {
                PerformOptChannel(FFChannelConsentField("Post"), true);
                PerformOptChannel(FFChannelConsentField("Harrods Magazine"), true);

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
                ValidateOptChannel(FFChannelConsentField("email"), true);
                ValidateOptChannel(FFChannelConsentField("sms"), true);
                ValidateOptChannel(FFChannelConsentField("postal"), true);
                ValidateOptChannel(FFChannelConsentField("phone"), true);
                ValidateOptChannel(FFChannelConsentField("publications"), true);
                //unselect all consent 
                PerformOptChannel(FFChannelConsentField("email"), false);
                PerformOptChannel(FFChannelConsentField("sms"), false);
                PerformOptChannel(FFChannelConsentField("postal"), false);
                PerformOptChannel(FFChannelConsentField("phone"), false);
                PerformOptChannel(FFChannelConsentField("publications"), false);
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
    }
    #endregion
}
       