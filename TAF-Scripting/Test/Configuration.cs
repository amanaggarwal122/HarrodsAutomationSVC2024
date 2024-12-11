using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_GenericUtility;
using TAF_GenericUtility.Scripted.Security;

namespace TAF_Scripting.Test
{
    public class Configuration
    {
        private string propertyFile = string.Empty;

        public string SCAYLEUrl { get; set; }
        public string SCAYLEUserName { get; set; }
        public string SCAYLEPassword { get; set; }

        public string YopMailUrl { get; set; }
        public string FFCustomerPassword { get; set; }
        public string FFUrl { get; set; }
        public string FFLiteVerifyUrl { get; set; }
        public string FFProductUrl { get; set; }
        public string FFUserName { get; set; }
        public string FFPassword { get; set; }
        public string BBUrl { get; set; }
        public string BBBookingUrl { get; set; }
        public string IDSUrl { get; set; }
        public string IDSUserName { get; set; }
        public string IDSPassword { get; set; }
        public string CDCUrl { get; set; }
        public string CDCUserName { get; set; }
        public string CDCPassword { get; set; }
        public string SMCUrl { get; set; }
        public string SMCUserName { get; set; }
        public string SMCPassword { get; set; }
        public string SSCUrl { get; set; }
        public string SSCUserName { get; set; }
        public string SSCPassword { get; set; }
        public string SSCTicketAssignedTo { get; set; }
        public string ACUrl { get; set; }
        public string ACUserName { get; set; }
        public string ACPassword { get; set; }
        public string SCVUrl { get; private set; }
        public string SCVUserName { get; private set; }
        public string SCVPassword { get; private set; }
        public string CRMUrl { get; set; }
        public string CRMUserName { get; set; }
        public string CRMPassword { get; set; }
        public string STORMUrl { get; set; }
        public string STORMUserName { get; set; }
        public string STORMPassword { get; set; }
        public string SAPWebEmulator { get; set; }

        public string SAPLanguage { get; set; }
        public string SAPUserName { get; set; }
        public string SAPHQ4 { get; set; }
        public string SAPHQ4Client { get; set; }
        public string SAPHQ4Password { get; set; }
        public string SAPEQ1 { get; set; }
        public string SAPEQ1Client { get; set; }
        public string SAPEQ1Password { get; set; }
        public string SAPCQ1 { get; set; }
        public string SAPCQ1Client { get; set; }
        public string SAPCQ1Password { get; set; }
       
          
       
        
       
        public string AllocUser { get; set; }
        public string AllocUserPassword { get; set; }

        public string EmailRegisteredAppName { get; set; }
        public string EmailUserName { get; set; }
        public string EmailRegistrationFilter { get; set; }
        public string EmailCredentialFilePath { get; set; }

        public string PaymentCardNumber { get; set; }
        public string PaymentExpiryMonth { get; set; }
        public string PaymentExpiryYear { get; set; }
        public string PaymentNameOnCard { get; set; }
        public string PaymentCVV { get; set; }

        public Configuration()
        {
            propertyFile = GlobalVariables.GetHarrodsConfig();
        }

