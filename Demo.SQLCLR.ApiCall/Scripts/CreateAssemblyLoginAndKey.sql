--use the below to create the necessary login and keys
use [master];
GO

--First we drop any existing login and keys named DemoApiCallSQLCLRKey and DemoApiCallSQLCLRLogin
IF EXISTS(SELECT * FROM sys.server_principals WHERE name = 'DemoApiCallSQLCLRLogin' )
    DROP LOGIN DemoApiCallSQLCLRLogin
  
IF EXISTS(SELECT * FROM sys.asymmetric_keys WHERE name = 'DemoApiCallSQLCLRKey')
    DROP ASYMMETRIC KEY DemoApiCallSQLCLRKey

CREATE ASYMMETRIC KEY DemoApiCallSQLCLRKey FROM EXECUTABLE FILE ='<Path to Demo.SQLCLR.ApiCall.dll accessible from server>';
CREATE LOGIN DemoApiCallSQLCLRLogin FROM ASYMMETRIC KEY DemoApiCallSQLCLRKey;
GRANT EXTERNAL ACCESS ASSEMBLY TO DemoApiCallSQLCLRLogin;
--FOR SQL 2017+ that has the CLR strict security enabled(default)
--See https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/clr-strict-security?view=sql-server-ver16
GRANT UNSAFE ASSEMBLY TO DemoApiCallSQLCLRLogin;