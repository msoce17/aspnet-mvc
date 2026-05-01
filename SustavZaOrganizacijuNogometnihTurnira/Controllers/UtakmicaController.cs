using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;
using SustavZaOrganizacijuNogometnihTurnira.Models;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    [Route("utakmice")]
    public class UtakmicaController : Controller
    {
        private readonly UtakmicaRepository _utakmicaRepository;
        private readonly TurnirRepository _turnirRepository;
        private readonly EkipaRepository _ekipaRepository;
        private readonly StadionRepository _stadionRepository;
        private readonly SudacRepository _sudacRepository;

        public UtakmicaController(
            UtakmicaRepository utakmicaRepository,
            TurnirRepository turnirRepository,
            EkipaRepository ekipaRepository,
            StadionRepository stadionRepository,
            SudacRepository sudacRepository)
        {
            _utakmicaRepository = utakmicaRepository;
            _turnirRepository = turnirRepository;
            _ekipaRepository = ekipaRepository;
            _stadionRepository = stadionRepository;
            _sudacRepository = sudacRepository;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var utakmice = _utakmicaRepository.GetAll()
                .Select(CreateViewModel);

            return View(utakmice);
        }

        [HttpGet("{id:int}")]
        public IActionResult Details(int id)
        {
            var utakmica = _utakmicaRepository.GetById(id);

            if (utakmica == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return View("~/Views/Shared/NotFound.cshtml", new NotFoundViewModel
                {
                    Title = "Utakmica nije pronađena",
                    Message = $"Utakmica s ID-em {id} ne postoji.",
                    BackLinkText = "Nazad na utakmice",
                    BackController = "Utakmica",
                    BackAction = "Index"
                });
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
