using TestPortal.Web.Models;

namespace TestPortal.Web.Service.Interface
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync(); 
        Task<IEnumerable<City>> GetAllCitiesAsync(); 
    }
}
