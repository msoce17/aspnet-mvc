using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;
using SustavZaOrganizacijuNogometnihTurnira.Models;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TurnirMockRepository _turnirRepository;
        private readonly EkipaMockRepository _ekipaRepository;
        private readonly IgracMockRepository _igracRepository;
        private readonly StadionMockRepository _stadionRepository;
        private readonly SudacMockRepository _sudacRepository;
        private readonly UtakmicaMockRepository _utakmicaRepository;
        private readonly PrijavaEkipeMockRepository _prijavaEkipeRepository;

        public HomeController(
            ILogger<HomeController> logger,
            TurnirMockRepository turnirRepository,
            EkipaMockRepository ekipaRepository,
            IgracMockRepository igracRepository,
            StadionMockRepository stadionRepository,
            SudacMockRepository sudacRepository,
            UtakmicaMockRepository utakmicaRepository,
            PrijavaEkipeMockRepository prijavaEkipeRepository)
        {
            _logger = logger;
            _turnirRepository = turnirRepository;
            _ekipaRepository = ekipaRepository;
            _igracRepository = igracRepository;
            _stadionRepository = stadionRepository;
            _sudacRepository = sudacRepository;
            _utakmicaRepository = utakmicaRepository;
            _prijavaEkipeRepository = prijavaEkipeRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeDashboardViewModel
            {
                BrojTurnira = _turnirRepository.GetAll().Count(),
                BrojEkipa = _ekipaRepository.GetAll().Count(),
                BrojIgraca = _igracRepository.GetAll().Count(),
                BrojStadiona = _stadionRepository.GetAll().Count(),
                BrojSudaca = _sudacRepository.GetAll().Count(),
                BrojUtakmica = _utakmicaRepository.GetAll().Count(),
                BrojPrijava = _prijavaEkipeRepository.GetAll().Count()
            };

            return View(viewModel);
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
