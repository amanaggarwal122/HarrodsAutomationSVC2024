using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.ObjectModel;
using TAF_Web.Scripted.Web;


namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCCustomerOverviewPage
    {
        public IWebDriver driver;
        private Configuration config = null;
        string card_assigned = "";
        private SSCCustomersPage SSC_Customers_Page = null;
        private SSCUserHomePage SSC_Customer_Home_Page = null;
        #region  Constructor
        public SSCCustomerOverviewPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements 

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle')][contains(@id,'img')]")]
        private IWebElement SSCDetailsEditIcon;
        [FindsBy(How = How.XPath, Using = "//*[text()='Deactivate Card']")]
        private IWebElement SSC_DeactivateCard_btn;
        //[FindsBy(How = How.XPath, Using = "//*[text()='Reason for deactivation']/following::div[contains(@id,'dropdownlistbox')][1]")]
        [FindsBy(How = How.XPath, Using = "//*[text()='Deactivation Reason']/following::div[contains(@id,'dropdownlistbox')][1]")]
        private IWebElement SSC_Card_deactivate_dropdown;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Name On Card 1']/following::input[1]")]
        private IWebElement SSC_UserFirstName_Txtbox;
        //[FindsBy(How = How.XPath, Using = "//*[@id='inputfield3Cr18bn8qqMbHfM6DsuLtm_635-inner']")]
        [FindsBy(How = How.XPath, Using = "//th[@title='Name on Card 1']//following::input[1]")]
        private IWebElement SSC_NameonCard1_Txtbox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Name On Card 1']/following::input[2]")]
        private IWebElement SSC_UserLastName_Txtbox;
        [FindsBy(How = How.XPath, Using = "//*[text()='Save']")]
        private IWebElement SSCSaveButton;
        [FindsBy(How = How.XPath, Using = "//div[text()='Rewards Data']")]
        private IWebElement RewardDataTab;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Send Card To Customer']")]
        // "//bdi[text()='Send Card to Customer']")]
        private IWebElement SSC_SendCardtocustomer;
        [FindsBy(How = How.XPath, Using = "//*[text()='Assign New Card']")]
        private IWebElement SSC_ActivateCard_btn;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Reason for Status']/following::span[text()='Assigned']")]
        private IWebElement SSC_CardAssigned_Status;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Card ID']/following::a[1]")]
        private IWebElement SSC_Card_Assigned;
        [FindsBy(How = How.XPath, Using = "(//*[text()='Card ID'])[1]//following::span[14]")]
        private IWebElement SSC_RewardCard_Assigned;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'-searchButton-img')]")]
        private IWebElement SSCCustomersSearchIcon;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'-searchField-I')]")]
        private IWebElement SSCCustomersSearchEdit;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'inputfield3fa290bb8e1a22fe0d86afd4640e1bc8')]")]
        private IWebElement SSCCustomerCDCID;
        [FindsBy(How = How.XPath, Using = "(//span[contains(@id,'dropdownlistboxa9a498bccf7fdaeaf586528c044f484a')])[1]")]
        private IWebElement SSCCustomerTierDetails;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save']")]
        private IWebElement SSCNewTicketSave;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Email']")]
        private IWebElement SSCNewTicketEmailIcon;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Send']")]
        private IWebElement SSCTicketEmailSend;

        #endregion
        public By SSCNewTicketFields(string FieldLabel) { return By.XPath("(//bdi[text()='" + FieldLabel + "']/following::input)[1]"); }
        public By SpanSSCText(string text) { return By.XPath("//span[contains(text(),'" + text + "')]"); }
        public By SSCCustomersSubtabClose(string text) { return By.XPath("//span[text()='" + text + "']/../../../button[2]"); }
        public By SSCTicketSubtabClose(string text) { return By.XPath("//span[contains(text(),'" + text + "')]/../../../button[2]"); }
        public By SSCUserFieldData(string FieldLabel) { return By.XPath("//bdi[text()='" + FieldLabel + "']/following::span[1]"); }
        public By SSCUserFieldDatas(string FieldLabel) { return By.XPath("//span[text()='" + FieldLabel + "']"); }
        public By SSCUserRewardData(string FieldLabel) { return By.XPath("//span[text()='" + FieldLabel + "']/following::span[1]"); }
        public By SSCCustomersGridData(string text) { return By.XPath("//a[text()='" + text + "']"); }
        public By SSCNewTicketSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }
        public By SSCCustomerRewardsPointsValue(string points) { return By.XPath("//bdi[text()='Rewards Points']/../following::div[1]//span[text()='" + points + "']"); }


        #region Events

        public void DeActivateandActivateCard(string DeactivateReason)
        {
            BrowserDriver.Sleep(2000);
            Actions ContentAction = new Actions(driver);
            //Card details under Reward Data tab - 18 june 2024
            driver.FindElement(SSCNewTicketSubTabs("Rewards Data")).Click();
            //WebHandlers.Instance.Click(SSCDetailsEditIcon);
            BrowserDriver.Sleep(2000);
            //precondition to assign new card
            //WebHandlers.Instance.Click(SSC_ActivateCard_btn);
            BrowserDriver.Sleep(10000);
            //To handle if card is not assigned

            {

                IWebElement deactivateCardElement = driver.FindElement(By.XPath("//*[@disabled='disabled']//*[text()='Deactivate Card']"));

                // Check if the "Deactivate Card" element is disabled


                if (deactivateCardElement.Displayed)
                {
                    // If "Deactivate Card" is disabled, click on "Assign New Card"
                    IWebElement assignNewCardElement = driver.FindElement(By.XPath("//*[text()='Assign New Card']"));
                    BrowserDriver.Sleep(5000);
                    assignNewCardElement.Click();
                    BrowserDriver.Sleep(5000);
                }

                
                    //To select the card
                    driver.FindElement(By.XPath("//*[@title='Card ID']/following::table[1]")).Click();
                    BrowserDriver.Sleep(9000);
                    //click deactivate button
                    WebHandlers.Instance.Click(SSC_DeactivateCard_btn);
                    BrowserDriver.Sleep(2000);

                    ContentAction.MoveToElement(SSC_Card_deactivate_dropdown).Click().SendKeys(DeactivateReason + "\n").DoubleClick().Build().Perform();
                    //WebWaitHelper.Instance.WaitForElement(SSC_Card_deactivate_dropdown);
                    //WebHandlers.Instance.EnterText(SSC_Card_deactivate_dropdown, DeactivateReason);
                    //WebHandlers.Instance.Click(SSC_Card_deactivate_Stolen);
                    BrowserDriver.Sleep(2000);
                    //Click OK button on popup
                    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='OK']")));
                    BrowserDriver.Sleep(3000);
            }
            
        }

        public void ChangeNameonCard(string firstname_to_change, string lastname_to_change)
        {
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCDetailsEditIcon);
            BrowserDriver.Sleep(5000);
            //WebHandlers.Instance.EnterText(SSC_UserFirstName_Txtbox, firstname_to_change);
            //SSC_UserFirstName_Txtbox.Clear();
            //SSC_UserFirstName_Txtbox.SendKeys(firstname_to_change);
            //BrowserDriver.Sleep(2000);
            ////WebHandlers.Instance.EnterText(SSC_UserLastName_Txtbox, lastname_to_change);
            //SSC_UserLastName_Txtbox.Clear();
            //SSC_UserLastName_Txtbox.SendKeys(lastname_to_change);

            //Only single NameonCard1 textbox in SSC now
            //Card details in Rewad Data Tab
            WebHandlers.Instance.Click(RewardDataTab);
            BrowserDriver.Sleep(5000);
            SSC_NameonCard1_Txtbox.Clear();
            BrowserDriver.Sleep(2000);
            SSC_NameonCard1_Txtbox.SendKeys(firstname_to_change + lastname_to_change);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCSaveButton);
            BrowserDriver.Sleep(3000);

            //*[text()='Request to send card to customer has been sent  |  Your entries have been saved.  ']
        }

        public void ValidateNameonCard(string firstname, string lastname)
        {
            //Boolean Firstnamepresent = WebHandlers.Instance.IsElementPresent(By.XPath("//*[text()='" + firstname + "']"));
            //Boolean Lastnamepresent = WebHandlers.Instance.IsElementPresent(By.XPath("//*[text()='" + lastname + "']"));
            //Assert.IsTrue(Firstnamepresent, "Firstname is not changed in card");
            //Assert.IsTrue(Lastnamepresent, "LastName is not changed in card");

            Boolean namepresent = WebHandlers.Instance.IsElementPresent(By.XPath("//*[text()='" + firstname + lastname + "']"));
            Assert.IsTrue(namepresent, "Name is not changed in card");

        }

        public void SendNewCardtoCustomer()
        {
            //Selecting the New card record
            WebHandlers.Instance.Click(SSCDetailsEditIcon);
            BrowserDriver.Sleep(5000);
            SSC_NameonCard1_Txtbox.Click();
            BrowserDriver.Sleep(2000);
            ReadOnlyCollection<IWebElement> actionlinks = driver.FindElements(By.XPath("//bdi[text()='Actions']"));
            WebHandlers.Instance.Click(actionlinks[1]);
            BrowserDriver.Sleep(8000);
            WebHandlers.Instance.Click(SSC_SendCardtocustomer);
            BrowserDriver.Sleep(3000);
            int status_ribbon = driver.FindElements(SpanSSCText("Request to send card to customer has been sent")).Count;
            //Boolean NewCardStatus = SSC_SendNewCardStatusRibbon.Displayed;
            //Assert.IsTrue(NewCardStatus, "New card is not sent to Customer");
            Assert.IsTrue(status_ribbon > 0, "New card is not sent to Customer");
        }
        //TC_152
        public string ActivateNewCardandValidateinSSC()
        {
            BrowserDriver.Sleep(9000);
            WebHandlers.Instance.Click(SSC_ActivateCard_btn);
            BrowserDriver.Sleep(4000);
           // WebHandlers.Instance.Click(SSCSaveButton);
            //BrowserDriver.Sleep(3000);
            string card_assigned_status = SSC_CardAssigned_Status.Text;
            Assert.IsTrue(card_assigned_status.Equals("Assigned"), "New Card is not Assigned");
            //storing the card number in class level variable
            card_assigned = SSC_RewardCard_Assigned.Text;
            return card_assigned;
        }

        public string FetchCurrentPointsFromSSC(string PointCategory, string UserName)
        {
            string CurrPoint = null;
            //driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            BrowserDriver.Sleep(5000);
            //Rewards Points and details under Reward Data tab
            driver.FindElement(SSCNewTicketSubTabs("Rewards Data")).Click();
            BrowserDriver.Sleep(5000);
            BrowserDriver.Sleep(2000);
            switch (PointCategory)
            {
                case "Rewards Points":
                    CurrPoint = driver.FindElement(SSCUserRewardData(PointCategory)).GetAttribute("innerText");
                    break;

                case "Status Points Balance":
                    CurrPoint = driver.FindElement(SSCUserRewardData(PointCategory)).GetAttribute("innerText");
                    break;

                case "Points to Next Tier":
                    CurrPoint = driver.FindElement(SSCUserRewardData("Points to Next Tier")).GetAttribute("innerText");
                    break;
            }
            //Reward tab changed to New tab, Since Customer Subtab closing not required
            //driver.FindElement(SSCCustomersSubtabClose(UserName)).Click();
            BrowserDriver.Sleep(3000);
            if (CurrPoint.Contains(",")) { CurrPoint = CurrPoint.Replace(",", ""); }
            return CurrPoint;
        }

        public void ValidateExpectedPointsAddedOnSSC(string UserName, string Email, string PointCategory, string ExpectedPoints)
        {

            string CurrPoint = null; int count = 0;
            HomePage homePage = new HomePage(driver);
            if (PointCategory == "Miscellaneous" || PointCategory == "Extend Points")
                PointCategory = "Rewards Points";
            do
            {
                //homePage.NavigateToSSCCustomers();
                //BrowserDriver.Sleep(5000);
                //SSCCustomersSearchEdit.Clear();
                //WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
                //BrowserDriver.Sleep(3000);
                //FetchCDCIdFromSSC(UserName, Email, true);
                //driver.FindElement(SSCCustomersGridData(UserName)).Click();
                //BrowserDriver.PageWait();

                try { SSCCustomersSearchIcon.Click(); }
                catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
                BrowserDriver.Sleep();
                WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
                BrowserDriver.Sleep(3000);
                string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
                driver.FindElement(SSCCustomersGridData(UserName)).Click();
                BrowserDriver.PageWait();
                BrowserDriver.Sleep(3000);

                //driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
                //Rewards Points and details under Reward Data tab
                driver.FindElement(SSCNewTicketSubTabs("Rewards Data")).Click();
                BrowserDriver.Sleep(2000);
                // CurrPoint = driver.FindElement(SSCUserFieldData(PointCategory)).GetAttribute("innerText");
                CurrPoint = driver.FindElement(SSCUserRewardData(PointCategory)).GetAttribute("innerText");
                CurrPoint = CurrPoint.Replace(",", "");
                driver.FindElement(SSCCustomersSubtabClose(UserName)).Click();
                BrowserDriver.Sleep(3000);

                //if (PointCategory == "Points to Next Tier")
                //{
                //    string Rewardpoint = driver.FindElement(SSCUserRewardData("Rewards Points")).GetAttribute("innerText");
                //    Assert.AreEqual(ExpectedPoints, Rewardpoint, PointCategory + " Points not showing as expected on SSC");
                //    BrowserDriver.Sleep(3000);
                //}



                if (CurrPoint == ExpectedPoints)
                        break;
                    count++;
                } while (count < 5);

                Assert.AreEqual(ExpectedPoints, CurrPoint, PointCategory + " Points not showing as expected on SSC");        
        }

        public void ValidatePointsGetTransferedFromPrimary(string PrimaryName, string PrimaryEmail, string PreviousPoints)
        {
            string CurrPoint = null; int count = 0;
            SSC_Customer_Home_Page = new SSCUserHomePage(driver, config);
            SSC_Customers_Page = new SSCCustomersPage(driver, config);

            do
            {
                SSC_Customer_Home_Page.NavigateToSSCCustomers();
                BrowserDriver.Sleep(15000);
                SSC_Customers_Page.FetchCDCIdFromSSC(PrimaryName, PrimaryEmail, true);
                driver.FindElement(SSCNewTicketSubTabs("Rewards Data")).Click();
                BrowserDriver.Sleep(2000);
                CurrPoint = driver.FindElement(SSCUserFieldDatas("Rewards Points")).GetAttribute("innerText");
                driver.FindElement(SSCCustomersSubtabClose(PrimaryName)).Click();
                BrowserDriver.Sleep(3000);

                if (CurrPoint != PreviousPoints)
                    break;
                count++;
            } while (count < 8);

            Assert.AreNotEqual(PreviousPoints, CurrPoint, "Points not get transfered from SSC");
        }

        public string ValidateUserTierGetsUpgradedTo(string UserName, string Email, string ExpectedTier, string ExpectedPoints)
        {
            string CurrPoint = null, CurrTier = null; int count = 0;
            SSC_Customer_Home_Page = new SSCUserHomePage(driver, config);
            SSC_Customers_Page = new SSCCustomersPage(driver, config);

            do
            {
                SSC_Customer_Home_Page.NavigateToSSCCustomers();
                BrowserDriver.Sleep(15000);
                SSC_Customers_Page.FetchCDCIdFromSSC(UserName, Email, true);
                driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
                BrowserDriver.Sleep(10000);
                CurrPoint = driver.FindElement(SSCUserFieldData("Status Points")).GetAttribute("innerText");
                driver.FindElement(SSCCustomersSubtabClose(UserName)).Click();
                BrowserDriver.Sleep(5000);

                if (CurrPoint == ExpectedPoints)
                    break;
                count++;
            } while (count < 15);

            Assert.AreEqual(ExpectedPoints, CurrPoint, "Upgraded points not showing as expected on SSC");
            Assert.AreEqual(ExpectedTier, WebHandlers.Instance.GetAttribute(SSCCustomerTierDetails, "innerHTML"), "SSC - Customer tier details is not showing as expected");
            return WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        }

        public void ProcessSSCTicketAsPerGivenData(string Subject, string PointCategory, string Points)
        {
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            //BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), Subject);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields(PointCategory)), Points);
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Reason"), "Loyalty");
            //SSC_StatusAdjust_Reason.Click();
            BrowserDriver.Sleep(2000);
            //SSC_StatusAdjust_Reason.Clear();
            //SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing" + "\n");
            driver.FindElement(SSCNewTicketFields("Reason")).SendKeys("Loyalty Testing");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);

            //Sending interaction email from ticket
            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
            //WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, Email);
            WebHandlers.Instance.Click(SSCTicketEmailSend);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(6000);
        }

        public string ValidateUserRewardsPointsDetailsOnSSC(string FullName, string Email)
        {
            string CdcId = null; int CurrPoint, count = 0;
            SSC_Customer_Home_Page = new SSCUserHomePage(driver, config);
            SSC_Customers_Page = new SSCCustomersPage(driver, config);

            do
            {
                SSC_Customer_Home_Page.NavigateToSSCCustomers();
                BrowserDriver.Sleep(5000);
                CdcId = SSC_Customers_Page.FetchCDCIdFromSSC(FullName, Email, true);
                driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
                BrowserDriver.Sleep(10000);
                CurrPoint = driver.FindElements(SSCCustomerRewardsPointsValue("5,000")).Count;
                driver.FindElement(SSCCustomersSubtabClose(FullName)).Click();
                BrowserDriver.Sleep(10000);

                if (CurrPoint != 0)
                    break;
                count++;


            } while (count < 15);

            Assert.IsTrue(driver.FindElement(SSCCustomerRewardsPointsValue("5,000")).Displayed, "SSC - Customer rewards point value is not showing as expected");
            return CdcId;
        }

       //TC_23l


        public void ValidatePointstoNextTierAddedOnSSC(string UserName, string Email, string PointCategory, string ExpectedPoints)
        {

            string CurrPoint = null; int count = 0;
            HomePage homePage = new HomePage(driver);
            if (PointCategory == "Points to Next Tier") ;

            do
            {
                //homePage.NavigateToSSCCustomers();
                //BrowserDriver.Sleep(5000);
                //SSCCustomersSearchEdit.Clear();
                //WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
                //BrowserDriver.Sleep(3000);
                //FetchCDCIdFromSSC(UserName, Email, true);
                //driver.FindElement(SSCCustomersGridData(UserName)).Click();
                //BrowserDriver.PageWait();

                try { SSCCustomersSearchIcon.Click(); }
                catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
                BrowserDriver.Sleep();
                WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
                BrowserDriver.Sleep(3000);
                string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
                driver.FindElement(SSCCustomersGridData(UserName)).Click();
                BrowserDriver.PageWait();
                BrowserDriver.Sleep(3000);

                //driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
                //Rewards Points and details under Reward Data tab
                driver.FindElement(SSCNewTicketSubTabs("Rewards Data")).Click();
                BrowserDriver.Sleep(2000);
                // CurrPoint = driver.FindElement(SSCUserFieldData(PointCategory)).GetAttribute("innerText");
                CurrPoint = driver.FindElement(SSCUserRewardData(PointCategory)).GetAttribute("innerText");
                CurrPoint = CurrPoint.Replace(",", "");
                driver.FindElement(SSCCustomersSubtabClose(UserName)).Click();
                BrowserDriver.Sleep(3000);

                if (CurrPoint == ExpectedPoints)
                    break;
                count++;
            } while (count < 5);

            Assert.AreEqual(ExpectedPoints, CurrPoint, PointCategory + " Points not showing as expected on SSC");
        }

        #endregion
    }
}
