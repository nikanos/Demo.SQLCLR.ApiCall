using Demo.SQLCLR.ApiCall.Common;
using Demo.SQLCLR.ApiCall.Entities;
using Demo.SQLCLR.ApiCall.Interfaces;
using LitJson;
using System.Collections.Generic;

namespace Demo.SQLCLR.ApiCall.Implementation
{
    public class NationalizeHttpApiResponseParser : INationalizeHttpApiResponseParser
    {
        public NationalizeHttpApiResponseParser()
        {
        }

        public NationalizeResponse ParseResponse(string response)
        {
            Ensure.StringArgumentNotNullAndNotEmpty(response, nameof(response));

            JsonData responseObject = JsonMapper.ToObject(response);
            NationalizeResponse ret = new NationalizeResponse();
            ret.name = (string)responseObject["name"];
            JsonData responseCountries = responseObject["country"];
            List<Country> countries = new List<Country>();
            if (responseCountries.IsArray)
            {
                int countriesCount = responseCountries.Count;
                for (int i = 0; i < countriesCount; i++)
                {
                    Country country = new Country();
                    country.country_id = (string)responseCountries[i]["country_id"];
                    JsonData probability = responseCountries[i]["probability"];
                    if (probability.IsInt)
                        country.probability = (int)probability;
                    else if (probability.IsDouble)
                        country.probability = (double)probability;

                    countries.Add(country);
                }
            }
            ret.country = countries.ToArray();
            return ret;
        }
    }
}