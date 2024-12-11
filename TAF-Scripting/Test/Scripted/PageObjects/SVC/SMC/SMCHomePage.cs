using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SMC
{
    class SMCHomePage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public SMCHomePage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements
        #endregion
        public By SMCSpanContainsText(string text) { return By.XPath("(//span[contains(text(),'" + text + "')])[1]"); }
       // public By SMCSpanContainsText(string text) {return By.XPath("(//span[contains(text(),'Content')])");}

       //TC_182
        public void NavigateToSMCcontentStudio()
        {
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("(//span[contains(text(),'Home')])")));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("(//span[contains(text(),'Content')])")));
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.Click(driver.FindElement(SMCSpanContainsText("Content Studio")));
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("(//span[contains(text(),'Content Studio')])")));
            BrowserDriver.Sleep(3000);
        }

        public void SearchandInsertImageToSMCcontentStudio()
        {
            //click on template available
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("(//div[@class='sapCntPgPreviewLoader'])[1]")));
            BrowserDriver.Sleep(7000);
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//div[@id='application-CampaignMessage-manage-component---object--DesignView--ContentPage-0-2']")));
            BrowserDriver.Sleep(7000);
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//i[@class='mce-ico mce-i-image']")));
            BrowserDriver.Sleep(7000);
            //click on insert button
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[@aria-label='Show Value Help']")));
            BrowserDriver.Sleep(7000);

            //Note: image uploading need to be implemented // Images not available in Canto

        }
    }
}
