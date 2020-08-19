using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Configuration;
namespace VendorPortal.Data
{ 
    public static class DbUtils
    { 
        public static bool TableExists(string TableName) {
            var _config = ConfigurationHelper.GetConfiguration(Environment.CurrentDirectory);  
            var connectionString = _config.GetConnectionString("DefaultConnection"); 
            SqlDataReader oReader;
            bool result = false; 
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                SqlCommand oCmd = new SqlCommand($"SELECT * FROM sys.tables WHERE name = @TableName", myConnection);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@TableName";
                param.Value = TableName;
                oCmd.Parameters.Add(param); 
                myConnection.Open();
                using (oReader = oCmd.ExecuteReader())
                {
                    result = oReader.HasRows; 
                    myConnection.Close();
                }
            }
            return result;
        }
        public static string GetSaltById(int ProfileID) {
            SqlDataReader oReader;
            string result = "";
            var _config = ConfigurationHelper.GetConfiguration(Environment.CurrentDirectory);
            var connectionString = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            { 
                SqlCommand oCmd = new SqlCommand($"SELECT PasswordSalt From Profiles WHERE ProfileID = @ProfileID", myConnection); 
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ProfileID";
                param.Value = ProfileID;
                oCmd.Parameters.Add(param);

                myConnection.Open();
                using (oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        result = oReader[0].ToString();
                    }
                    myConnection.Close();
                }
            }
            return result;
        }
    }

    public static class ConfigurationHelper
    {
        #region GetConfiguration()
        public static IConfigurationRoot GetConfiguration(string path, string environmentName = null, bool addUserSecrets = false)
        {
         
            if (path.Contains("UnitTests") && !path.EndsWith("UnitTests")) 
                path = path.Substring(0, path.LastIndexOf(@"\UnitTests\", StringComparison.Ordinal) + @"\UnitTests\".Length);
            if (path.Contains("VendorPortal") && !path.EndsWith("VendorPortal"))
                path = path.Substring(0, path.LastIndexOf(@"\VendorPortal\", StringComparison.Ordinal) + @"\VendorPortal\".Length);
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (!String.IsNullOrWhiteSpace(environmentName))
            {
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }
            builder = builder.AddEnvironmentVariables(); 
            return builder.Build();
        }
        #endregion
    }

}