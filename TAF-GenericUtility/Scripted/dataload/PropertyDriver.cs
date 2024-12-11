using System;
using System.IO;

using TAF_GenericUtility.Scripted.generic;

namespace TAF_GenericUtility.Scripted.dataload
{
    public class PropertyDriver
    {

        public static FileInfo filePath;


        /**
         * Constructors based on input parameter type
         * @param filename - full name of the property file
         */

        public static void setPropFilePath(String filename)
        {
            FileInfo filePath = new FileInfo(FileUtils.GetFilePath(filename));
            PropertyDriver.filePath = filePath;
        }


        public static FileInfo getFilePath()
        {
            return PropertyDriver.filePath;

        }
        /**
         * Read the property value based on key
         * @param key - identification key
         */

        public static FileInfo readProp()
        {
            try
            {
                FileInfo fileInfo = getFilePath();
                return fileInfo;
                //FileReader reader = new FileReader(filePath);
                //Properties pf = new Properties();
                //pf.load(reader);
                //return pf.getProperty(key);
            }
            catch (Exception)
            {
                //e.printStackTrace();
                return null;
            }
        }



    }
}
