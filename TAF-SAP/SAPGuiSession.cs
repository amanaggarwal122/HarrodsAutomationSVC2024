using sapfewse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_SAP
{
    public class SAPGuiSession
    {
        private GuiSession session;

        private GuiConnection connection;

        private GuiApplication app;

        public SAPGuiSession(SAPLogon logon) {
            this.app = logon.Application;
            this.connection = logon.Connection;
            this.session = logon.Session;
        }
    }
}
