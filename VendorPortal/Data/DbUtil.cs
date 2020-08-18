using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Configuration;
namespace AssistWith.Data
{
    public class DbUtils
    {
        private readonly IConfiguration _config;
        public DbUtils(IConfiguration Config)
        {
            _config = Config; 
        }
        public string GetSaltById(int ProfileID) {
            SqlDataReader oReader;
            string result = "";
            var con = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection myConnection = new SqlConnection(con))
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
}