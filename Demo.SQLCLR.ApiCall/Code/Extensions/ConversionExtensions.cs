using Demo.SQLCLR.ApiCall.Entities;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.Data;

namespace Demo.SQLCLR.ApiCall.Extensions
{
    public static class ConversionExtensions
    {
        public static IList<SqlDataRecord> ToRecords(this NationalizeResponse nationalizeResponse)
        {
            List<SqlDataRecord> records = new List<SqlDataRecord>();
            foreach(var country in nationalizeResponse.country)
            {
                SqlDataRecord record= new SqlDataRecord(new SqlMetaData("CountryCode", SqlDbType.NVarChar, 128), new SqlMetaData("Probability", SqlDbType.Float));
                record.SetString(0, country.country_id);
                record.SetDouble(1, country.probability);
                records.Add(record);
            }
            return records;
        }
    }
}