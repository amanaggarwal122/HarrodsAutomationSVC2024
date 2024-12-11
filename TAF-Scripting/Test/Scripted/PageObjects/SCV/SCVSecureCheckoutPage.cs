using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_GenericUtility.Scripted.Email;
using TAF_GenericUtility.Scripted.Security;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects.SCV
{
    public class SCVSecureCheckoutPage
    {
        public IWebDriver driver;
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Configuration config = null;

        #region  Constructor

        public SCVSecureCheckoutPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        public SCVSecureCheckoutPage(Configuration configuration)
        {
            config = configuration;
        }
        #endregion

        #region Elements

        [FindsBy(How = How.XPath, Using = "//*[@id='storm-layout-container']/div[2]/div/div/div/div[2]/div[1]/div/div[1]")]
        private IWebElement collapsePanel_ShippingAddress;
        [FindsBy(How = How.XPath, Using = "//*[@id='storm-layout-container']/div[2]/div/div/div/div[2]/div[1]/div/div[2]")]
        private IWebElement collapsePanel_BillingAddress;
        [FindsBy(How = How.XPath, Using = "//*[@id='storm-layout-container']/div[2]/div/div/div/div[2]/div[1]/div/div[3]")]
        private IWebElement collapsePanel_ShippingMethod;
        [FindsBy(How = How.XPath, Using = "//*[@id='storm-layout-container']/div[2]/div/div/div/div[2]/div[1]/div/div[4]")]
        private IWebElement collapsePanel_PaymentMethod;

        [FindsBy(How = How.XPath, Using = "//div[@id='storm-layout-container']/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/button[1]")]
        private IWebElement linkAddnewAddress;

        [FindsBy(How = How.XPath, Using = "//div[@class='Dropdown-placeholder_-oW5B'][@data-test='country']")]
        private IWebElement countrySearch;
        
        [FindsBy(How = How.XPath, Using = "//input[@class='input_2aAk3'][@data-test='field-firstName'][@name='firstName']")]
        private IWebElement input_FirstName;

        [FindsBy(How = How.XPath, Using = "//input[@class='input_2aAk3'][@data-test='field-lastName'][@name='lastName']")]
        private IWebElement input_LastName;

        [FindsBy(How = How.XPath, Using = "//input[@class='input_2aAk3'][@data-test='field-addressLine1'][@name='addressLine1']")]
        private IWebElement input_StreetLine1;

        [FindsBy(How = How.XPath, Using = "//input[@class='input_2aAk3'][@data-test='field-addressLine2'][@name='addressLine2']")]
        private IWebElement input_StreetLine2;

        [FindsBy(How = How.XPath, Using = "//input[@class='input_2aAk3'][@data-test='field-addressLine3'][@name='addressLine3']")]
        private IWebElement input_StreetLine3;

        [FindsBy(How = How.XPath, Using = "//input[@class='input_2aAk3'][@data-test='field-zipCode'][@name='zipCode']")]
        private IWebElement input_PostCode;
        
        [FindsBy(How = How.XPath, Using = "//input[@class='input_2aAk3'][@data-test='field-phone'][@name='phone']")]
        private IWebElement input_Phone;

        [FindsBy(How = How.XPath, Using = "//input[@class='input_2aAk3'][@data-test='field-state'][@name='state']")]
        private IWebElement input_Muncipality;

        [FindsBy(How = How.XPath, Using = "//input[@class='input_2aAk3'][@data-test='field-city'][@name='city']")]
        private IWebElement input_city;

        [FindsBy(How = How.XPath, Using = "//*[@id='ModalWrapper']/div[2]/div/form/div/div[6]/div[2]/div/div/div/div/div/div[@data-test='field-state']")]
        private IWebElement select_Muncipality;
        
        [FindsBy(How = How.XPath, Using = " //*[@id='ModalWrapper']/div[2]/div/form/div/div[8]/div/div/span/label")]
        private IWebElement clickUseBillingAsShipping;
        [FindsBy(How = How.XPath, Using = "//button[@class='Button_3jwe5 Button--primary_1gh9S Button--autoWidth_2TYMR'][@data-test='button-save']")]
        private IWebElement AddShippingAddress;

        [FindsBy(How = How.XPath, Using = "//*[@id='storm-layout-container']/div[2]/div/div/div/div[2]/div[1]/div/div[3]/div[2]/div/div/div/div[2]/button")]
        private IWebElement apply_ShippingMethod;

        [FindsBy(How = How.XPath, Using = "//*[@id='ModalWrapper']/footer/div/button")]
        private IWebElement CallRecordBlocking;

        [FindsBy(How = How.XPath, Using = "//button[@class='Button_3jwe5 Button--secondary_3Scww Button--autoWidth_2TYMR addNewCard_3QL9t'][@data-test='add-new-card-schema']")]
        private IWebElement AddNewCard;
        [FindsBy(How = How.XPath, Using = "//div[@id='ModalWrapper']/div[2]/div[1]/form[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]")]
        private IWebElement div_CardType;
        [FindsBy(How = How.Id, Using = "cardNumber")]
        private IWebElement input_CardNumber;
        [FindsBy(How = How.Id, Using = "cardHolderName")]
        private IWebElement input_NameOnCard;
        [FindsBy(How = How.Id, Using = "cardCvv")]
        private IWebElement input_SecurityCode;
        [FindsBy(How = How.XPath, Using = "//div[@id='ModalWrapper']/div[2]/div[1]/form[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]")]
        private IWebElement div_month;  
        [FindsBy(How = How.XPath, Using = "//div[@id='ModalWrapper']/div[2]/div[1]/form[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]")]
        private IWebElement div_Year;
        [FindsBy(How = How.XPath, Using = "//*[@id='ModalWrapper']/footer/div/button")]
        private IWebElement submitNewCard;

        [FindsBy(How = How.XPath, Using = "//button[@class='Button_3jwe5 Button--secondary_3Scww Button--autoWidth_2TYMR addNewCard_3QL9t'][@data-test='add-new-gift-card']")]
        private IWebElement AddGiftCard;
        [FindsBy(How = How.Id, Using = "giftCardNumber")]
        private IWebElement input_giftCardNumber;
        [FindsBy(How = How.Id, Using = "giftCardCsc")]
        private IWebElement input_giftCardCsc;
        [FindsBy(How = How.XPath, Using = "//*[@id='ModalWrapper']/footer/div/button")]
        private IWebElement submitGiftCard;
        [FindsBy(How = How.XPath, Using = "//div[@id='ModalWrapper']/div[2]/div[1]/form[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/label[1]")]
        private IWebElement label_Remember;
        [FindsBy(How = How.XPath, Using = "//button[@class='Button_3jwe5 Button--primary_1gh9S'][@data-test='place-order']")]
        private IWebElement buttonPlaceOrder;
        #endregion

        #region Events  

        public void AddNewAddress()
        {
            BrowserDriver.Sleep(1500);
            string classValue = collapsePanel_ShippingAddress.GetAttribute("class").ToString();
            if (classValue.Contains("isOpen_2L96F"))
            {
                if (WebHandlers.Instance.WebElementExists(linkAddnewAddress))
                    WebHandlers.Instance.ClickByJsExecutor(linkAddnewAddress, "Add new address");
                else
                {
                    Assert.Fail("Option to add new address is not found");
                    log.Error("Option to add new address is not found");
                }
            }
        }

        public void AddNewShippingAddress(Dictionary<string, List<string>> customerDataDictionary, Dictionary<string, string> TCDataDictionary, Dictionary<string, string> PostalAddress = null)
        {
            log.Info("Adding new shipping address");
            WebHandlers.Instance.Click(countrySearch);
            BrowserDriver.Sleep(1000);

           IWebElement selectCountry = WebHandlers.Instance.GetElement(driver, By.XPath("//div[@id='ModalWrapper']/div[2]/div[1]/form[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/ul[1]/li[text()='" + TCDataDictionary["Country"] + "']"));
           // IWebElement selectCountry = WebHandlers.Instance.GetElement(driver, By.XPath("//div[@id='ModalWrapper']/div[2]/div[1]/form[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/ul[1]/li[text()='" + CustomerCountry + "']"));
            WebHandlers.Instance.Click(selectCountry);
            BrowserDriver.Sleep(1000);

            WebHandlers.Instance.EnterTextInModalPopup(input_FirstName, customerDataDictionary["FirstName"][0], $"Entered {customerDataDictionary["FirstName"][0]} for First Name");
            WebHandlers.Instance.EnterTextInModalPopup(input_LastName, customerDataDictionary["LastName"][0], $"Entered {customerDataDictionary["LastName"][0]} for Last Name");

            if (PostalAddress.Count >0)
            {
                string addressLine1 = PostalAddress["AddressLine1"].ToString();
                string addressLine2 = PostalAddress["AddressLine2"].ToString();
                string addressLine3 = PostalAddress["AddressLine3"].ToString();
                string city = PostalAddress["City"].ToString();
                string state = PostalAddress["State"].ToString();
                string country1 = PostalAddress["Country"].ToString();
                string postalCode = PostalAddress["Postcode"].ToString();
                
                WebHandlers.Instance.EnterTextInModalPopup(input_StreetLine1, addressLine1, $"Entered {addressLine1} for StreetLine1");
                if (addressLine2 != string.Empty)
                     WebHandlers.Instance.EnterTextInModalPopup(input_StreetLine2, addressLine2, $"Entered {addressLine2} for StreetLine2");
                if (addressLine2 != string.Empty)
                     WebHandlers.Instance.EnterTextInModalPopup(input_StreetLine3, addressLine3, $"Entered {addressLine3} for StreetLine3");

                WebHandlers.Instance.EnterTextInModalPopup(input_city, city, $"Entered {city} for City");

                if (WebHandlers.Instance.WebElementExists(input_Muncipality))
                     WebHandlers.Instance.EnterTextInModalPopup(input_Muncipality, state, $"Entered {state} for Muncipality");

                if (WebHandlers.Instance.WebElementExists(select_Muncipality))
                {
                    WebHandlers.Instance.Click(select_Muncipality);
                    BrowserDriver.Sleep(1000);
                   
                    IWebElement selectMuncipality = WebHandlers.Instance.GetElement(driver, By.XPath("//*[@id='ModalWrapper']/div[2]/div/form/div/div[6]/div[2]/div/div/div/div/div/div[2]/div/div/div/ul/li[text()='" + state + "']"));
                    WebHandlers.Instance.Click(selectMuncipality);
                    BrowserDriver.Sleep(1000);
                }
                
                if (WebHandlers.Instance.WebElementExists(input_PostCode))
                     WebHandlers.Instance.EnterTextInModalPopup(input_PostCode, postalCode, $"Entered {postalCode} for PostCode");

                WebHandlers.Instance.EnterTextInModalPopup(input_Phone, customerDataDictionary["CellPhone"][0], $"Entered {customerDataDictionary["CellPhone"][0]} for CellPhone");
            }
            else
            {
                Assert.Fail("Postal Address not mentioned.");
                return;
            }






            BrowserDriver.Sleep(1000);

            WebHandlers.Instance.Click(clickUseBillingAsShipping);
            BrowserDriver.Sleep(1000);

            if (WebHandlers.Instance.WebElementExists(AddShippingAddress))
                WebHandlers.Instance.ClickByJsExecutor(AddShippingAddress, "Add new shipping address");
            else
            {
                Assert.Fail("Button to add new shipping address is not present");
                log.Error("Button to add new shipping address is not present");
            }
        }

        public void ApplyShippingMethod()
        {
            log.Info("Adding shipping method");
            BrowserDriver.Sleep(3000);
            string classValue = collapsePanel_ShippingMethod.GetAttribute("class").ToString();
            if (classValue.Contains("isOpen_2L96F"))
            {

                if (WebHandlers.Instance.WebElementExists(apply_ShippingMethod))
                    WebHandlers.Instance.Click(apply_ShippingMethod, "Apply ShippingMethod");
                else
                {
                    Assert.Fail("Button to apply shipping method is not present");
                    log.Error("Button to apply shipping method is not present");
                }
            }
            else
            {
                Assert.Fail("Button to apply shipping method is not present");
                log.Error("Button to apply shipping method is not present");
            }
        }

        public void AddPaymentDetails(Dictionary<string, string> carddetails)
        {
            log.Info("Adding payment details");
            BrowserDriver.Sleep(8000);
            string classValue = collapsePanel_PaymentMethod.GetAttribute("class").ToString();
            if (classValue.Contains("isOpen_2L96F"))
            {
                string cardType = "MC";
                IWebElement selectCardType;
                IWebElement selectMonth;
                IWebElement selectYear;
                string cardNumber;
                switch (carddetails["CardType"].ToUpper())
                {
                    case "GIFTCARD":
                        log.Info("Selected gift card");
                        WebHandlers.Instance.ClickByJsExecutor(AddGiftCard);
                        BrowserDriver.Sleep(1000);

                        if (WebHandlers.Instance.ElementPresent(CallRecordBlocking))
                            WebHandlers.Instance.ClickByJsExecutor(CallRecordBlocking);


                        WebWaitHelper.Instance.WaitForElementPresence(input_giftCardNumber);
                        cardNumber = carddetails["CardNumber"].Decrypt();
                        cardNumber = cardNumber.Replace(" ", "");
                        WebHandlers.Instance.EnterText(input_giftCardNumber, cardNumber);
                        WebHandlers.Instance.EnterText(input_giftCardCsc, carddetails["SecurityCode"].Decrypt());
                        BrowserDriver.Sleep(1000);
                        if (WebHandlers.Instance.ElementPresent(submitGiftCard))
                            WebHandlers.Instance.ClickByJsExecutor(submitGiftCard);
                        else
                            Assert.Fail($"Submit Button is not available to click");

                        break;
                    case "MASTERCARD":
                        log.Info("Selected master card");
                        WebHandlers.Instance.ClickByJsExecutor(AddNewCard);
                        BrowserDriver.Sleep(1000);

                        if (WebHandlers.Instance.ElementPresent(CallRecordBlocking))
                            WebHandlers.Instance.ClickByJsExecutor(CallRecordBlocking);

                        WebHandlers.Instance.Click(div_CardType);
                        selectCardType = WebHandlers.Instance.GetElement(driver, By.XPath("//*[@id='ModalWrapper']/div[2]/div/form/div/div/div[1]/div[1]/div/div/div/div/div/div[2]/div/div/div/ul/li[text()='" + cardType + "']"));
                        BrowserDriver.Sleep(1000);
                        WebHandlers.Instance.Click(selectCardType);
                        WebHandlers.Instance.EnterTextInModalPopup(input_NameOnCard, carddetails["NameOnCard"].Decrypt());
                        cardNumber = carddetails["CardNumber"].Decrypt();
                        cardNumber = cardNumber.Replace(" ", "");
                        WebHandlers.Instance.EnterTextInModalPopup(input_CardNumber, cardNumber);

                        WebHandlers.Instance.Click(div_month);
                        selectMonth = WebHandlers.Instance.GetElement(driver, By.XPath("//*[@id='ModalWrapper']/div[2]/div/form/div/div/div[2]/div[2]/div/div[1]/div/div/div/div/div/div[2]/div/div/div/ul/li[text()='" + carddetails["ExpiryMonth"].Decrypt() + "']"));
                        BrowserDriver.Sleep(1000);
                        WebHandlers.Instance.Click(selectMonth);

                        WebHandlers.Instance.Click(div_Year);
                        selectYear = WebHandlers.Instance.GetElement(driver, By.XPath("//*[@id='ModalWrapper']/div[2]/div/form/div/div/div[2]/div[2]/div/div[2]/div/div/div/div/div/div[2]/div/div/div/ul/li[text()='" + carddetails["ExpiryYear"].Decrypt() + "']"));
                        BrowserDriver.Sleep(1000);
                        WebHandlers.Instance.Click(selectYear);

                        WebHandlers.Instance.EnterTextInModalPopup(input_SecurityCode, carddetails["SecurityCode"].Decrypt());
                        BrowserDriver.Sleep(1000);
                        if (WebHandlers.Instance.ElementPresent(submitNewCard))
                            WebHandlers.Instance.ClickByJsExecutor(submitNewCard);
                        else
                            Assert.Fail($"Submit Button is not available to click");

                        break;
                    default:
                        {
                            WebHandlers.Instance.ClickByJsExecutor(AddNewCard);
                            BrowserDriver.Sleep(1000);

                            if (WebHandlers.Instance.ElementPresent(CallRecordBlocking))
                                WebHandlers.Instance.ClickByJsExecutor(CallRecordBlocking);

                            WebHandlers.Instance.Click(div_CardType);
                            selectCardType = WebHandlers.Instance.GetElement(driver, By.XPath("//*[@id='ModalWrapper']/div[2]/div/form/div/div/div[1]/div[1]/div/div/div/div/div/div[2]/div/div/div/ul/li[text()='" + cardType + "']"));
                            BrowserDriver.Sleep(1000);
                            WebHandlers.Instance.Click(selectCardType);
                            WebHandlers.Instance.EnterTextInModalPopup(input_NameOnCard, carddetails["NameOnCard"].Decrypt());
                            cardNumber = carddetails["CardNumber"].Decrypt();
                            cardNumber = cardNumber.Replace(" ", "");
                            WebHandlers.Instance.EnterTextInModalPopup(input_CardNumber, cardNumber);

                            WebHandlers.Instance.Click(div_month);
                            selectMonth = WebHandlers.Instance.GetElement(driver, By.XPath("//*[@id='ModalWrapper']/div[2]/div/form/div/div/div[2]/div[2]/div/div[1]/div/div/div/div/div/div[2]/div/div/div/ul/li[text()='" + carddetails["ExpiryMonth"].Decrypt() + "']"));
                            BrowserDriver.Sleep(1000);
                            WebHandlers.Instance.Click(selectMonth);

                            WebHandlers.Instance.Click(div_Year);
                            selectYear = WebHandlers.Instance.GetElement(driver, By.XPath("//*[@id='ModalWrapper']/div[2]/div/form/div/div/div[2]/div[2]/div/div[2]/div/div/div/div/div/div[2]/div/div/div/ul/li[text()='" + carddetails["ExpiryYear"].Decrypt() + "']"));
                            BrowserDriver.Sleep(1000);
                            WebHandlers.Instance.Click(selectYear);

                            WebHandlers.Instance.EnterTextInModalPopup(input_SecurityCode, carddetails["SecurityCode"].Decrypt());
                            BrowserDriver.Sleep(2000);
                            if (WebHandlers.Instance.ElementPresent(submitNewCard))
                                WebHandlers.Instance.ClickByJsExecutor(submitNewCard);
                            else
                                Assert.Fail($"Submit Button is not available to click");
                        }
                        break;
                }
            }
            else
            {
                Assert.Fail("Option to apply payment method is not found");
                log.Error("Option to apply payment method is not found");
            }

        }

        public void placeOrder()
        {
            log.Info("Placing the order");
            BrowserDriver.Sleep(1000);
            if (WebHandlers.Instance.WebElementExists(buttonPlaceOrder))
                WebHandlers.Instance.ClickByJsExecutor(buttonPlaceOrder, "Place Order");
            else
            {
                Assert.Fail("Button to place the order is not present");
                log.Error("Button to place the order is not present");
            }

        }
        #endregion

        public void ValidateOrderConfirmationEmail(string portalOrderNumber)
        {
            GoogleApiClient client = new GoogleApiClient(config.EmailRegisteredAppName,
               config.EmailUserName, config.EmailCredentialFilePath);
            client.Connect();

            //List<MailItem> mailItems = client.GetEmailsFromInBox(false, 1, portalOrderNumber);
            RetryEmailSearch(portalOrderNumber, client);
        }

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
