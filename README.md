### Demo.SQLCLR.ApiCall
SQL CLR Demo for calling a JSON REST Api from a stored procedure.

The demo uses the [nationalize.io](https://nationalize.io/) API to predict the nationality from a name.

The script Scripts/CreateAssemblyLoginAndKey.sql needs to be run manually once after build.
You should copy the DLL to a path accessible from the SQL server and edit the CREATE ASSYMETRIC KEY statement accordingly before running the script.

After execution, the script creates the **ASYMMETRIC KEY** named **"DemoApiCallSQLCLRKey"** and the **LOGIN** named **"DemoApiCallSQLCLRLogin"** in the **master** database.

The assembly is marked with the EXTERNAL_ACCESS permission level.
It should be noted that, beginning with SQL Server 2017, the assembly is treated as UNSAFE due to the [CLR Strict Security](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/clr-strict-security?view=sql-server-ver15) feature.
For this reason, in the Scripts/CreateAssemblyLoginAndKey.sql, the UNSAFE ASSEMBLY permission gets granted to the LOGIN that is created.

To avoid loading any extra .NET assemblies the following was done:

- [WebClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.webclient?view=netframework-4.5) was used instead of [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netframework-4.5) to call the API
- [LitJson](https://github.com/LitJSON/litjson) was used to parse the JSON response (LitJson classes that would require reflection have been removed)