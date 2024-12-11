
using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using System.IO;

namespace TAF_GenericUtility.Scripted.Screenshot
{

    /// <summary>
    /// Provides functions to capture the entire screen, or a particular window, and save it to a file.
    /// </summary>
    public class ScreenCapture
    {
        public string dirPath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.IndexOf("\\bin"));

        /// <summary>
        /// Creates an Image object containing a screen shot of the entire desktop
        /// </summary>
        /// <returns></returns>
        public Image CaptureScreen()
        {

            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);

            }

            return bmp;
        }

        public void CaptureScreenToFile(string filename, ImageFormat format)
        {
           
            Image img = CaptureScreen();
            img.Save(filename, format);
        }

        public string CaptureScreenToFile(ScenarioContext _scenarioContext,string FileNameAppender="")
        {
            //if (_scenarioContext.TestError != null)
            //{
                try
                {
                    string[] tags = _scenarioContext.ScenarioInfo.Tags;

                    string fileNameBase = string.Format("Screenshot_{0}_{1}",
                                                         tags.Length > 0 ? tags[0] : string.Empty,
                                                         string.IsNullOrEmpty(FileNameAppender)?DateTime.Now.ToString("yyyyMMdd_HHmmss"): FileNameAppender);

                    string screenshotFolder = Path.Combine(dirPath + GlobalVariables.getScreenShotPath());

                    string filepath = string.Format("{0}\\{1}", screenshotFolder, DateTime.Now.ToString("dd-MM-yyyy"));

                    if (!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }

                    string screenshotFilePath = Path.Combine(filepath, fileNameBase + ".png");

                    Image img = CaptureScreen();
                    img.Save(screenshotFilePath, ImageFormat.Png);

                    return screenshotFilePath;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while taking screenshot: {0}", ex);
                }
            //}
            return string.Empty;

        }
    }
}