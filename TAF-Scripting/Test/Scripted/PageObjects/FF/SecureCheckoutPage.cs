using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_GenericUtility.Scripted.Email;
using TAF_GenericUtility.Scripted.Generic;
using TAF_GenericUtility.Scripted.Security;
using TAF_Web.Scripted.Web;


namespace TAF_Scripting.Test.Scripted.PageObjects
{
    public class SecureCheckoutPage
    {
        public IWebDriver driver;
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Configuration config = null;

        #region  Constructor

        public SecureCheckoutPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        public SecureCheckoutPage(Configuration configuration)
        {
            config = configuration;
        }

        #endregion

        #region Elements		

        [FindsBy(How = How.Id, Using = "newAddressForm-firstName")]
        private IWebElement FirstName;

        [FindsBy(How = How.Id, Using = "addressForm-firstName")]
        private IWebElement GuestFirstName;

        [FindsBy(How = How.Id, Using = "newAddressForm-lastName")]
        private IWebElement LastName;

        [FindsBy(How = How.Id, Using = "addressForm-lastName")]
        private IWebElement GuestLastName;

        [FindsBy(How = How.Id, Using = "newAddressForm-phone")]
        private IWebElement ContactPhone;

        [FindsBy(How = How.Id, Using = "addressForm-phone")]
        private IWebElement GuestContactPhone;

        [FindsBy(How = How.Id, Using = "addressForm-email")]
        private IWebElement GuestContactEmail;

        [FindsBy(How = How.Id, Using = "newAddressForm-country")]
        private IWebElement CountrySelect;

        [FindsBy(How = How.Id, Using = "addressForm-country")]
        private IWebElement GuestCountrySelect;

        [FindsBy(How = How.XPath, Using = "//*[@id='tabpanel-delivery']/form/section/div/div[@data-test='addressForm-addressLine1-searchable']")]
        private IWebElement checkAddressLine1Searchable;

        
        [FindsBy(How = How.XPath, Using = "//*[@id='tabpanel-delivery']/form/section/div/div[@data-test='addressForm-zipCode-wrapper']")]
        private IWebElement checkAddressZipCode;

        [FindsBy(How = How.Id, Using = "addressForm-addressLine1-searchable")]
        private IWebElement AddressInput;

        [FindsBy(How = How.Id, Using = "addressForm-zipCode")]
        private IWebElement AddressZipCode;

        [FindsBy(How = How.Id, Using = "newAddressForm-zipCode")]
        private IWebElement newAddressZipCode;

        [FindsBy(How = How.Id, Using = "addressForm-addressLine1-searchable-select")]
        private IWebElement AddressSelect;

        [FindsBy(How = How.Id, Using = "addressForm-addressLine1")] 
        private IWebElement AddressLine1;

        [FindsBy(How = How.Id, Using = "addressForm-addressLine2")] 
        private IWebElement AddressLine2;

        [FindsBy(How = How.Id, Using = "addressForm-addressLine3")] 
        private IWebElement AddressLine3;

        [FindsBy(How = How.Id, Using = "newAddressForm-addressLine1")]
        private IWebElement newAddressLine1;
        
        [FindsBy(How = How.Id, Using = "newAddressForm-addressLine2")]
        private IWebElement newAddressLine2;

        [FindsBy(How = How.Id, Using = "newAddressForm-addressLine3")]
        private IWebElement newAddressLine3;

        [FindsBy(How = How.Id, Using = "addressForm-city")]
        private IWebElement CityAddress;

        [FindsBy(How = How.Id, Using = "newAddressForm-city")]
        private IWebElement newCityAddress;

        //[FindsBy(How = How.Id, Using = "addressForm-state")]
        //private IWebElement StateAddress;

        [FindsBy(How = How.XPath, Using = "//input[@id='addressForm-state']")]
        private IWebElement input_StateAddress;
        
        [FindsBy(How = How.XPath, Using = "//select[@id='addressForm-state']")]
        private IWebElement select_StateAddress;

        //[FindsBy(How = How.Id, Using = "newAddressForm-state")]
        //private IWebElement newStateAddress;

        [FindsBy(How = How.XPath, Using = "//input[@id='newAddressForm-state']")]
        private IWebElement input_newStateAddress;

        [FindsBy(How = How.XPath, Using = "//select[@id='newAddressForm-state']")]
        private IWebElement select_newStateAddress;       

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Harrods Gift Card')]/preceding-sibling::input")]
        private IWebElement HarrodsGiftCardCheckbox;
        

        [FindsBy(How = How.Id, Using = "giftCardForm-cardNumber")]
        private IWebElement GiftCardNumber;

