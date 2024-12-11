using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_Web.Scripted.Web.BrowserOptions
{
    interface IBrowser
    {
        IWebDriver StartDriver(string fileNmae);
    }
}
