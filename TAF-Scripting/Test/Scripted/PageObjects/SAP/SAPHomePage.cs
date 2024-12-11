using TAF_SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sapfewse;
using NUnit.Framework;

namespace TAF_Scripting.Test.Scripted.PageObjects
{
    public class SAPHomePage
    {
       public static GuiSession _session;
        public SAPHomePage(GuiSession session)
        {
            _session = session;
        }

        public GuiOkCodeField Transaction => _session.FindById<GuiOkCodeField>("wnd[0]/tbar[0]/okcd");

        public GuiTree MainMenu => _session.FindById<GuiTree>("wnd[0]/usr/cntlIMAGE_CONTAINER/shellcont/shell/shellcont[0]/shell");

        public void SelectTransaction(string transaction)
        {
            SAPHandlers.Instance.EnterTextInGuiOkCodeField(Transaction, transaction);
            SAPHandlers.Instance.SendKeysByWindow(_session,SAPKeys.Enter);
        }

        public void SelectTransactionFromMenu(string node)
        {
            SAPHandlers.Instance.SelectTreeNodeByCode(MainMenu, node);
        }

        public void ValidatePageTitle(string title, int window = 0)
        {
            string windowTitle = SAPHandlers.Instance.GetWindowTitle(_session, window);
            SAPHandlers.Instance.VerifyTextContains(windowTitle, title);
        }

        public void SAPLogin(Configuration config,string connection)
        {
            if (connection.Contains("HQ4"))
                SAPDriver.Instance.Login(config.SAPHQ4, config.SAPUserName, config.SAPHQ4Password, config.SAPHQ4Client, config.SAPLanguage);
            else if (connection.Contains("EQ1"))
                SAPDriver.Instance.Login(config.SAPEQ1, config.SAPUserName, config.SAPEQ1Password, config.SAPEQ1Client, config.SAPLanguage);
            else
                Assert.Fail("No connection available");

        }

    }
}
