using Demo.SQLCLR.ApiCall.Entities;
using Demo.SQLCLR.ApiCall.Exceptions;
using Demo.SQLCLR.ApiCall.Implementation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace Demo.SQLCLR.ApiCall.Tests.Unit
{
    [TestClass]
    public class ResponseParserTests
    {
        [TestMethod]
        public void TestNationalizeHttpApiResponseParserHelper_WithValidJson_SuceedsAndReturns()
        {
            var responseParser = CreateNationalizeHttpApiResponseParserHelper();
            var responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            string responseString = "{\"country\":[{\"country_id\":\"CY\",\"probability\":1}],\"name\":\"test_name\"}";
            responseMessage.Content = new StringContent(responseString, System.Text.Encoding.UTF8, "application/json");
            NationalizeResponse nationalizeResponse = responseParser.ParseResponse(responseString);
            nationalizeResponse.Should().NotBeNull();
            nationalizeResponse.name.Should().Be("test_name");
            nationalizeResponse.country.Should().NotBeNull();
            nationalizeResponse.country.Should().HaveCount(1);
            nationalizeResponse.country[0].country_id.Should().Be("CY");
            nationalizeResponse.country[0].probability.Should().Be(1);
        }

        private NationalizeHttpApiResponseParser CreateNationalizeHttpApiResponseParserHelper()
        {
            return new NationalizeHttpApiResponseParser();
        }
    }
}