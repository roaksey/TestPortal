using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestPortal.Web.Models.ViewModel
{
    public class PopulationVM
    {
        public List<Population> PopulationTypes { get; set; }
        public List<CountryPopulation> TopCountries { get; set; }

        public int SelectedCountryId { get; set; } 
        public IEnumerable<SelectListItem> Countries { get; set; }

        public int CityId { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }

    }
}
