using Demo.SQLCLR.ApiCall.Entities;

namespace Demo.SQLCLR.ApiCall.Interfaces
{
    public interface INationalizeApiCaller
    {
        NationalizeResponse Nationalize(string name);
    }
}