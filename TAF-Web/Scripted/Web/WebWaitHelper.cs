using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using ElementCondition = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TAF_Web.Scripted.Web
{
    public class WebWaitHelper
    {
        private static readonly WebWaitHelper _instance = new WebWaitHelper();

        private WebWaitHelper()
        {
        }
        static WebWaitHelper()
        {
        }
        public static WebWaitHelper Instance
        {
            get
            {
                return _instance;
            }
        }

        public Actions action = new Actions(BrowserDriver.GetDriver());

        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TimeSpan GetElementTimeout()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS);
            return timeSpan;
        }

        private TimeSpan GetPollingTimeoutInMilliSeconds()
        {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(WebConstants.ELEMENT_POLLING_MS);
            return timeSpan;
        }

        private DateTime GetPollingTimeoutInDuration()
        {
            DateTime dateTime = new DateTime(0);
            return dateTime.AddMilliseconds(WebConstants.ELEMENT_POLLING_DURATION_MS);
        }

        private TimeSpan GetElementWaitTimeoutInDuration()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS);
            return timeSpan;
        }

        public void WaitForElement(IWebElement webEle, string logMsg="")
        {

            WebDriverWait wait = new WebDriverWait(BrowserDriver.GetDriver(), GetElementWaitTimeoutInDuration());
            Type[] exceptionTypesToIgnore = new Type[] { typeof(NoSuchElementException) };
            wait.IgnoreExceptionTypes(exceptionTypesToIgnore);

            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                try
                {
                    IWebElement element = webEle;
                    By byEle = WebHandlers.Instance.WebElementToBy(webEle);
                    WaitForPresence(byEle, GetElementTimeout());
                    WaitForNotStale(byEle, GetElementTimeout());
                    ScrollToElement(byEle);
                    WaitForVisibleble(byEle, GetElementTimeout());
                    WaitForClickable(byEle, GetElementTimeout());
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    log.Error(e+ "Wait failed for element" + logMsg);
                    throw e;
                }
            });

            wait.Until(waitForElement);

        }

        public void WaitForClear(IWebElement webEle)
        {

            WebDriverWait wait = new WebDriverWait(BrowserDriver.GetDriver(), GetElementWaitTimeoutInDuration());
            Type[] exceptionTypesToIgnore = new Type[] { typeof(NoSuchElementException) };
            wait.IgnoreExceptionTypes(exceptionTypesToIgnore);

            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                try
                {
                    IWebElement element = webEle;
                    By byEle = WebHandlers.Instance.WebElementToBy(webEle);
                    WaitForPresence(byEle, GetElementTimeout());
                    WaitForNotStale(byEle, GetElementTimeout());
                    ScrollToElement(byEle);
                    WaitForVisibleble(byEle, GetElementTimeout());
                    WaitForClickable(byEle, GetElementTimeout());
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    log.Error(e);
                    throw e;
                }
            });

            wait.Until(waitForElement);
        }

        public void WaitForClearModalPopup(IWebElement webEle)
        {

            WebDriverWait wait = new WebDriverWait(BrowserDriver.GetDriver(), GetElementWaitTimeoutInDuration());
            Type[] exceptionTypesToIgnore = new Type[] { typeof(NoSuchElementException) };
            wait.IgnoreExceptionTypes(exceptionTypesToIgnore);

            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                try
                {
                    IWebElement element = webEle;
                    By byEle = WebHandlers.Instance.WebElementToBy(webEle);
                    WaitForPresence(byEle, GetElementTimeout());
                    WaitForNotStale(byEle, GetElementTimeout());
                    WaitForVisibleble(byEle, GetElementTimeout());
                    WaitForClickable(byEle, GetElementTimeout());
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    log.Error(e);
                    throw e;
                }
            });

            wait.Until(waitForElement);
        }
        public void WaitForElePresence(IWebElement webEle)
        {
            WebDriverWait wait = new WebDriverWait(BrowserDriver.GetDriver(), GetElementWaitTimeoutInDuration());
            Type[] exceptionTypesToIgnore = new Type[] { typeof(NoSuchElementException) };
            wait.IgnoreExceptionTypes(exceptionTypesToIgnore);

            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                try
                {
                    IWebElement element = webEle;
                    By byEle = WebHandlers.Instance.WebElementToBy(webEle);
                    WaitForPresence(byEle, GetElementTimeout());
                    WaitForNotStale(byEle, GetElementTimeout());
                   // ScrollToElement(byEle);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    log.Error(e);
                    throw e;
                }
            });

            wait.Until(waitForElement);
        }
        public void WaitForElementPresence(IWebElement webEle)
        {
            WebDriverWait wait = new WebDriverWait(BrowserDriver.GetDriver(), GetElementWaitTimeoutInDuration());
            Type[] exceptionTypesToIgnore = new Type[] { typeof(NoSuchElementException) };
            wait.IgnoreExceptionTypes(exceptionTypesToIgnore);

            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                try
                {
                    IWebElement element = webEle;
                    By byEle = WebHandlers.Instance.WebElementToBy(webEle);
                    WaitForPresence(byEle, GetElementTimeout());
                    WaitForNotStale(byEle, GetElementTimeout());
                    ScrollToElement(byEle);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    log.Error(e);
                    throw e;
                }
            });

            wait.Until(waitForElement);
        }

        public void WaitForElementPresence(IWebElement webEle, TimeSpan time)
        {
            WebDriverWait wait = new WebDriverWait(BrowserDriver.GetDriver(), GetElementWaitTimeoutInDuration());
            Type[] exceptionTypesToIgnore = new Type[] { typeof(NoSuchElementException) };
            wait.IgnoreExceptionTypes(exceptionTypesToIgnore);

            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                try
                {
                    IWebElement element = webEle;
                    By byEle = WebHandlers.Instance.WebElementToBy(webEle);
                    WaitForPresence(byEle, time);
                    WaitForNotStale(byEle, time);
                    ScrollToElement(byEle);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    log.Error(e);
                    throw e;
                }
            });

            wait.Until(waitForElement);
        }

        ////Helper methods
        public void WaitForPresence(By byEle, TimeSpan time)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait( BrowserDriver.GetDriver(), time);
                wait.Until(ElementCondition.PresenceOfAllElementsLocatedBy(byEle));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                log.Error(ex);
                throw ex;
                // log.Error("Error occurred while performing  waitForPresence action for  locator :" + byEle + "Exception :" + ex);
                //Assert.Fail("Error occurred while performing  waitForPresence action for  locator :" + byEle + "Exception :" + ex);
            }
        }


        public void Waituntilelementnotpresent(By byEle, TimeSpan tim)

        {
            WebDriverWait wait = new WebDriverWait(BrowserDriver.GetDriver(), tim);
            wait.Until(ElementCondition.InvisibilityOfElementLocated(byEle));

               

        }
        public void WaitForClickable(By byEle, TimeSpan time)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(new SystemClock(), BrowserDriver.GetDriver(), time, GetPollingTimeoutInMilliSeconds());
                wait.Until(ElementCondition.ElementToBeClickable(byEle));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                log.Error(ex);
                throw ex;
                //log.Error("Error occurred while performing  WaitForClickable action for  locator :" + byEle + "Exception :" + ex);
                //Assert.Fail("Error occurred while performing  WaitForClickable action for  locator :" + byEle + "Exception :" + ex);
            }
        }

        public void WaitForVisibleble(By byEle, TimeSpan time)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(new SystemClock(), BrowserDriver.GetDriver(), time, GetPollingTimeoutInMilliSeconds());
                wait.Until(d => (ElementCondition.ElementIsVisible(byEle)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                log.Error(ex);
                throw ex;
                //log.Error("Error occurred while performing  WaitForVisibleble action for  locator :" + byEle + "Exception :" + ex);
                //Assert.Fail("Error occurred while performing  WaitForVisibleble action for  locator :" + byEle + "Exception :" + ex);
            }

        }

        //public  void WaitForNotStale(By byEle, TimeSpan time)
        //{
        //    try
        //    {
        //        WebDriverWait wait = new WebDriverWait(BrowserDriver.GetDriver(), time);
        //        wait.Until(ElementCondition.StalenessOf(BrowserDriver.GetDriver().FindElement(byEle)));
        //    }
        //    catch (WebAutomationException ex)
        //    {
        //        log.Error("Error occurred while performing  WaitForNotStale action for  locator :" + byEle + "Exception :" + ex);
        //        Assert.Fail("Error occurred while performing  WaitForNotStale action for  locator :" + byEle + "Exception :" + ex);
        //    }
        //}

        //changed and added checking if element is enabled

        public void WaitForNotStale(By byEle, TimeSpan time)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(new SystemClock(), BrowserDriver.GetDriver(), time, GetPollingTimeoutInMilliSeconds());
                var element = wait.Until(condition =>
                {
                    try
                    {
                        var elementToBeDisplayed = BrowserDriver.GetDriver().FindElement(byEle);
                        return elementToBeDisplayed.Enabled;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return false;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                log.Error(ex);
                throw ex;
                //Assert.Fail("Error occurred while performing  WaitForNotStale action for  locator :" + byEle + "Exception :" + ex);
            }
        }

        public void ScrollToElement(By locator)
        {
            try
            {
                IWebElement element = BrowserDriver.GetDriver().FindElement(locator);
                WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                new Actions(BrowserDriver.GetDriver()).MoveToElement(element).MoveByOffset(element.Location.X, element.Location.Y).Click().Perform();                
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                //log.Error(ex);
                // log.Info("Error occurred while performing  ScrollToElement action for  locator :" + locator + "Exception :" + ex);
                //Assert.Fail("Error occurred while performing  ScrollToElement action for  locator :" + locator + "Exception :" + ex);
            }
        }

        //additional methods

        public void WaitForClear(By by, TimeSpan time)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(new SystemClock(), BrowserDriver.GetDriver(), time, GetPollingTimeoutInMilliSeconds());
                var element = wait.Until(condition =>
                {
                    try
                    {
                        var elementToBeDisplayed = BrowserDriver.GetDriver().FindElement(by);
                        //return elementToBeDisplayed.Enabled;
                        try
                        {
                            GetAction().KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control)
                                    .SendKeys(Keys.Delete).Build().Perform();
                        }
                        catch (InvalidElementStateException e)
                        {
                            Console.WriteLine(e.Message);
                            // TODO: handle exception
                        }
                        if (elementToBeDisplayed.Text.Length < 1)
                            return true;
                        try
                        {
                            elementToBeDisplayed.Click();
                            elementToBeDisplayed.Clear();
                        }
                        catch (InvalidElementStateException e)
                        {
                            Console.WriteLine(e.Message);
                            log.Error(e);
                            // TODO: handle exception
                        }
                        if (elementToBeDisplayed.Text.Length < 1)
                            return true;
                        try
                        {
                            elementToBeDisplayed.Click();
                            IJavaScriptExecutor js = (IJavaScriptExecutor)GetAction();
                            string title = (string)js.ExecuteScript("arguments[0].value ='';", elementToBeDisplayed);
                        }
                        catch (InvalidElementStateException e)
                        {
                            Console.WriteLine(e.Message);
                            log.Error(e);
                            // TODO: handle exception
                        }
                        if (elementToBeDisplayed.Text.Length < 1)
                            return true;
                        return false;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return false;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                log.Error(ex);
                throw ex;
                //log.Error("Error occurred while performing  WaitForClear action for  locator Exception :" + ex);
                //Assert.Fail("Error occurred while performing  WaitForClear action for  locator Exception :" + ex);
            }
        }

        public Actions GetAction()
        {
            return new Actions(BrowserDriver.GetDriver());
        }

    }
}
