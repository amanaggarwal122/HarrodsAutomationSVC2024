using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TAF_Web.Scripted.Web;
using TAF_GenericUtility.Scripted.Email;
using HtmlAgilityPack;
using TAF_Scripting.Test.Common;
using TAF_Scripting.Test.Scripted.StepDefinitions;
using TAF_Web.Scripted.Web.BrowserOptions;
using Keys = System.Windows.Forms.Keys;
using OpenQA.Selenium.Support.UI;

namespace TAF_Scripting.Test.Scripted.PageObjects.SCAYLE
{ 
  class ScayleUserPersonalDetailsPage
{
    public IWebDriver driver;
    private Configuration config = null;

    #region  Constructor
    public ScayleUserPersonalDetailsPage(IWebDriver driver, Configuration configuration)
    {
        this.driver = driver;
        PageFactory.InitElements(this.driver, this);
        config = configuration;
    }

    #endregion

    #region Elements
    [FindsBy(How = How.XPath, Using = "//div[@data-test='account-sidebar']//span[text()='Personal Details']")]
    private IWebElement lnkPersonalDetails;
    [FindsBy(How = How.XPath, Using = "//*[@data-test='reminder-button'and contains(text(), 'Add my number')]")]
    private IWebElement btnaddmynumber;
    [FindsBy(How = How.Id, Using = "profileForm-phoneCode")]
    private IWebElement Country_Phonecode;
    [FindsBy(How = How.XPath, Using = "(//*[@name='profile.phones.number'])[3]")]
    private IWebElement txtPhone;
    [FindsBy(How = How.XPath, Using = "//*[@id='__nuxt']/div/div[3]/div/div[2]/div/div/div[4]/div[1]/div/select")]
    private IWebElement ddDay;
    [FindsBy(How = How.XPath, Using = "//*[@id='__nuxt']/div/div[3]/div/div[2]/div/div/div[4]/div[2]/select")]
    private IWebElement ddMonth;
    [FindsBy(How = How.XPath, Using = "//*[@id='__nuxt']/div/div[3]/div/div[2]/div/div/div[4]/div[3]/select")]
    private IWebElement ddYear;
    [FindsBy(How = How.Id, Using = "profileForm-password")]
    private IWebElement txtPwd;
    [FindsBy(How = How.XPath, Using = "//input[@value='Update Number']")]
    private IWebElement btnUpdateNumber;
    [FindsBy(How = How.XPath, Using = "(//*[@name='profile.country'])[3]")]
    private IWebElement countrycode_dropdown;
    [FindsBy(How = How.XPath, Using = "//div[@data-test='notification-confirmation']/div")]
    private IWebElement DetailsConfirmation;
    [FindsBy(How = How.XPath, Using = "//*[@data-test='twoFactorAuth-code']")]
    private IWebElement Txt_EmailCode;
    [FindsBy(How = How.XPath, Using = "//*[@data-test='twoFactorAuth-submitButton']")]
    private IWebElement EmailCode_SubmitBtn;
    [FindsBy(How = How.XPath, Using = "//*[text()='You have successfully updated your personal details']")]
    private IWebElement Confirm_Message;

    #endregion

    #region Events
    public void InvokePersonalDetails()
    {
        BrowserDriver.Sleep(5000);
        WebHandlers.Instance.Click(lnkPersonalDetails);
        BrowserDriver.Sleep(3000);
    }

    public void ClickAddnumber()
    {

        WebHandlers.Instance.Click(btnaddmynumber);
        BrowserDriver.Sleep(3000);
    }

    public void ConfirmStatus(string confirmMsg)
    {
        BrowserDriver.Sleep(5000);
        WebHandlers.Instance.VerifyText(DetailsConfirmation, confirmMsg);
    }


