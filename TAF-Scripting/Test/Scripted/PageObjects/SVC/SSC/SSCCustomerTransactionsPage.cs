using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCCustomerTransactionsPage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public SSCCustomerTransactionsPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements
        #endregion

        #region Events
        #endregion
    }
}
