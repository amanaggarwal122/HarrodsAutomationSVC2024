using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using TAF_Web.Scripted.Web;
using TechTalk.SpecFlow;


namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCServiceTicketsPage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public SSCServiceTicketsPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements 
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'-searchButton-img')]")]
        private IWebElement SSCCustomersSearchIcon;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'-searchField-I')]")]
        private IWebElement SSCCustomersSearchEdit;
        [FindsBy(How = How.XPath, Using = "//button[@title='Create']")]
        private IWebElement SSCTicketCreateBtn;
        [FindsBy(How = How.XPath, Using = "//button[@title='Create']")]
        private IWebElement SSCSaveBtn;
        [FindsBy(How = How.XPath, Using = "//textarea[@data-role='editor']")]
        private IWebElement SSCNewTicketDescription;
        [FindsBy(How = How.XPath, Using = "//iframe[@class='k-content']")]
        private IWebElement SSCNewTicketEmailFrame;
        [FindsBy(How = How.XPath, Using = "//body[@class='sapClientMRTEBodyFullHeight']//span")]
        private IWebElement SSCNewTicketContentBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save and Open']")]
        private IWebElement SSCNewTicketSaveOpen;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle')][contains(@id,'img')]")]
        private IWebElement SSCDetailsEditIcon;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle_')][@role='presentation']")]
        private IWebElement SSCNewTicketEditIcon;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Summary']/following::input)[1]")]
        private IWebElement SSC_TierChangeSummary;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Target Tier']/following::input[1]")]        
        private IWebElement SSC_Ticket_TargetTierDropdown;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Status']/following::div/../input)[1]")]
        private IWebElement SSC_Status_Dropdown;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Reason']/following::input[1]")]
        private IWebElement SSC_StatusAdjust_Reason;
        [FindsBy(How = How.XPath, Using = "//*[text()='Save']")]
        private IWebElement SSCSaveButton;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Open']")]
        private IWebElement SSC_StatusDropdown_TicketOpen;
        [FindsBy(How = How.XPath, Using = "//*[text()='Transfer Points To']//following::div[4]")]
        private IWebElement TransferPointTofilter;
        [FindsBy(How = How.XPath, Using = "//*[text()='Transfer Points From']//following::div[4]")]
        private IWebElement TransferPointFromfilter;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Actions'][contains(@id,'button')]")]
        private IWebElement SSC_Actions_Btn;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Withdraw from Approval']")]
        private IWebElement SSC_Wihdraw_approval_menu;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Solved']")]
        private IWebElement SSC_StatusDropdown_TicketSolved;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Closed']")]
        private IWebElement SSC_StatusDropdown_TicketClosed;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Subject Details Category']/following::div)[1]")]
        private IWebElement SSC_Customer_SubDetails;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='CDC ID']/following::div/span)[1]")]
        private IWebElement SSC_CdcID;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Customer Tier']/following::div)[1]")]
        private IWebElement SSC_CustomerTier_Status;
        [FindsBy(How = How.XPath, Using = "//iframe[contains(@src,'harrodscalendappcalendapp')]")]
        private IWebElement SSCTicketDetailCalendarFrame;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='New  ']")]
        private IWebElement TenpTicketNewSSC;        
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save']")]
        private IWebElement SSCNewTicketSave;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Send']")]
        private IWebElement SSCTicketEmailSend;
        [FindsBy(How = How.XPath, Using = "//span/bdi[text()='Email']")]
        private IWebElement SSCNewTicketEmailIcon;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'CreateEmail-ToAddressInput-inner')]")]
        private IWebElement SSCNewTicketEmailToAddress;
        [FindsBy(How = How.XPath, Using = "//span[text()='My Tickets']")]
        private IWebElement SSCMyTicketsHeader;
        [FindsBy(How = How.XPath, Using = "//*[text()='Status Points To Be Adjusted']")]
        private IWebElement SSC_StatusPointsLbl;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Cancel ']")]
        private IWebElement TenpTicketCancelSSC;
        [FindsBy(How = How.XPath, Using = "//div[contains(@aria-label,'Booking 10% day')]")]
        private IWebElement SSCBookedDiscountDay;
        [FindsBy(How = How.XPath, Using = "//iframe[contains(@id,'-iframe')][contains(@src,'calendapp')]")]
        private IWebElement SSCCalenderFrame;
        [FindsBy(How = How.XPath, Using = "//*[@id='buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle_1995_1996 - inner']")]
        private IWebElement SSCEditbtn; 
         [FindsBy(How = How.XPath, Using = "//*[@id='__data13']")]
        private IWebElement SSCNewButton;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='New  ']")]
        private IWebElement SSCNewBookingButton;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Cancel ']")]
        private IWebElement SSCDiscountDayCancellButton;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'button-content')]/bdi[text()='Actions']")]
        private IWebElement SSCTicketsActions;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Withdraw from Approval']")]
        private IWebElement SSCTicketsActionsWithdrawApproval;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'inputfield3fa290bb8e1a22fe0d86afd4640e1bc8')]")]
        private IWebElement SSCCustomerCDCID;
        [FindsBy(How = How.XPath, Using = "//a[@title='Tickets']")]
        private IWebElement SSCNavTickets;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='New']")]
        private IWebElement SSCCreateNewTicketButton;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Add'][contains(@id,'buttontdiGV')]")]
        private IWebElement SSCTicketsAttachmentAddBtn;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Rewards Points']/following::input[1]")]
        private IWebElement SSC_Ticket_RewardsPoints;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Status Points']/following::input[1]")]
        private IWebElement SSC_Ticket_StatusPoints;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Status Points To Be Adjusted']/following::input[1]")]
        private IWebElement SSC_Ticket_AdjustStatusPoints;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Status']/following::div/span)[1]")]
        private IWebElement SSC_Approval_Status;
        [FindsBy(How = How.XPath, Using = "//span[text()='Solved']")]
        private IWebElement SSCNewTicketSolved;
        #endregion

        public By SSCSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }
        public By SSCNewTicketFields(string FieldLabel) { return By.XPath("(//bdi[text()='" + FieldLabel + "']/following::input)[1]"); }
        public By SSCNewEmailIconFields(string FieldLabel)
        {
            return By.XPath("//span/bdi[text()='" + FieldLabel + "']");
        }
                
        public By SSCNewTicketSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }
        public By SSCInputFieldValue(string text) { return By.XPath("//input[@value='" + text + "']"); }
        public By TenpTicketAvailDateSSC(string AvailDate) { return By.XPath("//div[@aria-label='" + AvailDate + "']/span"); }
        public By SpanSSCText(string text) { return By.XPath("//span[contains(text(),'" + text + "')]"); }
        public By SSCNavAdminServiceTree { get => By.XPath("//span[@title='Service']"); }
        public By SSCCustomersGridData(string text) { return By.XPath("//a[text()='" + text + "']"); }
        public By SSCBdiGridValue(string Text) { return By.XPath("//bdi[text()='" + Text + "']"); }
        #region Events

        public void CreateNewSSCServiceTicket()
        {
            WebHandlers.Instance.Click(SSCTicketCreateBtn);
            BrowserDriver.Sleep(3000);
        }

        
        // public void SSCSaveBtn()
        //{
        //    WebHandlers.Instance.Click(SSCSaveBtn);
        //    BrowserDriver.Sleep(3000);
        //}
        public void NavigateToSSC_Service()
        {
            if (driver.FindElements(SSCNavAdminServiceTree).Count != 0)
            {
                driver.FindElement(SSCNavAdminServiceTree).Click();

            }
            BrowserDriver.Sleep(2000);
        }

        public void NavigateToSSC_Service_To_Ticket()
        {

            //driver.FindElement(SSC_Nav_Tickets).Click();
            BrowserDriver.Sleep(5000);
            WebWaitHelper.Instance.WaitForElementPresence(SSCNavTickets);
            WebHandlers.Instance.ClickByJsExecutor(SSCNavTickets);
            BrowserDriver.Sleep(3000);
        }


        public void PerformSSCEditTicket()
        {
            BrowserDriver.Sleep(4000);
            WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
        }

        public void CreateEnquiryTicket_SSCService(Dictionary<string, string> CustomerTicketData)
        {
            WebHandlers.Instance.WaitForPageLoad();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
            BrowserDriver.Sleep(4000);
            //driver.FindElement(SSCNewTicketFields("Type")).Clear();
            if (!CustomerTicketData["Type"].Equals("General"))
            {
                WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Type"), CustomerTicketData["Type"]);
            }
            BrowserDriver.Sleep(3000);
            //driver.FindElement(SSCNewTicketFields("Type")).SendKeys(CustomerTicketData["Type"]);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), CustomerTicketData["Source"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), CustomerTicketData["IndividualCustomer"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), CustomerTicketData["Subject"]);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), CustomerTicketData["ContactCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), CustomerTicketData["SubjectCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), CustomerTicketData["SubjectDetailsCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Item Category")), CustomerTicketData["ItemCategory"]);
            BrowserDriver.Sleep(2000);

            driver.FindElement(SSCNewTicketFields("Team")).Clear();
            driver.FindElement(SSCNewTicketFields("Team")).SendKeys(CustomerTicketData["Team"]);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Business Area")).SendKeys(CustomerTicketData["BusinessArea"] + "\n");
            BrowserDriver.Sleep(3000);
            //Performing ticket Save and close
            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    " + CustomerTicketData["Subject"]).DoubleClick().Build().Perform();
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(4000);
            //WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            driver.FindElement(SSCNewTicketFields("Brand")).Click();
            driver.FindElement(SSCNewTicketFields("Brand")).SendKeys(CustomerTicketData["Brand"]);

            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Business Area")), CustomerTicketData["BusinessArea"]);
            //WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Business Area")));
            
            BrowserDriver.GetDriver().SwitchTo().DefaultContent();
            //  WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Fulfillment point")), CustomerTicketData["FulfillmentPoint"]);
            driver.FindElement(SSCNewTicketFields("Fulfillment point")).SendKeys(CustomerTicketData["FulfillmentPoint"]);
            BrowserDriver.Sleep(3000);

            // WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Online Division")), CustomerTicketData["OnlineDivision"]);
            driver.FindElement(SSCNewTicketFields("Online Division")).SendKeys(CustomerTicketData["OnlineDivision"]);
            BrowserDriver.Sleep(3000);

            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), CustomerTicketData["Source"]);
            driver.FindElement(SSCNewTicketFields("Source")).Clear();
            driver.FindElement(SSCNewTicketFields("Source")).SendKeys(CustomerTicketData["Source"]);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Subject")).SendKeys(CustomerTicketData["Subject"]);
            BrowserDriver.Sleep(2000);
            SSCNewTicketSaveOpen.Click();
            BrowserDriver.Sleep(6000);

        }

        public void EditInquiryTicket()
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCDetailsEditIcon);
        }

        public void ChangeTier(string tier)
        {
            BrowserDriver.Sleep(5000);
            //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(3000);
            SSCNewTicketEditIcon.Click();
            BrowserDriver.Sleep(5000);
            SSC_TierChangeSummary.SendKeys("Automated Tier Upgrade");
            //WebWaitHelper.Instance.WaitForElementPresence(SSC_Ticket_TargetTierDropdown,TimeSpan.FromSeconds(120));
            driver.SwitchTo().DefaultContent();
            //driver.FindElement(By.XPath("//*[text()='Rewards']")).Click();
            WebHandlers.Instance.Click(SSC_Ticket_TargetTierDropdown);
            //WebHandlers.Instance.EnterText(SSC_Ticket_TargetTierDropdown, tier);
            SSC_Ticket_TargetTierDropdown.SendKeys(tier);
            BrowserDriver.Sleep(3000);
            //SSC_Ticket_TargetTierDropdown.SendKeys(Keys.Tab);           

        }

        public void ChangeTierfromGreen(string tier)
        {
            Actions actions = new Actions(driver);
            driver.Navigate().Refresh();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEditIcon);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementToBeClickable(SSCNewTicketEditIcon));
            try
            {
                BrowserDriver.Sleep(3000);
                actions.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
                //SSCNewTicketEditIcon.Click();
            }
            catch (StaleElementReferenceException)
            {
                // driver.Navigate().Refresh();
                BrowserDriver.Sleep(4000);
                actions.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
                //SSCNewTicketEditIcon.Click();
            }

            BrowserDriver.Sleep(3000);
            try
            {
                SSC_Status_Dropdown.Clear();
                SSC_Status_Dropdown.SendKeys("Open" + "\n");
                BrowserDriver.Sleep(3000);
                //driver.FindElement(SSCNewTicketFields("Assigned to")).SendKeys("Anusree Nair");
                //BrowserDriver.Sleep(3000);

                SSC_TierChangeSummary.SendKeys("Test Summary");
                BrowserDriver.Sleep(2000);
            }
            catch (NoSuchElementException)
            {
                BrowserDriver.Sleep(2000);
                SSCNewTicketEditIcon.Click();
                BrowserDriver.Sleep(4000);
                SSC_Status_Dropdown.Clear();
                SSC_Status_Dropdown.SendKeys("Open" + "\n");
                BrowserDriver.Sleep(3000);
                //driver.FindElement(SSCNewTicketFields("Assigned to")).SendKeys("Anusree Nair");
                //BrowserDriver.Sleep(3000);
                SSC_TierChangeSummary.SendKeys("Test Summary");
                BrowserDriver.Sleep(2000);
            }
            SSC_Ticket_TargetTierDropdown.Clear();
            BrowserDriver.Sleep(2000);
            SSC_Ticket_TargetTierDropdown.SendKeys(tier + "\n");
            BrowserDriver.Sleep(2000);
            try
            {
                //actions.MoveToElement(driver.FindElement(By.XPath("//*[text()='Status Points To Be Adjusted']"))).Build().Perform();
                driver.FindElement(By.XPath("//*[text()='Status Points To Be Adjusted']")).Click();
                BrowserDriver.Sleep(3000);
            }
            catch (ElementClickInterceptedException)
            {
                string statuspoints = driver.FindElement(By.XPath("//*[text()='Status Points To Be Adjusted']/following::input[1]")).Text;
                BrowserDriver.Sleep(3000);
            }
            catch (StaleElementReferenceException)
            {
                string statuspoints = driver.FindElement(By.XPath("//*[text()='Status Points To Be Adjusted']/following::input[1]")).Text;
                BrowserDriver.Sleep(3000);
            }
            //WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(By.XPath("//*[text()='Status Points To Be Adjusted']"))); 

            //WebWaitHelper.Instance.WaitForElementPresence(SSC_StatusAdjust_Reason);
            //SSC_StatusAdjust_Reason.Clear();
            //SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing");
            //BrowserDriver.Sleep(3000);


        }

        public void GestureSelection()
        {
            try
            {
                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Single/Multiple")), "Single");
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Goodwill Type")), "Dining Experience Vouchers");
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Dining Voucher Value")), "£15 - Complimentary Hot Beverage & Dessert for 2 in Harrods Café");
                BrowserDriver.Sleep(3000);
            }
            catch (NoSuchElementException)
            {

            }

            BrowserDriver.Sleep(3000);
            Actions ContentAction = new Actions(driver);
            //BrowserDriver.Sleep(2000);
            //WebWaitHelper.Instance.WaitForElement(SSC_StatusAdjust_Reason);
            //SSC_StatusAdjust_Reason.Click();
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().SendKeys("    Loyalty Testing" + "\n").DoubleClick().Build().Perform();

            BrowserDriver.Sleep(4000);
            SSC_StatusAdjust_Reason.Clear();
            SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing" + "\n");

            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCSaveButton);
        }

        public void ChangeTicketStatustoOpen()
        {
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(4000);
            //driver.Navigate().Refresh();
            WebWaitHelper.Instance.WaitForElementPresence(SSCDetailsEditIcon);
            //WebHandlers.Instance.Click(SSCDetailsEditIcon);
            SSCDetailsEditIcon.Click();
            //ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
            BrowserDriver.Sleep(3000);
            try
            {
                //SSC_Status_Dropdown.Clear();
                //SSC_Status_Dropdown.SendKeys("Solved" + "\n");
                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                //SSC_StatusDropdownBtn.Click();
                BrowserDriver.Sleep(1000);
                SSC_StatusDropdown_TicketOpen.Click();
                BrowserDriver.Sleep(1000);
            }
            catch (Exception e)
            {
                BrowserDriver.Sleep(4000);
                try
                {
                    ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
                }
                catch (Exception f)
                {

                }
                BrowserDriver.Sleep(3000);

                try
                {
                    SSC_Actions_Btn.Click();
                    BrowserDriver.Sleep(2000);
                    SSC_Wihdraw_approval_menu.Click();
                    BrowserDriver.Sleep(4000);
                    //SSC_Status_Dropdown.Clear();
                    //SSC_Status_Dropdown.SendKeys("Solved" + "\n");
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketOpen.Click();
                    BrowserDriver.Sleep(1000);
                    //}
                }
                catch (Exception g)
                {
                    BrowserDriver.Sleep(4000);

                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketOpen.Click();
                    BrowserDriver.Sleep(1000);
                }
            }

            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCSaveButton);
        }

        public void ChangeTicketStatustoSolved()
        {
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(2000);
            //driver.Navigate().Refresh();
            WebWaitHelper.Instance.WaitForElementPresence(SSCDetailsEditIcon);
            //WebHandlers.Instance.Click(SSCDetailsEditIcon);
            SSCDetailsEditIcon.Click();
            //ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
            BrowserDriver.Sleep(3000);
            try
            {
                //SSC_Status_Dropdown.Clear();
                //SSC_Status_Dropdown.SendKeys("Solved" + "\n");
                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                //SSC_StatusDropdownBtn.Click();
                BrowserDriver.Sleep(1000);
                SSC_StatusDropdown_TicketSolved.Click();
                BrowserDriver.Sleep(1000);
            }
            catch (Exception e)
            {
                BrowserDriver.Sleep(4000);
                try
                {
                    ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
                }
                catch (Exception f)
                {

                }
                BrowserDriver.Sleep(3000);
                //  if (SSC_Lock_BarMessage.Displayed || SSC_Status_Dropdown.GetAttribute("readonly").Equals("readonly"))
                // {
                try
                {
                    SSC_Actions_Btn.Click();
                    BrowserDriver.Sleep(2000);
                    SSC_Wihdraw_approval_menu.Click();
                    BrowserDriver.Sleep(4000);
                    //SSC_Status_Dropdown.Clear();
                    //SSC_Status_Dropdown.SendKeys("Solved" + "\n");
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketSolved.Click();
                    BrowserDriver.Sleep(1000);
                    //}
                }
                catch (Exception g)
                {
                    BrowserDriver.Sleep(4000);
                    //SSC_Status_Dropdown.Clear();
                    //SSC_Status_Dropdown.SendKeys("Solved" + "\n"); 
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketSolved.Click();
                    BrowserDriver.Sleep(1000);
                }
            }


            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //string title = (string)js.ExecuteScript("arguments[0].value = 'Solved'", SSC_Status_Dropdown);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCSaveButton);
        }
        public void ChangeTicketStatustoClosed()
        {
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(4000);
            try
            {
                ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
                //SSC_Status_Dropdown.Clear();
                //SSC_Status_Dropdown.SendKeys("Closed" + "\n");
                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                //SSC_StatusDropdownBtn.Click();
                BrowserDriver.Sleep(5000);
                SSC_StatusDropdown_TicketClosed.Click();
                BrowserDriver.Sleep(2000);
            }
            catch (Exception e)
            {
                try
                {
                    ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
                    //SSC_Status_Dropdown.Clear();
                    //SSC_Status_Dropdown.SendKeys("Closed" + "\n");
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(5000);
                    SSC_StatusDropdown_TicketClosed.Click();
                    BrowserDriver.Sleep(3000);
                }
                catch (Exception w)
                {
                    BrowserDriver.Sleep(2000);
                    //ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
                    BrowserDriver.Sleep(2000);
                    //SSC_Status_Dropdown.Clear();
                    //SSC_Status_Dropdown.SendKeys("Closed" + "\n");
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(5000);
                    SSC_StatusDropdown_TicketClosed.Click();
                    BrowserDriver.Sleep(1000);
                }
            }
            //BrowserDriver.Sleep(2000);
            //try
            //{

            //    SSC_Status_Dropdown.Clear();
            //    SSC_Status_Dropdown.SendKeys("Closed" + "\n");
            //}
            //catch (Exception e)
            //{
            //    BrowserDriver.Sleep(2000);              
            //    ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
            //    BrowserDriver.Sleep(2000);
            //    SSC_Status_Dropdown.Clear();
            //    SSC_Status_Dropdown.SendKeys("Closed" + "\n");
            //}

            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(SSCSaveButton);
        }

        public void ClickTicketCancelButton()
        {
            try
            {
                driver.FindElement(By.XPath("//*[text()='Cancel']")).Click();
            }
            catch (Exception e)
            {

            }
        }

        public string ValidateCustomerTierinTicketScreen(ScenarioContext scenarioContext)
        {
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            BrowserDriver.Sleep(4000);
            string CustomerTier = WebHandlers.Instance.GetTextOfElement(SSC_Customer_SubDetails);
            string Cdcid = WebHandlers.Instance.GetTextOfElement(SSC_CdcID);
            //scenarioContext.Add("UserCDCId", SSC_CdcID);

            //Assert.IsTrue(CustomerTier.Equals("10% Nominated Day"), "Customer Subject Details is not displayed as 10% Nominated day");
            Assert.IsTrue(CustomerTier.Equals("Manual tier upgrade"), "Customer Subject Details is not displayed as Manual tier upgrade");
            return Cdcid;
        }

        public string ValidateCustomerSubjectDetailsinTicketScreen(ScenarioContext scenarioContext)
        {

            BrowserDriver.Sleep(2000);
            string CustomerTier = WebHandlers.Instance.GetTextOfElement(SSC_CustomerTier_Status);
            string Cdcid = WebHandlers.Instance.GetTextOfElement(SSC_CdcID);
            //scenarioContext.Add("UserCDCId", SSC_CdcID);

            //Assert.IsTrue(CustomerTier.Equals("Gold"), "Customer Tier is not displayed as Gold");
            return Cdcid;
        }

        public void CreateTenpDayBookingTicket(string UserName, string Email, string FirstName)
        {
            //Creating manual tier upgrade ticket
            //WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCTicketCreateBtn);
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
            WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Type"), "General");
            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), "Online Fulfillment");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), UserName);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "10% Nominated Day");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), "Enquiry");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), "G3-A08");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), "G4-AH13");
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");
            BrowserDriver.Sleep(2000);

            //Performing ticket Save and close
            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    10% Nominated Day").DoubleClick().Build().Perform();
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            BrowserDriver.Sleep(4000);
            SSCNewTicketSaveOpen.Click();
            BrowserDriver.Sleep(6000);

            //Selecting an available day for 10p
            WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketSubTabs("Manage 10% Day Booking")).Click();
            WebHandlers.Instance.SwitchToFrame(SSCTicketDetailCalendarFrame);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.WebElementExists(driver.FindElement(SSCInputFieldValue(FirstName)));
            BrowserDriver.Sleep(6000);
            driver.FindElement(TenpTicketAvailDateSSC(DateTime.Now.ToString("MMMM 30, yyyy"))).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(TenpTicketNewSSC);
            WebHandlers.Instance.WebElementExists(TenpTicketCancelSSC);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(TenpTicketCancelSSC);
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCNewTicketSave);
            WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
        }

        public void CreateTicketForPointAddition(string UserName, string Email)
        {
            //Creating manual tier upgrade ticket
            WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCTicketCreateBtn);
            //SSCTicketCreateBtn.Click();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
            WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Type"), "General");
            WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Source"), "Online Fulfillment");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), UserName);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "Ticket for rewards point addition");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), "Enquiry");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), "G3-A08");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), "G4-AH01");
            BrowserDriver.Sleep(2000);

            //Performing ticket Save and close
            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    PointAdd").DoubleClick().Build().Perform();
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            BrowserDriver.Sleep(4000);
            SSCNewTicketSaveOpen.Click();
            BrowserDriver.Sleep(6000);

            //Changing ticket status and target tier details
            try
            {
                WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
                WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
            }
            catch
            {
                WebHandlers.Instance.Click(SSCNewTicketEditIcon); BrowserDriver.Sleep(2000);
                WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
            }
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "PointsAdd");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Rewards Points To Be Adjusted")), "5000");
            WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Reason"), "Loyalty");

            //Sending interaction email from ticket
            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
            WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, Email);
            WebHandlers.Instance.Click(SSCTicketEmailSend);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(SSCNewTicketSave);
            WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(6000);

            //Changing ticket status to solved
            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
            WebHandlers.Instance.Click(SSCNewTicketSave);
            WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(4000);

            if (driver.FindElements(SpanSSCText("Solved")).Count == 0)
            {
                WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
                BrowserDriver.Sleep(1000);
                WebHandlers.Instance.Click(SSCNewTicketSave);
                WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
                BrowserDriver.Sleep(6000);
            }
        }
        //TC_229
        public void CreateTicketForTierUpgrade(string UserName, string Email, string TargetTier)
        {
            //Creating manual tier upgrade ticket
            WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCTicketCreateBtn);
            //SSCTicketCreateBtn.Click();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
            WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Type"), "General");
            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), "Online Fulfillment");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), UserName);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "Ticket for customer tier upgrade");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), "Complaint");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), "G3-B09");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), "G4-BI03");
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Team")).Clear();
            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");
            BrowserDriver.Sleep(90000);
            // Scroll down by 1000 pixels
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 1000);");
            //Performing ticket Save and close
            //WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
            //BrowserDriver.Sleep(6000);
            //Actions ContentAction = new Actions(driver);
            //ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    TierUpgrade").DoubleClick().Build().Perform();
            //WebHandlers.Instance.SwithBackFromFrame();

            //// To handle Description textbox

            // Switch to the frame
            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);

            // Explicit wait for the content box to be visible and enabled
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IWebElement contentBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SSCNewTicketContentBox));

            if (contentBox != null)
            {
                // Initialize Actions class
                Actions contentAction = new Actions(driver);

                // Move to the content box and perform actions
                contentAction.MoveToElement(contentBox)
                    .Click()
                    .SendKeys("    TierUpgrade")
                    .DoubleClick()
                    .Build()
                    .Perform();
            }
            else
            {
                Console.WriteLine("ContentBox element not found");
            }
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            BrowserDriver.Sleep(4000);
            driver.FindElement(SSCNewTicketFields("Source")).Clear();
            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), "Online Fulfillment");
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Subject")).Clear();
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "Ticket for customer tier upgrade");
            SSCNewTicketSaveOpen.Click();
            BrowserDriver.Sleep(8000);

            //Changing ticket status and target tier details
            WebHandlers.Instance.WaitForPageLoad();
            //WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(2000);
            try
            {
                WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open" + "\n");
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
                BrowserDriver.Sleep(2000);
            }

            catch
            {
                WebHandlers.Instance.Click(SSCNewTicketEditIcon); BrowserDriver.Sleep(2000);
                WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open" + "\n");
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
                BrowserDriver.Sleep(2000);
            }
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "ManualUpgrade");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Target Tier"), TargetTier);


            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Reason"), "Loyalty");
            SSC_StatusPointsLbl.Click();
            BrowserDriver.Sleep(3000);
            SSC_StatusAdjust_Reason.Click();
            // ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().SendKeys("    Loyalty Testing" + "\n").DoubleClick().Build().Perform();

            BrowserDriver.Sleep(2000);
            SSC_StatusAdjust_Reason.Clear();
            SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing" + "\n");

            BrowserDriver.Sleep(3000);

            //Sending interaction email from ticket
            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, Email);
            WebHandlers.Instance.Click(SSCTicketEmailSend);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(SSCNewTicketSave);
            WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(6000);

            //Changing ticket status to solved
            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            BrowserDriver.Sleep(6000);
            try
            {
                BrowserDriver.Sleep(6000);
                WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Solved");
                BrowserDriver.Sleep(6000);
            }
            catch (Exception g)
            {
                try
                {
                    BrowserDriver.Sleep(6000);
                    SSC_Actions_Btn.Click();
                    BrowserDriver.Sleep(4000);
                    SSC_Wihdraw_approval_menu.Click();
                    BrowserDriver.Sleep(6000);
                    SSC_Status_Dropdown.Clear();
                    SSC_Status_Dropdown.SendKeys("Solved" + "\n");
                    //}
                }
                catch (Exception e)
                {
                    BrowserDriver.Sleep(6000);
                    SSC_Status_Dropdown.Clear();
                    SSC_Status_Dropdown.SendKeys("Solved" + "\n");
                }
            }
            WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(60000);
            ChangeTicketStatustoClosed();
            //WebHandlers.Instance.Click(SSCNewTicketSave);
        }

        public void CreateTicketForTierUpgrade(string UserName, string Email)
        {
            //Creating manual tier upgrade ticket
            WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCTicketCreateBtn);
            //SSCTicketCreateBtn.Click();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
            WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Type"), "General");
            WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Source"), "Online Fulfillment");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), UserName);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "Ticket for customer tier upgrade");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), "Complaint");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), "G3-B09");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), "G4-BI03");
            BrowserDriver.Sleep(2000);

            //Performing ticket Save and close
            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    TierUpgrade").DoubleClick().Build().Perform();
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            BrowserDriver.Sleep(4000);
            SSCNewTicketSaveOpen.Click();
            BrowserDriver.Sleep(8000);

            //Changing ticket status and target tier details
            try
            {
                WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
                WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
            }
            catch
            {
                WebHandlers.Instance.Click(SSCNewTicketEditIcon); BrowserDriver.Sleep(2000);
                WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
            }
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "ManualUpgrade");
            WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Target Tier"), "Black");
            WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Reason"), "Loyalty");

            //Sending interaction email from ticket
            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
            WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, Email);
            WebHandlers.Instance.Click(SSCTicketEmailSend);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(SSCNewTicketSave);
            WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(6000);

            //Changing ticket status to solved
            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
            WebHandlers.Instance.Click(SSCNewTicketSave);
            WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(4000);

            if (driver.FindElements(SpanSSCText("Solved")).Count == 0)
            {
                WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
                BrowserDriver.Sleep(1000);
                WebHandlers.Instance.Click(SSCNewTicketSave);
                WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
                BrowserDriver.Sleep(6000);
            }
        }

        public void createNewTicketfor10PCancellation(string UserName, string Email)
        {
            //Creating manual tier upgrade ticket
            //WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Tickets")));
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='New']")));
            BrowserDriver.Sleep(4000);
            // WebHandlers.Instance.Click(SSCTicketCreateBtn);
            //SSCTicketCreateBtn.Click();
           // WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
            //WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Type"), "General");
            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), "Online");


           // driver.FindElement(SSCNewTicketFields("Type")).Clear();
           BrowserDriver.Sleep(5000);
           // driver.FindElement(SSCNewTicketFields("Type")).SendKeys("General");
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), "Online Fulfillment");
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), UserName);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "Ticket for 10p cancellation");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), "Enquiry");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), "Rewards");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), "10% Nominated Day");
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Team")).Clear();
            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");
            BrowserDriver.Sleep(9000);

            // Scroll down by 1000 pixels
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 1000);");
            BrowserDriver.Sleep(2000);
            //Performing ticket Save and close
            //WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
            //BrowserDriver.Sleep(10000);
            //Actions ContentAction = new Actions(driver);
            //BrowserDriver.Sleep(10000);
            ////(SSCNewTicketContentBox).Click();
            ////BrowserDriver.Sleep(2000);
            //ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("  Description- 10PCancel").DoubleClick().Build().Perform();

            //// To handle Description textbox

            // Switch to the frame
            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);

            // Explicit wait for the content box to be visible and enabled
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IWebElement contentBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SSCNewTicketContentBox));

            if (contentBox != null)
            {
                // Initialize Actions class
                Actions contentAction = new Actions(driver);

                // Move to the content box and perform actions
                contentAction.MoveToElement(contentBox)
                    .Click()
                    .SendKeys("  Description- 10PCancel")
                    .DoubleClick()
                    .Build()
                    .Perform();
            }
            else
            {
                Console.WriteLine("ContentBox element not found");
            }
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            BrowserDriver.Sleep(4000);
            SSCNewTicketSaveOpen.Click();
            BrowserDriver.Sleep(6000);
            BrowserDriver.PageWait();
            //Changing ticket status and target tier details
            //WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);

            //try { WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open");

            //}
            //catch
            //{
            //    WebHandlers.Instance.Click(SSCNewTicketEditIcon); BrowserDriver.Sleep(2000);
            //    WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open");                
            //}
           // try
           // {
            //    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
            //    //SSC_StatusDropdownBtn.Click();
            //    BrowserDriver.Sleep(1000);
            //    SSC_StatusDropdown_TicketOpen.Click();
            //    BrowserDriver.Sleep(1000);
            //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
           // }
            //catch
            {
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                BrowserDriver.Sleep(2000);
                //SSC_StatusDropdownBtn.Click();
                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                BrowserDriver.Sleep(1000);
                SSC_StatusDropdown_TicketOpen.Click();
                BrowserDriver.Sleep(1000);
                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            }


            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "10 p cancel");
            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Reason"), "Loyalty");
            //SSC_StatusAdjust_Reason.Click();
            BrowserDriver.Sleep(2000);
            //SSC_StatusAdjust_Reason.Clear();
            //SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing" + "\n");
            driver.FindElement(SSCNewTicketFields("Reason")).SendKeys("Loyalty Testing");

            //Sending interaction email from ticket
            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, Email);
            WebHandlers.Instance.Click(SSCTicketEmailSend);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(6000);

            //Cancel the booked slot 
            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketSubTabs("Manage 10% Day Booking")), "Clicked on Manage Booking");
            BrowserDriver.Sleep(9000);
            WebHandlers.Instance.SwitchToFrame(SSCCalenderFrame);
            Actions action = new Actions(driver);
            //BrowserDriver.Sleep(2000);
            //action.MoveToElement(SSCBookedDiscountDay).Click().Build().Perform();
            //Console.WriteLine("Aria label --" + SSCBookedDiscountDay.GetAttribute("aria-label"));
            //string dmy = convertStringToDate(SSCBookedDiscountDay.GetAttribute("aria-label"));
            //Console.WriteLine("Discount day --" + dmy);
            //BrowserDriver.Sleep(5000);
            //SSCEditbtn.Click();
            //SSCNewButton.Click();
           //// Xpath change for New button click
            SSCNewBookingButton.Click();
            BrowserDriver.Sleep(4000);
            SSCDiscountDayCancellButton.Click();
            BrowserDriver.Sleep(9000);
            WebHandlers.Instance.SwithBackFromFrame();

            //Changing ticket status to solved
            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
            //SSC_StatusDropdownBtn.Click();
            BrowserDriver.Sleep(3000);
            SSC_StatusDropdown_TicketSolved.Click();
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Solved");
            WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(4000);
        }

        public string FetchDay2slotdate()
        {
            string day2slot = "";
            return day2slot;
        }

        public string CreateTicketForBonusPointAddition(string UserName, string Email)
        {
            WebHandlers.Instance.WaitForPageLoad();
            BrowserDriver.Sleep(4000);
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

            driver.FindElement(SSCCustomersGridData(UserName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);
            //Creating manual tier upgrade ticket
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Tickets")));
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='New']")));
            BrowserDriver.Sleep(4000);
            // WebHandlers.Instance.Click(SSCTicketCreateBtn);
            //SSCTicketCreateBtn.Click();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
            WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Type"), "General");
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), "Online Fulfillment");
            BrowserDriver.Sleep(1000);

            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "Ticket for Add bonus point");
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), "Enquiry");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), "Rewards");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), "Bonus points");
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");
            BrowserDriver.Sleep(2000);

            //Performing ticket Save and close
            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    BonusPointAdd").DoubleClick().Build().Perform();
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            BrowserDriver.Sleep(4000);
            SSCNewTicketSaveOpen.Click();
            BrowserDriver.Sleep(6000);

            //Changing ticket status and target tier details
            //WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
            WebHandlers.Instance.WaitForPageLoad();
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(2000);
            try
            {
                WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open");
                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            }
            catch
            {
                WebHandlers.Instance.Click(SSCNewTicketEditIcon); BrowserDriver.Sleep(2000);
                WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open");
                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            }
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "BonusAdd");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Bonus Points To Be Adjusted")), "5000");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Reason"), "Points");
            BrowserDriver.Sleep(2000);

            //Sending interaction email from ticket
            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
            WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, Email);
            WebHandlers.Instance.Click(SSCTicketEmailSend);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(6000);

            //Changing ticket status to solved
            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Solved");
            WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(4000);
            return CdcId;
        }
        public string CreateTicketForPartnerPointAddition(string UserName, string Email)
        {
            WebHandlers.Instance.WaitForPageLoad();
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

            driver.FindElement(SSCCustomersGridData(UserName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);
            //Creating manual tier upgrade ticket
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Tickets")));
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='New']")));
            BrowserDriver.Sleep(4000);
            // WebHandlers.Instance.Click(SSCTicketCreateBtn);
            //SSCTicketCreateBtn.Click();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
            //WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Type"), "General");
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), "Online Fulfillment");
            BrowserDriver.Sleep(1000);

            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "City Bank point");
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), "Enquiry");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), "Rewards");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), "Citibank Partner Points");
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");
            BrowserDriver.Sleep(2000);

            //Performing ticket Save and close
            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    Award city bank points").DoubleClick().Build().Perform();
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            BrowserDriver.Sleep(4000);
            SSCNewTicketSaveOpen.Click();
            BrowserDriver.Sleep(6000);

            //Changing ticket status and target tier details
            WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(2000);
            try { WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open"); }
            catch
            {
                WebHandlers.Instance.Click(SSCNewTicketEditIcon); BrowserDriver.Sleep(2000);
                WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open");
            }
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "City banks points add");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Rewards Points To Be Adjusted")), "5000");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Reason"), "CitiBank");
            BrowserDriver.Sleep(2000);

            //Sending interaction email from ticket
            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
            WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, Email);
            WebHandlers.Instance.Click(SSCTicketEmailSend);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(6000);

            //Changing ticket status to solved
            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Solved");
            WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(4000);
            return CdcId;

        }

        public void CreateSSCTicketAsPerGivenData_Duplicate(Dictionary<string, string> SSCTicketData)
        {
            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Tickets")));
            WebHandlers.Instance.WebElementExists(SSCCreateNewTicketButton);
            WebHandlers.Instance.Click(SSCCreateNewTicketButton);
            WebHandlers.Instance.WebElementExists(SSCNewTicketDescription);
            BrowserDriver.Sleep(4000);
            WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Type"), SSCTicketData["Type"]);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Source"), SSCTicketData["Source"]);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), SSCTicketData["ContactCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), SSCTicketData["SubCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), SSCTicketData["SubDetailCategory"]);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");

            //Performing ticket Save and close
            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    " + SSCTicketData["Subject"]).DoubleClick().Build().Perform();
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            BrowserDriver.Sleep(3000);
            SSCNewTicketSaveOpen.Click();
            BrowserDriver.Sleep(6000);
        }

        public void CreateSSCTicketAsPerGivenData(Dictionary<string, string> SSCTicketData)
        {
            Actions ContentAction = new Actions(driver);
            //Navigating to Tickets
            HomePage homePage = new HomePage(driver);
            NavigateToSSC_Service();
            BrowserDriver.Sleep(3000);
            NavigateToSSC_Service_To_Ticket();
            BrowserDriver.Sleep(3000);
            //Creating manual tier upgrade ticket
            try { WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader); }
            catch { NavigateToSSC_Service_To_Ticket(); }
            BrowserDriver.Sleep(5000);

            //SSCTicketCreateBtn.Click();
            WebHandlers.Instance.Click(SSCTicketCreateBtn);
            BrowserDriver.Sleep(6000);
            //Type selected by default in the application
            //WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
            //WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
            BrowserDriver.Sleep(3000);
            //driver.FindElement(SSCNewTicketFields("Type")).Clear();
            //driver.FindElement(SSCNewTicketFields("Type")).SendKeys(SSCTicketData["Type"]);
            BrowserDriver.Sleep(3000);

            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), SSCTicketData["UserName"]);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), SSCTicketData["ContactCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), SSCTicketData["SubCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), SSCTicketData["SubDetailCategory"]);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Team")).Clear();
            driver.FindElement(SSCNewTicketFields("Team")).SendKeys(SSCTicketData["Team"]);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            BrowserDriver.Sleep(6000);
            //Performing ticket Save and close
            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);

            //BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    " + SSCTicketData["Subject"]).DoubleClick().Build().Perform();
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);

            driver.FindElement(SSCNewTicketFields("Source")).Clear();
            driver.FindElement(SSCNewTicketFields("Source")).SendKeys(SSCTicketData["Source"]);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Subject")).Clear();
            driver.FindElement(SSCNewTicketFields("Subject")).SendKeys(SSCTicketData["Subject"]);
            BrowserDriver.Sleep(2000);
            SSCNewTicketSaveOpen.Click();
            BrowserDriver.Sleep(10000);

            //Changing ticket status and target tier details
            WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(2000);
            try
            {
                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                BrowserDriver.Sleep(1000);
                SSC_StatusDropdown_TicketOpen.Click();
                BrowserDriver.Sleep(1000);
            }
            catch
            {
                WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                BrowserDriver.Sleep(1000);
                SSC_StatusDropdown_TicketOpen.Click();
                BrowserDriver.Sleep(3000);
            }
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();

            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), SSCTicketData["Subject"]);
            //driver.FindElement(SSCNewTicketFields("Summary")).SendKeys(SSCTicketData["Subject"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), SSCTicketData["Subject"]);
            BrowserDriver.Sleep(2000);
            BrowserDriver.Sleep(3000);
           driver.FindElement(SSCNewTicketFields(SSCTicketData["FieldName"])).Clear();
           WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields(SSCTicketData["FieldName"])), "5000");
            BrowserDriver.Sleep(2000);

            BrowserDriver.Sleep(3000);
            //Actions ContentAction = new Actions(driver);
           // BrowserDriver.Sleep(2000);
            //ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().Build().Perform();
            //ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().SendKeys("    Loyalty Testing" + "\n").DoubleClick().Build().Perform();
            //SSC_StatusAdjust_Reason.Click();
            BrowserDriver.Sleep(2000);
            //SSC_StatusAdjust_Reason.Clear();
            //SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing" + "\n");
            //SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing");
            driver.FindElement(SSCNewTicketFields("Reason")).SendKeys("Loyalty Testing");
            BrowserDriver.Sleep(3000);



            //Sending interaction email from ticket
            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
            BrowserDriver.Sleep(5000);
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
            
            BrowserDriver.Sleep(2000); 
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            //WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewEmailIconFields("Email")));
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, SSCTicketData["Email"]);
            BrowserDriver.Sleep(3000);
            SSCTicketEmailSend.Click();
            BrowserDriver.Sleep(3000);
            SSCNewTicketSave.Click();
            BrowserDriver.Sleep(3000);

            //Changing ticket status to solved
            //WebHandlers.Instance.Click(SSCNewTicketEditIcon);

            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            BrowserDriver.Sleep(2000);


            //Approval verification and withdrawal == > Below part of code is currently on hold due to admin rights for ssc user
            WebHandlers.Instance.Click(SSCTicketsActions);
            BrowserDriver.Sleep(1000);
            Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
            WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
            BrowserDriver.Sleep(4000);

            if (driver.FindElements(SpanSSCText("Solved")).Count == 0)
            {
                try
                {
                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                    BrowserDriver.Sleep(4000);
                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
                    //Status selection
                    WebHandlers.Instance.Click(SSCTicketsActions);
                    BrowserDriver.Sleep(1000);
                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
                    BrowserDriver.Sleep(4000);
                    //Status selection
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketSolved.Click();
                    BrowserDriver.Sleep(1000);
                    //Status selection

                    BrowserDriver.Sleep(1000);
                    WebHandlers.Instance.Click(SSCNewTicketSave);
                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
                    BrowserDriver.Sleep(6000);

                }
                catch (Exception e)
                {
                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                    BrowserDriver.Sleep(4000);
                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
                    //Status selection
                    WebHandlers.Instance.Click(SSCTicketsActions);
                    BrowserDriver.Sleep(1000);
                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
                    BrowserDriver.Sleep(4000);
                    //Status selection
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketSolved.Click();
                    BrowserDriver.Sleep(1000);
                    //Status selection

                    BrowserDriver.Sleep(1000);
                    WebHandlers.Instance.Click(SSCNewTicketSave);
                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
                    BrowserDriver.Sleep(6000);
                }

            }
        }

        public void CreateSSCTicketToResolveComplaintByApology(Dictionary<string, string> SSCTicketData)
        {
            string Url = "https://www.google.com/";

            //Creating manual tier upgrade ticket
            //WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCTicketCreateBtn);
            //WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
            //WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(SSCNewTicketFields("Type")));
            BrowserDriver.Sleep(3000);
            //WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
            BrowserDriver.Sleep(1000);
            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Type"), SSCTicketData["Type"]);

            //Type selected by default, value selelection with below code not working
            //driver.FindElement(SSCNewTicketFields("Type")).Clear();
            //driver.FindElement(SSCNewTicketFields("Type")).SendKeys(SSCTicketData["Type"]);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Type")), SSCTicketData["Type"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), SSCTicketData["UserName"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), SSCTicketData["ContactCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), SSCTicketData["SubCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), SSCTicketData["SubDetailCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Item Category")), SSCTicketData["ItemCategory"]);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Team")).Clear();
            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Relations");
            BrowserDriver.Sleep(10000);


            ////Performing ticket Save and close
            //WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
            //BrowserDriver.Sleep(3000);
            //Actions ContentAction = new Actions(driver);
            //BrowserDriver.Sleep(5000);
            ////ContentAction.MoveToElement(SSCNewTicketContentBox).DoubleClick();
            //BrowserDriver.Sleep(3000);
            //ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    " + SSCTicketData["Subject"]).DoubleClick().Build().Perform();
            ////Discription Field entering
            ////ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    " + "    Subject Discription").DoubleClick().Build().Perform();
            //BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);

            //// To handle Description textbox

            

            // Explicit wait for the content box to be visible and enabled
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(55));
            // Scroll down by 1000 pixels


            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 1000);");
            BrowserDriver.Sleep(2000);
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            
            BrowserDriver.Sleep(2000);
            // Switch to the frame
            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
            IWebElement contentBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SSCNewTicketContentBox));

            if (contentBox != null)
            {
                // Initialize Actions class
                Actions contentAction = new Actions(driver);

                // Move to the content box and perform actions
                contentAction.MoveToElement(contentBox)
                    .Click()
                    .SendKeys("  Description- Subject Discription")
                    .DoubleClick()
                    .Build()
                    .Perform();
            }
            else
            {
                Console.WriteLine("ContentBox element not found");
            }
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);

            //WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            //BrowserDriver.Sleep(4000);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
            //driver.FindElement(SSCNewTicketFields("Source")).Clear();
            //driver.FindElement(SSCNewTicketFields("Source")).SendKeys(SSCTicketData["Source"]);
            //BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
            BrowserDriver.Sleep(2000);
            SSCNewTicketSaveOpen.Click();
            BrowserDriver.Sleep(10000);

            //Changing ticket status and target tier details

            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEditIcon);
            //try { WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open"); }
            try
            {

                SSCNewTicketEditIcon.Click();
                BrowserDriver.Sleep(4000);

                //Status selection
                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                //SSC_StatusDropdownBtn.Click();
                BrowserDriver.Sleep(5000);
                SSC_StatusDropdown_TicketOpen.Click();
                BrowserDriver.Sleep(2000);
                //Status selection

            }
            catch
            {
                //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                //SSCNewTicketEditIcon.Click();
                BrowserDriver.Sleep(2000);
                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
                //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Open");

                //Status selection
                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                //SSC_StatusDropdownBtn.Click();
                BrowserDriver.Sleep(9000);
                SSC_StatusDropdown_TicketOpen.Click();
                BrowserDriver.Sleep(1000);
                //Status selection
            }
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), SSCTicketData["Subject"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Mobile")));
            try
            {
                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Business Area"), "Online");
                //WebHandlers.Instance.DropDownSetByVal(driver.FindElement(SSCNewTicketFields("Business Area")), "Online");
                driver.FindElement(SSCNewTicketFields("Business Area")).Clear();
                driver.FindElement(SSCNewTicketFields("Business Area")).SendKeys("Online");
            }
            catch
            {
                //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Business Area")), "Online");
                driver.FindElement(SSCNewTicketFields("Business Area")).Clear();
                driver.FindElement(SSCNewTicketFields("Business Area")).SendKeys("Online");
            }
            BrowserDriver.Sleep(1000);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Fulfillment Point")), "Harrods");
            driver.FindElement(SSCNewTicketFields("Fulfillment Point")).Clear();
            //Fulfillment Point "Harrods" no longer exist
            // driver.FindElement(SSCNewTicketFields("Fulfillment Point")).SendKeys("Harrods");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Fulfillment Point")), "Burberry");       
            BrowserDriver.Sleep(1000);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Online Division")), "Mens");
            driver.FindElement(SSCNewTicketFields("Online Division")).Clear();
            //Means UI not exist
            //driver.FindElement(SSCNewTicketFields("Online Division")).SendKeys("Mens");
            driver.FindElement(SSCNewTicketFields("Online Division")).SendKeys("Menswear");
            BrowserDriver.Sleep(1000);

            if (SSCTicketData["Subject"] == "Rewards card")
                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Reason"), "Points");
                //driver.FindElement(SSCNewTicketFields("Reason")).SendKeys("Points"); ==> changed by ajay 04.11.2022
                driver.FindElement(SSCNewTicketFields("Reason")).SendKeys("Points Migration");
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Single/Multiple"), "Single");
            driver.FindElement(SSCNewTicketFields("Single/Multiple")).SendKeys("Single");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Goodwill Type")), "Gift Cards");
            BrowserDriver.Sleep(3000);

            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Gift Card Value")), "10.50");
            IJavaScriptExecutor jss = (IJavaScriptExecutor)driver;
            string title = (string)jss.ExecuteScript("arguments[0].value = '';", driver.FindElement(SSCNewTicketFields("Gift Card Value")));
            driver.FindElement(SSCNewTicketFields("Gift Card Value")).Clear();
            BrowserDriver.Sleep(3000);
            driver.FindElement(SSCNewTicketFields("Gift Card Value")).SendKeys("10.50");

            BrowserDriver.Sleep(3000);
            //Sending interaction email from ticket
            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Assigned to")).SendKeys(config.SSCTicketAssignedTo);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
            WebHandlers.Instance.Click(SSCTicketEmailSend);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(6000);

            //Adding Attachment
            driver.FindElement(SSCNewTicketSubTabs("Attachments")).Click();
            //WebHandlers.Instance.WebElementExists(driver.FindElement(SSCBdiGridValue("Add")));
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCBdiGridValue("Status")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(SSCBdiGridValue("Add")));
            WebHandlers.Instance.Click(driver.FindElement(SSCBdiGridValue("Web Link")));
            WebHandlers.Instance.WebElementExists(driver.FindElement(SSCNewTicketFields("Link")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Link")), Url);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Title")), SSCTicketData["Subject"]);
            WebHandlers.Instance.Click(SSCTicketsAttachmentAddBtn);
            BrowserDriver.Sleep(4000);

            //Changing ticket status to solved

            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), "Ajay Sundar"); //hard coded to ajay id
            //driver.FindElement(SSCNewTicketFields("Assigned to")).SendKeys("Ajay Sundar");
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");

            ///======//// Look at this later 
            //            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //            string title = (string)js.ExecuteScript("arguments[0].value = 'Solved';", SSCNewTicketFields("Status"));
            ///======////
            //driver.FindElement(SSCNewTicketFields("Status")).Clear();
            BrowserDriver.Sleep(1000);
            // driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
            //BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(9000);

            //Approval verification and withdrawal == > Below part of code is currently on hold due to admin rights for ssc user
            WebHandlers.Instance.Click(SSCTicketsActions);
            BrowserDriver.Sleep(1000);
            Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
            WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
            BrowserDriver.Sleep(4000);

            if (driver.FindElements(SpanSSCText("Solved")).Count == 0)
            {
                try
                {
                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                    BrowserDriver.Sleep(4000);
                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
                    //Status selection
                    WebHandlers.Instance.Click(SSCTicketsActions);
                    BrowserDriver.Sleep(1000);
                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
                    BrowserDriver.Sleep(4000);
                    //Status selection
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketSolved.Click();
                    BrowserDriver.Sleep(1000);
                    //Status selection

                    BrowserDriver.Sleep(1000);
                    WebHandlers.Instance.Click(SSCNewTicketSave);
                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
                    BrowserDriver.Sleep(6000);

                }
                catch (Exception e)
                {
                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                    BrowserDriver.Sleep(4000);
                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
                    //Status selection
                    WebHandlers.Instance.Click(SSCTicketsActions);
                    BrowserDriver.Sleep(1000);
                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
                    BrowserDriver.Sleep(4000);
                    //Status selection
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketSolved.Click();
                    BrowserDriver.Sleep(1000);
                    //Status selection

                    BrowserDriver.Sleep(1000);
                    WebHandlers.Instance.Click(SSCNewTicketSave);
                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
                    BrowserDriver.Sleep(6000);
                }

            }
            //'Solved' Element xpath change
            //Assert.IsTrue(driver.FindElement(SpanSSCText("Solved")).Displayed, "SSC Ticket status not changed to solved");
            Assert.IsTrue(SSCNewTicketSolved.Displayed, "SSC Ticket status not changed to solved");

        }

        public void CreateSSCTicketForFlowerAsCompensation(Dictionary<string, string> SSCTicketData)
        {
            //Creating manual tier upgrade ticket
            //WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCTicketCreateBtn);
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
            WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Type"), SSCTicketData["Type"]); => changed by ajay 04.11.2022

            //Type selected by default in the application, not working below code of separate selection
            //driver.FindElement(SSCNewTicketFields("Type")).Clear();
            //driver.FindElement(SSCNewTicketFields("Type")).SendKeys(SSCTicketData["Type"]);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), SSCTicketData["UserName"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), SSCTicketData["ContactCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), SSCTicketData["SubCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), SSCTicketData["SubDetailCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Item Category")), SSCTicketData["ItemCategory"]);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Team")).Clear();
            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");
            BrowserDriver.Sleep(9000);

            //Performing ticket Save and close
            //WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
            //Actions ContentAction = new Actions(driver);
            //BrowserDriver.Sleep(2000);
            //ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    " + SSCTicketData["Subject"]).DoubleClick().Build().Perform();
            //WebHandlers.Instance.SwithBackFromFrame();
            //BrowserDriver.Sleep(2000);

            //// To handle Description textbox

            // Switch to the frame
            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);

            // Explicit wait for the content box to be visible and enabled
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IWebElement contentBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SSCNewTicketContentBox));

            if (contentBox != null)
            {
                // Initialize Actions class
                Actions contentAction = new Actions(driver);

                // Move to the content box and perform actions
                contentAction.MoveToElement(contentBox)
                    .Click()
                    .SendKeys("  Description- ComplaintBasedFlowersAsCompensation")
                    .DoubleClick()
                    .Build()
                    .Perform();
            }
            else
            {
                Console.WriteLine("ContentBox element not found");
            }
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);

            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            BrowserDriver.Sleep(4000);
            driver.FindElement(SSCNewTicketFields("Source")).Clear();
            driver.FindElement(SSCNewTicketFields("Source")).SendKeys(SSCTicketData["Source"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
            BrowserDriver.Sleep(2000);
            //try
            //{
            //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
            //    BrowserDriver.Sleep(2000);
            //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
            //    BrowserDriver.Sleep(2000);
            //}
            //catch (Exception e)
            //{
            //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
            //    BrowserDriver.Sleep(2000);
            //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
            //    BrowserDriver.Sleep(2000);
            //}
            SSCNewTicketSaveOpen.Click();
            BrowserDriver.Sleep(10000);

            //Changing ticket status and target tier details
            WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
            //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(2000);
            try
            {
                //    WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
                //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(SSCTicketData["Open"]);
                SSCNewTicketEditIcon.Click();
                BrowserDriver.Sleep(4000);
                //WebHandlers.Instance.DropDownSetByVal(driver.FindElement(SSCNewTicketFields("Status")), "Open");                
                //ContentAction.MoveToElement(driver.FindElement(SSCNewTicketFields("Status"))).Click().SendKeys("Open").DoubleClick().Build().Perform();
                //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);

                //Status selection
                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                //SSC_StatusDropdownBtn.Click();
                BrowserDriver.Sleep(1000);
                SSC_StatusDropdown_TicketOpen.Click();
                BrowserDriver.Sleep(1000);
                //Status selection
            }
            catch
            {
                WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                BrowserDriver.Sleep(2000);
                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
                //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(SSCTicketData["Open"]);
                BrowserDriver.Sleep(4000);
                //WebHandlers.Instance.DropDownSetByVal(driver.FindElement(SSCNewTicketFields("Status")), "Open");                
                //ContentAction.MoveToElement(driver.FindElement(SSCNewTicketFields("Status"))).Click().SendKeys("Open").DoubleClick().Build().Perform();
                //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);

                //Status selection
                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                //SSC_StatusDropdownBtn.Click();
                BrowserDriver.Sleep(1000);
                SSC_StatusDropdown_TicketOpen.Click();
                BrowserDriver.Sleep(1000);
                //Status selection
            }
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), SSCTicketData["Subject"]);

            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Business Area")), "Online");
            BrowserDriver.Sleep(1000);
            //Fulfillment Point "Harrods" no longer exist
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Fulfillment Point")), "Harrods");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Fulfillment Point")), "Burberry");
            BrowserDriver.Sleep(1000);
            //"Mens " option of Online Division no longer exist in UI
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Online Division")), "Mens");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Online Division")), "Menswear");
            BrowserDriver.Sleep(1000);

            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Single/Multiple"), "Single");
            driver.FindElement(SSCNewTicketFields("Single/Multiple")).Clear();
            //driver.FindElement(SSCNewTicketFields("Single/Multiple")).SendKeys(SSCTicketData["Single"]);
            driver.FindElement(SSCNewTicketFields("Single/Multiple")).SendKeys("Single");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Goodwill Type")), "Flowers");
            BrowserDriver.Sleep(1000);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("eFlorist Order Value")), "2.50");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string title = (string)js.ExecuteScript("arguments[0].value = '';", driver.FindElement(SSCNewTicketFields("eFlorist Order Value")));
            driver.FindElement(SSCNewTicketFields("eFlorist Order Value")).Clear();
            BrowserDriver.Sleep(3000);
            driver.FindElement(SSCNewTicketFields("eFlorist Order Value")).SendKeys("2.50");


            //Sending interaction email from ticket
            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
            WebHandlers.Instance.Click(SSCTicketEmailSend);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(6000);

            //Changing ticket status to solved
            //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            //BrowserDriver.Sleep(2000);
            //driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
            //driver.FindElement(SSCNewTicketFields("Status")).Clear();
            //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(SSCTicketData["Solved"]);
            //WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
            //BrowserDriver.Sleep(1000);
            //SSC_StatusDropdown_TicketSolved.Click();
            //BrowserDriver.Sleep(1000);
            //BrowserDriver.Sleep(1000);
            //WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(6000);

            //Approval verification and withdrawal
            WebHandlers.Instance.Click(SSCTicketsActions);
            BrowserDriver.Sleep(1000);
            Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
            WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
            BrowserDriver.Sleep(4000);

            if (driver.FindElements(SpanSSCText("Solved")).Count == 0)
            {
                try
                {
                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                    BrowserDriver.Sleep(4000);
                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
                    //Status selection
                    WebHandlers.Instance.Click(SSCTicketsActions);
                    BrowserDriver.Sleep(1000);
                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
                    BrowserDriver.Sleep(4000);
                    //Status selection
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketSolved.Click();
                    BrowserDriver.Sleep(1000);
                    //Status selection

                    BrowserDriver.Sleep(1000);
                    WebHandlers.Instance.Click(SSCNewTicketSave);
                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
                    BrowserDriver.Sleep(6000);

                }
                catch (Exception e)
                {
                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                    BrowserDriver.Sleep(4000);
                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
                    //Status selection
                    WebHandlers.Instance.Click(SSCTicketsActions);
                    BrowserDriver.Sleep(1000);
                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
                    BrowserDriver.Sleep(4000);
                    //Status selection
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketSolved.Click();
                    BrowserDriver.Sleep(1000);
                    //Status selection

                    BrowserDriver.Sleep(1000);
                    WebHandlers.Instance.Click(SSCNewTicketSave);
                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
                    BrowserDriver.Sleep(6000);
                }
            }
            //"Solved" element xpath change
            Assert.IsTrue(SSCNewTicketSolved.Displayed, "SSC Ticket status not changed to solved");
        }

        public void CreateSSCTicketForDiningVoucherCompensation(Dictionary<string, string> SSCTicketData)
        {
            ////Navigating to Tickets
            HomePage homePage = new HomePage(driver);
            //homePage.NavigateToSSC_Service();
            //homePage.NavigateToSSC_Service_To_Ticket();

            //Creating manual tier upgrade ticket
            //WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCTicketCreateBtn);
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
            //WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
            BrowserDriver.Sleep(5000);
            // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Type"), SSCTicketData["Type"]);

            //Type selected by default in the application, not working the below code
            //WebHandlers.Instance.SSCCustomDropDownSelectValue((SSCNewTicketFields("Type")), SSCTicketData["Type"]);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Type")), SSCTicketData["Type"]);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), SSCTicketData["UserName"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), SSCTicketData["ContactCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), SSCTicketData["SubCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), SSCTicketData["SubDetailCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Item Category")), SSCTicketData["ItemCategory"]);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Team")).Clear();
            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");

            //Performing ticket Save and close
            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    DiningVoucher").DoubleClick().Build().Perform();
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Source")).Clear();
            driver.FindElement(SSCNewTicketFields("Source")).SendKeys(SSCTicketData["Source"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
            BrowserDriver.Sleep(2000);
            //try
            //{
            //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
            //    BrowserDriver.Sleep(2000);
            //}
            //catch (Exception e)
            //{
            //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
            //    BrowserDriver.Sleep(2000);
            //}
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), SSCTicketData["SubCategory"]);
            SSCNewTicketSaveOpen.Click();
            BrowserDriver.Sleep(6000);

            //Changing ticket status and target tier details
            //WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(2000);
            try
            {
                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
                //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Status")), "Open");

                //Status selection
                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                //SSC_StatusDropdownBtn.Click();
                BrowserDriver.Sleep(1000);
                SSC_StatusDropdown_TicketOpen.Click();
                BrowserDriver.Sleep(1000);
                //Status selection
            }
            catch
            {
                WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                BrowserDriver.Sleep(2000);
                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
                //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Status")), "Open");
                //Status selection
                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                //SSC_StatusDropdownBtn.Click();
                BrowserDriver.Sleep(1000);
                SSC_StatusDropdown_TicketOpen.Click();
                BrowserDriver.Sleep(1000);
                //Status selection
            }
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "DiningVoucher");

            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Business Area")), "Online");
            BrowserDriver.Sleep(1000);
            //Fulfillment Point "Harrods" no longer exist
           // WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Fulfillment Point")), "Harrods");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Fulfillment Point")), "Burberry");
            BrowserDriver.Sleep(1000);
            //"Mens " option of Online Division no longer exist in UI
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Online Division")), "Mens");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Online Division")), "Menswear");
            BrowserDriver.Sleep(1000);

            // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Single/Multiple"), "Single");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Single/Multiple")), "Single");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Goodwill Type")), "Dining Experience Vouchers");
            BrowserDriver.Sleep(1000);
            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Dining Voucher Value"), "£15-Hot Beverage");
            //"£15 - Hot Beverage & Dessert in Harrods Cafe" No longer exist in UI
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Dining Voucher Value")), "£15 - Hot Beverage & Dessert in Harrods Cafe");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Dining Voucher Value")), "£15 - Complimentary Hot Beverage & Dessert for 2 in Harrods Café");
            //Sending interaction email from ticket
            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
            //WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
            WebHandlers.Instance.Click(SSCTicketEmailSend);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(6000);

            //Changing ticket status to solved
            //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            //BrowserDriver.Sleep(2000);
            // WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            BrowserDriver.Sleep(2000);
            //driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Status")), "Solved");
            //BrowserDriver.Sleep(1000);
            //WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(6000);

            //Approval verification and withdrawal
            WebHandlers.Instance.Click(SSCTicketsActions);
            BrowserDriver.Sleep(1000);
            Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
            WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
            BrowserDriver.Sleep(4000);

            if (driver.FindElements(SpanSSCText("Solved")).Count == 0)
            {
                try
                {
                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                    BrowserDriver.Sleep(4000);
                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
                    //Status selection
                    WebHandlers.Instance.Click(SSCTicketsActions);
                    BrowserDriver.Sleep(1000);
                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
                    BrowserDriver.Sleep(4000);
                    //Status selection
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketSolved.Click();
                    BrowserDriver.Sleep(1000);
                    //Status selection

                    BrowserDriver.Sleep(1000);
                    WebHandlers.Instance.Click(SSCNewTicketSave);
                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
                    BrowserDriver.Sleep(6000);

                }
                catch (Exception e)
                {
                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                    BrowserDriver.Sleep(4000);
                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
                    //Status selection
                    WebHandlers.Instance.Click(SSCTicketsActions);
                    BrowserDriver.Sleep(1000);
                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
                    BrowserDriver.Sleep(4000);
                    //Status selection
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketSolved.Click();
                    BrowserDriver.Sleep(1000);
                    //Status selection

                    BrowserDriver.Sleep(1000);
                    WebHandlers.Instance.Click(SSCNewTicketSave);
                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
                    BrowserDriver.Sleep(6000);
                }
            }
            BrowserDriver.Sleep(6000);
            //Solved Element xpath change
            //Assert.IsTrue(driver.FindElement(SpanSSCText("Solved")).Displayed, "SSC Ticket status not changed to solved");
            Assert.IsTrue(SSCNewTicketSolved.Displayed, "SSC Ticket status not changed to solved");

            
        }

        public string CreateSSCTicketForPrimaryToSecondaryTransfer(Dictionary<string, string> SSCTicketData)
        {
            //Navigating to Tickets
            HomePage homePage = new HomePage(driver);
            BrowserDriver.Sleep(2000);
            NavigateToSSC_Service();
            //homePage.NavigateToSSC_Service_To_Ticket();

            BrowserDriver.Sleep(2000);
            //Creating manual tier upgrade ticket
            WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCTicketCreateBtn);
            //SSCTicketCreateBtn.Click();
            //WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
            //WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
            BrowserDriver.Sleep(5000);
            driver.FindElement(SSCNewTicketFields("Type")).Clear();
            driver.FindElement(SSCNewTicketFields("Type")).SendKeys(SSCTicketData["Type"]);
            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Type"), SSCTicketData["Type"]);
            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), SSCTicketData["Source"]);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), SSCTicketData["UserName"]);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), SSCTicketData["ContactCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), SSCTicketData["SubCategory"]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), SSCTicketData["SubDetailCategory"]);
            BrowserDriver.Sleep(2000);
            //driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");
            driver.FindElement(SSCNewTicketFields("Team")).Clear();
            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");

            ////Performing ticket Save and close
            //WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
            //Actions ContentAction = new Actions(driver);
            //BrowserDriver.Sleep(2000);
            //ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    TransferPoints").DoubleClick().Build().Perform();
            //WebHandlers.Instance.SwithBackFromFrame();
            //BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            BrowserDriver.Sleep(4000);
            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), SSCTicketData["Source"]);
            driver.FindElement(SSCNewTicketFields("Source")).Clear();
            driver.FindElement(SSCNewTicketFields("Source")).SendKeys(SSCTicketData["Source"]);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Subject")).Clear();
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
            BrowserDriver.Sleep(2000);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCNewTicketFields("Team")).Clear();
            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");
            BrowserDriver.Sleep(9000);

            //// To handle Description textbox

            // Switch to the frame
            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);

            // Explicit wait for the content box to be visible and enabled
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IWebElement contentBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SSCNewTicketContentBox));

            if (contentBox != null)
            {
                // Initialize Actions class
                Actions contentAction = new Actions(driver);

                // Move to the content box and perform actions
                contentAction.MoveToElement(contentBox)
                    .Click()
                    .SendKeys("  Description- TransferPoints")
                    .DoubleClick()
                    .Build()
                    .Perform();
            }
            else
            {
                Console.WriteLine("ContentBox element not found");
            }
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);

            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
            BrowserDriver.Sleep(4000);

            SSCNewTicketSaveOpen.Click();
            BrowserDriver.Sleep(9000);

            //Changing ticket status and target tier details
           // WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
            //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(5000);
            //try { WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open"); }
            try
            {

                SSCNewTicketEditIcon.Click();
                BrowserDriver.Sleep(7000);
                //WebHandlers.Instance.DropDownSetByVal(driver.FindElement(SSCNewTicketFields("Status")), "Open");                
                //ContentAction.MoveToElement(driver.FindElement(SSCNewTicketFields("Status"))).Click().SendKeys("Open").DoubleClick().Build().Perform();
                //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);

                //Status selection
                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                //SSC_StatusDropdownBtn.Click();
                BrowserDriver.Sleep(5000);
                SSC_StatusDropdown_TicketOpen.Click();
                BrowserDriver.Sleep(5000);
                //Status selection

            }
            catch
            {
                //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                //SSCNewTicketEditIcon.Click();
                BrowserDriver.Sleep(5000);
                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
                //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Open");

                //Status selection
                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                //SSC_StatusDropdownBtn.Click();
                BrowserDriver.Sleep(3000);
                SSC_StatusDropdown_TicketOpen.Click();
                BrowserDriver.Sleep(1000);
                //Status selection
            }
            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();

            BrowserDriver.Sleep(2000);
            // Scroll down by 1000 pixels
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 1000);");
            TransferPointFromfilter.Click();
            // WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "TransferPoints");
            // WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Transfer Points From")), SSCTicketData["TransferFrom"]);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Transfer Points To")), SSCTicketData["TransferTo"]);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Rewards Points To Be Adjusted")), SSCTicketData["PointsToTransfer"]);
            // IWebElement dropdownElement = driver.FindElement(SSCNewTicketFields("Summary"));
            BrowserDriver.Sleep(1000);
            string optionText = SSCTicketData["TransferFrom"];
            IWebElement option = driver.FindElement(By.XPath($"//*[text()='{optionText}']"));
            option.Click();
            BrowserDriver.Sleep(5000);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Rewards points to be given/deducted/extended/transferred")), SSCTicketData["PointsToTransfer"]);
            //WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", TransferPointTofilter);
            BrowserDriver.Sleep(1000);
            TransferPointTofilter.Click();
            BrowserDriver.Sleep(1000);
            string optionTexts = SSCTicketData["TransferTo"];
            IWebElement options = driver.FindElement(By.XPath($"//*[text()='{optionTexts}']"));
            options.Click();

            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "TransferPoints");
            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Reason"), "Points Migration");
            string RewardsPoints = driver.FindElement(SSCNewTicketFields("Rewards Points")).GetAttribute("value");
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Rewards Points To Be Adjusted")), SSCTicketData["PointsToTransfer"]);
            BrowserDriver.Sleep(3000);
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().Build().Perform();
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().SendKeys("Loyalty Testing" + "\n").DoubleClick().Build().Perform();

            //Sending interaction email from ticket
            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
            //WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, SSCTicketData["Email"]);
            WebHandlers.Instance.Click(SSCTicketEmailSend);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            BrowserDriver.Sleep(9000);
            WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            BrowserDriver.Sleep(6000);

            ////Changing ticket status to solved
            //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            //BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            //BrowserDriver.Sleep(2000);
            //driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Sub-Reason"), "Other");
            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Solved");
            //BrowserDriver.Sleep(1000);
            //WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
            //BrowserDriver.Sleep(6000);

            //Approval verification and withdrawal
            //WebHandlers.Instance.Click(SSCTicketsActions);
            BrowserDriver.Sleep(1000);
            //Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
            //WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
            BrowserDriver.Sleep(4000);

            if (driver.FindElements(SpanSSCText("Solved")).Count == 0)
            {
                try
                {
                    //driver.Navigate().Refresh();
                    BrowserDriver.Sleep(4000);
                    //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                    BrowserDriver.Sleep(4000);
                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
                    ////Status selection
                    //WebHandlers.Instance.Click(SSCTicketsActions);
                    //BrowserDriver.Sleep(1000);
                    //Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
                    //WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
                    BrowserDriver.Sleep(4000);
                    //Status selection
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketSolved.Click();
                    BrowserDriver.Sleep(1000);
                    //Status selection

                    BrowserDriver.Sleep(1000);
                    WebHandlers.Instance.Click(SSCNewTicketSave);
                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
                    BrowserDriver.Sleep(6000);

                }
                catch (Exception e)
                {
                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                    BrowserDriver.Sleep(4000);
                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
                    //Status selection
                    WebHandlers.Instance.Click(SSCTicketsActions);
                    BrowserDriver.Sleep(1000);
                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
                    BrowserDriver.Sleep(4000);
                    //Status selection
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketSolved.Click();
                    BrowserDriver.Sleep(1000);
                    //Status selection

                    BrowserDriver.Sleep(1000);
                    WebHandlers.Instance.Click(SSCNewTicketSave);
                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
                    BrowserDriver.Sleep(6000);
                }
            }
            return RewardsPoints;
        }

        //TC_221
        public void ValidateStatusPointsafterTierChange()
        {
            string RewardsPoints = WebHandlers.Instance.GetTextOfElement(SSC_Ticket_RewardsPoints);
            string StatusPoints = WebHandlers.Instance.GetTextOfElement(SSC_Ticket_StatusPoints);
            string adjustStatuspoints = WebHandlers.Instance.GetTextOfElement(SSC_Ticket_AdjustStatusPoints);

            //int rewardpoint = Int16.Parse(RewardsPoints);
            //int statuspoints = Int16.Parse(StatusPoints);
            //int adjust_statuspoints = Int16.Parse(adjustStatuspoints);

            //WebHandlers.Instance.EnterText(SSC_StatusAdjust_Reason, "Loyalty Testing");

            BrowserDriver.Sleep(3000);
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().Build().Perform();
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().SendKeys("Loyalty Testing" + "\n").DoubleClick().Build().Perform();
            //SSC_StatusAdjust_Reason.Click();
            BrowserDriver.Sleep(2000);
            //SSC_StatusAdjust_Reason.Clear();
            //SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing" + "\n");
            //SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing");
            //BrowserDriver.Sleep(3000);

            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Single/Multiple")), "Single");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Goodwill Type")), "Dining Experience Vouchers");
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Dining Voucher Value")), "£15 - Complimentary Hot Beverage & Dessert for 2 in Harrods Café");
            BrowserDriver.Sleep(3000);

            WebHandlers.Instance.Click(SSCSaveButton);
            BrowserDriver.Sleep(2000);
            //string approval_status = WebHandlers.Instance.GetTextOfElement(SSC_Approval_Status);
            ////Assert.IsTrue(adjust_statuspoints == (rewardpoint - statuspoints),"Adjusted Status points is incorrect and doesnt match");
            //driver.FindElement(SSCNewTicketSubTabs("Approval")).Click();
            BrowserDriver.Sleep(2000);
            //Assert.IsTrue(approval_status.Equals("In Approval"), "Status is not displayed as --In Approval--");

        }

        //TC_226
        public void ValidateStatusPointsafterChangeInTier()
        {
            string RewardsPoints = WebHandlers.Instance.GetTextOfElement(SSC_Ticket_RewardsPoints);
            string StatusPoints = WebHandlers.Instance.GetTextOfElement(SSC_Ticket_StatusPoints);
            string adjustStatuspoints = WebHandlers.Instance.GetTextOfElement(SSC_Ticket_AdjustStatusPoints);

            //int rewardpoint = Int16.Parse(RewardsPoints);
            //int statuspoints = Int16.Parse(StatusPoints);
            //int adjust_statuspoints = Int16.Parse(adjustStatuspoints);

            //WebHandlers.Instance.EnterText(SSC_StatusAdjust_Reason, "Loyalty Testing");

            BrowserDriver.Sleep(3000);
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().Build().Perform();
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().SendKeys("Loyalty Testing" + "\n").DoubleClick().Build().Perform();
            //SSC_StatusAdjust_Reason.Click();
            BrowserDriver.Sleep(2000);
            //SSC_StatusAdjust_Reason.Clear();
            //SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing" + "\n");
            //SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing");
            //BrowserDriver.Sleep(3000);

            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Single/Multiple")), "Single");
            //BrowserDriver.Sleep(2000);
           // WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Goodwill Type")), "Dining Experience Vouchers");
           // BrowserDriver.Sleep(2000);
           // WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Dining Voucher Value")), "£15 - Complimentary Hot Beverage & Dessert for 2 in Harrods Café");
            //BrowserDriver.Sleep(3000);

            WebHandlers.Instance.Click(SSCSaveButton);
            BrowserDriver.Sleep(2000);
            //string approval_status = WebHandlers.Instance.GetTextOfElement(SSC_Approval_Status);
            ////Assert.IsTrue(adjust_statuspoints == (rewardpoint - statuspoints),"Adjusted Status points is incorrect and doesnt match");
            //driver.FindElement(SSCNewTicketSubTabs("Approval")).Click();
            BrowserDriver.Sleep(2000);
            //Assert.IsTrue(approval_status.Equals("In Approval"), "Status is not displayed as --In Approval--");

        }

        public void ValidateStatusPointsafterTierChangeforTransfer()
        {
            string RewardsPoints = WebHandlers.Instance.GetTextOfElement(SSC_Ticket_RewardsPoints);
            string StatusPoints = WebHandlers.Instance.GetTextOfElement(SSC_Ticket_StatusPoints);
            string adjustStatuspoints = WebHandlers.Instance.GetTextOfElement(SSC_Ticket_AdjustStatusPoints);
            BrowserDriver.Sleep(3000);
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().Build().Perform();
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().SendKeys("Loyalty Testing" + "\n").DoubleClick().Build().Perform();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCSaveButton);
            BrowserDriver.Sleep(2000);
        }

        #endregion
    }
}
