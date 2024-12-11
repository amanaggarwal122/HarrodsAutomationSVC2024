using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TAF_Scripting.Test.Common;
using TAF_Scripting.Test.Scripted;
using TAF_Scripting.Test.Scripted.StepDefinitions;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test
{
    public class CommonFunctions
    {
        private static Random random = new Random();
        public static string RewriteFarfetchUrl(string url, Configuration config)
        {
            return BrowserDriver.CreateAuthUrl(url, config.FFUserName, config.FFPassword);
        }

        public static string RewriteSCAYLEUrl(string url, Configuration config)
        {
            return BrowserDriver.CreateAuthUrl(url, config.SCAYLEUserName, config.SCAYLEPassword);
        }

        public static string RewriteInsightUrl(string url, Configuration config)
        {
            return BrowserDriver.CreateAuthUrl(url, config.CRMUserName, config.CRMPassword);
        }

        public static string AppendFarfetchUrl(string stringToAppend, Configuration config)
        {
            return RewriteFarfetchUrl($"{config.FFUrl}{stringToAppend}", config);
        }
        public static Dictionary<string, List<string>> ReplaceDictionaryRandomValues(Dictionary<string, List<string>> DictData)
        {
            Dictionary<string, List<string>> Dict_new = new Dictionary<string, List<string>>();

            int changevalue = 0;
            foreach (string key in DictData.Keys)
            {
                List<string> values = DictData[key];
                
                for (int i = 0; i < values.Count(); i++)
                {
                    if (values[i].Contains("RANDOM"))
                    {
                        values[i] = GetRandomValue(values[i]);

                        changevalue++;
                    }
                }
                Dict_new.Add(key, values);
                     

            }
            return Dict_new;
        }

        public static Dictionary<string, List<string>> AppendDateTime(Dictionary<string, List<string>> DictData)
        {
            Dictionary<string, List<string>> Dict_new = new Dictionary<string, List<string>>();

            int changevalue = 0;
            foreach (string key in DictData.Keys)
            {
                List<string> values = DictData[key];
             

                for (int i = 0; i < values.Count(); i++)
                {
                    if (values[i].Contains("DATETIME"))
                    {
                        values[i] = ReplaceDateTime(values[i]);

                        changevalue++;
                    }
                }
                Dict_new.Add(key, values);


            }
            return Dict_new;
        }

        public static  string ReplaceDateTime(string value)
        {

            value = value.Replace("<DATETIME>", DateTime.Now.ToString("MMddyyyy.HHmmss"));
            return value;
        }

        public static int ExtractnumberFromPaginationString(string inputpaginationstring)
        {
            int number=0;
            // Define a regular expression pattern to match the number
            string pattern = @"\d+";

            // Use Regex.Match to find the number in the string
            Match match = Regex.Match(inputpaginationstring, pattern);

            // Check if a match is found
            if (match.Success)
            {
                // Extract the matched number
                number = int.Parse(match.Value);
                Console.WriteLine("Extracted number: " + number);
            }
            else
            {
                Console.WriteLine("No number found in the string.");
            }
            return number;
        }
        public static IList<int> RetrieveSize(string text, string str, StringComparison comparisonType)
        {
            int startpos, lastpos, length;
            IList<int> NextCharacter = new List<int>();
            int index = text.IndexOf(str, comparisonType);
            int Lastindex = index + str.Length - 1;
            while (index != -1)
            {

                startpos = Lastindex + 1;
                lastpos = text.IndexOf(")", Lastindex, comparisonType);
                length = lastpos - startpos;
                NextCharacter.Add(Int16.Parse(text.Substring(startpos, length)));
                index = text.IndexOf(str, Lastindex, comparisonType);
                Lastindex = index + str.Length - 1;
            }
            return NextCharacter;
        }

        public static string ReplaceRandomKeyword(string RandomKeyword, string value)
        {
            switch (RandomKeyword)
            {
                case "RANDOMSTRING":
                    IList<int> stringsizes = RetrieveSize(value, "RANDOMSTRING(", StringComparison.OrdinalIgnoreCase);
                    foreach (int size in stringsizes)
                    {
                        value = value.Replace("RANDOMSTRING(" + size + ")", GetRandomString(size, true));
                    }

                    break;

                case "RANDOMNUMBER":
                    IList<int> Numbersizes = RetrieveSize(value, "RANDOMNUMBER(", StringComparison.OrdinalIgnoreCase);
                    foreach (int size in Numbersizes)
                    {
                        value = value.Replace("RANDOMNUMBER(" + size + ")", GetRandomNumber(size));
                    }
                    break;

                case "RANDOMALPHA":

                    IList<int> Alphasizes = RetrieveSize(value, "RANDOMALPHA(", StringComparison.OrdinalIgnoreCase);
                    foreach (int size in Alphasizes)
                    {
                        value = value.Replace("RANDOMALPHA(" + size + ")", GetRandomAlphaNumeric(size));
                    }

                    break;
                case "RANDOMNOW":
                    string TestDate = DateTime.Now.ToString("yyyy-MM-dd'T'hh:mm:ss");

                    value = value.Replace("RANDOMNOW", TestDate);
                    break;
                case "RANDOMDAY":
                    string Day = GetRandomDay();
                    value = value.Replace("RANDOMDAY", Day);
                    break;
                case "RANDOMMONTH":
                    string Month = GetRandomMonth();
                    value = value.Replace("RANDOMMONTH", Month);
                    break;

                case "RANDOMGUID":
                    string randomstring = GetNewGuid();
                    value = value.Replace("RANDOMGUID", randomstring);
                    break;
            }

            return value;
        }

        public static string GetRandomValue(String value)

        {

            if (value.Contains("RANDOMALPHA"))
            {
               
                value = ReplaceRandomKeyword("RANDOMALPHA", value);
            }
            if ((value.Contains("RANDOMSTRING")))
            {
                value = ReplaceRandomKeyword("RANDOMSTRING", value);
            }

            if ((value.Contains("RANDOMNUMBER")))
            {
                value = ReplaceRandomKeyword("RANDOMNUMBER", value);

            }
            if ((value.Contains("RANDOMNOW")))
            {
                value = ReplaceRandomKeyword("RANDOMNOW", value);
            }

            if ((value.Contains("RANDOMDAY")))
            {
                value = ReplaceRandomKeyword("RANDOMDAY", value);
            }
            if ((value.Contains("RANDOMMONTH")))
            {
                value = ReplaceRandomKeyword("RANDOMMONTH", value);
            }
            if ((value.Contains("RANDOMGUID")))
            {
                value = ReplaceRandomKeyword("RANDOMGUID", value);
            }
            return value;
        }

        #region GenerateRandomNumber
        public static string GetRandomNumber(int size)
        {
        

            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i <= size; i++)
            {
                r += random.Next(0, 9).ToString();
            }
            return r;
        }

        public static string GenerateRandomUser(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenerateRandomGender()
        {
            Random random = new Random();            
            int re = random.Next(0, 1);
            string r = "";
            if (re == 0)
            {
                r = "Male";
            }
            else { r = "Female"; }
            return r;
        }

        public static string GetCurrentDateTime()
        {
            DateTime now = DateTime.Now;          
            string date_str = now.ToString("ddMMyyyy_HHmmss");
            Console.WriteLine(date_str);
            return date_str;
        }
        #endregion
        #region GenerateRandomDay
        public static string GetRandomDay()
        {
            Random random = new Random();
            string r = "";
            int day = random.Next(01, 28);
            if (day < 10)
            {                
                r = "0" + day.ToString();
            }
            else
            {
                r = day.ToString();
            }
                    
            //string r = random.Next(01, 28).ToString();
            return r;
        }

        public string GetNumbers(String InputString)
        {
            String Result = "";
            string Numbers = "0123456789";
            int i = 0;

            for (i = 0; i < InputString.Length; i++)
            {
                if (Numbers.Contains(InputString.ElementAt(i)))
                {
                    Result += InputString.ElementAt(i);
                }
            }
            return Result;
        }
        #endregion
        #region GenerateRandomMonth
        public static string GetRandomMonth()
        {
            Random random = new Random();
            string r = "";
            int month = random.Next(01, 12);
            if (month < 10)
            {
                r = "0" + month.ToString();
            }
            else
            {
                r = month.ToString();
            }
            //string r = random.Next(01, 12).ToString();
            return r;
        }
        #endregion
        #region GenerateRandomBirthYear
        public static string GetRandomYear()
        {
            Random random = new Random();
            string r = random.Next(1980, 2005).ToString();
            return r;
        }
        public static string GetRandomChildYear()
        {
            DateTime currenttime = DateTime.Now;
            int currentyear = currenttime.Year;
            int elevenyearbef = currentyear - 10;
            Random random = new Random();
            string r = random.Next(elevenyearbef, currentyear).ToString();
            return r;
        }

        #region GenerateRandomDOB
        public static string GetRandomDOB()
        {
            Random random = new Random();       
            string r = GetRandomDay() +"."+ GetRandomMonth() + "." + GetRandomYear();
            return r;
        }

        public static string GetRandomChildDOB()
        {
            Random random = new Random();
            string r = GetRandomDay() + "." + GetRandomMonth() + "." + GetRandomChildYear();
            return r;

        }
        #endregion
        #endregion

        #region GenerateRandomString
        public static string GetRandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        #endregion

        #region GenerateAplhaNumeric
        public static string GetRandomAlphaNumeric(int size)
        {
            StringBuilder builder = new StringBuilder();


            while (size > 0)
            {
                builder.Append(GetRandomString(1, true));
                size = size - 1;
                if (size > 0)
                {
                    builder.Append(GetRandomNumber(1));
                    size = size - 1;
                }
            }



            return builder.ToString();
        }
        #endregion

        #region GenerateNewGuid
        public static string GetNewGuid()
        {
            StringBuilder builder = new StringBuilder(Guid.NewGuid().ToString());
            return builder.ToString();
        }
        #endregion

        #region RetrieveProductDetails
        public static IList<Dictionary<string, string>> RetrieveProductDetails(string TestDataFile,Dictionary<string,string> Testdata,string producttype)
        {
            IList<Dictionary<string, string>> Product_Attributes = new List<Dictionary<string, string>>(); 
            switch (producttype)
            {
                case "HarrodsProducts":
                    if (Testdata["HP_Product"] != "")
                    {
                        IList<string> HP_Product = Testdata["HP_Product"].Split(new string[] { "," }, StringSplitOptions.None);

                        foreach (string productid in HP_Product)
                        {
                            Dictionary<string, string> TestData = DataFilesUtil.GetDataRowWithUniqueKey(TestDataFile, "HarrodProducts", "HP_KEY", productid);
                            Product_Attributes.Add(TestData);
                        }
                    }
                    break;

                case "BrandPartnerProducts":
                    if (Testdata["BP_Product"] != "")
                    {
                        IList<string> BP_Product = Testdata["BP_Product"].Split(new string[] { "," }, StringSplitOptions.None);

                        foreach (string productid in BP_Product)
                        {
                            Dictionary<string, string> TestData = DataFilesUtil.GetDataRowWithUniqueKey(TestDataFile, "BrandProducts", "BP_KEY", productid);
                            Product_Attributes.Add(TestData);
                        }
                    }
                    break;
            }

            return Product_Attributes;
        }

        public static Dictionary<string, string> RetrievePostalAddressDetails(string TestDataFile, string PostalAddressID)
        {
             Dictionary<string, string> Postal_Address = new Dictionary<string, string>();
             Postal_Address = DataFilesUtil.GetDataRowWithUniqueKey(TestDataFile, "PostalAddress", "PostalAddressID", PostalAddressID);                
             return Postal_Address;
        }


        #endregion

        #region CleanData

        public static void CleanLastRunData(string FileName, string SheetName ,string TestCaseID)
        {if (SheetName.Contains("OM"))
            {
                DataFilesUtil.SaveDataToExcel(FileName, SheetName, "BP-StormOrderCode", TestCaseID, "");
                DataFilesUtil.SaveDataToExcel(FileName, SheetName, "HP-StormOrderCode", TestCaseID, "");
                DataFilesUtil.SaveDataToExcel(FileName, SheetName, "PortalOrderNumber", TestCaseID, "");
                DataFilesUtil.SaveDataToExcel(FileName, SheetName, "CustomerEmail", TestCaseID, "");
                DataFilesUtil.SaveDataToExcel(FileName, SheetName, "Status", TestCaseID, "");
            }
        else if(FileName.ToUpper().Contains("CANCEL"))
                DataFilesUtil.SaveDataToExcel(FileName, SheetName, "Status", TestCaseID, "");
            DataFilesUtil.SaveDataToExcel(FileName, SheetName, "CustomerEmail", TestCaseID, "");
        }
        #endregion

        #region WriteOrderData
        public static void WriteOrderDetails(ApplicationCache cache,string FileName, string SheetName,string UniqueColumn= "PortalOrderNumber")
        {
            if (UniqueColumn == "PortalOrderNumber")
            {
                DataFilesUtil.SaveDataToExcel(FileName, SheetName, "StormOrderCode", cache.PortalOrderNumber, "");
                DataFilesUtil.SaveDataToExcel(FileName, SheetName, "OrderUpdatedDate", cache.PortalOrderNumber, "");
            }

            else {
                DataFilesUtil.SaveDataToExcel(FileName, SheetName, "PortalOrderNumber","", cache.PortalOrderNumber);
                DataFilesUtil.SaveDataToExcel(FileName, SheetName, "TC_ID", cache.PortalOrderNumber, "");
                DataFilesUtil.SaveDataToExcel(FileName, SheetName, "OrderCreationDate", cache.PortalOrderNumber, "");
            }
        }


        #endregion
    }


}
