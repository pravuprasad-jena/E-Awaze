using EAwaze.Models;
using EAwaze.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EAwaze.Controllers
{
    public class HomeController : Controller
    {
        private const string Lat = "50.390392";
        private const string Long = "50.390392";
        private readonly ILogger<HomeController> _logger;
        private readonly IChargingStationRepository _chargingStationRepository;

        public HomeController(ILogger<HomeController> logger, IChargingStationRepository chargingStationRepository)
        {
            _logger = logger;
            _chargingStationRepository = chargingStationRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> GetElecricChargingPoints()
        {
            var locations = await _chargingStationRepository.GetAllChargeDevicesAsync("M50+2BB", 10);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