        [FindsBy(How = How.Id, Using = "giftCardForm-pinNumber")]
        private IWebElement GiftCardPinNumber;
        
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Available Balance')]")]
        private IWebElement CheckAvailBalance;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Apply')]")]
        private IWebElement ApplyButton;       

       
        [FindsBy(How = How.Id, Using = "paymentGateway")]
        private IWebElement paymentFrame;


        // [FindsBy(How = How.XPath, Using = "//*[@id='cardNumber']")]
        [FindsBy(How = How.Id, Using = "number")]
        private IWebElement CardNumber;

        //*[@id="expirationMonth"] newCreditCardForm-expiryDateMonth

        // [FindsBy(How = How.XPath, Using = "//*[@id='expirationMonth']")]
        [FindsBy(How = How.Id, Using = "expirationMonth")]
        private IWebElement ExpiryMonth;

        //*[@id="expirationYear"] newCreditCardForm-expiryDateYear
        // [FindsBy(How = How.XPath, Using = "//*[@id='expirationYear']")]
        [FindsBy(How = How.Id, Using = "expirationYear")]
        private IWebElement ExpiryYear;

        //*[@id="cardHolderName"] newCreditCardForm-name
        //[FindsBy(How = How.Id, Using = "cardHolderName")]
        //[FindsBy(How = How.XPath, Using = "//*[@id='cardHolderName']")]
        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement NameOnCard;


        //*[@id="securityCode"] newCreditCardForm-cvv

        // [FindsBy(How = How.XPath, Using = "//*[@id='securityCode']")]
        [FindsBy(How = How.Id, Using = "securityCode")]
        private IWebElement CVV;

        [FindsBy(How = How.XPath, Using = "//*[@id='billingCardForm-cvv']")]
        private IWebElement BillingCVV;

        //*[@id="tabpanel-delivery"]/form/button //*[@id="tabpanel-delivery"]/form/button   newCreditCard-checkbox
        //[FindsBy(How = How.Id, Using = "//button[@data-test='pay-securely-button']")]
        //private IWebElement SaveCard;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='pay-securely-button']")]
        private IWebElement SaveCard;

