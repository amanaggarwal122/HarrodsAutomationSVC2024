using TAF_SAP;
using System;
using sapfewse;
using NUnit.Framework;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    public  class SAPStockOverview
    {
        static GuiFrameWindow _frameWindow;
        static GuiSession _session;

        /*Window Stock Overview*/
        public GuiCTextField merchandiseCateg => _frameWindow.FindById<GuiCTextField>("usr/ctxtP_MATKL");
        public GuiCTextField ArticleTo => _frameWindow.FindById<GuiCTextField>("usr/ctxtS_MATNR-LOW");
        public GuiCTextField SiteTo => _frameWindow.FindById<GuiCTextField>("usr/tabsTABSTRIP_SEL_DISP/tabpSEL_CRI/ssub%_SUBSCREEN_SEL_DISP:RWBEST01:1010/ctxtS_WERKS-LOW");
        public GuiButton execButton => _frameWindow.FindById<GuiButton>("tbar[1]/btn[8]");


        public GuiLabel siteStockOverview => _frameWindow.FindById<GuiLabel>("usr/lbl[26,10]");
        public SAPStockOverview(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;
        }

        public void onStockOverviewScreen()
        {
            if (merchandiseCateg == null)
                _session.GotoTransaction("/nRwbe");
        }

        public int viewStock(string articleNumber, string site)
        {
           
            SAPHandlers.Instance.EnterTextInGuiCTextField(SiteTo, site);
            SAPHandlers.Instance.EnterTextInGuiCTextField(ArticleTo, articleNumber);
            SAPHandlers.Instance.ClickButton(execButton);

            string balStock = SAPHandlers.Instance.GetLabelText(siteStockOverview);
            decimal decBalance = Convert.ToDecimal(string.IsNullOrEmpty(balStock) ? "0" : balStock);
            
            int availableStock = Convert.ToInt32(decBalance);           

            return availableStock;
        }

       
    }

   
}
