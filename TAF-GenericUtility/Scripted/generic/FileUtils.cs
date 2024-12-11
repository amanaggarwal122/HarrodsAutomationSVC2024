using System;
using System.IO;
using System.Threading;

namespace TAF_GenericUtility.Scripted.generic
{
    public class FileUtils
    {
        private static string cdir = ConfigDriver.getDirPathLibrary();

        public static String GetFilePath(String fileName)
        {
            //log.info("Inside FileUtil.getFilePath method");
            String filePath = cdir + "/" + fileName;
            try
            {
                FileInfo file = new FileInfo(filePath);
            }
            catch (Exception e)
            {
                //log.error(e);
                throw e;//new Exceptions(new RuntimeException(e.getMessage()));
            }
            return cdir + "/" + fileName;
        }

        public static void setDirectory(String path)
        {
            //log.info("Inside FileUtil.setDirectory method");
            cdir = path;
            try
            {
                FileInfo file = new FileInfo(cdir);
                if (!file.Exists)
                    throw new FileNotFoundException();

            }
            catch (Exception e)
            {
                //log.error(e);
                throw e;
            }
        }

        public static string getCurrentDir()
        {
            return cdir;
        }

        public static void DirectoryCreateIfNotExists(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public static void DirectoryDeleteAndCreate(string path)
        {
            DirectoryDelete(path, true);
            DirectoryCreateIfNotExists(path);
        }

        public static void DirectoryDelete(string path, bool deletefiles)
        {
            if (Directory.Exists(path))
                Directory.Delete(path, deletefiles);
        }

        public static void DirectoryIfExistsDeleteAndCreate(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryDeleteAndCreate(path);
            }
            else
            {
                DirectoryCreateIfNotExists(path);
            }
        }

        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();

        public static void WriteToFileThreadSafe(string text, string path)
        {
            // Set Status to Locked
            _readWriteLock.EnterWriteLock();
            try
            {
                // Append text to the file
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(text);
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }
    }
}
