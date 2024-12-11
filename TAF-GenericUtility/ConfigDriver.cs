using System;
using System.Configuration;
using System.Collections.Generic;

namespace TAF_GenericUtility
{
    public class ConfigDriver
    {
        public static string strDirPath = null;

        public static string Config(string key)
        {
            try
            {
                ExeConfigurationFileMap file = new ExeConfigurationFileMap();
                file.ExeConfigFilename = getDirPath() + GlobalVariables.getbrowserconfigPath();
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
                AppSettingsSection appsection = (AppSettingsSection)config.GetSection("appSettings");
                return appsection.Settings[key].Value;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Key{0}：{1}/Message：{2}", key, ex.Message, ex.StackTrace));
            }
        }

        public static string getDirPath()
        {
            try
            {
                strDirPath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.IndexOf("\\bin"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return strDirPath;
        }
        public static string getDirPathLibrary()
        {
            try
            {
                strDirPath = getDirPath() + GlobalVariables.getdirectoryconfigPath();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return strDirPath;
        }
        public static string getPropertyValue(string configPath, string key)
        {
            string configValue = string.Empty;
            try
            {
                ExeConfigurationFileMap file = new ExeConfigurationFileMap();
                file.ExeConfigFilename = getDirPath() + configPath;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
                AppSettingsSection appsection = (AppSettingsSection)config.GetSection("appSettings");
                configValue = appsection.Settings[key].Value;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Key{0}：{1}/Message：{2}", key, ex.Message, ex.StackTrace));
            }
            return configValue;
        }

        public static string getConfigValue(string key)
        {
            string configValue = string.Empty;
            try
            {
                ExeConfigurationFileMap file = new ExeConfigurationFileMap();
                file.ExeConfigFilename = getDirPath() + GlobalVariables.GetscriptmateconfigPath();
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
                AppSettingsSection appsection = (AppSettingsSection)config.GetSection("appSettings");
                configValue = appsection.Settings[key].Value;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Key{0}：{1}/Message：{2}", key, ex.Message, ex.StackTrace));
            }
            return configValue;
        }

        public static Dictionary<string, string> GetConfigProperties(string configPath)
        {
            string keyVal1 = string.Empty;
            Dictionary<string, string> objSetting = new Dictionary<string, string>();
            string configValue = string.Empty;
            try
            {
                ExeConfigurationFileMap file = new ExeConfigurationFileMap();
                file.ExeConfigFilename = getDirPath() + configPath;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
                AppSettingsSection appsection = (AppSettingsSection)config.GetSection("appSettings");
                foreach (string keyVal in appsection.Settings.AllKeys)
                {
                    keyVal1 = keyVal;
                    objSetting.Add(keyVal, appsection.Settings[keyVal].Value);
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Key{0}：{1}/Message：{2}", keyVal1, ex.Message, ex.StackTrace));
            }
            return objSetting;
        }
        public static void AddToEnvironmentVariablePath(string valueToAdd)
        {
            const string name = "PATH";
            string pathvar = System.Environment.GetEnvironmentVariable(name);
            string newValue = string.Empty;
            if (!pathvar.Contains(valueToAdd) && !string.IsNullOrEmpty(valueToAdd))
            {
                newValue = pathvar + @";" + valueToAdd;
                var target = EnvironmentVariableTarget.Machine;
                System.Environment.SetEnvironmentVariable(name, newValue, target);
            }

        }
        public static string GetPropertyValue(string configPath, string key)
        {
            string configValue = string.Empty;
            try
            {
                ExeConfigurationFileMap file = new ExeConfigurationFileMap();
                string BasePath = System.AppDomain.CurrentDomain.BaseDirectory.Substring(0, System.AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin"));
                file.ExeConfigFilename = configPath;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
                AppSettingsSection appsection = (AppSettingsSection)config.GetSection("appSettings");
                configValue = appsection.Settings[key].Value;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Key{0}：{1}/Message：{2}", key, ex.Message, ex.StackTrace));
            }
            return configValue;
        }

        public static Dictionary<string, string> GetConfigurationValues(string configPath)
        {
            string keyVal1 = string.Empty;
            Dictionary<string, string> objSetting = new Dictionary<string, string>();
            string configValue = string.Empty;
            try
            {
                ExeConfigurationFileMap file = new ExeConfigurationFileMap();
                file.ExeConfigFilename = configPath;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
                AppSettingsSection appsection = (AppSettingsSection)config.GetSection("appSettings");
                foreach (string keyVal in appsection.Settings.AllKeys)
                {
                    keyVal1 = keyVal;
                    objSetting.Add(keyVal, appsection.Settings[keyVal].Value);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Key{0}：{1}/Message：{2}", keyVal1, ex.Message, ex.StackTrace));
            }
            return objSetting;
        }


    }
}
