using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;
using SustavZaOrganizacijuNogometnihTurnira.Models;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    public class UtakmicaController : Controller
    {
        private readonly UtakmicaMockRepository _utakmicaRepository;
        private readonly TurnirMockRepository _turnirRepository;
        private readonly EkipaMockRepository _ekipaRepository;
        private readonly StadionMockRepository _stadionRepository;
        private readonly SudacMockRepository _sudacRepository;

        public UtakmicaController(
            UtakmicaMockRepository utakmicaRepository,
            TurnirMockRepository turnirRepository,
            EkipaMockRepository ekipaRepository,
            StadionMockRepository stadionRepository,
            SudacMockRepository sudacRepository)
        {
            _utakmicaRepository = utakmicaRepository;
            _turnirRepository = turnirRepository;
            _ekipaRepository = ekipaRepository;
            _stadionRepository = stadionRepository;
            _sudacRepository = sudacRepository;
        }

        public IActionResult Index()
        {
            var utakmice = _utakmicaRepository.GetAll()
                .Select(CreateViewModel);

            return View(utakmice);
        }

        public IActionResult Details(int id)
        {
            var utakmica = _utakmicaRepository.GetById(id);

            if (utakmica == null)
            {
                return NotFound();
            }

            return View(CreateViewModel(utakmica));
        }

        private UtakmicaViewModel CreateViewModel(Model.Utakmica utakmica)
        {
            return new UtakmicaViewModel
            {
                Utakmica = utakmica,
                Turnir = _turnirRepository.GetById(utakmica.TurnirId),
                DomacaEkipa = _ekipaRepository.GetById(utakmica.DomacaEkipaId),
                GostujucaEkipa = _ekipaRepository.GetById(utakmica.GostujucaEkipaId),
                Stadion = _stadionRepository.GetById(utakmica.StadionId),
                Sudac = _sudacRepository.GetById(utakmica.SudacId)
            };
        }
    }
}
