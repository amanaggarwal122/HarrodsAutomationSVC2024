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
    public class SearchCustomerPage
    {
        public IWebDriver driver;

        #region  Constructor

        public SearchCustomerPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        #endregion

        #region Elements		

        [FindsBy(How = How.Id, Using = "Customersearch1_ctl11_txtControl")]
        private IWebElement SearchEmail;

        [FindsBy(How = How.Id, Using = "Customersearch1_btnSearch")]
        private IWebElement SearchButton;

        [FindsBy(How = How.Id, Using = "frmMain")]
        private IWebElement MainFrame;


        [FindsBy(How = How.Id, Using = "Customersearch1_errorLabel")]
        private IWebElement ErrorText;

        #endregion

        #region Events 

        public void SearchRegisteredCustomer(string searchEmail)
        {
            WebHandlers.Instance.SwitchToFrame(MainFrame);

            WebHandlers.Instance.EnterText(SearchEmail, searchEmail);
            WebHandlers.Instance.Click(SearchButton);

            string NoCustomerFoundErrorText = "No results returned for this search criteria";
            if (WebHandlers.Instance.WebElementExists(ErrorText))
                WebHandlers.Instance.CheckForError(ErrorText, NoCustomerFoundErrorText);

            WebHandlers.Instance.SwithBackFromFrame();
        }

        public void GetRewardNumber()
        {

        }

        #endregion

        #region Validation    
        #endregion
    }
}
