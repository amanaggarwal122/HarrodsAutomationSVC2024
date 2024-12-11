using NUnit.Framework;
using OpenQA.Selenium;
using ElementCondition = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Winium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using TAF_GenericUtility;
using OpenQA.Selenium.Winium;
using System.Text;

namespace TAF_Web.Scripted.Web
{
    public partial class WebHandlers
    {
        private static readonly WebHandlers _instance = new WebHandlers();
        private WebHandlers()
        {
        }
        static WebHandlers()
        {
        }
        public static WebHandlers Instance
        {
            get
            {
                return _instance;
            }
        }

        public Actions action = new Actions(BrowserDriver.GetDriver());

        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //public  WiniumDriver desktopDriver = null;

        public IWebElement GetElement(IWebDriver driver, By locator)
        {
            IWebElement element = driver.FindElement(locator);
            return element;
        }

        public By WebElementToBy(IWebElement webEle)
        {
            try
            {
                Dictionary<string, string> locators = GetLocatorAndUsing(webEle);

                if (locators.Keys.Any())
                {
                    string locator = locators.Keys.FirstOrDefault();

                    if (!string.IsNullOrEmpty(locator.Trim()))
                    {
                        string term = locators[locator];

                        if (!string.IsNullOrEmpty(term.Trim()))
                        {
                            switch (locator)
                            {
                                case "xpath":
                                    return By.XPath(term);
                                case ("cssselector"):
                                case ("css selector"):
                                    return By.CssSelector(term);
                                case "id":
                                    return By.Id(term);
                                case "tag name":
                                case "tagname":
                                    return By.TagName(term);
                                case "name":
                                    return By.Name(term);
                                case "link text":
                                case "linktext":
                                    return By.LinkText(term);
                                case "class name":
                                case "classname":
                                    return By.ClassName(term);
                            }
                        }
                    }
                }

                if (webEle == null) throw new NullReferenceException();

                var attributes =
                    ((IJavaScriptExecutor)BrowserDriver.GetDriver()).ExecuteScript(
                        "var items = {}; for (index = 0; index < arguments[0].attributes.length; ++index) { items[arguments[0].attributes[index].name] = arguments[0].attributes[index].value }; return items;",
                        webEle) as Dictionary<string, object>;
                if (attributes == null) throw new NullReferenceException();

                var selector = "//" + webEle.TagName;
                selector = attributes.Aggregate(selector, (current, attribute) =>
                     current + "[@" + attribute.Key + "='" + attribute.Value + "']");

                return By.XPath(selector);
            }
            catch (Exception)
            {
            }

            return null;
        }
        
     
        public void EnterText(IWebElement locator, String value)
        {
            try
            {
                WebWaitHelper.Instance.WaitForClear(locator);
                locator.Clear();
                locator.SendKeys(value);
                log.Info("Text entered successfully");
            }
            catch (Exception e)
            {
                string msg = ("Error  while entering text for the locator: Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
                Console.WriteLine(msg);
            }
        }
        ///<summary>
        ///<para>Function to get table index </para>
        ///<para>Return type is void</para>
        ///</summary>
        ///
        public string GetTableItemIndex(IList<IWebElement> RowHeader, IList<IWebElement> ColumnHeader, string RowHeaderValue, string ColumnHeaderValue)
        {
            int ItemRowIndex = 0, ItemColumnIndex = 0;
            string TableIndex;
            for (int rowindex = 0; rowindex < RowHeader.Count; rowindex++)
            {
                if (RowHeader[rowindex].Text.Equals(RowHeaderValue))
                {
                    ItemRowIndex = rowindex;

                    ItemRowIndex = ItemRowIndex + 1;
                    break;
                }

            }

            for (int colindex = 0; colindex < ColumnHeader.Count; colindex++)
            {
                if (ColumnHeader[colindex].Text.Equals(ColumnHeaderValue))
                {
                    ItemColumnIndex = colindex;
                    ItemColumnIndex = ItemColumnIndex + 1;
                    break;
                }

            }
            TableIndex = ItemRowIndex + "," + ItemColumnIndex;
            if (TableIndex.Equals("0,0"))
            {
                string msg = (" Row: " + RowHeaderValue + " and Column header: " + ColumnHeaderValue + " names are not found");
                LogMessage(msg, true, true, false, true, null);
                
                Assert.Fail();
            }
            return TableIndex;
        }


        ///<summary>
        ///<para>Function to wait until page loaded</para>
        ///<para>Return type is void</para>
        ///</summary>
        ///
        public void FnWaitForPageLoad(int timeoutSec = 15)
        {
            IWebDriver driver = BrowserDriver.GetDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }
        public void ClickByJsExecutor(By locator)
        {
            IWebElement element = null;

            try
            {
                element = BrowserDriver.GetDriver().FindElement(locator);

                if (element.Enabled && element.Displayed)
                {
                    ((IJavaScriptExecutor)BrowserDriver.GetDriver()).ExecuteScript("arguments[0].click();", element);
                    log.Info("Click action completed successfully for the locator");
                }
                else
                {
                    log.Info("Unable to click on element");
                }
            }
            catch (Exception ex)
            {
                string msg = ("Error while performing the ClickByJsExecutor action for the locator: " + locator + "Exception :" + ex);
                LogMessage(msg, true, true, false, true, ex);
            }
        }

        bool bVerifyText = true;
        public bool VerifyText(IWebElement locator, String strVText)
        {
            String actualText = "";
            try
            {
                if (locator.TagName.Equals("select"))
                {
                    SelectElement seleObj = new SelectElement(locator);
                    actualText = seleObj.SelectedOption.Text.Trim();
                    bVerifyText = CompareText(actualText, strVText);
                }
                else
                {
                    WebWaitHelper.Instance.WaitForElementPresence(locator);
                    actualText = locator.Text;
                    if (String.IsNullOrEmpty(actualText))
                    {
                        actualText = locator.GetAttribute("innerText");
                        if (String.IsNullOrEmpty(actualText))
                        {
                            actualText = locator.GetAttribute("value");
                            bVerifyText = CompareText(actualText, strVText);
                        }
                        else
                        {
                            bVerifyText = CompareText(actualText, strVText);
                        }
                    }
                    else
                    {
                        bVerifyText = CompareText(actualText, strVText);
                    }
                }
            }
            catch (Exception e)
            {
                string msg = ("Error while performing the VerifyText action for the locator Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return bVerifyText;
        }           

        bool bExistText = true;
        public bool ExistText(IWebElement locator)
        {
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                if ((String.IsNullOrEmpty(locator.GetAttribute("value"))))
                {
                    bExistText = false;
                    Assert.Fail("Text does not exists");
                }
                else
                {
                    bExistText = true;
                    log.Info("Text exits ");
                }
            }
            catch (Exception e)
            {
                string msg = ("Error occurred while trying to check whether the text exists " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);

            }
            return bExistText;
        }

        public void ClearText(IWebElement locator)
        {
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                locator.Clear();
                log.Info("Text cleared successfully ");
            }
            catch (Exception e)
            {
                string msg = ("Error occurred while trying to clear text " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);

            }
        }

        public bool ObjDisabled(IWebElement locator)
        {
            bool eFlag = false;
            try
            {
                if (!locator.Enabled)
                {
                    eFlag = true;
                    log.Info("Object is disabled");
                }
                else
                {
                    eFlag = false;
                    log.Info("Object is enabled");
                }

                log.Info("objDisabled check completed successfully ");
            }
            catch (Exception e)
            {
                string msg = ("Error occurred while checking whether the object is disabled " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return eFlag;
        }

        public string FetchPropertyVal(IWebElement locator, String property)
        {
            String propValue = "";
            try
            {
                propValue = locator.GetAttribute(property).ToString();
                log.Info(
                     "Property value fetched  successfully for the locator prop value :" + propValue);
                return propValue;
            }
            catch (Exception e)
            {
                string msg = ("Error  while fetching  the property value " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
                return propValue;
            }
        }

        public void VerifyProperty(IWebElement locator, String property, String expected)
        {
            String actual = "";
            try
            {
                actual = FetchPropertyVal(locator, property);
                log.Info("Property value fetched successfully for the locator");
            }
            catch (Exception e)
            {
                string msg = ("Error while trying to verify the property " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            if (!expected.Equals(actual))
            {
                string msg = ("property does not  matches" + "locator value: " + locator + " Expected value :" + expected
                    + "Actual value :" + actual);
                LogMessage(msg, true, false, true, true, null);
            }
            else
            {
                log.Info("Property matches" + "locator value Expected value :" + expected
                        + "Actual value :" + actual);
            }
        }

        public void DoubleClick(IWebElement locator)
        {
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                Actions _action = new Actions(BrowserDriver.GetDriver());
                _action.DoubleClick(locator).Perform();
                log.Info("Double click performed successfully");
            }
            catch (Exception e)
            {
                string msg = ("Error while performing double click " + "Exception: " + e);
                LogMessage(msg, true, true, false, true, e);
            }
        }

        public void RightClick(IWebElement locator)
        {
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                Actions _action = new Actions(BrowserDriver.GetDriver());
                _action.ContextClick(locator).Perform();
                log.Info("Right click performed successfully");
            }
            catch (Exception e)
            {
                string msg = ("Error while performing right click " + "Exception: " + e);
                LogMessage(msg, true, true, false, true, e);
            }
        }

        public void ObjExists(IWebElement locator)
        {
            try
            {
                By byEle = WebHandlers.Instance.WebElementToBy(locator);
                WebWaitHelper.Instance.WaitForPresence(byEle, WebWaitHelper.Instance.GetElementTimeout());
                log.Info("objExists check completed successfully, Object exists ");
            }
            catch (Exception e)
            {
                string msg = ("Error occurred while checking whether the object exists " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
        }      

        public bool ChkboxIsChecked(IWebElement locator)
        {
            WebWaitHelper.Instance.WaitForElement(locator);
            bool eFlag = false;
            try
            {
                if (locator.Selected)
                {
                    eFlag = true;
                }
                else
                {
                    eFlag = false;
                    //Assert.Fail("Checkbox is not checked");
                }
            }
            catch (Exception e)
            {
                string msg = ("Error while performing the chkboxIsChecked action for the locator: " + locator + "Exception :" + e);
                LogMessage(msg, true, true, false, true);

                return eFlag;
            }
            return eFlag;
        }

        public bool RadiobtnNotChecked(IWebElement locator)
        {
            WebWaitHelper.Instance.WaitForElementPresence(locator);
            bool eFlag = false;
            try
            {
                if (!locator.Selected)
                {
                    eFlag = true;
                }
                else
                {
                    eFlag = false;
                    Assert.Fail("Radio button is checked");
                }
            }
            catch (Exception e)
            {
                string msg = ("Error while performing radioBtnIsSelected action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);

                return eFlag;
            }
            return eFlag;
        }

        public bool RadioBtnIsSelected(IWebElement locator)
        {
            WebWaitHelper.Instance.WaitForElementPresence(locator);

            bool eFlag = false;
            try
            {
                if (locator.Selected)
                {
                    eFlag = true;
                }
                else
                {
                    eFlag = false;
                    //Assert.Fail("Radio button is not selected");
                }
            }
            catch (Exception e)
            {
                string msg = ("Error while performing radioBtnIsSelected action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);

                return eFlag;

            }
            return eFlag;
        }

        public bool RadioBtnIsNotSelected(IWebElement locator)
        {
            WebWaitHelper.Instance.WaitForElementPresence(locator);
            bool eFlag = false;
            try
            {
                if (!locator.Selected)
                {
                    eFlag = true;
                }
                else
                {
                    eFlag = false;
                    Assert.Fail("Radio button is  selected");
                }
            }
            catch (Exception e)
            {
                string msg = ("Error while performing radioBtnIsNotSelected action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
                return eFlag;
            }
            return eFlag;
        }

        public Dictionary<int, string> SltCtrlReadAllVal(IWebElement locator)
        {
            Dictionary<int, string> comboValuesMap = new Dictionary<int, string>();
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);

                SelectElement dropdown = new SelectElement(locator);
                List<IWebElement> lstValues = dropdown.Options.ToList();

                for (int j = 0; j < lstValues.Count(); j++)
                {
                    comboValuesMap[j] = lstValues[j].Text;
                }
                Console.WriteLine(comboValuesMap);

                log.Info("The values are " + comboValuesMap);

                return comboValuesMap;
            }
            catch (Exception e)
            {
                string msg = ("Error while performing the sltCtrlReadAllVal action for the locator: " + locator
                    + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);

                return comboValuesMap;
            }
        }

        public string DropDownGetCurrentSelection(IWebElement locator)
        {
            String cmbSelectedValue = "";
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                SelectElement seleObj = new SelectElement(locator);
                cmbSelectedValue = seleObj.SelectedOption.Text.Trim();
            }
            catch (Exception e)
            {
                string msg = ("Error while trying to get current selection of dropdown for the locator: " + locator
                    + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);

                return cmbSelectedValue;
            }
            return cmbSelectedValue;
        }

        public void DropDownSelectByIndex(IWebElement locator, int index)
        {
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                String cmbSelectedValue = "";
                SelectElement dropdown = new SelectElement(locator);
                List<IWebElement> cmbOptions = dropdown.Options.ToList();
                cmbSelectedValue = cmbOptions[index].Text;
                log.Info("Selected value :" + cmbSelectedValue);
            }
            catch (Exception e)
            {
                string msg = (
                    "Error while trying to select index from drop down  the locator: " + locator + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
        }

        public bool DropDownSetByVal(IWebElement locator, String value)
        {
            bool flag = false;
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                SelectElement dropdown = new SelectElement(locator);
                List<IWebElement> cmbOptions = dropdown.Options.ToList();
                for (int i = 0; i <= cmbOptions.Count; i++)
                {
                    if (value.ToLower().Equals(cmbOptions[i].Text.ToLower()))
                    {
                        dropdown.SelectByIndex(i);
                        flag = true;
                        break;
                    }
                }
                log.Info(" The action dropDownSetByVal completed successfully ");
                return flag;
            }
            catch (Exception e)
            {
                string msg = ("Error while trying to set  drop down by value for the locator: " + locator + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
                return flag;
            }

        }

        public bool DropDownSetByIndex(IWebElement locator, int index)
        {
            bool flag = false;
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                SelectElement dropdown = new SelectElement(locator);
                if (dropdown.Options == null)
                    BrowserDriver.Sleep(2000);
                List<IWebElement> cmbOptions = dropdown.Options.ToList();
                for (int i = 0; i <= cmbOptions.Count; i++)
                {
                    if (!string.IsNullOrEmpty(cmbOptions[i].Text))
                    {
                        dropdown.SelectByIndex(index);
                        flag = true;
                        break;
                    }
                }
                log.Info(" The action dropDownSetByIndex completed successfully ");
                BrowserDriver.Sleep(2000);
                return flag;
            }
            catch (Exception e)
            {
                string msg = ("Error while trying to set drop down by index for the locator:" + locator + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return flag;

            
        }

        public void SwitchToFrame(IWebElement locator)// Jiju need to check
        {
            String actual = "";
            try
            {
                //actual = String.valueOf(locator.isDisplayed());
                actual = locator.Displayed.ToString();

                BrowserDriver.GetDriver().SwitchTo().Frame(locator);
                if (actual == null)
                    throw new WebAutomationException(locator, "Switch to Frame", "Frame not Found");
                actual = actual.Trim().ToLower();
            }
            catch (WebAutomationException e)
            {
                string msg = ("Tried switching to next frame, not found " + locator + "Exception: " + e);
                LogMessage(msg, true, true, false, true, e);
            }
            catch (Exception e)
            {
                string msg = ("Tried switching to next frame, not found " + locator + "Exception: " + e);
                LogMessage(msg, true, true, false, true, e);
            }
        }

        public void SwithBackFromFrame()
        {
            try
            {
                BrowserDriver.GetDriver().SwitchTo().DefaultContent();
            }
            catch (Exception e)
            {
                string msg = ("Error while trying to perform switch back from frame" + " Exception: " + e);
                LogMessage(msg, true, true, false, true, e);
            }
        }

        public bool MultiDeselectByText(IWebElement locator, String options)
        {
            bool flag = false;
            ArrayList optionList = null;
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                optionList = OptionsSplit(options);
                for (int i = 0; i < optionList.Count; i++)
                {
                    SelectElement multiple = new SelectElement(locator);
                    multiple.DeselectByText(optionList[i].ToString());
                }

                flag = true;
                return flag;
            }
            catch (Exception e)
            {
                string msg = ("Error while trying to perform multideselect by text " + " Exception: " + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return flag;
            
        }

        public bool MultiDeselectAll(IWebElement locator)
        {
            bool flag = false;
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                SelectElement multiple = new SelectElement(locator);
                multiple.DeselectAll();
                flag = true;
                return flag;
            }
            catch (Exception e)
            {
                string msg = ("Error while trying to perform multideselect" + " Exception: " + e);
                LogMessage(msg, true, true, false, true, e);

                return flag;
                //Console.WriteLine(e.Message);
            }
            //return flag;
        }

        public bool MultiSelectByText(IWebElement locator, String options)
        {
            bool flag = false;
            ArrayList optionList = null;
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                optionList = OptionsSplit(options);
                for (int i = 0; i < optionList.Count; i++)
                {
                    SelectElement multiple = new SelectElement(locator);
                    multiple.SelectByText(optionList[i].ToString());
                }
                flag = true;
                return flag;
            }
            catch (Exception e)
            {
                string msg = ("Error while trying to perform multiSelectByText" + " Exception: " + e);
                LogMessage(msg, true, true, false, true, e);

                return flag;
            }
        }

        public bool MultiSelectByIndex(IWebElement locator, String indexes)
        {
            bool flag = false;
            ArrayList indexList = null;
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                indexList = OptionsSplit(indexes);
                ArrayList intList = new ArrayList(indexList.OfType<int>().ToArray());

                SelectElement multiple = new SelectElement(locator);
                for (int i = 0; i < intList.Count; i++)
                {
                    multiple.SelectByIndex((int)intList[i]);
                }

                flag = true;
                return flag;
            }
            catch (Exception e)
            {
                string msg = ("Error while trying to perform multiSelect by providing an index value" + " Exception: " + e);
                LogMessage(msg, true, true, false, true, e);

                return flag;
            }
        }

        public ArrayList OptionsSplit(String options)
        {
            ArrayList tempOptionList = null;
            try
            {
                String[] items = options.Split(':');
                tempOptionList = new ArrayList(items);
                return tempOptionList;
            }
            catch (Exception e)
            {
                string msg = ("Error while performing  action optionsSplit" + " Exception: " + e);
                LogMessage(msg, true, true, false, true, e);

                return tempOptionList;
            }
        }

        public Dictionary<String, int> GetTblHeaderVal(IWebElement locator)
        {
            Dictionary<String, int> headermap = new Dictionary<String, int>();
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                IWebElement mytableHead = locator.FindElement(By.TagName("thead"));
                List<IWebElement> rowsTable = mytableHead.FindElements(By.TagName("tr")).ToList<IWebElement>();
                for (int row = 0; row < rowsTable.Count; row++)
                {
                    List<IWebElement> colRow = rowsTable[row].FindElements(By.TagName("th")).ToList<IWebElement>();
                    for (int column = 0; column < colRow.Count; column++)
                    {
                        headermap[colRow[column].Text] = column;
                    }
                }
                log.Info("getTblHeaderVal action completed successfully");
            }
            catch (Exception e)
            {
                string msg = ("Error  while performing getTblHeaderVal action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return headermap;
        }

        public Dictionary<String, int> GetTblBodyVal(IWebElement locator)
        {
            Dictionary<String, int> bodymap = new Dictionary<String, int>();
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                IWebElement mytableBody = locator.FindElement(By.TagName("tbody"));
                List<IWebElement> rowsTable = mytableBody.FindElements(By.TagName("tr")).ToList<IWebElement>();
                for (int row = 0; row < rowsTable.Count; row++)
                {
                    List<IWebElement> colRow = rowsTable[row].FindElements(By.TagName("td")).ToList<IWebElement>();
                    for (int column = 0; column < colRow.Count; column++)
                    {
                        bodymap[colRow[column].Text] = column;
                    }
                }
                log.Info("getTblBodyVal action completed successfully");
            }
            catch (Exception e)
            {
                string msg = ("Error while performing the getTblBodyVal action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return bodymap;
        }

        string strGetTblTdVal = "";
        public String GetTblTdVal(IWebElement locator, int rowIndex, int colIndex)
        {
            IWebElement ele = null;
            IWebElement rowele = null;

            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                List<IWebElement> mytables = locator.FindElements(By.TagName("tr")).ToList<IWebElement>();
                rowele = mytables[rowIndex];
                List<IWebElement> rowsTable = rowele.FindElements(By.TagName("td")).ToList<IWebElement>();
                ele = rowsTable[colIndex];
                strGetTblTdVal = ele.Text;
                log.Info("The getTblTdVal action completed successfully");
            }
            catch (Exception e)
            {
                string msg = ("Error  while performing the getTblTdVal action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return strGetTblTdVal;
        }

        public String GetTblThVal(IWebElement locator, int rowIndex, int colIndex)
        {
            IWebElement ele = null;
            IWebElement tblEle = null;
            //IWebElement rowEle = null;

            IWebElement myTblHead = null;
            List<IWebElement> myTblHeadRow = null;
            List<IWebElement> myTblHeadRowCol = null;
            String tblCellValue = "";
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                myTblHead = locator.FindElement(By.TagName("thead"));
                myTblHeadRow = myTblHead.FindElements(By.XPath("tr")).ToList<IWebElement>();
                for (int row = 0; row < myTblHeadRow.Count; row++)
                {
                    tblEle = myTblHeadRow[row];
                    myTblHeadRowCol = tblEle.FindElements(By.TagName("th")).ToList<IWebElement>();
                    //List<IWebElement> hdrRowCol = rowEle.FindElements(By.TagName("th")).ToList<IWebElement>();
                    ele = myTblHeadRowCol[colIndex];
                    tblCellValue = ele.Text;
                }
                log.Info("getTblThVal action completed successfully");
            }
            catch (Exception e)
            {
                string msg = ("Error  while performing the getTblThVal action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return tblCellValue;
        }

        public String GetIndexofVal(IWebElement locator, String value)
        {
            IWebElement mytableBody = null;
            List<IWebElement> mytableBodyrow = null;
            IWebElement tblEle = null;
            List<IWebElement> mytableBodycol = null;
            String indexVal = "";
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                mytableBody = locator.FindElement(By.TagName("tbody"));
                mytableBodyrow = mytableBody.FindElements(By.TagName("tr")).ToList<IWebElement>();
                for (int row = 0; row < mytableBodyrow.Count; row++)
                {
                    tblEle = mytableBodyrow[row];
                    mytableBodycol = tblEle.FindElements(By.TagName("td")).ToList<IWebElement>();
                    for (int column = 0; column < mytableBodycol.Count; column++)
                    {
                        if (mytableBodycol[column].Text.ToLower().Equals(value.ToLower()))
                        {
                            Console.WriteLine("Index of " + value + "is (" + row + "," + column + ")");
                            indexVal = row + "," + column;
                            break;
                        }
                    }
                }
                log.Info("getIndexofVal action completed successfully");
            }
            catch (Exception e)
            {
                string msg = ("Error while performing the getIndexofVal action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return indexVal;
        }

        public String GetFirstIndexofVal(IWebElement locator, String value)
        {
            IWebElement mytableBody = null;
            List<IWebElement> mytableBodyrow = null;
            IWebElement tblEle = null;
            List<IWebElement> mytableBodycol = null;
            String indexVal = "";
            bool flag = false;
            try
            {
                WebWaitHelper.Instance.WaitForElementPresence(locator);
                mytableBody = locator.FindElement(By.TagName("tbody"));

                mytableBodyrow = mytableBody.FindElements(By.TagName("tr")).ToList<IWebElement>();

                for (int row = 0; row < mytableBodyrow.Count; row++)
                {
                    tblEle = mytableBodyrow[row];
                    mytableBodycol = tblEle.FindElements(By.TagName("td")).ToList<IWebElement>();
                    for (int column = 0; column < mytableBodycol.Count; column++)
                    {
                        if (mytableBodycol[column].Text.ToLower().Equals(value.ToLower()))
                        {
                            row = row + 1;
                            column = column + 1;
                            log.Info("Index of " + value + "is (" + row + "," + column + ")");
                            indexVal = row + "," + column;
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                string msg = ("Error while performing the getFirstIndexofVal action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return indexVal;

        }

        public Dictionary<String, String> GetColMapByHdrVal(IWebElement locator, String colHeader)
        {
            Dictionary<String, String> colMap = new Dictionary<String, String>();
            Dictionary<String, int> headerMap = new Dictionary<String, int>();
            IWebElement mytableBody = null;
            List<IWebElement> mytableBodyrow = null;
            IWebElement tblEle = null;
            List<IWebElement> mytableBodycol = null;
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                headerMap = GetTblHeaderVal(locator);
                int colNum = headerMap[colHeader];
                mytableBody = locator.FindElement(By.TagName("tbody"));
                mytableBodyrow = mytableBody.FindElements(By.TagName("tr")).ToList<IWebElement>();
                for (int row = 0; row < mytableBodyrow.Count; row++)
                {
                    tblEle = mytableBodyrow[row];
                    mytableBodycol = tblEle.FindElements(By.TagName("td")).ToList<IWebElement>();
                    colMap[mytableBodycol[colNum].Text] = "Row Number is " + row.ToString();
                }
                return colMap;
            }
            catch (Exception e)
            {
                string msg = ("Error while performing the getColMapByHdrVal action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return colMap;
        }

        public Dictionary<String, int> GetRowMapByIndxVal(IWebElement locator, int rowIndex)
        {
            Dictionary<String, int> rowMap = new Dictionary<String, int>();
            IWebElement mytableBody = null;
            List<IWebElement> mytableBodyrow = null;
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                mytableBody = locator.FindElement(By.TagName("tbody"));
                mytableBodyrow = mytableBody.FindElements(By.TagName("tr")).ToList<IWebElement>();
                for (int i = 0; i < mytableBodyrow[rowIndex].FindElements(By.TagName("td")).Count; i++)
                {
                    rowMap[mytableBodyrow[rowIndex].FindElements(By.TagName("td"))[i].Text] = i;
                }
                return rowMap;
            }
            catch (Exception e)
            {
                string msg = ("Error while perfoming the getRowMapByIndxVal action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return rowMap;
        }

        public Dictionary<String, int> GetRowMapByHdrVal(IWebElement locator, String rowHeader)
        {
            Dictionary<String, int> rowMap = new Dictionary<String, int>();
            Dictionary<String, int> bodyMap = new Dictionary<String, int>();
            IWebElement mytableBody = null;
            List<IWebElement> mytableBodyrow = null;
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                bodyMap = GetTblBodyVal(locator);
                int rowNum = bodyMap[rowHeader];

                mytableBody = locator.FindElement(By.TagName("tbody"));
                mytableBodyrow = mytableBody.FindElements(By.TagName("tr")).ToList<IWebElement>(); ;
                for (int i = 0; i < mytableBodyrow[(rowNum)].FindElements(By.TagName("td")).Count; i++)
                {
                    rowMap[mytableBodyrow[rowNum].FindElements(By.TagName("td"))[i].Text] = i;
                }
                return rowMap;
            }
            catch (Exception e)
            {
                string msg = ("Error  while performing the getRowMapByHdrVal action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return rowMap;
        }

        public Dictionary<String, int> GetColMapByIndxVal(IWebElement locator, int colIndex)
        {
            Dictionary<String, int> colMap = new Dictionary<String, int>();
            IWebElement mytableBody = null;
            List<IWebElement> mytableBodyrow = null;
            IWebElement mytableBodyrowCol = null;
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                mytableBody = locator.FindElement(By.TagName("tbody"));
                mytableBodyrow = mytableBody.FindElements(By.TagName("tr")).ToList<IWebElement>(); ;
                for (int i = 0; i < mytableBodyrow.Count; i++)
                {
                    mytableBodyrowCol = mytableBodyrow[i].FindElements(By.TagName("td"))[colIndex];
                    colMap[mytableBodyrowCol.Text + i] = colIndex;
                    Console.WriteLine(i);
                }
                return colMap;
            }
            catch (Exception e)
            {
                string msg = ("Error  while performing the getColMapByIndxVal action " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
            return colMap;
        }

        public void TblCelChkboxClick(IWebElement locator, String value)
        {
            IWebElement mytableBody = null;
            List<IWebElement> mytableBodyrow = null;
            try
            {
                String index = GetIndexofVal(locator, value);
                String[] arrSplit = index.Split(',');

                WebWaitHelper.Instance.WaitForElement(locator);
                mytableBody = locator.FindElement(By.TagName("tbody"));
                mytableBodyrow = mytableBody.FindElements(By.TagName("tr")).ToList<IWebElement>(); ;
                IWebElement eleRow = mytableBodyrow[(Convert.ToInt32(arrSplit[0]))];
                IWebElement eleRowCol = eleRow.FindElements(By.TagName("td"))[Convert.ToInt32(arrSplit[1]) - 1];
                eleRowCol.Click();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
        }

        public void TblCelChkboxClick(IWebElement tbllocator, String value, int chkColIndex)
        {
            IWebElement mytableBody = null;
            // List<WebElement> mytableBodyrow = null;
            // WebElement eleRow = null;
            String[] arrSplit = null;
            try
            {
                WebWaitHelper.Instance.WaitForElementPresence(tbllocator);
                String index = GetFirstIndexofVal(tbllocator, value);
                arrSplit = index.Split(',');

                mytableBody = tbllocator.FindElement(By.TagName("tbody"));
                IWebElement eleRowCol = mytableBody
                        .FindElement(By.XPath("tr[" + arrSplit[0] + "]//td[" + chkColIndex + "]//input"));
                eleRowCol.Click();
            }
            catch (Exception e)
            {
                try
                {
                    IWebElement eleRowCol = mytableBody
                            .FindElement(By.XPath("tr[" + arrSplit[0] + "]//td[" + chkColIndex + "]"));
                    eleRowCol.Click();
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1.Message);
                    string msg = ("Error  while trying to click a checkbox inside table" + "Exception :" + e);
                    LogMessage(msg, true, true, false, true, e);
                }
            }
        }

        public void TblCelEleClick(IWebElement tbllocator, String value, int chkColIndex, String eleXpath)
        {
            IWebElement mytableBody = null;
            List<IWebElement> mytableBodyrow = null;
            IWebElement eleRow = null;
            try
            {
                String index = GetFirstIndexofVal(tbllocator, value);
                String[] arrSplit = index.Split(',');

                WebWaitHelper.Instance.WaitForElement(tbllocator);
                mytableBody = tbllocator.FindElement(By.TagName("tbody"));
                mytableBodyrow = mytableBody.FindElements(By.TagName("tr")).ToList<IWebElement>();
                eleRow = mytableBodyrow[(Convert.ToInt32(arrSplit[0]))];
                IWebElement eleRowCol = eleRow.FindElement(By.XPath("//td[" + chkColIndex + "]" + eleXpath));
                eleRowCol.Click();
            }
            catch (Exception e)
            {
                string msg = ("Error  while trying to click an element inside table" + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
        }

        public void TblCelLinkClick(IWebElement locator, String value)
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
                IWebElement ele = eleRowCol.FindElement(By.TagName("a"));
                ele.Click();
            }
            catch (Exception e)
            {
                string msg = ("Error  while trying to click a link inside table " + "Exception :" + e);
                LogMessage(msg, true, true, false, true, e);
            }
        }

        public int? TblNumberOfRows(IWebElement locator)
        {
            List<IWebElement> row = locator.FindElements(By.TagName("tr")).ToList();
            if (!row.Any()) return 0;
            return row.Count;
        }

        public int? TblNumberOfColumns(IWebElement locator)
        {
            List<IWebElement> column = locator.FindElements(By.TagName("td")).ToList();
            if (!column.Any()) return 0;
            return column.Count;
        }

        public void DivSpanListBox(IWebElement locator, String value)
        {
            try
            {
                WebWaitHelper.Instance.WaitForElement(locator);
                locator.Click();
                IReadOnlyCollection<IWebElement> listSpan = locator.FindElements(By.TagName("span"));
                foreach (IWebElement span in listSpan.ToList<IWebElement>())
                {
                    if (span.Text.Trim().ToLower().Equals(value.ToLower()))
                    {
                        span.Click();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
        }

        public void ClickForLogout(IWebElement locator)
        {
            try
            {
                // Need to add the assertions when we decide the reporting
                locator.Click();
                BrowserDriver.PageWait();
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
                    log.Error(ex.Message);
                    throw new WebAutomationException(locator, ex.Message);
                }
                log.Error(e.Message);
                throw new WebAutomationException(locator, e.Message);
            }
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                BrowserDriver.GetDriver().FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public object ExecuteScript(string script, params object[] args)
        {
            IWebDriver driver = BrowserDriver.GetDriver();

            var scriptExecutor = driver as IJavaScriptExecutor;

            if (scriptExecutor == null)
                throw new InvalidOperationException(
                    $"The driver type '{driver.GetType().FullName}' does not support Javascript execution.");

            return scriptExecutor.ExecuteScript(script, args);
        }

        public void ResetZoom()
        {
            IWebDriver driver = BrowserDriver.GetDriver();
            IWebElement element = driver.FindElement(By.TagName("body"));
            element.SendKeys(Keys.Control + "0");
        }

        public bool AlertIsPresent(TimeSpan timeout)
        {
            IWebDriver driver = BrowserDriver.GetDriver();

            WebDriverWait wait = new WebDriverWait(driver, timeout);
            try
            {
                wait.Until(ElementCondition.AlertIsPresent());
                return true;
            }
            catch (NoSuchElementException) { }
            catch (WebDriverTimeoutException) { }
            return false;
        }

        public bool ElementPresent(IWebElement ele)
        {
            try
            {
                By byEle = WebHandlers.Instance.WebElementToBy(ele);
                return BrowserDriver.GetDriver().FindElement(byEle).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool ElementPresent(string text)
        {
            try
            {
                return ElementPresent(BrowserDriver.GetDriver().FindElement(By.XPath($"//*[text()='{text}']")));

            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetAttribute(IWebElement element, string attribute)
        {
            return this.FetchPropertyVal(element, attribute);
        }

        /// <summary>
        /// This method use for Driver title of page
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            IWebDriver driver = BrowserDriver.GetDriver();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(20));
            return driver.Title;
        }
        /// <summary>
        /// This method is use for
        /// return value of css
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetCssValue(IWebElement element, string value)
        {
            return element.GetCssValue(value);
        }

        public void UploadFile(string fileName, string elementName)
        {
            IWebDriver driver = BrowserDriver.GetDriver();
            IWebElement fileInput = driver.FindElement(By.Name(elementName));
            fileInput.SendKeys(fileName);
        }

        public void UploadFile(string fileName, IWebElement element)
        {
            IWebDriver driver = BrowserDriver.GetDriver();
            element.SendKeys(fileName);
        }

        WiniumDriver desktopDriver = null;
        public void UploadFile(String fileNameWithExtention)
        {
            try
            {
                String uploadFilePath = fileNameWithExtention;
                string DriverPath = WebDriverPathUtil.GetWiniumDriverPath();


                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + "taskkill /F /IM Winium.Desktop.Driver.exe");

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

                proc.WaitForExit();

                DesktopOptions options = new DesktopOptions();
                options.ApplicationPath = "C:\\Windows\\System32\\openfiles.exe";

                WiniumDriverService service = WiniumDriverService.CreateDesktopService(DriverPath);
                WiniumDriver driver = new WiniumDriver(service, options);
                service.Start();

                desktopDriver = new WiniumDriver(service, options);
                desktopDriver.FindElementByName("File name:").SendKeys(uploadFilePath);
                desktopDriver.FindElement(By.XPath("//*[@Name='Cancel']//preceding-sibling::*[@Name='Open']")).Click();

                desktopDriver.Close();
                desktopDriver.Dispose();

            }
            catch (Exception e)
            {
                log.Error("Error while uploading file" + e);
                Assert.Fail("Error while uploading file" + e);
            }
        }      

        private Dictionary<string, string> GetLocatorAndUsing(IWebElement webElement)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();

            try
            {
                string key = "";
                string val = "";

                System.Runtime.Remoting.Proxies.RealProxy realproxy = System.Runtime.Remoting.RemotingServices.GetRealProxy(webElement);
                var byPropertyInfo = realproxy.GetType().GetProperty("Bys", BindingFlags.NonPublic | BindingFlags.Instance);
                IEnumerable<OpenQA.Selenium.By> byValue = (IEnumerable<OpenQA.Selenium.By>)byPropertyInfo.GetValue(realproxy, null);
                OpenQA.Selenium.By value = byValue.FirstOrDefault();
                var propertyDescription = value.GetType().GetProperty("Description", BindingFlags.NonPublic | BindingFlags.Instance);
                var valDescription = propertyDescription.GetValue(value, null) as string;

                string[] array = valDescription.Split(':');
                if (array.Length >= 1)
                {
                    string[] arrayLocator = array[0].Split('.');

                    if (arrayLocator.Length >= 1)
                    {
                        key = arrayLocator[1].Trim().ToLower();
                    }
                }

                if (array.Length >= 2)
                {
                    val = array[1].Trim();
                }

                dic[key] = val;

            }
            catch (Exception ex)
            {
            }

            return dic;
        }
    }
}