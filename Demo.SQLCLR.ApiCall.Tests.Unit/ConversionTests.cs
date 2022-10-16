using Demo.SQLCLR.ApiCall.Entities;
using Demo.SQLCLR.ApiCall.Extensions;
using FluentAssertions;
using Microsoft.SqlServer.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Demo.SQLCLR.ApiCall.Tests.Unit
{
    [TestClass]
    public class ConversionTests
    {
        [TestMethod]
        public void TestConvertNationalizeResponseToRecords_WithOneCountryInResponse_SuceedsAndReturnsOneRecord()
        {
            var response = new NationalizeResponse
            {
                name = "test",
                country = new Country[] {
                    new Country{ country_id="CY", probability=1}
                }
            };

            IList<SqlDataRecord> records = response.ToRecords();
            records.Should().NotBeNullOrEmpty();
            records.First().FieldCount.Should().Be(2);
            records.First().GetString(0).Should().Be("CY");
            records.First().GetDouble(1).Should().Be(1);
        }

        [TestMethod]
        public void TestConvertNationalizeResponseToRecords_WithTwoCountriesInResponse_SuceedsAndReturnsTwoRecords()
        {
            var response = new NationalizeResponse
            {
                name = "test",
                country = new Country[] {
                    new Country{ country_id="CY", probability=0.6},
                    new Country{ country_id="GR", probability=0.4}
                }
            };

            IList<SqlDataRecord> records = response.ToRecords();
            records.Should().NotBeNull();
            records.Should().HaveCount(2);
            records.First().FieldCount.Should().Be(2);
            records[0].GetString(0).Should().Be("CY");
            records[0].GetDouble(1).Should().Be(0.6);
            records[1].GetString(0).Should().Be("GR");
            records[1].GetDouble(1).Should().Be(0.4);
        }
    }
}