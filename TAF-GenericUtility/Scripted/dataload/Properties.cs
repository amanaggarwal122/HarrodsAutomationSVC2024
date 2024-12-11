using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_GenericUtility.Scripted.DataLoad
{
    public class Properties
    {
        private Dictionary<String, String> list;
        private String filename;

        public Properties(String file)
        {
            Reload(file);
        }

        public String Get(String field, String defValue)
        {
            return (Get(field) == null) ? (defValue) : (Get(field));
        }

        public String Get(String field)
        {
            return (list.ContainsKey(field)) ? (list[field]) : (null);
        }

        public void Reload()
        {
            Reload(this.filename);
        }

        public void Reload(String filename)
        {
            this.filename = filename;
            list = new Dictionary<String, String>();

            if (System.IO.File.Exists(filename))
                LoadFromFile(filename);
            else
                System.IO.File.Create(filename);
        }

        private void LoadFromFile(String file)
        {
            using (var stream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    while (sr.Peek() >= 0)
                    {
                        string line = sr.ReadLine();
                        if ((!String.IsNullOrEmpty(line)) &&
                            (!line.StartsWith(";")) &&
                            (!line.StartsWith("#")) &&
                            (!line.StartsWith("'")) &&
                            (line.Contains('=')))
                        {
                            int index = line.IndexOf('=');
                            String key = line.Substring(0, index).Trim();
                            String value = line.Substring(index + 1).Trim();

                            if ((value.StartsWith("\"") && value.EndsWith("\"")) ||
                                (value.StartsWith("'") && value.EndsWith("'")))
                            {
                                value = value.Substring(1, value.Length - 2);
                            }

                            try
                            {
                                //ignore dublicates
                                list.Add(key, value);
                            }
                            catch { }
                        }
                    }
                }
            }
        }
    }
}
