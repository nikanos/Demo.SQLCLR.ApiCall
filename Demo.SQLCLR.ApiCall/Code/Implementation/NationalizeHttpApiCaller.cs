using Demo.SQLCLR.ApiCall.Common;
using Demo.SQLCLR.ApiCall.Entities;
using Demo.SQLCLR.ApiCall.Interfaces;
using System;
using System.Net;

namespace Demo.SQLCLR.ApiCall.Implementation
{
    public class NationalizeHttpApiCaller : INationalizeApiCaller
    {
        private readonly IConfiguration _configuration;
        private readonly INationalizeHttpApiResponseParser _nationalizeHttpApiResponseParser;

        public NationalizeHttpApiCaller(IConfiguration configuration, INationalizeHttpApiResponseParser nationalizeHttpApiResponseParser)
        {
            Ensure.ArgumentNotNull(configuration, nameof(configuration));
            Ensure.ArgumentNotNull(nationalizeHttpApiResponseParser, nameof(nationalizeHttpApiResponseParser));

            _configuration = configuration;
            _nationalizeHttpApiResponseParser = nationalizeHttpApiResponseParser;
        }

        public NationalizeResponse Nationalize(string name)
        {
            Ensure.StringArgumentNotNullAndNotEmpty(name, nameof(name));

            string urlToCall = _configuration.NationalizeUrl;
            urlToCall += $"?name={Uri.EscapeUriString(name)}";
            using (WebClient wc = new WebClient())
            {
                string responseContent = wc.DownloadString(urlToCall);
                return _nationalizeHttpApiResponseParser.ParseResponse(responseContent);
            }
        }
    }
}