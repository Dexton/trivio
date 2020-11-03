using System.Collections.Generic;

namespace trivio.Models
{
//// Auto generated code from https://json2csharp.com/
// CountryResult myDeserializedClass = JsonConvert.DeserializeObject<CountryResult>(myJsonResponse); 
    public class Currency    {
        public string code { get; set; } 
        public string name { get; set; } 
        public string symbol { get; set; } 
    }

    public class Language    {
        public string iso639_1 { get; set; } 
        public string iso639_2 { get; set; } 
        public string name { get; set; } 
        public string nativeName { get; set; } 
    }

    public class Translations    {
        public string de { get; set; } 
        public string es { get; set; } 
        public string fr { get; set; } 
        public string ja { get; set; } 
        public string it { get; set; } 
        public string br { get; set; } 
        public string pt { get; set; } 
        public string nl { get; set; } 
        public string hr { get; set; } 
        public string fa { get; set; } 
    }

    public class RegionalBloc    {
        public string acronym { get; set; } 
        public string name { get; set; } 
        public List<object> otherAcronyms { get; set; } 
        public List<object> otherNames { get; set; } 
    }

    public class CountryResult {
        public string name { get; set; } 
        public List<string> topLevelDomain { get; set; } 
        public string alpha2Code { get; set; } 
        public string alpha3Code { get; set; } 
        public List<string> callingCodes { get; set; } 
        public string capital { get; set; } 
        public List<string> altSpellings { get; set; } 
        public string region { get; set; } 
        public string subregion { get; set; } 
        public int population { get; set; } 
        public List<double> latlng { get; set; } 
        public string demonym { get; set; } 
        public double area { get; set; } 
        public object gini { get; set; } 
        public List<string> timezones { get; set; } 
        public List<object> borders { get; set; } 
        public string nativeName { get; set; } 
        public string numericCode { get; set; } 
        public List<Currency> currencies { get; set; } 
        public List<Language> languages { get; set; } 
        public Translations translations { get; set; } 
        public string flag { get; set; } 
        public List<RegionalBloc> regionalBlocs { get; set; } 
        public string cioc { get; set; } 
        public override string ToString()
        {
            return $"The capital of {name} is {capital}";
        }

    }

}