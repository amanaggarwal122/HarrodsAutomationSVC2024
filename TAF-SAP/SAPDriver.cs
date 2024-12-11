﻿using sapfewse;
using saprotwr;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace TAF_SAP
{
    public delegate void OnRequestErrorHanlder(object sender, SAPRequestInfoArgs e);

    public class SAPDriver
    {
        public event OnRequestErrorHanlder OnRequestError;
        public event OnRequestErrorHanlder OnRequestSuccess;
        public event OnRequestErrorHanlder OnRequestWarning;

        private static object _lockObj = new object();

        private static SAPDriver _instance;

        public List<ScreenData> ScreenDatas { get; private set; }

        private ScreenData _currentScreen;

        private ScreenLogLevel _screenLogLevel;

        private GuiApplication _sapGuiApplication;
        private GuiSession _sapGuiSession;
        private GuiConnection _sapGuiConnection;

        public GuiApplication SAPGuiApplication { get { return _sapGuiApplication; } }
        public GuiSession SAPGuiSession { get { return _sapGuiSession; } }
        public GuiConnection SAPGuiConnection { get { return _sapGuiConnection; } }

        public static GuiApplication GetSAPGuiApp(int secondsOfTimeout = 10)
        {
            saprotwr.net.CSapROTWrapper saprotwrapper = new saprotwr.net.CSapROTWrapper();
            return getSAPGuiApp(saprotwrapper, secondsOfTimeout);
        }

        private static GuiApplication getSAPGuiApp(saprotwr.net.CSapROTWrapper saprotwrapper, int secondsOfTimeout)
        {

            object SapGuilRot = saprotwrapper.GetROTEntry("SAPGUI");
            if (secondsOfTimeout < 0)
            {
                throw new TimeoutException(string.Format("Can get sap script engine in {0} seconds", secondsOfTimeout));
            }
            else
            {
                if (SapGuilRot == null)
                {
                    Thread.Sleep(1000);
                    return getSAPGuiApp(saprotwrapper, secondsOfTimeout - 1);
                }
                else
                {
                    object engine = SapGuilRot.GetType().InvokeMember("GetSCriptingEngine", System.Reflection.BindingFlags.InvokeMethod, null, SapGuilRot, null);
                    if (engine == null)
                        throw new NullReferenceException("No SAP GUI application found");
                    return engine as GuiApplication;
                }
            }
        }

        public SAPDriver()
        {
            this.ScreenDatas = new List<ScreenData>();
            _screenLogLevel = ScreenLogLevel.ScreenOnly;
        }

        public GuiMainWindow MainWindow
        {
            get { return this.GetElementById<GuiMainWindow>("wnd[0]"); }
        }

        public GuiFrameWindow PopupWindow
        {
            get
            {
                if (!(this.SAPGuiSession.ActiveWindow is GuiMainWindow))
                    return this.SAPGuiSession.ActiveWindow;
                else
                    return null;
            }
        }

        public void TurnScreenLog(ScreenLogLevel level)
        {
            _screenLogLevel = level;
            if (_sapGuiSession != null)
            {
                if (_screenLogLevel == ScreenLogLevel.ScreenAndDetails || _screenLogLevel == ScreenLogLevel.All)
                {
                    _sapGuiSession.Record = true;
                }
                else
                {
                    _sapGuiSession.Record = false;
                }
            }
        }

        public static SAPDriver Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObj)
                    {
                        if (_instance == null)
                            _instance = new SAPDriver();
                    }
                }
                return _instance;
            }
        }

        public static SAPDriver GetCurrentInstance()
        {
            return _instance;

        }

        #region SetSession
        public void SetSession(SAPLogon logon)
        {
            SetSession(logon.Application, logon.Connection, logon.Session);
        }

        public void SetSession(GuiApplication application, GuiConnection connection, GuiSession session)
        {
            this._sapGuiApplication = application;
            this._sapGuiConnection = connection;
            this._sapGuiSession = session;
            _currentScreen = new ScreenData(session.Info.SystemName, session.Info.Transaction, session.Info.Program, session.Info.ScreenNumber, session.ActiveWindow.Text);
            hookSessionEvent();
        }

        public void SetSession(string BoxName)
        {
            var application = GetSAPGuiApp();
            GuiConnection connection = null;
            GuiSession session = null;
            int index = application.Connections.Count - 1;
            if (index < 0)
            {
                throw new Exception("No SAP GUI Connections found");
            }
            for (int i = 0; i < application.Children.Count; i++)
            {
                var con = application.Children.ElementAt(i) as GuiConnection;
                index = con.Sessions.Count - 1;
                if (index < 0)
                {
                    throw new Exception("No SAP GUI Session Found");
                }
                for (int j = 0; j < con.Sessions.Count; j++)
                {
                    var ses = con.Children.ElementAt(j) as GuiSession;
                    if (ses.Info.SystemName.ToLower() == BoxName.ToLower())
                    {
                        session = ses;
                        break;
                    }

                }
                if (session != null)
                {
                    connection = con;
                    break;
                }
            }
            if (session != null)
            {
                SetSession(application, connection, session);
            }
            else
            {
                throw new Exception("No SAP GUI Session Found");
            }
        }

        public void SetSession()
        {
            var application = GetSAPGuiApp();
            int index = application.Connections.Count - 1;
            if (index < 0)
            {
                throw new Exception("No SAP GUI Connections found");
            }

            var connection = application.Children.ElementAt(index) as GuiConnection;
            index = connection.Sessions.Count - 1;
            if (index < 0)
            {
                throw new Exception("No SAP GUI Session Found");
            }
            var session = connection.Children.ElementAt(index) as GuiSession;

            SetSession(application, connection, session);
        }

        private void hookSessionEvent()
        {
            _sapGuiSession.Destroy -= _sapGuiSession_Destroy;
            _sapGuiSession.Destroy += _sapGuiSession_Destroy;
            _sapGuiSession.EndRequest -= _sapGuiSession_EndRequest;
            _sapGuiSession.EndRequest += _sapGuiSession_EndRequest;
            _sapGuiSession.StartRequest -= _sapGuiSession_StartRequest;
            _sapGuiSession.StartRequest += _sapGuiSession_StartRequest;
            _sapGuiSession.Change -= _sapGuiSession_Change;
            _sapGuiSession.Change += _sapGuiSession_Change;
            _sapGuiSession.EndRequest += _sapGuiSession_EndRequest1;
            _sapGuiSession.StartRequest += _sapGuiSession_StartRequest1;
        }


        #endregion

        #region Get SAP GUI Component
        public T GetElementById<T>(string id) where T : class
        {
            var component = GetElementById(id);
            T element = component as T;
            return element;
        }

        public GuiComponent GetElementById(string id)
        {
            GuiComponent component = _sapGuiSession.FindById(id);
            return component;
        }

        public GuiComponent TryGetElementById(string id)
        {
            try
            {
                return GetElementById(id);
            }
            catch
            {
                return null;
            }
        }

        public T TryGetElementById<T>(string id) where T : class
        {
            try
            {
                return GetElementById<T>(id);
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// This Method will find the element until the timeout, if secondsOfTimeout set to less than 0, this method will continue to find element without timeout
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="secondsOfFrequence"></param>
        /// <param name="secondsOfTimeout"></param>
        /// <returns></returns>
        public T GetElementUntil<T>(string id, int secondsOfFrequence, int secondsOfTimeout) where T : class
        {
            T comp = TryGetElementById<T>(id);
            if (comp == null)
            {
                Thread.Sleep(secondsOfFrequence * 1000);
                if (secondsOfTimeout < 0)
                {
                    return GetElementUntil<T>(id, secondsOfFrequence, secondsOfTimeout);
                }
                else
                {
                    if (secondsOfFrequence == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return GetElementUntil<T>(id, secondsOfFrequence, secondsOfTimeout - 1);
                    }
                }
            }

            return comp;

        }
        #endregion

        #region ScreenShot
        private ImageCodecInfo getEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public void TakeScreenShot(string filePath)
        {
            FileInfo f = new FileInfo(filePath);
            if (!f.Directory.Exists)
                f.Directory.Create();
            GuiFrameWindow win = _sapGuiSession.ActiveWindow;
            win.Maximize();

            byte[] screenData = (byte[])win.HardCopyToMemory();
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            ImageCodecInfo jpgEncoder = getEncoder(ImageFormat.Jpeg);

            using (var ms = new MemoryStream(screenData))
            {
                Bitmap bmp = new Bitmap(ms);
                EncoderParameters paras = new EncoderParameters(1);

                EncoderParameter para1 = new EncoderParameter(myEncoder, 50L);
                paras.Param[0] = para1;
                bmp.Save(filePath, jpgEncoder, paras);
            }


        }
        #endregion

        //public void CloseSession()
        //{
        //    _sapGuiConnection.CloseSession(SAPGuiSession.Id);
        //}

        public void CloseSession(string Id)
        {
            _sapGuiConnection.CloseSession(Id);
        }

        public void CloseAllConnections()
        {
            if (_sapGuiApplication.Connections!=null)
            {
                var sessionCount = _sapGuiApplication.Connections.Count;
                for (int i = 0; i < sessionCount; i++)
                {
                    var connection = _sapGuiApplication.Connections.ElementAt(0) as GuiConnection;
                    connection.CloseConnection();
                }
            }
        }


        public void CloseConnection()
        {
            _sapGuiConnection.CloseSession(SAPGuiSession.Id);
            _sapGuiConnection.CloseConnection();
        }

        void _sapGuiSession_Destroy(GuiSession Session)
        {
            _sapGuiSession = null;
        }

        void _sapGuiSession_Change(GuiSession Session, GuiComponent Component, object CommandArray)
        {
            if (_currentScreen != null)
            {
                SAPGuiElement comp = new SAPGuiElement()
                {
                    Id = Component.Id,
                    Type = Component.Type,
                    Name = Component.Name,
                };

                GuiVComponent vC = Component as GuiVComponent;
                if (vC != null)
                {
                    comp.Left = vC.Left;
                    comp.Top = vC.Top;
                    comp.Width = vC.Width;
                    comp.Height = vC.Height;
                    comp.AbsoluteLeft = vC.ScreenLeft - _sapGuiSession.ActiveWindow.ScreenLeft;
                    comp.AbsoluteTop = vC.ScreenTop - _sapGuiSession.ActiveWindow.ScreenTop;
                }

                object[] objs = CommandArray as object[];
                objs = objs[0] as object[];
                switch (objs[0].ToString().ToLower())
                {
                    case "m":
                        comp.Action = BindingFlags.InvokeMethod;
                        break;
                    case "sp":
                        comp.Action = BindingFlags.SetProperty;
                        break;
                }
                var action = objs[1].ToString();
                upperFirstChar(ref action);
                comp.ActionName = action;

                var count = objs.Count();

                if (count > 2)
                {
                    comp.ActionValues = new object[count - 2];
                    for (int i = 2; i < count; i++)
                    {
                        comp.ActionValues[i - 2] = objs[i];
                    }
                }
                _currentScreen.SAPGuiElements.Add(comp);
            }
        }

        private void upperFirstChar(ref string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                s = char.ToUpper(s[0]) + s.Substring(1);
            }
        }

        void _sapGuiSession_StartRequest(GuiSession Session)
        {
            GuiStatusbar status = _sapGuiSession.FindById<GuiStatusbar>("wnd[0]/sbar");
            if (status != null)
            {
                switch (status.MessageType)
                {
                    case "E":
                        Thread.Sleep(2000);
                        break;
                    case "S":
                        Thread.Sleep(2000);
                        break;
                    case "W":
                        Thread.Sleep(2000);
                        break;
                    default:
                        break;
                }
            }
            autoScreenShot();
        }

        private void autoScreenShot()
        {
            if (_screenLogLevel == ScreenLogLevel.All)
            {
                string name = ScreenDatas.Count.ToString() + ".jpg";
                TakeScreenShot(name);
                _currentScreen.ScreenShot = name;
            }
        }

        public static int count = 0;
        public static int sCount = 0;
        void _sapGuiSession_EndRequest1(GuiSession Session)
        {
            count++;
        }

        void _sapGuiSession_StartRequest1(GuiSession Session)
        {
            sCount++;
        }

        void _sapGuiSession_EndRequest(GuiSession Session)
        {
            ScreenDatas.Add(_currentScreen);
            Tuple<string, string, string, int, string> sessionInfo = new Tuple<string, string, string, int, string>(Session.Info.SystemName, Session.Info.Transaction, Session.Info.Program, Session.Info.ScreenNumber, Session.ActiveWindow.Text);


            GuiStatusbar status = _sapGuiSession.FindById<GuiStatusbar>("wnd[0]/sbar");
            if (status != null)
            {
                switch (status.MessageType)
                {
                    case "E":
                        _currentScreen.Status = ScreenStatus.Fail;
                        if (OnRequestError != null)
                            OnRequestError(this, new SAPRequestInfoArgs(status.Text));
                        break;
                    case "S":
                        _currentScreen.Status = ScreenStatus.Success;
                        if (OnRequestSuccess != null)
                            OnRequestSuccess(this, new SAPRequestInfoArgs(status.Text));
                        break;
                    case "W":
                        _currentScreen.Status = ScreenStatus.Warning;
                        if (OnRequestWarning != null)
                            OnRequestWarning(this, new SAPRequestInfoArgs(status.Text));
                        break;
                    default:
                        _currentScreen.Status = ScreenStatus.Pass;
                        break;
                }
            }

            newScreen(sessionInfo);
        }

        public void End()
        {
            autoScreenShot();
            ScreenDatas.Add(_currentScreen);
        }

        public void SaveLog(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(List<ScreenData>));
                xs.Serialize(fs, ScreenDatas);
            }
        }

        void newScreen(Tuple<string, string, string, int, string> sessionInfo)
        {

            _currentScreen = new ScreenData(sessionInfo.Item1, sessionInfo.Item2, sessionInfo.Item3, sessionInfo.Item4, sessionInfo.Item5);
        }

        public string Login(string server,
           string userName, string password, string client, string language)
        {
            string logonMessage = string.Empty;

            SAPLogon l = new SAPLogon();
            StartProcess();
            l.OpenConnection($"{server}");
            l.Login(userName, password, client, language, out logonMessage);

            SetSession(l);

            return logonMessage;
        }

        public  GuiSession GetSession(int sessionid=0)
        {
            
            GuiApplication Application;
            GuiConnection Connection;
            GuiSession guiSession;

            Application = GetSAPGuiApp(100);
            var connections = Application.Children;
            try
            {               
                Connection = (GuiConnection)connections.ElementAt(0);
                guiSession = (GuiSession)Connection.Sessions.Item(sessionid);
            }
            catch
            {
                int conCount = connections.Count;
                Connection = (GuiConnection)connections.ElementAt(conCount-1);
                guiSession = (GuiSession)Connection.Sessions.Item(sessionid);
            }

            return guiSession;
        }


        public void StartProcess(string processPath = "saplogon.exe")
        {
            Process.Start(processPath);
        }

        public void CloseProcess(string processPath = "saplogon")
        {
            Process[] workers = Process.GetProcessesByName(processPath);

            foreach (Process worker in workers)
            {
                if (worker.ProcessName.ToLower().Contains("sap"))
                {
                    try
                    {
                        worker.Kill();
                        break;
                    }
                    catch (Exception ex)
                    {
                        worker.CloseMainWindow();
                    }
                   
                }
            }

        }
    }

    public class SAPRequestInfoArgs : EventArgs
    {
        public string Message { get; set; }

        public SAPRequestInfoArgs() { }

        public SAPRequestInfoArgs(string Msg)
        {
            this.Message = Msg;
        }
    }
}
