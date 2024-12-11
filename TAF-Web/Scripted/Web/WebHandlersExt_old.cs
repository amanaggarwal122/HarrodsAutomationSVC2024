using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

//using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ElementCondition = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TAF_Web.Scripted.Web
{
    public partial class WebHandlers
    {
        public void Clic5(IWebElement locator)
        {
            try
            {
                By by = WebElementToBy(locator);
                IWebElement element_p = new WebDriverWait(new SystemClock(), BrowserDriver.GetDriver(), new TimeSpan(0, 0, 2), new TimeSpan(0, 0, 2)).
                    Until(ElementCondition.ElementIsVisible(by));

                locator.SendKeys(Keys.Return);
            }
            catch (Exception es)
            {
                try
                {
                    // Need to add the assertions when we decide the reporting
                    WebWaitHelper.Instance.WaitForElement(locator);
                    ExecuteScript("arguments[0].scrollIntoView(true);", locator);
                    Actions _action = new Actions(BrowserDriver.GetDriver());
                    _action.MoveToElement(locator).Build().Perform();
                    locator.Click();

                    //Actions _action = new Actions(BrowserDriver.GetDriver());
                    //_action.MoveToElement(locator);
                    //_action.Click(locator);
                    //_action.Build();
                    //_action.Perform();

                    BrowserDriver.PageWait();
                    log.Info("Click action completed successfully for the locator");
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                    try
                    {
                        locator.Click();

                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            ClickByJsExecutor(locator);
                        }
                        catch (Exception ex1)
                        {
                            Console.WriteLine(ex1.Message);
                            string msg = ("Error while performing the click action for the locator Exception :" + ex1);
                            LogMessage(msg, true, true, false, true, ex1);
                        }
                    }
                }
            }
        }

        public void Click(IWebElement locator)
        {
            //Console.WriteLine(e.Message);
            try
            {
                WebDriverWait wait = new WebDriverWait(BrowserDriver.GetDriver(), new TimeSpan(0, 0, 2));
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));
           
                locator.Click();

            }
            catch (Exception ex)
            {
                try
                {
                    ClickByJsExecutor(locator);
                }
                catch (Exception ex1)
                {
                    Console.WriteLine(ex1.Message);
                    string msg = ("Error while performing the click action for the locator Exception :" + ex1);
                    LogMessage(msg, true, true, false, true, ex1);
                }
            }

        }

        public void CheckForError(IWebElement locator, String strVText)
        {
            String actualText = "";
            try
            {
                WebWaitHelper.Instance.WaitForElementPresence(locator);
                actualText = locator.Text;
                if (String.IsNullOrEmpty(actualText))
                {
                    actualText = locator.GetAttribute("innerText");
                    if (String.IsNullOrEmpty(actualText))
                    {
                        actualText = locator.GetAttribute("value");
                        bVerifyText = ContainsText(actualText, strVText);
                    }
                    else
                    {
                        bVerifyText = ContainsText(actualText, strVText);
                    }
                }
                else
                {
                    bVerifyText = ContainsText(actualText, strVText);
                }
            }
            catch (Exception e)
            {
                string msg = ("Error while performing the Verify action for the locator Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            if (bVerifyText || locator.Displayed)
            {
                string msg = ("Error:" + strVText);
                LogMessage(msg, true, true, false, true, null);
            }
        }

        public bool WebElementExists(IWebElement locator)
        {
            try
            {
                By byEle = WebHandlers.Instance.WebElementToBy(locator);
                WebWaitHelper.Instance.WaitForPresence(byEle, WebWaitHelper.Instance.GetElementTimeout());
                log.Info("objExists check completed successfully, Object exists ");
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void LogMessage(string msg, bool showPopup = false, bool logError = false, bool logInfo = false, bool assert = false, Exception ex = null)
        {
            if (showPopup)
            {
                string newMSG = "";

                if (ex != null)
                {
                    if (ex.Message.Length > 150)
                    {
                        newMSG = ex.Message.Substring(0, 150).Replace("\n", " ").Replace("\r", " ");
                    }
                    else
                    {
                        newMSG = ex.Message.Replace("\n", " ").Replace("\r", " ");
                    }

                    BrowserDriver.ShowPopup(newMSG);
                }
                else
                {
                    if (msg.Length > 150)
                    {
                        BrowserDriver.ShowPopup(msg.Substring(0, 150).Replace("\n", " ").Replace("\r", " "));
                    }
                    else
                    {
                        BrowserDriver.ShowPopup(msg.Replace("\n", " ").Replace("\r", " "));
                    }
                }
            }

            if (logError)
                log.Error(msg);

            if (logInfo)
                log.Info(msg);

            if (assert)
                Assert.Fail(msg);
        }

        public bool CompareObject<T>(T objA, T objB, string customMessage)
        {
            bool compFlag = false;
            try
            {
                if (objA.Equals(objB))
                {
                    compFlag = true;
                }
                else
                {
                    compFlag = false;
                    Assert.Fail(customMessage);
                }
            }
            catch (Exception e)
            {
                string msg = ("Error occurred while doing the compareobject action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return compFlag;
        }

        public bool ContainsText(String strActualText, String strCompText)
        {
            bool compFlag = false;
            try
            {
                if (strActualText.ToLower().Contains(strCompText.ToLower()))
                {
                    compFlag = true;
                }
                else
                {
                    compFlag = false;
                }
            }
            catch (Exception e)
            {
                string msg = ("Error occurred while doing the ContainsText action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return compFlag;
        }

        public void ClickByJsExecutor(IWebElement element)
        {
            try
            {
                if (element.Enabled && element.Displayed)
                {
                    ExecuteScript("arguments[0].scrollIntoView(true);", element);
                    ExecuteScript("arguments[0].click();", element);
                    log.Info("Click action completed successfully for the locator");
                }
                else
                {
                    log.Info("Unable to click on element");
                }
            }
            catch (Exception ex)
            {
                string msg = ("Error while performing the ClickByJsExecutor action for the locator: " + element + "Exception :" + ex);
                LogMessage(msg, true, true, false, true, ex);
            }
        }

        public bool CompareText(String strActualText, String strCompText)
        {
            bool compFlag = false;
            try
            {
                if (strActualText.Trim().Equals(strCompText.Trim()))
                {
                    compFlag = true;
                }
                else
                {
                    compFlag = false;
                    Assert.Fail(strActualText + " doesnot match with " + strCompText);
                    //System.out.println(strActualText + "doesnot match with" + strCompText);// Jiju This will not work
                }
            }
            catch (Exception e)
            {
                string msg = ("Error occurred while doing the compareText action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return compFlag;
        }

        public void RemoveItemsFromCart(IWebElement parentElement, IWebElement remove, IWebElement confirmRemove)
        {
            IWebDriver driver = BrowserDriver.GetDriver();

            if (driver != null)
            {
                if (WebElementExists(parentElement))
                {
                    By removeLocator = WebElementToBy(remove);

                    ReadOnlyCollection<IWebElement> removeElements = parentElement.FindElements(removeLocator);

                    foreach (IWebElement webElement in removeElements)
                    {
                        ClickByJsExecutor(webElement);

                        BrowserDriver.Sleep(250);

                        if (WebElementExists(confirmRemove))
                        {
                            Click(confirmRemove);
                        }
                    }
                }
                else
                {
                    By removeLocator = WebElementToBy(remove);

                    ReadOnlyCollection<IWebElement> removeElements = driver.FindElements(removeLocator);

                    foreach (IWebElement webElement in removeElements)
                    {
                        ClickByJsExecutor(webElement);

                        BrowserDriver.Sleep(250);

                        if (WebElementExists(confirmRemove))
                        {
                            Click(confirmRemove);
                        }
                    }
                }
            }
        }

        public List<string> GetTextFromMultipleElements(IWebElement webElement)
        {
            List<string> messages = new List<string>();

            IWebDriver driver = BrowserDriver.GetDriver();

            if (driver != null)
            {
                if (WebElementExists(webElement))
                {
                    By locator = WebElementToBy(webElement);

                    ReadOnlyCollection<IWebElement> elements = driver.FindElements(locator);

                    foreach (IWebElement elemnt in elements)
                    {
                        string actualText = string.Empty;
                        actualText = elemnt.Text;

                        if (String.IsNullOrEmpty(actualText))
                        {
                            actualText = elemnt.GetAttribute("innerText");

                            if (String.IsNullOrEmpty(actualText))
                            {
                                actualText = elemnt.GetAttribute("value");

                                if (!String.IsNullOrEmpty(actualText))
                                {
                                    actualText = elemnt.GetAttribute("innerHTML");
                                    messages.Add(actualText);
                                }
                                else
                                {
                                    messages.Add(actualText);
                                }
                            }
                            else
                            {
                                messages.Add(actualText);
                            }
                        }
                        else
                        {
                            messages.Add(actualText);
                        }
                    }
                }
            }

            return messages;
        }

        public List<string> GetAttributeValueFromMultipleElements(IWebElement webElement, string attribute)
        {
            List<string> messages = new List<string>();

            IWebDriver driver = BrowserDriver.GetDriver();

            if (driver != null)
            {
                if (WebElementExists(webElement))
                {
                    By locator = WebElementToBy(webElement);

                    ReadOnlyCollection<IWebElement> elements = driver.FindElements(locator);

                    foreach (IWebElement elemnt in elements)
                    {
                        string actualText = elemnt.GetAttribute(attribute);
                        messages.Add(actualText);
                    }
                }
            }

            return messages;
        }

        public int GetIndexUsingText(IWebElement webElement, string text)
        {
            List<string> data = GetTextFromMultipleElements(webElement);
            int index = data.FindIndex(a => a.Contains(text));
            return (index);
        }

        public string GetTextUsingIndex(IWebElement webElement, int index)
        {
            List<string> data = GetTextFromMultipleElements(webElement);
            return data[index - 1];

        }

        public void TblCelButtonClick(IWebElement locator, String value)
        {
            IWebElement mytableBody = null;
            List<IWebElement> mytableBodyrow = null;
            try
            {
                String index = GetIndexofVal(locator, value);
                String[] arrSplit = index.Split(',');
                WebWaitHelper.Instance.WaitForElement(locator);
                mytableBody = locator.FindElement(By.TagName("tbody"));
                mytableBodyrow = mytableBody.FindElements(By.TagName("tr")).ToList<IWebElement>();
                IWebElement eleRow = mytableBodyrow[Convert.ToInt32(arrSplit[0])];
                IWebElement eleRowCol = eleRow.FindElements(By.TagName("td"))[Convert.ToInt32(arrSplit[1])];
                IWebElement ele = eleRowCol.FindElement(By.TagName("button"));
                Click(ele);
            }
            catch (Exception e)
            {
                string msg = ("Error  while trying to click a link inside table " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
        }

        public string GetTextOfElement(IWebElement elemnt)
        {
            string actualText = string.Empty;
            actualText = elemnt.Text;

            if (String.IsNullOrEmpty(actualText))
            {
                actualText = elemnt.GetAttribute("innerText");

                if (String.IsNullOrEmpty(actualText))
                {
                    actualText = elemnt.GetAttribute("value");

                    if (!String.IsNullOrEmpty(actualText))
                    {
                        actualText = elemnt.GetAttribute("innerHTML");
                        return actualText;
                    }
                    else
                    {
                        return actualText;
                    }
                }
                else
                {
                    return actualText;
                }
            }
            else
            {
                return actualText;
            }
        }

        public void ScrollWebPageToTop()
        {
            ExecuteScript("window.scrollTo(0, 0);", null);
        }
    }
}