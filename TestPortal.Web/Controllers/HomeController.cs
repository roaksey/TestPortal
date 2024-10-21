using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestPortal.Web.Models;
using TestPortal.Web.Models.ViewModel;

namespace TestPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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