    //TC_63A
    public void ValidatePhoneNumber(string countrycode, string phonenumber)
    {
        if (!phonenumber.Equals(""))
        {
            string countrycode_full = "";
            switch (countrycode)
            {
                case ("UK"):
                    countrycode_full = "GB +44";
                    break;
                case ("US"):
                    countrycode_full = "US +1";
                    break;
                case ("China"):
                    countrycode_full = "CN +86";
                    break;
                case ("Canada"):
                    countrycode_full = "CA +1";
                    break;
                case ("France"):
                    countrycode_full = "FR +33";
                    break;
            }
            Boolean country_code = countrycode_dropdown.Displayed;
            if (country_code)
            {
                string txt = txtPhone.GetAttribute("value");
                string phonenumberwithoutcode = phonenumber.Substring(phonenumber.Length - 12);
                Console.WriteLine(phonenumberwithoutcode);

                Assert.IsTrue(txt.Equals(phonenumberwithoutcode), "Phone number is not displayed as expected");
            }
        }
        else
        {
            string txt = txtPhone.GetAttribute("value");
            Assert.IsTrue(txt.Equals(""), "Phone number is not displayed");
        }
    }

    public void Validate_PersonalDetails(string firstname, string lastname, string DOB)
    {
        //string[] DOB1 = DOB.Split('.');
        string username = firstname + " " + lastname;
        string displayedname = driver.FindElement(By.XPath("//*[text()='Name']/following::div[1]")).Text;
        string displayedday = driver.FindElement(By.XPath("//*[@data-test='dateInput-readOnly-day']")).Text;
        string displayedmonth = driver.FindElement(By.XPath("//*[@data-test='dateInput-readOnly-month']")).Text;
        int month = Int32.Parse(displayedmonth);
        if (month < 10)
        {
            displayedmonth = "0" + displayedmonth;
        }
        string displayedyear = driver.FindElement(By.XPath("//*[@data-test='dateInput-readOnly-year']")).Text;
        string displayedDOB = displayedday + "." + displayedmonth + "." + displayedyear;
        Assert.IsTrue(displayedDOB.Equals(DOB), "DOB is displayed as expected");
        Assert.IsTrue(displayedname.Contains(username), "USername is displayed as expected");

    }

    public void updatePersonalDetails(Dictionary<string, string> customerData)
    {
        string DOB = customerData["DOB"];
        string[] DOB1 = DOB.Split('.');
        if (WebHandlers.Instance.WebElementExists(ddDay))
        {
            WebHandlers.Instance.MultiSelectByText(ddDay, DOB1[0]);
            if (WebHandlers.Instance.WebElementExists(ddMonth))
                WebHandlers.Instance.MultiSelectByText(ddMonth, DOB1[1]);
            if (WebHandlers.Instance.WebElementExists(ddYear))
                WebHandlers.Instance.MultiSelectByText(ddYear, DOB1[2]);
        }


        WebHandlers.Instance.EnterText(txtPhone, customerData["CellPhone"]);
        WebHandlers.Instance.EnterText(txtPwd, customerData["Password"]);
        WebHandlers.Instance.Click(btnUpdateNumber);
    }


    //Validation for Universal Code acceptance scenarios- Creation Suite
    public void EnterEmailCode(string emailcode)
    {
        WebHandlers.Instance.EnterText(Txt_EmailCode, emailcode);
        BrowserDriver.Sleep(9000);
        WebHandlers.Instance.Click(EmailCode_SubmitBtn);
        //BrowserDriver.Sleep(10000);
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='You have successfully updated your personal details']"))); // Replace with your element's locator
        Assert.True(Confirm_Message.Displayed, "You have NOT successfully updated your personal details");
    }

