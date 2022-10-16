using Demo.SQLCLR.ApiCall.Implementation;
using Demo.SQLCLR.ApiCall.Interfaces;
using FluentAssertions;
using Microsoft.SqlServer.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Demo.SQLCLR.ApiCall.Tests.Integration
{
    [TestClass]
    public class ClrStoredProcedureTests
    {
        [TestMethod]
        public void NationalizeTest_WithCommonGreekNameYiannis_SuceedsAndReturnsGreeceInRecords()
        {
            var config = new Mock<IConfiguration>();
            config.Setup(x => x.NationalizeUrl).Returns(Settings.Default.ApiUrlNationalize);

            var nationalizeHttpApiCaller = CreateNationalizeHttpApiCallerHelper(config.Object);

            IList<SqlDataRecord> records = StoredProcedures.NationalizeNameCaller(nationalizeHttpApiCaller, "Yiannis");
            records.Should().NotBeNullOrEmpty();
            records.All(x => x.FieldCount == 2).Should().BeTrue();
            records.Any(x => x.GetString(0) == "GR").Should().BeTrue();
        }

        private NationalizeHttpApiCaller CreateNationalizeHttpApiCallerHelper(IConfiguration configuration,
                                                                              INationalizeHttpApiResponseParser nationalizeHttpApiResponseParser = null)
        {
            if (nationalizeHttpApiResponseParser == null)
                nationalizeHttpApiResponseParser = new NationalizeHttpApiResponseParser();
            return new NationalizeHttpApiCaller(configuration: configuration,
                                                nationalizeHttpApiResponseParser: nationalizeHttpApiResponseParser);
        }
    }
}
