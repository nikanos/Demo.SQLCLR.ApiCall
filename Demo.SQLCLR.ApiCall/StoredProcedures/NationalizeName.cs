using Demo.SQLCLR.ApiCall.Entities;
using Demo.SQLCLR.ApiCall.Extensions;
using Demo.SQLCLR.ApiCall.Implementation;
using Demo.SQLCLR.ApiCall.Interfaces;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void NationalizeName(string name)
    {
        INationalizeApiCaller nationalizeApiCaller = CreateNationalizeApiCaller();
        IList<SqlDataRecord> records = NationalizeNameCaller(nationalizeApiCaller, name);
        if (records != null)
        {
            if (records.Count >= 1)
            {
                SqlContext.Pipe.SendResultsStart(records[0]);
                for (int i = 0; i < records.Count; i++)
                    SqlContext.Pipe.SendResultsRow(records[i]);
                SqlContext.Pipe.SendResultsEnd();
            }
        }
    }

    public static IList<SqlDataRecord> NationalizeNameCaller(INationalizeApiCaller nationalizeApiCaller, string name)
    {
        NationalizeResponse response = nationalizeApiCaller.Nationalize(name);
        IList<SqlDataRecord> records = response.ToRecords();
        return records;
    }

    private static INationalizeApiCaller CreateNationalizeApiCaller()
    {
        return new NationalizeHttpApiCaller(new DatabaseConfiguration(), new NationalizeHttpApiResponseParser());
    }
}
