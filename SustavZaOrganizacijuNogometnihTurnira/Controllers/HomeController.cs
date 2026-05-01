using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;
using SustavZaOrganizacijuNogometnihTurnira.Models;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TurnirRepository _turnirRepository;
        private readonly EkipaRepository _ekipaRepository;
        private readonly IgracRepository _igracRepository;
        private readonly StadionRepository _stadionRepository;
        private readonly SudacRepository _sudacRepository;
        private readonly UtakmicaRepository _utakmicaRepository;
        private readonly PrijavaEkipeRepository _prijavaEkipeRepository;

        public HomeController(
            ILogger<HomeController> logger,
            TurnirRepository turnirRepository,
            EkipaRepository ekipaRepository,
            IgracRepository igracRepository,
            StadionRepository stadionRepository,
            SudacRepository sudacRepository,
            UtakmicaRepository utakmicaRepository,
            PrijavaEkipeRepository prijavaEkipeRepository)
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
