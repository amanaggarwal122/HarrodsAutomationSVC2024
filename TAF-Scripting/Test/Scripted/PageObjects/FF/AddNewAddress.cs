using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Scripting.Test.Common;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects.FF
{
    class AddNewAddress
    {
        public IWebDriver driver;
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Configuration config = null;

        #region  Constructor

        public AddNewAddress(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region elements

        [FindsBy(How = How.Id, Using = "addressForm-firstName")]
        private IWebElement FirstName;

        [FindsBy(How = How.Id, Using = "addressForm-lastName")]
        private IWebElement LastName;

        [FindsBy(How = How.Id, Using = "addressForm-phone")]
        private IWebElement Phone;

        [FindsBy(How = How.Id, Using = "addressForm-country")]
        private IWebElement Country;

        [FindsBy(How = How.Id, Using = "addressForm-addressLine1")]
        private IWebElement AddressLine1;

        [FindsBy(How = How.Id, Using = "addressForm-addressLine2")]
        private IWebElement AddressLine2;

        [FindsBy(How = How.Id, Using = "addressForm-addressLine3")]
        private IWebElement AddressLine3;

        [FindsBy(How = How.Id, Using = "addressForm-city")]
        private IWebElement CityAddress;       

        [FindsBy(How = How.XPath, Using = "//input[@id='addressForm-state']")]
        private IWebElement input_StateAddress;

        [FindsBy(How = How.XPath, Using = "//select[@id='addressForm-state']")]
        private IWebElement select_StateAddress;

        [FindsBy(How = How.Id, Using = "addressForm-zipCode")]
        private IWebElement AddressZipCode;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='addressForm-saveAddress']")]
        private IWebElement btnAddAddress;

        [FindsBy(How = How.Id, Using = "addressForm-deliveryAddress")]
        private IWebElement chkDefaultDelveryAdd;

        [FindsBy(How = How.Id, Using = "addressForm-billingAddress")]
        private IWebElement chkDefaultBillAdd;

        [FindsBy(How = How.Id, Using = "addressForm-contactAddress")]
        private IWebElement chkDefaultContactAdd;

        [FindsBy(How = How.XPath, Using = "//button[text()='Or Enter Address Manually']")]
        private IWebElement EnterAddressManualLink;
        
        public By FFCustomerAddressGridUserName(string FullName) { return By.XPath("//h3[text()='" + FullName + "']"); }
        public By FFCustomerAddressGridData(string AddressValue) { return By.XPath("//p[contains(text(),'"+ AddressValue + "')]"); }

        #endregion

        public void AddNewCustomerAddress(Dictionary<string, string> PostalAddress = null)
        {
            string firstName = PostalAddress["FirstName"].ToString();
            string lastName = PostalAddress["LastName"].ToString();
            string phoneNumber = PostalAddress["CellPhone"].ToString();
            string country = PostalAddress["Country"].ToString();
            string addressLine1 = PostalAddress["AddressLine1"].ToString();
            string addressLine2 = PostalAddress["AddressLine2"].ToString();
            string addressLine3 = PostalAddress["AddressLine3"].ToString();
            string city = PostalAddress["City"].ToString();
            string state = PostalAddress["State"].ToString();            
            string postalCode = PostalAddress["Postcode"].ToString();
            string defaultDelAdd = PostalAddress["DefaultDeliveryAddress"].ToString();
            string defaultBillAdd = PostalAddress["DefaultBillingAddress"].ToString();
            string defaultContAdd = PostalAddress["DefaultContactAddress"].ToString();

            WebHandlers.Instance.EnterText(FirstName, firstName, $"Entered First Name as {firstName}");
            WebHandlers.Instance.EnterText(LastName, lastName, $"Entered Last Name as {lastName}");
            WebHandlers.Instance.EnterText(Phone, phoneNumber, $"Entered Phone Number as {phoneNumber}");

            if (WebHandlers.Instance.WebElementExists(Country))
                WebHandlers.Instance.MultiSelectByText(Country, country, $"Entered Country Name as {country}");

            WebWaitHelper.Instance.WaitForElement(EnterAddressManualLink);
            WebHandlers.Instance.Click(EnterAddressManualLink);
            BrowserDriver.Sleep(3000);

            WebHandlers.Instance.EnterText(AddressLine1, addressLine1, $"Entered Address Line1 as {addressLine1}");
            if (addressLine2 != string.Empty)
                WebHandlers.Instance.EnterText(AddressLine2, addressLine2, $"Entered Last Name as {addressLine2}");
            //if (addressLine3 != string.Empty)
            //    WebHandlers.Instance.EnterText(AddressLine3, addressLine3, $"Entered First Name as {addressLine3}");
            WebHandlers.Instance.EnterText(CityAddress, city, $"Entered City Name as {city}");

            if (WebHandlers.Instance.WebElementExists(input_StateAddress))
                WebHandlers.Instance.EnterText(input_StateAddress, state, $"Entered State Name as {state}");

            if (WebHandlers.Instance.WebElementExists(select_StateAddress))
                WebHandlers.Instance.MultiSelectByText(select_StateAddress, state, $"Entered State Name as {state}");

            if (WebHandlers.Instance.WebElementExists(AddressZipCode))
                WebHandlers.Instance.EnterText(AddressZipCode, postalCode, $"Entered Postalcode as {postalCode}");

            if(defaultDelAdd.ToUpper()=="YES")
                WebHandlers.Instance.Click(chkDefaultDelveryAdd);
            if (defaultBillAdd.ToUpper() == "YES")
                WebHandlers.Instance.Click(chkDefaultBillAdd);
            if (defaultContAdd.ToUpper() == "YES")
                WebHandlers.Instance.Click(chkDefaultContactAdd);

            WebHandlers.Instance.Click(btnAddAddress);
        }
        public void addCityPostState(Dictionary<string, string> PostalAddress = null)
        {
            string city = PostalAddress["City"].ToString();
            string state = PostalAddress["State"].ToString();
            string postalCode = PostalAddress["Postcode"].ToString();

            WebHandlers.Instance.WaitForPageLoad();
            //WebWaitHelper.Instance.WaitForElement(EnterAddressManualLink);
            //WebHandlers.Instance.Click(EnterAddressManualLink);
            EnterAddressManualLink.Click();
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(CityAddress, PostalAddress["City"], $"Entered City Name as {city}");
            WebHandlers.Instance.EnterText(AddressLine1, PostalAddress["AddressLine1"]);
            WebHandlers.Instance.EnterText(AddressLine2, PostalAddress["AddressLine2"]);
            //if (WebHandlers.Instance.WebElementExists(input_StateAddress))
            WebHandlers.Instance.EnterText(input_StateAddress, PostalAddress["State"], $"Entered State Name as {state}");

            //if (WebHandlers.Instance.WebElementExists(select_StateAddress))
               // WebHandlers.Instance.MultiSelectByText(select_StateAddress, state, $"Entered State Name as {state}");

            //if (WebHandlers.Instance.WebElementExists(AddressZipCode))
                WebHandlers.Instance.EnterText(AddressZipCode, PostalAddress["Postcode"], $"Entered Postalcode as {postalCode}");
            WebHandlers.Instance.Click(btnAddAddress);
        }
        public void AddNewCustomerAddresswithDefaultContact(Dictionary<string, string> PostalAddress = null)
        {
                string firstName = PostalAddress["FirstName"].ToString();
                string lastName = PostalAddress["LastName"].ToString();
                string phoneNumber = PostalAddress["CellPhone"].ToString();
                string country = PostalAddress["Country"].ToString();
                string addressLine1 = PostalAddress["AddressLine1"].ToString();
                string addressLine2 = PostalAddress["AddressLine2"].ToString();
                string addressLine3 = PostalAddress["AddressLine3"].ToString();
                string city = PostalAddress["City"].ToString();
                string state = PostalAddress["State"].ToString();
                string postalCode = PostalAddress["Postcode"].ToString();
                string defaultDelAdd = PostalAddress["DefaultDeliveryAddress"].ToString();
                string defaultBillAdd = PostalAddress["DefaultBillingAddress"].ToString();
                string defaultContAdd = PostalAddress["DefaultContactAddress"].ToString();

                WebHandlers.Instance.EnterText(FirstName, firstName, $"Entered First Name as {firstName}");
                WebHandlers.Instance.EnterText(LastName, lastName, $"Entered Last Name as {lastName}");
                WebHandlers.Instance.EnterText(Phone, phoneNumber, $"Entered Phone Number as {phoneNumber}");

                if (WebHandlers.Instance.WebElementExists(Country))
                    WebHandlers.Instance.MultiSelectByText(Country, country, $"Entered Country Name as {country}");

                WebHandlers.Instance.EnterText(AddressLine1, addressLine1, $"Entered Address Line1 as {addressLine1}");
                if (addressLine2 != string.Empty)
                    WebHandlers.Instance.EnterText(AddressLine2, addressLine2, $"Entered Last Name as {addressLine2}");
                if (addressLine3 != string.Empty)
                    WebHandlers.Instance.EnterText(AddressLine3, addressLine3, $"Entered First Name as {addressLine3}");
                WebHandlers.Instance.EnterText(CityAddress, city, $"Entered City Name as {city}");

                if (WebHandlers.Instance.WebElementExists(input_StateAddress))
                    WebHandlers.Instance.EnterText(input_StateAddress, state, $"Entered State Name as {state}");

                if (WebHandlers.Instance.WebElementExists(select_StateAddress))
                    WebHandlers.Instance.MultiSelectByText(select_StateAddress, state, $"Entered State Name as {state}");

                if (WebHandlers.Instance.WebElementExists(AddressZipCode))
                    WebHandlers.Instance.EnterText(AddressZipCode, postalCode, $"Entered Postalcode as {postalCode}");

                //if (defaultDelAdd.ToUpper() == "YES")
                //    WebHandlers.Instance.Click(chkDefaultDelveryAdd);
                //if (defaultBillAdd.ToUpper() == "YES")
                //    WebHandlers.Instance.Click(chkDefaultBillAdd);
                if (defaultContAdd.ToUpper() == "YES")
                    WebHandlers.Instance.Click(chkDefaultContactAdd);
                WebHandlers.Instance.Click(btnAddAddress);            
        }

        public void AddNewCustomerAddresswithBillingAddress(Dictionary<string, string> PostalAddress = null)
        {
            string firstName = PostalAddress["FirstName"].ToString();
            string lastName = PostalAddress["LastName"].ToString();
            string phoneNumber = PostalAddress["CellPhone"].ToString();
            string country = PostalAddress["Country"].ToString();
            string addressLine1 = PostalAddress["AddressLine1"].ToString();
            string addressLine2 = PostalAddress["AddressLine2"].ToString();
            string addressLine3 = PostalAddress["AddressLine3"].ToString();
            string city = PostalAddress["City"].ToString();
            string state = PostalAddress["State"].ToString();
            string postalCode = PostalAddress["Postcode"].ToString();
            string defaultDelAdd = PostalAddress["DefaultDeliveryAddress"].ToString();
            string defaultBillAdd = PostalAddress["DefaultBillingAddress"].ToString();
            string defaultContAdd = PostalAddress["DefaultContactAddress"].ToString();

            WebHandlers.Instance.EnterText(FirstName, firstName, $"Entered First Name as {firstName}");
            WebHandlers.Instance.EnterText(LastName, lastName, $"Entered Last Name as {lastName}");
            WebHandlers.Instance.EnterText(Phone, phoneNumber, $"Entered Phone Number as {phoneNumber}");

            if (WebHandlers.Instance.WebElementExists(Country))
                WebHandlers.Instance.MultiSelectByText(Country, country, $"Entered Country Name as {country}");

            WebHandlers.Instance.EnterText(AddressLine1, addressLine1, $"Entered Address Line1 as {addressLine1}");
            if (addressLine2 != string.Empty)
                WebHandlers.Instance.EnterText(AddressLine2, addressLine2, $"Entered Last Name as {addressLine2}");
            if (addressLine3 != string.Empty)
                WebHandlers.Instance.EnterText(AddressLine3, addressLine3, $"Entered First Name as {addressLine3}");
            WebHandlers.Instance.EnterText(CityAddress, city, $"Entered City Name as {city}");

            if (WebHandlers.Instance.WebElementExists(input_StateAddress))
                WebHandlers.Instance.EnterText(input_StateAddress, state, $"Entered State Name as {state}");

            if (WebHandlers.Instance.WebElementExists(select_StateAddress))
                WebHandlers.Instance.MultiSelectByText(select_StateAddress, state, $"Entered State Name as {state}");

            if (WebHandlers.Instance.WebElementExists(AddressZipCode))
                WebHandlers.Instance.EnterText(AddressZipCode, postalCode, $"Entered Postalcode as {postalCode}");

            //if (defaultDelAdd.ToUpper() == "YES")
            //    WebHandlers.Instance.Click(chkDefaultDelveryAdd);
            if (defaultBillAdd.ToUpper() == "YES")
                WebHandlers.Instance.Click(chkDefaultBillAdd);
            //if (defaultContAdd.ToUpper() == "YES")
            //    WebHandlers.Instance.Click(chkDefaultContactAdd);
            //WebHandlers.Instance.Click(btnAddAddress);
        }

        public void AddNewCustomerAddresswithDeliveryAddress(Dictionary<string, string> PostalAddress = null)
        {
            string firstName = PostalAddress["FirstName"].ToString();
            string lastName = PostalAddress["LastName"].ToString();
            string phoneNumber = PostalAddress["CellPhone"].ToString();
            string country = PostalAddress["Country"].ToString();
            string addressLine1 = PostalAddress["AddressLine1"].ToString();
            string addressLine2 = PostalAddress["AddressLine2"].ToString();
            string addressLine3 = PostalAddress["AddressLine3"].ToString();
            string city = PostalAddress["City"].ToString();
            string state = PostalAddress["State"].ToString();
            string postalCode = PostalAddress["Postcode"].ToString();
            string defaultDelAdd = PostalAddress["DefaultDeliveryAddress"].ToString();
            string defaultBillAdd = PostalAddress["DefaultBillingAddress"].ToString();
            string defaultContAdd = PostalAddress["DefaultContactAddress"].ToString();

            WebHandlers.Instance.EnterText(FirstName, firstName, $"Entered First Name as {firstName}");
            WebHandlers.Instance.EnterText(LastName, lastName, $"Entered Last Name as {lastName}");
            WebHandlers.Instance.EnterText(Phone, phoneNumber, $"Entered Phone Number as {phoneNumber}");

            if (WebHandlers.Instance.WebElementExists(Country))
                WebHandlers.Instance.MultiSelectByText(Country, country, $"Entered Country Name as {country}");

            WebHandlers.Instance.EnterText(AddressLine1, addressLine1, $"Entered Address Line1 as {addressLine1}");
            if (addressLine2 != string.Empty)
                WebHandlers.Instance.EnterText(AddressLine2, addressLine2, $"Entered Last Name as {addressLine2}");
            if (addressLine3 != string.Empty)
                WebHandlers.Instance.EnterText(AddressLine3, addressLine3, $"Entered First Name as {addressLine3}");
            WebHandlers.Instance.EnterText(CityAddress, city, $"Entered City Name as {city}");

            if (WebHandlers.Instance.WebElementExists(input_StateAddress))
                WebHandlers.Instance.EnterText(input_StateAddress, state, $"Entered State Name as {state}");

            if (WebHandlers.Instance.WebElementExists(select_StateAddress))
                WebHandlers.Instance.MultiSelectByText(select_StateAddress, state, $"Entered State Name as {state}");

            if (WebHandlers.Instance.WebElementExists(AddressZipCode))
                WebHandlers.Instance.EnterText(AddressZipCode, postalCode, $"Entered Postalcode as {postalCode}");

            if (defaultDelAdd.ToUpper() == "YES")
                WebHandlers.Instance.Click(chkDefaultDelveryAdd);
            //if (defaultBillAdd.ToUpper() == "YES")
            //    WebHandlers.Instance.Click(chkDefaultBillAdd);
            //if (defaultContAdd.ToUpper() == "YES")
            //    WebHandlers.Instance.Click(chkDefaultContactAdd);
            //WebHandlers.Instance.Click(btnAddAddress);
        }

        public void UpdateCustomerAddress(Dictionary<string, string> PostalAddress = null)
        {
            string firstName = PostalAddress["FirstName"].ToString();
            string lastName = PostalAddress["LastName"].ToString();
            string phoneNumber = PostalAddress["CellPhone"].ToString();
            string country = PostalAddress["Country"].ToString();
            string addressLine1 = PostalAddress["AddressLine1"].ToString();
            string addressLine2 = PostalAddress["AddressLine2"].ToString();
            string addressLine3 = PostalAddress["AddressLine3"].ToString();
            string city = PostalAddress["City"].ToString();
            string state = PostalAddress["State"].ToString();
            string postalCode = PostalAddress["Postcode"].ToString();
            string defaultDelAdd = PostalAddress["DefaultDeliveryAddress"].ToString();
            string defaultBillAdd = PostalAddress["DefaultBillingAddress"].ToString();
            string defaultContAdd = PostalAddress["DefaultContactAddress"].ToString();

            WebHandlers.Instance.EnterText(FirstName, firstName, $"Entered First Name as {firstName}");
            WebHandlers.Instance.EnterText(LastName, lastName, $"Entered Last Name as {lastName}");
            WebHandlers.Instance.EnterText(Phone, phoneNumber, $"Entered Phone Number as {phoneNumber}");

            if (WebHandlers.Instance.WebElementExists(Country))
                WebHandlers.Instance.MultiSelectByText(Country, country, $"Entered Country Name as {country}");

            WebHandlers.Instance.EnterText(AddressLine1, addressLine1, $"Entered Address Line1 as {addressLine1}");
           // BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(AddressLine2, addressLine2, $"Entered Last Name as {addressLine2}");
           // BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(AddressLine3, addressLine3, $"Entered First Name as {addressLine3}");
            WebHandlers.Instance.EnterText(CityAddress, city, $"Entered City Name as {city}");

            if (WebHandlers.Instance.WebElementExists(input_StateAddress))
                WebHandlers.Instance.EnterText(input_StateAddress, state, $"Entered State Name as {state}");

            if (WebHandlers.Instance.WebElementExists(select_StateAddress))
                WebHandlers.Instance.MultiSelectByText(select_StateAddress, state, $"Entered State Name as {state}");

            if (WebHandlers.Instance.WebElementExists(AddressZipCode))
                WebHandlers.Instance.EnterText(AddressZipCode, postalCode, $"Entered Postalcode as {postalCode}");

           // if (!WebHandlers.Instance.ObjDisabled(chkDefaultDelveryAdd))
            if (defaultDelAdd.ToUpper() == "YES")
                    WebHandlers.Instance.Click(chkDefaultDelveryAdd);
            if (defaultBillAdd.ToUpper() == "YES")
                WebHandlers.Instance.Click(chkDefaultBillAdd);
            if (defaultContAdd.ToUpper() == "YES")
                WebHandlers.Instance.Click(chkDefaultContactAdd);

            WebHandlers.Instance.Click(btnAddAddress);
        }

        public void ValidateAddedNewCustomerAddress(Dictionary<string, string> PostalAddress)
        {
            //Performin address validation
            string FullName = PostalAddress["FirstName"] + " " + PostalAddress["LastName"];
            Assert.IsTrue(driver.FindElement(FFCustomerAddressGridUserName(FullName)).Displayed, FullName+ " not showing on customer address grid");
            Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["AddressLine1"])).Displayed, PostalAddress["AddressLine1"] + " not showing on Harrods.com customer address grid");
            Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["AddressLine2"])).Displayed, PostalAddress["AddressLine2"] + " not showing on Harrods.com customer address grid");
            //Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["AddressLine3"])).Displayed, PostalAddress["AddressLine3"] + " not showing on Harrods.com customer address grid");
            Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["City"])).Displayed, PostalAddress["City"] + " not showing on Harrods.com customer address grid");
            Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["State"])).Displayed, PostalAddress["State"] + " not showing on Harrods.com customer address grid");
            Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["Postcode"])).Displayed, PostalAddress["Postcode"] + " not showing on Harrods.com customer address grid");
            Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["Country"])).Displayed, PostalAddress["Country"] + " not showing on Harrods.com customer address grid");
        }
        public void ValidateAddNewCustomerAddressHarrods(Dictionary<string, string> PostalAddress)
        {
            //Performin address validation
            string FullName = PostalAddress["FirstName"] + " " + PostalAddress["LastName"];
            Assert.IsTrue(driver.FindElement(FFCustomerAddressGridUserName(FullName)).Displayed, FullName + " not showing on customer address grid");
            Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["AddressLine1"])).Displayed, PostalAddress["AddressLine1"] + " not showing on Harrods.com customer address grid");
            Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["AddressLine2"])).Displayed, PostalAddress["AddressLine2"] + " not showing on Harrods.com customer address grid");
            //Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["AddressLine3"])).Displayed, PostalAddress["AddressLine3"] + " not showing on Harrods.com customer address grid");
            Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["City"])).Displayed, PostalAddress["City"] + " not showing on Harrods.com customer address grid");
          //  Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["State"])).Displayed, PostalAddress["State"] + " not showing on Harrods.com customer address grid");
            Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["Postcode"])).Displayed, PostalAddress["Postcode"] + " not showing on Harrods.com customer address grid");
            Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["Country"])).Displayed, PostalAddress["Country"] + " not showing on Harrods.com customer address grid");
        }
        public void validateCityStatePostcodeAdded(Dictionary<string, string> PostalAddress)
        {
            Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["City"])).Displayed, PostalAddress["City"] + " not showing on Harrods.com customer address grid");
              Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["State"])).Displayed, PostalAddress["State"] + " not showing on Harrods.com customer address grid");
            Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["Postcode"])).Displayed, PostalAddress["Postcode"] + " not showing on Harrods.com customer address grid");

        }

    }
}
