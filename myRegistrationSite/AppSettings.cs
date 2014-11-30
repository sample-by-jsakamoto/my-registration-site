using System.Configuration;

namespace myRegistrationSite
{
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    public static class AppSettings
    {
        public static string ClientValidationEnabled
        {
            get { return ConfigurationManager.AppSettings["ClientValidationEnabled"]; }
        }

        public static class Smtp
        {
            public static string Credential
            {
                get { return ConfigurationManager.AppSettings["smtp.credential"]; }
            }

            public static string From
            {
                get { return ConfigurationManager.AppSettings["smtp.from"]; }
            }

            public static string Network
            {
                get { return ConfigurationManager.AppSettings["smtp.network"]; }
            }
        }

        public static string UnobtrusiveJavaScriptEnabled
        {
            get { return ConfigurationManager.AppSettings["UnobtrusiveJavaScriptEnabled"]; }
        }

        public static class Webpages
        {
            public static string Enabled
            {
                get { return ConfigurationManager.AppSettings["webpages:Enabled"]; }
            }

            public static string Version
            {
                get { return ConfigurationManager.AppSettings["webpages:Version"]; }
            }
        }
    }
}

