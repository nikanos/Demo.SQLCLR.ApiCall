using Demo.SQLCLR.ApiCall.Entities;

namespace Demo.SQLCLR.ApiCall.Interfaces
{
    public interface INationalizeHttpApiResponseParser
    {
        NationalizeResponse ParseResponse(string response);
    }
}