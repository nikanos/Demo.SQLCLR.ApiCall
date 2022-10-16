using Demo.SQLCLR.ApiCall.Entities;
using Demo.SQLCLR.ApiCall.Implementation;
using Demo.SQLCLR.ApiCall.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Demo.SQLCLR.ApiCall.Tests.Integration
{
    [TestClass]
    public class NationalizeHttpApiCallerTests
    {
        [TestMethod]
        public void NationalizeHttpApiCallerTest_NationalizeCommonGreekName_ReturnsResultsAndIncludesGreece()
        {
            var config = new Mock<IConfiguration>();
            config.Setup(x => x.NationalizeUrl).Returns(Settings.Default.ApiUrlNationalize);

            var nationalizeHttpApiCaller = CreateNationalizeHttpApiCallerHelper(config.Object);
            NationalizeResponse result = nationalizeHttpApiCaller.Nationalize("yiannis");
            result.country.Should().NotBeNullOrEmpty();
            result.country.Should().Contain(x => x.country_id == "GR");
        }

        private NationalizeHttpApiCaller CreateNationalizeHttpApiCallerHelper(IConfiguration configuration = null,
                                                                              INationalizeHttpApiResponseParser nationalizeHttpApiResponseParser = null)
        {
            if (nationalizeHttpApiResponseParser == null)
                nationalizeHttpApiResponseParser = new NationalizeHttpApiResponseParser();
            return new NationalizeHttpApiCaller(configuration: configuration,
                                                nationalizeHttpApiResponseParser: nationalizeHttpApiResponseParser);
        }
    }
}
