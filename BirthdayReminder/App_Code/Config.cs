using System;
using System.Configuration;

namespace BirthdayReminder.App_Code
{
    public class Config
    {
        private const string connectionStringName = "MyConnectionString";
        private static string connectionString = String.Empty;
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    if (ConfigurationManager.ConnectionStrings[connectionStringName] != null)
                    {
                        connectionString = ConfigurationManager.ConnectionStrings
                        [connectionStringName].ConnectionString;
                    }
                    else
                    {
                        throw new Exception(String.Format("The connection string '{0}' is not defined in the configuration file", connectionStringName));
                    }
                }
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }
    }
}