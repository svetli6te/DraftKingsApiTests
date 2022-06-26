using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DraftKings.APITests.TestSupport.Managers
{
    public static class ApiManager
    {
        public static string GetBaseUrl()
        {
            return ConfigurationManager.AppSettings.Get("BaseUrl");
        }

        public static string GetBooksEndPoint()
        {
            return ConfigurationManager.AppSettings.Get("BooksEndpoint");
        }

        public static string GetTokenEndPoint()
        {
            return ConfigurationManager.AppSettings.Get("TokenEndpoint");
        }

        public static string GetBookEndPoint()
        {
            return ConfigurationManager.AppSettings.Get("BookEndpoint");
        }

        public static string GetEmail()
        {
            return ConfigurationManager.AppSettings.Get("Email");
        }

        public static string GetUserName()
        {
            return ConfigurationManager.AppSettings.Get("UserName");
        }

        public static string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get("Password");
        }
    }
}
