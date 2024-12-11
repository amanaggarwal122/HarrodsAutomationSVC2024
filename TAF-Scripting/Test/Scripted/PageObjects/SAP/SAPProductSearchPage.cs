using TAF_SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sapfewse;

namespace TAF_Scripting.Test.Scripted.PageObjects
{
    public class SAPProductSearchPage
    {
        static GuiSession _session;
        public SAPProductSearchPage(GuiSession session)
        {
            _session = session;
        }

        public GuiTextField Article => _session.FindById<GuiTextField>("wnd[0]/usr/tabsTAB300/tabpF01/ssubINCLUDE300:SAPMM61R:0301/ctxtRM61R-MATNR");
        public GuiTextField Site => _session.FindById<GuiTextField>("wnd[0]/usr/tabsTAB300/tabpF01/ssubINCLUDE300:SAPMM61R:0301/ctxtRM61R-WERKS");

        public void SearchArticle(string articleId, string site)
        {
            SAPHandlers.Instance.EnterTextInGuiTextField(Article, articleId);
            SAPHandlers.Instance.EnterTextInGuiTextField(Site, site);

            SAPHandlers.Instance.SendKeysByWindow(_session,SAPKeys.Enter);
        }
        public void ValidatePageTitle(string title, int window = 0)
        {
            string windowTitle = SAPHandlers.Instance.GetWindowTitle(_session, window);
            SAPHandlers.Instance.VerifyTextEquals(windowTitle, title);
        }

    }
}