    //TC_45
    public void updatePhonenumber(string countrycode, string Phonenumber)
    {
        switch (countrycode)
        {
            case ("UK"):
                countrycode_dropdown.SendKeys("GB +44");
                break;
            case ("US"):
                countrycode_dropdown.SendKeys("US +1");
                break;
            case ("China"):
                countrycode_dropdown.SendKeys("CN +86");
                break;
            case ("Canada"):
                countrycode_dropdown.SendKeys("CA +1");
                break;
        }
        BrowserDriver.Sleep(3000);
        WebHandlers.Instance.Click(txtPhone);
        WebHandlers.Instance.ClearText(txtPhone);
        BrowserDriver.Sleep(2000);
        WebHandlers.Instance.EnterText(txtPhone, Phonenumber);
        Console.WriteLine("Phonenumber: " + Phonenumber);
        WebHandlers.Instance.Click(btnUpdateNumber);
        BrowserDriver.Sleep(5000);
        //Verification
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        IWebElement Confirm_Msg = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='Your phone number has been successfully changed']"))); 
        Assert.True(Confirm_Msg.Displayed, "You have NOT successfully updated your Phone Number");
        
    }


    public void editPhonenumber(string countrycode, string Phonenumber)
    {
        SelectElement oSelect = new SelectElement(driver.FindElement(By.Id("profileForm-phoneCode")));

        switch (countrycode)
        {
            case ("UK"):
                //oSelect.SelectByText("GB +44");
                countrycode_dropdown.SendKeys("GB +44");
                break;
            case ("US"):
                //oSelect.SelectByText("US +1");
                countrycode_dropdown.SendKeys("US +1");
                break;
            case ("China"):
                //oSelect.SelectByText("CN +86");
                countrycode_dropdown.SendKeys("CN +86");
                break;
            case ("Canada"):
                //oSelect.SelectByText("CA +1");
                countrycode_dropdown.SendKeys("CA +1");
                break;
            case ("France"):
                //oSelect.SelectByText("FR +33");
                countrycode_dropdown.SendKeys("FR +33");
                break;
        }

        BrowserDriver.Sleep(3000);
        WebHandlers.Instance.ClearText(txtPhone);
        BrowserDriver.Sleep(2000);
        WebHandlers.Instance.EnterText(txtPhone, Phonenumber);
        WebHandlers.Instance.EnterText(txtPwd, "Harrods123");
        WebHandlers.Instance.Click(btnUpdateNumber);
        BrowserDriver.Sleep(3000);
    }
    public void updateDOB(string DOB)
    {
            //string[] DOB1 = DOB.Split('.');
            //    BrowserDriver.Sleep(3000);
            //    if (WebHandlers.Instance.WebElementExists(ddDay))
            //{
            //        BrowserDriver.Sleep(3000);
            //        WebHandlers.Instance.MultiSelectByText(ddDay, DOB1[0]);
            //        BrowserDriver.Sleep(3000);
            //        if (WebHandlers.Instance.WebElementExists(ddMonth))
            //        WebHandlers.Instance.MultiSelectByText(ddMonth, DOB1[1]);
            //        BrowserDriver.Sleep(3000);
            //        if (WebHandlers.Instance.WebElementExists(ddYear))
            //            BrowserDriver.Sleep(3000);
            //        WebHandlers.Instance.MultiSelectByText(ddYear, DOB1[2]);
            //}

            try
            {
                // Split the input date string by '.' to get day, month, and year
                string[] dobParts = DOB.Split('.');

                // Wait for and select the day
                if (WebHandlers.Instance.WebElementExists(ddDay))
                {
                    WebDriverWait wait = new WebDriverWait(BrowserDriver.Instance, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.ElementToBeClickable(ddDay));
                    WebHandlers.Instance.MultiSelectByText(ddDay, dobParts[0].TrimStart('0')); // Removes leading zero
                }
                else
                {
                    Console.WriteLine("Day dropdown not found.");
                }

                // Wait for and select the month
                if (WebHandlers.Instance.WebElementExists(ddMonth))
                {
                    WebDriverWait wait = new WebDriverWait(BrowserDriver.Instance, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.ElementToBeClickable(ddMonth));
                    WebHandlers.Instance.MultiSelectByText(ddMonth, dobParts[1].TrimStart('0'));
                }
                else
                {
                    Console.WriteLine("Month dropdown not found.");
                }

                // Wait for and select the year
                if (WebHandlers.Instance.WebElementExists(ddYear))
                {
                    WebDriverWait wait = new WebDriverWait(BrowserDriver.Instance, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.ElementToBeClickable(ddYear));
                    WebHandlers.Instance.MultiSelectByText(ddYear, dobParts[2]);
                }
                else
                {
                    Console.WriteLine("Year dropdown not found.");
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Element not found: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating DOB: {ex.Message}");
            }
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.EnterText(txtPwd, "Harrods123");
            WebHandlers.Instance.Click(btnUpdateNumber);
    }

    public string getPhonenumber()
    {
        BrowserDriver.Sleep(3000);
        string phonenumber = txtPhone.Text;
        return phonenumber;
    }
    public void deletePhonenumber()
    {
        BrowserDriver.Sleep(2000);
        WebHandlers.Instance.EnterText(txtPwd, "Harrods123");
        txtPhone.Clear();

        WebHandlers.Instance.Click(btnUpdateNumber);
        BrowserDriver.Sleep(2000);
    }
    #endregion
}
}