        public Configuration Init()
        {
            SCAYLEUrl = ConfigDriver.getPropertyValue(propertyFile, "SCAYLE.Url");
            SCAYLEUserName = ConfigDriver.getPropertyValue(propertyFile, "SCAYLE.UserName");
            SCAYLEPassword = ConfigDriver.getPropertyValue(propertyFile, "SCAYLE.Password");

            FFCustomerPassword = ConfigDriver.getPropertyValue(propertyFile, "FF.CustomerPassword");
            FFUrl = ConfigDriver.getPropertyValue(propertyFile, "FF.Url");
            FFLiteVerifyUrl = ConfigDriver.getPropertyValue(propertyFile, "FF.LiteVerifyUrl");
            FFProductUrl = ConfigDriver.getPropertyValue(propertyFile, "FF.ProductUrl");
            FFUserName = ConfigDriver.getPropertyValue(propertyFile, "FF.UserName");
            FFPassword = ConfigDriver.getPropertyValue(propertyFile, "FF.Password") ;
            SCVUrl = ConfigDriver.getPropertyValue(propertyFile, "SCV.Url");
            SCVUserName = ConfigDriver.getPropertyValue(propertyFile, "SCV.UserName");
            SCVPassword = ConfigDriver.getPropertyValue(propertyFile, "SCV.Password");

            BBUrl = ConfigDriver.getPropertyValue(propertyFile, "BB.Url");
            BBBookingUrl = ConfigDriver.getPropertyValue(propertyFile, "BB.BookingUrl");

            IDSUrl = ConfigDriver.getPropertyValue(propertyFile, "IDS.Url");
            IDSUserName = ConfigDriver.getPropertyValue(propertyFile, "IDS.UserName");
            IDSPassword = ConfigDriver.getPropertyValue(propertyFile, "IDS.Password");

            CDCUrl = ConfigDriver.getPropertyValue(propertyFile, "CDC.Url");
            CDCUserName = ConfigDriver.getPropertyValue(propertyFile, "CDC.UserName");
            CDCPassword = ConfigDriver.getPropertyValue(propertyFile, "CDC.Password");

            SSCUrl = ConfigDriver.getPropertyValue(propertyFile, "SSC.Url");
            SSCUserName = ConfigDriver.getPropertyValue(propertyFile, "SSC.UserName");
            SSCPassword = ConfigDriver.getPropertyValue(propertyFile, "SSC.Password");
            SSCTicketAssignedTo = ConfigDriver.getPropertyValue(propertyFile, "SSC.TicketAssignedTo");
            
            SMCUrl = ConfigDriver.getPropertyValue(propertyFile, "SMC.Url");
            SMCUserName = ConfigDriver.getPropertyValue(propertyFile, "SMC.UserName");
            SMCPassword = ConfigDriver.getPropertyValue(propertyFile, "SMC.Password");

            YopMailUrl = ConfigDriver.getPropertyValue(propertyFile, "YopMailUrl.Url");

            ACUrl = ConfigDriver.getPropertyValue(propertyFile, "AC.Url");
            ACUserName = ConfigDriver.getPropertyValue(propertyFile, "AC.UserName");
            ACPassword = ConfigDriver.getPropertyValue(propertyFile, "AC.Password");

            CRMUrl = ConfigDriver.getPropertyValue(propertyFile, "CRM.Url");
            CRMUserName = ConfigDriver.getPropertyValue(propertyFile, "CRM.UserName");
            CRMPassword = ConfigDriver.getPropertyValue(propertyFile, "CRM.Password");
            STORMUrl = ConfigDriver.getPropertyValue(propertyFile, "STORM.Url");
            STORMUserName = ConfigDriver.getPropertyValue(propertyFile, "STORM.UserName");
            STORMPassword = ConfigDriver.getPropertyValue(propertyFile, "STORM.Password");

            SAPWebEmulator = ConfigDriver.getPropertyValue(propertyFile, "SAPWebEmulator.Url");
            SAPUserName = ConfigDriver.getPropertyValue(propertyFile, "SAP.UserName");
            SAPEQ1Password = ConfigDriver.getPropertyValue(propertyFile, "SAP.EQ1Password");
            SAPHQ4Password = ConfigDriver.getPropertyValue(propertyFile, "SAP.HQ4Password");
            SAPCQ1Password = ConfigDriver.getPropertyValue(propertyFile, "SAP.CQ1Password");
            SAPEQ1Client = ConfigDriver.getPropertyValue(propertyFile, "SAP.EQ1Client");
            SAPHQ4Client = ConfigDriver.getPropertyValue(propertyFile, "SAP.HQ4Client");
            SAPCQ1Client = ConfigDriver.getPropertyValue(propertyFile, "SAP.CQ1Client");
            SAPLanguage = ConfigDriver.getPropertyValue(propertyFile, "SAP.Language");
            SAPHQ4 = ConfigDriver.getPropertyValue(propertyFile, "SAP.HQ4");
            SAPEQ1 = ConfigDriver.getPropertyValue(propertyFile, "SAP.EQ1");
            SAPCQ1 = ConfigDriver.getPropertyValue(propertyFile, "SAP.CQ1");



            AllocUser = ConfigDriver.getPropertyValue(propertyFile, "SAP.AllocUser");
            AllocUserPassword = ConfigDriver.getPropertyValue(propertyFile, "SAP.AllocUserPassword");
            EmailRegisteredAppName = ConfigDriver.getPropertyValue(propertyFile, "Email.RegisteredAppName");
            EmailUserName = ConfigDriver.getPropertyValue(propertyFile, "Email.UserName");
            EmailRegistrationFilter = ConfigDriver.getPropertyValue(propertyFile, "Email.RegistrationFilter");
            PaymentCardNumber = ConfigDriver.getPropertyValue(propertyFile, "Payment.CardNumber");
            PaymentExpiryMonth = ConfigDriver.getPropertyValue(propertyFile, "Payment.ExpiryMonth");
            PaymentExpiryYear = ConfigDriver.getPropertyValue(propertyFile, "Payment.ExpiryYear");
            PaymentNameOnCard = ConfigDriver.getPropertyValue(propertyFile, "Payment.NameOnCard");
            PaymentCVV = ConfigDriver.getPropertyValue(propertyFile, "Payment.CVV");

            EmailCredentialFilePath = GetCredentialFile();

            return this;
        }

        private string GetCredentialFile()
        {
            return $"{ConfigDriver.getDirPath()}\\Resources\\Email\\credentials.json";             
        }
    }
}
