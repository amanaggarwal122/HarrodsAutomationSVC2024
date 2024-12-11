using System;

using OpenQA.Selenium;

namespace TAF_Web.Scripted.Web
{
    public class WebAutomationException : Exception
    {

        private const long serialVersionUID = 1L;

        public WebAutomationException(IWebElement webEle, String reason)
            : base(String.Format("Failed on locator %s due to error : %s", webEle, reason))
        {
        }
        public WebAutomationException(IWebElement webEle, String expected, String actual)
            : base(String.Format("Failed on locator %s with expected :  %s  but the actual : %s", webEle, expected, actual))
        {
        }
        public WebAutomationException(Exception ex)
            : base(ex.ToString())
        {
        }
        public WebAutomationException(String message)
            : base(message)
        {
        }
        public WebAutomationException(String message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
