using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_GenericUtility.Scripted.Generic
{
    public class PathUtil
    {
        public static string Combine(string path1, string path2)
        {
            return Path.Combine(path1, Path.IsPathRooted(path2) ? path2.Substring(1, path2.Length - 1) : path2);
        }

        public static string BasePath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory.Substring(0, System.AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin"));
        }
    }

}
