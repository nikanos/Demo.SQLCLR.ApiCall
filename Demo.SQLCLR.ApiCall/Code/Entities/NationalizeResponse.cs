namespace Demo.SQLCLR.ApiCall.Entities
{
    public class NationalizeResponse
    {
        public Country[] country { get; set; }
        public string name { get; set; }
    }

    public class Country
    {
        public string country_id { get; set; }
        public double probability { get; set; }
    }

}