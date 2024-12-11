using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TAF_GenericUtility.Scripted.generic
{
    class Extensions
    {
    }

    public static class TableExtensions
    {
        public static Dictionary<string, List<string>> TableRowsToDictionary(this Table dt)
        {
            var lstDict = new Dictionary<string, List<string>>();

            if (dt != null)
            {
                var headers = dt.Header;

                foreach (var row in dt.Rows)
                {
                    foreach (var header in headers)
                    {
                        if (lstDict.ContainsKey(header))
                        {
                            lstDict[header].Add(row[header]);
                        }
                        else
                        {
                            lstDict.Add(header, new List<string> { row[header] });
                        }
                    }
                }
            }

            return lstDict;
        }

        

    }    

    public static class ImageExtensions
    {
        public static byte[] ToByteArray(this Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }
    }

    public static class StringExtensions
    {
        public static bool CaseInsensitiveContains(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }

        public static string ParseColor(this string cssColor)
        {
            cssColor = cssColor.Trim();

            if (cssColor.StartsWith("#"))
            {
                return ColorTranslator.FromHtml(cssColor).ToString();
            }
            else if (cssColor.StartsWith("rgb")) //rgb or argb
            {
                int left = cssColor.IndexOf('(');
                int right = cssColor.IndexOf(')');

                if (left < 0 || right < 0)
                    throw new FormatException("rgba format error");
                string noBrackets = cssColor.Substring(left + 1, right - left - 1);

                string[] parts = noBrackets.Split(',');

                int r = int.Parse(parts[0], CultureInfo.InvariantCulture);
                int g = int.Parse(parts[1], CultureInfo.InvariantCulture);
                int b = int.Parse(parts[2], CultureInfo.InvariantCulture);

                return String.Format("#{0:X2}{1:X2}{2:X2}", r, g, b);

            }
            throw new FormatException("Not rgb, rgba or hexa color string");
        }
    }

    public static class DictionaryExtensions
    {
        public static void AddToNestedDictionary<TKey, TNestedDictionary, TNestedKey, TNestedValue>(
            this IDictionary<TKey, TNestedDictionary> dictionary,
            TKey key,
            TNestedKey nestedKey,
            TNestedValue nestedValue
        ) where TNestedDictionary : IDictionary<TNestedKey, TNestedValue>
        {
            dictionary.AddToNestedDictionary(
                key,
                nestedKey,
                nestedValue,
                () => (TNestedDictionary)(IDictionary<TNestedKey, TNestedValue>)
                    new Dictionary<TNestedKey, TNestedValue>());
        }

        public static void AddToNestedDictionary<TKey, TNestedDictionary, TNestedKey, TNestedValue>(
            this IDictionary<TKey, TNestedDictionary> dictionary,
            TKey key,
            TNestedKey nestedKey,
            TNestedValue nestedValue,
            Func<TNestedDictionary> provider
        ) where TNestedDictionary : IDictionary<TNestedKey, TNestedValue>
        {
            TNestedDictionary nested;
            if (!dictionary.TryGetValue(key, out nested))
            {
                nested = provider();
                dictionary.Add(key, nested);
            }
            nested.Add(nestedKey, nestedValue);
        }
    }

}
