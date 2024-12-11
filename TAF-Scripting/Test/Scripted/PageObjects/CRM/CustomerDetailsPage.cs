using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects
{
    public class CustomerDetailsPage
    {
        public IWebDriver driver;

        #region  Constructor

        public CustomerDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        #endregion

        #region Elements		

        [FindsBy(How = How.Id, Using = "section0_ctl03_lblfield")]
        private IWebElement CustomerName;

        [FindsBy(How = How.Id, Using = "section0_ctl01_lblfield")]
        private IWebElement CustomerId;

        [FindsBy(How = How.Id, Using = "frmMain")]
        private IWebElement MainFrame;

        #endregion

        #region Events 

        #endregion

        #region Validation         

        public void ValidateCustomer(Dictionary<string, List<string>> customerdetails)
        {
            WebHandlers.Instance.SwitchToFrame(MainFrame);

            string title = customerdetails["Title"][0];
            string firstName = customerdetails["FirstName"][0];
            string lastName = customerdetails["LastName"][0];
            string email = customerdetails["Email"][0];

            string textToCompare = $"{title.Remove(title.Length - 1, 1) } {firstName.Trim()} {lastName.Trim()}";

          
            WebHandlers.Instance.VerifyText(CustomerName, textToCompare);

            WebHandlers.Instance.SwithBackFromFrame();

        }

        #endregion
    }
}
