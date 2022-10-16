/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS (SELECT 1 FROM ConfigurationParameter WHERE ParameterName = 'NationalizeApiUrl') 
BEGIN
	INSERT INTO ConfigurationParameter([ParameterName],[ParameterValue],[Description])
	VALUES ('NationalizeApiUrl', 'https://api.nationalize.io', 'URL for the Nationalize API')
END