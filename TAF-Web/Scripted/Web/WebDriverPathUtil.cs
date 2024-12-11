using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TAF_GenericUtility.Scripted.generic;
//using TAF_GenericUtility.Scripted.generic;

namespace TAF_Web.Scripted.Web
{
    public class WebDriverPathUtil
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string GetIEDriverPath()
        {
            log.Info("Inside WebDriverUtil.GetIEDriverPath method");
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Drivers\\";
        }


        public static String GetChromeDriverPath()
        {
            log.Info("Inside WebDriverUtil.GetChromeDriverPath method");
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Drivers\\";
        }

        public static String GetGeckoDriverPath()
        {
            log.Info("Inside WebDriverUtil.GetGeckoDriverPath method");
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Drivers\\";
        }

        public static String GetPhatomJSDriverPath()
        {
            log.Info("Inside WebDriverUtil.GetPhatomJSDriverPath method");
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Drivers\\";
        }

        public static String GetScreenShotPath()
        {
            log.Info("Inside WebDriverUtil.GetScreenShotPath method");
            return FileUtils.GetFilePath("src/main/resources/Screenshots/");
        }

        public static String GetWiniumDriverPath()
        {
            log.Info("Inside DesktopDriverUtil.GetWiniumDriverPath method");
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+ "\\Drivers\\";
        }
    }
}

