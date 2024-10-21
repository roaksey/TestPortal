using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using TestPortal.Web.Models;
using TestPortal.Web.Models.ViewModel;
using TestPortal.Web.Service.Interface;

namespace TestPortal.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
   
        public ICountryService _countryService { get; }

        public HomeController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new PopulationVM
            {
                PopulationTypes = new List<Population>
            {
                new Population { PopulationType = "Old", Number = "1,000,000,000" },
                new Population { PopulationType = "Young", Number = "3,000,000,000" },
                new Population { PopulationType = "Child", Number = "1,000,000,000" }
            },
                TopCountries = new List<CountryPopulation>
            {
                new CountryPopulation { SN = 1, CountryName = "China", Population = 152220000 },
                new CountryPopulation { SN = 2, CountryName = "India", Population = 85000000 },
                new CountryPopulation { SN = 3, CountryName = "USA", Population = 6663441 }
            }
            };
            var countries = await _countryService.GetAllCountriesAsync();
            var countrySelectList = countries.Select(c => new SelectListItem
            {
                Value = c.CountryId.ToString(),
                Text = c.CountryName.ToString()
            }).ToList();

            model.Countries = countrySelectList;
            var cities = await _countryService.GetAllCitiesAsync();
            model.Cities = cities.Select(c => new SelectListItem {
                Value = c.Id.ToString(),
                Text = c.Name.ToString() 
            });

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
