using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCCardManagementRewardCardsPage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public SSCCardManagementRewardCardsPage(IWebDriver driver, Configuration configuration)
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
