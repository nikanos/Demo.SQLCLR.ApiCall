using Demo.SQLCLR.ApiCall.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Demo.SQLCLR.ApiCall.Implementation
{
    public class DatabaseConfiguration : IConfiguration
    {
        public string NationalizeUrl
        {
            get
            {
                using (SqlConnection connection = new SqlConnection("context connection=true"))
                {
                    using (var command = new SqlCommand("Select ParameterValue FROM ConfigurationParameter WHERE ParameterName=@ParameterName", connection))
                    {
                        connection.Open();

                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(new SqlParameter("@ParameterName", SqlDbType.NVarChar)
                        {
                            Value = "NationalizeApiUrl"
                        });

                        return (string)command.ExecuteScalar();
                    }
                }
            }
        }
    }
}