        [FindsBy(How = How.Name, Using = "useBillingAsShipping")]
        private IWebElement UseBillingAsShipping;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='checkout-continue']")]
        private IWebElement PaySecurely;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='pay-securely-button']")]
        private IWebElement PaySecurelyNow;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='checkout-continue']")]
        private IWebElement ContinueToPayment;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='header-secureCheckout']")]
        private IWebElement SecureCheckoutHeader;
       
        [FindsBy(How = How.XPath, Using = "//h2[@data-test='secure-payment-title']")]
        private IWebElement SecurePaymentHeader;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'New Customer')]")]
        private IWebElement NewCustomer;

        [FindsBy(How = How.XPath, Using = "//span[@data-test='input-error']")]
        private IWebElement PaymentError;


        [FindsBy(How = How.XPath, Using = "//button[@data-test='deliveryAddresses-useAnotherAddressButton']")]
        private IWebElement UseADifferentAddress;

        [FindsBy(How = How.XPath, Using = "//input[@name='selectedAddressId' and @value='new']")]
        private IWebElement AddNewAddress;

        [FindsBy(How = How.XPath, Using = "//label[text()='Add New Card']")]
        private IWebElement AddNewCard;

        [FindsBy(How = How.Id, Using = "loginForm-email")]
        private IWebElement loginEmail;

        [FindsBy(How = How.Id, Using = "loginForm-password")]
        private IWebElement loginPassword;
        #endregion
        [FindsBy(How = How.XPath, Using = "//button[@data-test='loginForm-submitButton']")]
        private IWebElement Login2;

        [FindsBy(How = How.Id, Using = "tab-click-and-collect")]
        private IWebElement ClickCollect;

        [FindsBy(How = How.XPath, Using = "(//span[text()='Is this order a gift?']/following::input)[2]")]
        private IWebElement IsaGift;        

        [FindsBy(How = How.Id, Using = "giftForm-message")]
        private IWebElement GiftFormMessage;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='notification-alert']//div")]
        private IWebElement NotificationAlert;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Nominated Day Delivery')]//parent::p/parent::span//preceding-sibling::input")]
        private IWebElement rbtnNDD;

        #region Events  
        public void ClickandCollect(string storeAddress)
        {
           
            BrowserDriver.Sleep(10000);

            WebHandlers.Instance.ClickByJsExecutor(ClickCollect);

            WebHandlers.Instance.WaitForPageLoad();
            BrowserDriver.Sleep(8000);
            
           // IWebElement SelectStoreAddress = WebHandlers.Instance.GetElement(driver, By.XPath("//*[@id='tabpanel-click-and-collect']//div[contains(@class,'css-nt1nfi e7iljr68') and contains(text(), '" + storeAddress + "')]/parent::div/following-sibling::div/button[text()='Select']"));
            IWebElement SelectStoreAddress = WebHandlers.Instance.GetElement(driver, By.XPath("//*[@id='tabpanel-click-and-collect']//div[contains(@class,'css-1lvozf7 e7iljr61')]//P[contains(text(),'" + storeAddress + "')]//parent::div//following-sibling::section//div//button[text()='Select']"));
            WebHandlers.Instance.Click(SelectStoreAddress, "Click and Collect");

            WebHandlers.Instance.WaitForPageLoad();

        }

        public void SetGiftMessage(string message)
        {
            WebHandlers.Instance.Click(IsaGift, "Its a gift");
            BrowserDriver.Sleep(3000);

            WebHandlers.Instance.EnterText(GiftFormMessage, message, $"Entered gift message as {message}");
            
        }

        public void EnterShippingAddressAsGuest(Dictionary<string, List<string>> customerdetails, Dictionary<string, string> TCDataDictionary, Dictionary<string, string> PostalAddress = null)
        {
            string title = customerdetails["Title"][0];
            string firstName = customerdetails["FirstName"][0];
            string lastName = customerdetails["LastName"][0];
            string email = customerdetails["Email"][0];
            string cellphone = customerdetails["CellPhone"][0];

            string country = TCDataDictionary["Country"];
            string postcode = TCDataDictionary["PostCode"];

            WebHandlers.Instance.ClickByJsExecutor(NewCustomer);

            //BrowserDriver.Sleep(6000);

            //if (WebHandlers.Instance.WebElementExists(UseADifferentAddress))
            //{
            //    WebHandlers.Instance.ClickByJsExecutor(UseADifferentAddress);

            //    if (WebHandlers.Instance.WebElementExists(AddNewAddress))
            //    {
            //        WebHandlers.Instance.Click(AddNewAddress);
            //    }

            //}
            BrowserDriver.Sleep(2000);

            WebHandlers.Instance.EnterText(GuestFirstName, firstName, $"Entered First Name as {firstName}");
            WebHandlers.Instance.EnterText(GuestLastName, lastName, $"Entered Last Name as {lastName}");
            WebHandlers.Instance.EnterText(GuestContactPhone, cellphone, $"Entered Contact Phone Number as {cellphone}");
            WebHandlers.Instance.EnterText(GuestContactEmail, email, $"Entered Contact Email as {email}");
            WebHandlers.Instance.MultiSelectByText(GuestCountrySelect, country, $"Select Country");

            BrowserDriver.Sleep(2000);

            bool searchAddress = false;
            if (WebHandlers.Instance.WebElementExists(AddressInput) && searchAddress)
            {
                WebHandlers.Instance.EnterText(AddressInput, postcode, $"Entered Postcode as {postcode}");

                int attempts = 1;
                while (AddressSelect == null && attempts <= 4)
                {
                    BrowserDriver.Sleep(5000);
                    attempts++;
                }
                //Time to load items in dropdown
                BrowserDriver.Sleep(5000);

                if (AddressSelect == null)
                    Assert.Fail("Address lookup not loaded");


                WebHandlers.Instance.DropDownSetByIndex(AddressSelect, 1);
            }
            else
            {
                if (PostalAddress.Count > 0)
                {
                    string addressLine1 = PostalAddress["AddressLine1"].ToString();
                    string addressLine2 = PostalAddress["AddressLine2"].ToString();
                    string addressLine3 = PostalAddress["AddressLine3"].ToString();
                    string city = PostalAddress["City"].ToString();
                    string state = PostalAddress["State"].ToString();
                    string country1 = PostalAddress["Country"].ToString();
                    string postalCode = PostalAddress["Postcode"].ToString();
                    WebHandlers.Instance.EnterText(AddressLine1, addressLine1, $"Entered Address Line1 as {addressLine1}");
                    if (addressLine2 != string.Empty)
                        WebHandlers.Instance.EnterText(AddressLine2, addressLine2, $"Entered Last Name as {addressLine2}");
                    if (addressLine2 != string.Empty)
                        WebHandlers.Instance.EnterText(AddressLine3, addressLine3, $"Entered First Name as {addressLine3}");
                    WebHandlers.Instance.EnterText(CityAddress, city, $"Entered City Name as {city}");

                    if (WebHandlers.Instance.WebElementExists(input_StateAddress))
                        WebHandlers.Instance.EnterText(input_StateAddress, state, $"Entered State Name as {state}");

                    if (WebHandlers.Instance.WebElementExists(select_StateAddress))
                        WebHandlers.Instance.MultiSelectByText(select_StateAddress, state, $"Entered State Name as {state}");

                    if (WebHandlers.Instance.WebElementExists(AddressZipCode))
                        WebHandlers.Instance.EnterText(AddressZipCode, postalCode, $"Entered Postalcode as {postalCode}");

                }
                else
                {
                    Assert.Fail("Postal Address not mentioned.");
                    return;
                }

            }


            WebWaitHelper.Instance.WaitForElementPresence(ContinueToPayment);
            log.Info("Continue to payment");
            WebHandlers.Instance.ClickByJsExecutor(ContinueToPayment);

        }

        public void EnterShippingAddressAsGuest(Dictionary<string, string> customerdetails)
        {
            string firstName = customerdetails["FirstName"];
            string email = customerdetails["Email"];
            string cellphone = customerdetails["CellPhone"];
            string country = "United Kingdom", postcode = "LE14";

            Dictionary<string, string> PostalAddress = new Dictionary<string, string>(){
                    { "AddressLine1" , "102 Brompton Rd"} , { "AddressLine2", "" } , { "AddressLine3", "" },
                    { "City", "Ab Kettleby" }, { "State", "England" }, { "Country", "United Kingdom" }, { "Postcode", "LE14" }
                };


            WebHandlers.Instance.ClickByJsExecutor(NewCustomer);
            BrowserDriver.Sleep(5000);

            WebHandlers.Instance.EnterText(GuestFirstName, firstName, $"Entered First Name as {firstName}");
            WebHandlers.Instance.EnterText(GuestLastName, firstName+"Lname", $"Entered Last Name");
            WebHandlers.Instance.EnterText(GuestContactPhone, cellphone, $"Entered Contact Phone Number as {cellphone}");
            WebHandlers.Instance.EnterText(GuestContactEmail, email, $"Entered Contact Email as {email}");
            WebHandlers.Instance.MultiSelectByText(GuestCountrySelect, country, $"Select Country");
            BrowserDriver.Sleep(2000);

            bool searchAddress = false;
            if (WebHandlers.Instance.WebElementExists(AddressInput) && searchAddress)
            {
                WebHandlers.Instance.EnterText(AddressInput, postcode, $"Entered Postcode as {postcode}");

                int attempts = 1;
                while (AddressSelect == null && attempts <= 4)
                {
                    BrowserDriver.Sleep(5000);
                    attempts++;
                }
                //Time to load items in dropdown
                BrowserDriver.Sleep(5000);

                if (AddressSelect == null)
                    Assert.Fail("Address lookup not loaded");


                WebHandlers.Instance.DropDownSetByIndex(AddressSelect, 1);
            }
            else
            {
                BrowserDriver.Sleep(3000);
                WebHandlers.Instance.Click(driver.FindElement(By.XPath("//*[text()='Or Enter Address Manually']")));
                if (PostalAddress.Count > 0)
                {
                    string addressLine1 = PostalAddress["AddressLine1"].ToString();
                    string addressLine2 = PostalAddress["AddressLine2"].ToString();
                    string addressLine3 = PostalAddress["AddressLine3"].ToString();
                    string city = PostalAddress["City"].ToString();
                    string state = PostalAddress["State"].ToString();
                    string country1 = PostalAddress["Country"].ToString();
                    string postalCode = PostalAddress["Postcode"].ToString();
                    WebHandlers.Instance.EnterText(AddressLine1, addressLine1, $"Entered Address Line1 as {addressLine1}");
                    if (addressLine2 != string.Empty)
                        WebHandlers.Instance.EnterText(AddressLine2, addressLine2, $"Entered Last Name as {addressLine2}");
                    if (addressLine2 != string.Empty)
                        WebHandlers.Instance.EnterText(AddressLine3, addressLine3, $"Entered First Name as {addressLine3}");
                    WebHandlers.Instance.EnterText(CityAddress, city, $"Entered City Name as {city}");

                    if (WebHandlers.Instance.WebElementExists(input_StateAddress))
                        WebHandlers.Instance.EnterText(input_StateAddress, state, $"Entered State Name as {state}");

                    if (WebHandlers.Instance.WebElementExists(select_StateAddress))
                        WebHandlers.Instance.MultiSelectByText(select_StateAddress, state, $"Entered State Name as {state}");

                    if (WebHandlers.Instance.WebElementExists(AddressZipCode))
                        WebHandlers.Instance.EnterText(AddressZipCode, postalCode, $"Entered Postalcode as {postalCode}");

                }
                else
                {
                    Assert.Fail("Postal Address not mentioned.");
                    return;
                }

            }


            WebWaitHelper.Instance.WaitForElementPresence(ContinueToPayment);
            log.Info("Continue to payment");
            WebHandlers.Instance.ClickByJsExecutor(ContinueToPayment);

        }

        public void BillingAddressForExistingCustomer(Dictionary<string, List<string>> customerdetails, Dictionary<string, string> TCDataDictionary, Dictionary<string, string> PostalAddress = null)
        {
            BrowserDriver.Sleep(3000);
            string postcode = TCDataDictionary["PostCode"];

            try
            {
                TAFHooks.ApplicationCache.OrderType = TCDataDictionary["Country"];                               
                IWebElement ExistingAddress = WebHandlers.Instance.GetElement(driver, By.XPath("//span[@class='css-927zz9 e1erjc445' and contains(text(),'" + postcode + "')]/parent::span/preceding-sibling::input"));
                
                BrowserDriver.Sleep(5000);
                WebHandlers.Instance.Click(ExistingAddress);
            }
            catch (NoSuchElementException)
            {
                
                  AddNewAddressOfCustomer(customerdetails, TCDataDictionary, PostalAddress);                   

            }                   

        }
        public void ShippingAddressForExistingCustomer(Dictionary<string, List<string>> customerdetails,  Dictionary<string, string> TCDataDictionary, Dictionary<string, string> PostalAddress = null)
        {
            BrowserDriver.Sleep(3000);
            string postcode = TCDataDictionary["PostCode"];

            try
            {
                TAFHooks.ApplicationCache.OrderType = TCDataDictionary["Country"];          
                IWebElement ExistingAddress = WebHandlers.Instance.GetElement(driver, By.XPath("//p[@data-test='deliveryAddresses-fullAddress' and contains(text(),'" + postcode + "')]/parent::div/preceding-sibling::input"));
               
                BrowserDriver.Sleep(5000);
                WebHandlers.Instance.Click(ExistingAddress);
            }
            catch (NoSuchElementException)
            { 
                if (WebHandlers.Instance.WebElementExists(UseADifferentAddress))
                {
                    WebHandlers.Instance.ClickByJsExecutor(UseADifferentAddress);

                    try
                    {
                        TAFHooks.ApplicationCache.OrderType = TCDataDictionary["Country"];
                        IWebElement ExistingAddress = WebHandlers.Instance.GetElement(driver, By.XPath("//p[@data-test='deliveryAddresses-fullAddress' and contains(text(),'" + postcode + "')]/parent::div/preceding-sibling::input"));
                        BrowserDriver.Sleep(5000);
                        WebHandlers.Instance.Click(ExistingAddress);
                    }
                    catch(NoSuchElementException)
                    {
                        AddNewAddressOfCustomer(customerdetails, TCDataDictionary, PostalAddress);
                    }                 

                }
                else if(WebHandlers.Instance.WebElementExists(AddNewAddress))
                {
                    AddNewAddressOfCustomer(customerdetails, TCDataDictionary, PostalAddress);
                }

     
            }                  
            
        }

        public void AddNewAddressOfCustomer(Dictionary<string, List<string>> customerdetails, Dictionary<string, string> TCDataDictionary, Dictionary<string, string> PostalAddress = null)
        {

            string title = customerdetails["Title"][0];
            string firstName = customerdetails["FirstName"][0];
            string lastName = customerdetails["LastName"][0];
            string email = customerdetails["Email"][0];
            string cellphone = customerdetails["CellPhone"][0];

            string country = TCDataDictionary["Country"];
            string postcode = TCDataDictionary["PostCode"];
            if (WebHandlers.Instance.WebElementExists(AddNewAddress))
            {
                WebHandlers.Instance.Click(AddNewAddress);

                BrowserDriver.Sleep(2000);

                WebHandlers.Instance.EnterText(FirstName, firstName, $"Entered First Name as {firstName}");
                WebHandlers.Instance.EnterText(LastName, lastName, $"Entered Last Name as {lastName}");
                WebHandlers.Instance.EnterText(ContactPhone, cellphone, $"Entered Contact Phone Number as {cellphone}");
                WebHandlers.Instance.MultiSelectByText(CountrySelect, country, $"Select Country");
                TAFHooks.ApplicationCache.OrderType = country;
                BrowserDriver.Sleep(2000);

                bool searchAddress = false;
                if (WebHandlers.Instance.WebElementExists(checkAddressLine1Searchable) && searchAddress)
                {
                    WebHandlers.Instance.EnterText(AddressInput, postcode, $"Entered Postcode as {postcode}");

                    int attempts = 0;
                    while (AddressSelect == null && attempts <= 2)
                    {
                        BrowserDriver.Sleep(4000);
                        attempts++;
                    }

                    BrowserDriver.Sleep(10000);
                    WebHandlers.Instance.DropDownSetByIndex(AddressSelect, 1);
                }
                else
                {
                    if (PostalAddress.Count > 0)
                    {
                        string addressLine1 = PostalAddress["AddressLine1"].ToString();
                        string addressLine2 = PostalAddress["AddressLine2"].ToString();
                        string addressLine3 = PostalAddress["AddressLine3"].ToString();
                        string city = PostalAddress["City"].ToString();
                        string state = PostalAddress["State"].ToString();
                        string country1 = PostalAddress["Country"].ToString();
                        string postalCode = PostalAddress["Postcode"].ToString();

                        TAFHooks.ApplicationCache.OrderType = country1;
                        WebHandlers.Instance.EnterText(newAddressLine1, addressLine1, $"Entered Address Line1 as {addressLine1}");
                        if (addressLine2 != string.Empty)
                            WebHandlers.Instance.EnterText(newAddressLine2, addressLine2, $"Entered Last Name as {addressLine2}");
                        if (addressLine2 != string.Empty)
                            WebHandlers.Instance.EnterText(newAddressLine3, addressLine3, $"Entered First Name as {addressLine3}");
                        WebHandlers.Instance.EnterText(newCityAddress, city, $"Entered City Name as {city}");

                        if (WebHandlers.Instance.WebElementExists(input_newStateAddress))
                            WebHandlers.Instance.EnterText(input_newStateAddress, state, $"Entered State Name as {state}");

                        if (WebHandlers.Instance.WebElementExists(select_newStateAddress))
                            WebHandlers.Instance.MultiSelectByText(select_newStateAddress, state, $"Entered State Name as {state}");

                        if (WebHandlers.Instance.WebElementExists(checkAddressZipCode))
                            WebHandlers.Instance.EnterText(newAddressZipCode, postalCode, $"Entered Postalcode as {postalCode}");

                    }
                    else
                    {
                        Assert.Fail("Postal Address not mentioned.");
                        return;
                    }
                }
            }
        }
        
        public void AddPaymentForGuest(Dictionary<string, string> CardDataDictionary)
        {
            ValidateSecureCardPaymentPage();
            AddPaymentDetails(CardDataDictionary);          
        }

        public void CompletePaymentForGuest()
        {
            WebWaitHelper.Instance.WaitForElementPresence(PaySecurelyNow);
            WebHandlers.Instance.ClickByJsExecutor(PaySecurelyNow);
        }

        public void AddPaymentForResgisteredOrExisiting(Dictionary<string, string> CardDataDictionary)
        {
            WebWaitHelper.Instance.WaitForElementPresence(paymentFrame);
            WebHandlers.Instance.SwitchToFrame(paymentFrame);
            BrowserDriver.Sleep(3000);

            WebHandlers.Instance.EnterText(CardNumber, CardDataDictionary["CardNumber"]);
            WebHandlers.Instance.MultiSelectByText(ExpiryMonth, CardDataDictionary["CardExpiryMonth"]);
            WebHandlers.Instance.MultiSelectByText(ExpiryYear, CardDataDictionary["CardExpiryYear"]);
            WebHandlers.Instance.EnterText(NameOnCard, CardDataDictionary["CardName"]);
            WebHandlers.Instance.EnterText(CVV, CardDataDictionary["CardCVV"]);
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);
            WebWaitHelper.Instance.WaitForElementPresence(PaySecurely);
            WebHandlers.Instance.ClickByJsExecutor(PaySecurely);
        }

        public void CompletePaymentForReg()
        {
            WebHandlers.Instance.ClickByJsExecutor(PaySecurely);
        }

        public void AddPaymentDetails(Dictionary<string,string> carddetails)
        {
            WebWaitHelper.Instance.WaitForElementPresence(paymentFrame);
           
            WebHandlers.Instance.SwitchToFrame(paymentFrame);
                         
            BrowserDriver.Sleep(2000);
            switch (carddetails["CardType"].ToUpper())
            {
                case "GIFTCARD":
                    WebHandlers.Instance.ClickByJsExecutor(HarrodsGiftCardCheckbox);
                    WebWaitHelper.Instance.WaitForElementPresence(GiftCardNumber);
                    string cardNumber = carddetails["CardNumber"].Decrypt();
                    WebHandlers.Instance.EnterText(GiftCardNumber, cardNumber);
                    TAFHooks.ApplicationCache.CardNumber ="ending " + cardNumber.Substring(cardNumber.Length - 4);
                    
                    WebHandlers.Instance.EnterText(GiftCardPinNumber, carddetails["SecurityCode"].Decrypt());
                    WebHandlers.Instance.ClickByJsExecutor(CheckAvailBalance);
                    if(WebHandlers.Instance.ElementPresent(ApplyButton))
                    WebHandlers.Instance.ClickByJsExecutor(ApplyButton);
                    else
                        Assert.Fail($"Apply Button is not available to click");
                    
                    break;
                default:
                    {
                        WebWaitHelper.Instance.WaitForElementPresence(CardNumber);
                        string cardNumber1 = carddetails["CardNumber"];
                        WebHandlers.Instance.EnterText(CardNumber, cardNumber1);
                        TAFHooks.ApplicationCache.CardNumber = "ending " + cardNumber1.Substring(cardNumber1.Length - 4);
                       
                        WebHandlers.Instance.MultiSelectByText(ExpiryMonth, carddetails["CardExpiryMonth"]);
                        WebHandlers.Instance.MultiSelectByText(ExpiryYear, carddetails["CardExpiryYear"]);
                        WebHandlers.Instance.EnterText(NameOnCard, carddetails["CardName"]);
                        WebHandlers.Instance.EnterText(CVV, carddetails["CardCVV"]);
                    }
                    break;
            }

            WebHandlers.Instance.SwithBackFromFrame();

            log.Info("Added card details");

            BrowserDriver.Sleep(2000);
            if (WebHandlers.Instance.WebElementExists(SaveCard))
            {
                if (WebHandlers.Instance.ChkboxIsChecked(SaveCard, "SaveCardCheckBox"))
                    WebHandlers.Instance.ClickByJsExecutor(SaveCard);
            }
                
        }


        public void UseDeliveryAsShippingAddress()
        {
            if (!WebHandlers.Instance.ChkboxIsChecked(UseBillingAsShipping))
                WebHandlers.Instance.ClickByJsExecutor(UseBillingAsShipping);
        }


        public void EnterAddressForCustomer(Dictionary<string, string> CustomerData)
        {
            Dictionary<string, string> PostalAddress = new Dictionary<string, string>(){
                    { "AddressLine1" , "102 Brompton Rd"} , { "AddressLine2", "" } , { "AddressLine3", "" },
                    { "City", "Ab Kettleby" }, { "State", "England" }, { "Country", "United Kingdom" }, { "Postcode", "LE14" }
                };
            string firstName = CustomerData["UserName"];
            string lastName = firstName + "Lname";
            string cellphone = CustomerData["Phone"];


            if (WebHandlers.Instance.WebElementExists(AddNewAddress))
            {
                WebHandlers.Instance.Click(AddNewAddress);

                BrowserDriver.Sleep(2000);

                WebHandlers.Instance.EnterText(FirstName, firstName, $"Entered First Name as {firstName}");
                WebHandlers.Instance.EnterText(LastName, lastName, $"Entered Last Name as {lastName}");
                WebHandlers.Instance.EnterText(ContactPhone, cellphone, $"Entered Contact Phone Number as {cellphone}");
                WebHandlers.Instance.MultiSelectByText(CountrySelect, PostalAddress["Country"], $"Select Country");
                TAFHooks.ApplicationCache.OrderType = PostalAddress["Country"];
                BrowserDriver.Sleep(2000);

                bool searchAddress = false;
                if (WebHandlers.Instance.WebElementExists(checkAddressLine1Searchable) && searchAddress)
                {
                    WebHandlers.Instance.EnterText(AddressInput, PostalAddress["Postcode"], $"Entered Postcode");

                    int attempts = 0;
                    while (AddressSelect == null && attempts <= 2)
                    {
                        BrowserDriver.Sleep(4000);
                        attempts++;
                    }

                    BrowserDriver.Sleep(10000);
                    WebHandlers.Instance.DropDownSetByIndex(AddressSelect, 1);
                }
                else
                {
                    if (PostalAddress.Count > 0)
                    {
                        string addressLine1 = PostalAddress["AddressLine1"].ToString();
                        string addressLine2 = PostalAddress["AddressLine2"].ToString();
                        string addressLine3 = PostalAddress["AddressLine3"].ToString();
                        string city = PostalAddress["City"].ToString();
                        string state = PostalAddress["State"].ToString();
                        string country1 = PostalAddress["Country"].ToString();
                        string postalCode = PostalAddress["Postcode"].ToString();

                        TAFHooks.ApplicationCache.OrderType = country1;
                        WebHandlers.Instance.EnterText(newAddressLine1, addressLine1, $"Entered Address Line1 as {addressLine1}");
                        if (addressLine2 != string.Empty)
                            WebHandlers.Instance.EnterText(newAddressLine2, addressLine2, $"Entered Last Name as {addressLine2}");
                        if (addressLine2 != string.Empty)
                            WebHandlers.Instance.EnterText(newAddressLine3, addressLine3, $"Entered First Name as {addressLine3}");
                        WebHandlers.Instance.EnterText(newCityAddress, city, $"Entered City Name as {city}");

                        if (WebHandlers.Instance.WebElementExists(input_newStateAddress))
                            WebHandlers.Instance.EnterText(input_newStateAddress, state, $"Entered State Name as {state}");

                        if (WebHandlers.Instance.WebElementExists(select_newStateAddress))
                            WebHandlers.Instance.MultiSelectByText(select_newStateAddress, state, $"Entered State Name as {state}");

                        if (WebHandlers.Instance.WebElementExists(checkAddressZipCode))
                            WebHandlers.Instance.EnterText(newAddressZipCode, postalCode, $"Entered Postalcode as {postalCode}");

                    }
                    else
                    {
                        Assert.Fail("Postal Address not mentioned.");
                        return;
                    }
                }
            }
        }


        #endregion

        #region Validation     

        public void ValidateSecureCheckoutPage()
        {
            string header = "Secure checkout";
            
            WebHandlers.Instance.VerifyText(SecureCheckoutHeader, header);

            log.Info("Secure Checkout");
        }

        public void NomainateDeliveryDate(string ndd)
        {
            WebHandlers.Instance.Click(rbtnNDD);
            BrowserDriver.Sleep(6000);

            string[] ddMMyyyy = ndd.Split('/');
            int day =Convert.ToInt32(ddMMyyyy[1]);
            string month = Convert.ToDateTime(ndd).ToString("MMM");
            string monthYear = month + ' ' + ddMMyyyy[2];

            string sDate = Convert.ToDateTime(ndd).ToString("ddd MMM dd yyyy");


            try
            {
              //  IWebElement SelectMonthYear = WebHandlers.Instance.GetElement(driver, By.XPath("//div[text()='" + monthYear + "']"));
                
                //  IWebElement SelectDay = WebHandlers.Instance.GetElement(driver, By.XPath("//span[text()='" + day.ToString() + "']"));
                IWebElement SelectDay = WebHandlers.Instance.GetElement(driver, By.XPath("//div[contains(@class, 'DayPicker-Day') and @aria-label='" + sDate + "']"));
                WebHandlers.Instance.ClickByJsExecutor(SelectDay);
            }
            catch (NoSuchElementException)
            {                
                IWebElement SelectNextMonth = WebHandlers.Instance.GetElement(driver, By.XPath("//button[contains(@class,'e1js263q1 css-fptgu4')]"));
                WebHandlers.Instance.ClickByJsExecutor(SelectNextMonth);

                BrowserDriver.Sleep(5000);
                IWebElement SelectDay = WebHandlers.Instance.GetElement(driver, By.XPath("//div[contains(@class, 'DayPicker-Day') and @aria-label='" + sDate + "']"));
                WebHandlers.Instance.ClickByJsExecutor(SelectDay);
            }

        }

        public void ValidateSecureCardPaymentPage()
        {
            string header = "Secure Card Payment";
            int attempt = 1;
            while (!WebHandlers.Instance.WebElementExists(SecurePaymentHeader) && attempt <=5)
            {
                //Waiting for payment page
                BrowserDriver.Sleep(5000);
                attempt++;
            }
                           
             WebHandlers.Instance.VerifyText(SecurePaymentHeader, header);
           
             
        }
        public void ValidateOrderConfirmationEmail(string portalOrderNumber)
        {
            GoogleApiClient client = new GoogleApiClient(config.EmailRegisteredAppName,
               config.EmailUserName, config.EmailCredentialFilePath);
            client.Connect();

            //List<MailItem> mailItems = client.GetEmailsFromInBox(false, 1, portalOrderNumber);
            RetryEmailSearch(portalOrderNumber, client);
        }

        public void ValidateErrors()
        {

            if (WebHandlers.Instance.WebElementExists(PaymentError))
            {
                List<string> errors = WebHandlers.Instance.GetTextFromMultipleElements(PaymentError);
                if (errors.Any())
                {
                    string msg = errors.Aggregate((i, j) => i + ";" + j);
                    Assert.Fail($"Exception occured while checkout. Error details: " + msg);
                }
            }

        }

        #endregion

        private void RetryEmailSearch(string portalOrderNumber, GoogleApiClient client, int maxRetries = 10, int delayInMilliSeconds = 30000)
        {
            bool isFound = false;
            var attempts = 0;

            while (!isFound)
            {
                List<MailItem> mailItems = client.GetEmailsFromInBox(false, 1, portalOrderNumber);

                if (!mailItems.Any())
                {
                    if (attempts == maxRetries)
                        break;

                    Task.Delay(delayInMilliSeconds).Wait();
                    isFound = false;
                    attempts++;
                }
                else
                {
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
        
                Assert.Fail($"Exception occured while checkout. Error details: No emails found with portal order number : {portalOrderNumber}");
            }
        }
    }
}
