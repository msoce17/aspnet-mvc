using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;
using SustavZaOrganizacijuNogometnihTurnira.Models;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    [Route("turniri")]
    public class TurnirController : Controller
    {
        private readonly TurnirRepository _turnirRepository;
        private readonly PrijavaEkipeRepository _prijavaEkipeRepository;
        private readonly UtakmicaRepository _utakmicaRepository;
        private readonly EkipaRepository _ekipaRepository;
        private readonly IgracRepository _igracRepository;
        private readonly StadionRepository _stadionRepository;
        private readonly SudacRepository _sudacRepository;

        public TurnirController(
            TurnirRepository turnirRepository,
            PrijavaEkipeRepository prijavaEkipeRepository,
            UtakmicaRepository utakmicaRepository,
            EkipaRepository ekipaRepository,
            IgracRepository igracRepository,
            StadionRepository stadionRepository,
            SudacRepository sudacRepository)
        {
            _turnirRepository = turnirRepository;
            _prijavaEkipeRepository = prijavaEkipeRepository;
            _utakmicaRepository = utakmicaRepository;
            _ekipaRepository = ekipaRepository;
            _igracRepository = igracRepository;
            _stadionRepository = stadionRepository;
            _sudacRepository = sudacRepository;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var turniri = _turnirRepository.GetAll();

            return View(turniri);
        }

        [HttpGet("{id:int}/ekipe")]
        public IActionResult Teams(int id)
        {
            var turnir = _turnirRepository.GetById(id);

            if (turnir == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return View("~/Views/Shared/NotFound.cshtml", new NotFoundViewModel
                {
                    Title = "Turnir nije pronađen",
                    Message = $"Turnir s ID-em {id} ne postoji.",
                    BackLinkText = "Nazad na turnire",
                    BackController = "Turnir",
                    BackAction = "Index"
                });
            }

            var prijave = _prijavaEkipeRepository.GetAll()
                .Where(prijava => prijava.TurnirId == id)
                .Select(prijava =>
                {
                    var ekipa = _ekipaRepository.GetById(prijava.EkipaId);

                    return new TurnirTeamsListItemViewModel
                    {
                        Prijava = prijava,
                        Ekipa = ekipa,
                        BrojIgraca = _igracRepository.GetAll().Count(igrac => igrac.EkipaId == prijava.EkipaId)
                    };
                })
                .OrderBy(stavka => stavka.Ekipa?.Naziv)
                .ToList();

            return View(new TurnirTeamsListViewModel
            {
                Turnir = turnir,
                Stavke = prijave
            });
        }

        [HttpGet("{id:int}")]
        public IActionResult Details(int id)
        {
            var turnir = _turnirRepository.GetById(id);

            if (turnir == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return View("~/Views/Shared/NotFound.cshtml", new NotFoundViewModel
                {
                    Title = "Turnir nije pronađen",
                    Message = $"Turnir s ID-em {id} ne postoji.",
                    BackLinkText = "Nazad na turnire",
                    BackController = "Turnir",
                    BackAction = "Index"
                });
            }

            var prijaveEkipe = _prijavaEkipeRepository.GetAll()
                .Where(prijava => prijava.TurnirId == id)
                .Select(prijava =>
                {
                    var ekipa = _ekipaRepository.GetById(prijava.EkipaId);

                    return new TurnirPrijavaViewModel
                    {
                        Prijava = prijava,
                        Ekipa = ekipa,
                        Igraci = _igracRepository.GetAll().Where(igrac => igrac.EkipaId == prijava.EkipaId)
                    };
                })
                .ToList();

            var utakmice = _utakmicaRepository.GetAll()
                .Where(utakmica => utakmica.TurnirId == id)
                .Select(utakmica => new TurnirUtakmicaViewModel
                {
                    Utakmica = utakmica,
                    DomacaEkipa = _ekipaRepository.GetById(utakmica.DomacaEkipaId),
                    GostujucaEkipa = _ekipaRepository.GetById(utakmica.GostujucaEkipaId),
                    Stadion = _stadionRepository.GetById(utakmica.StadionId),
                    Sudac = _sudacRepository.GetById(utakmica.SudacId)
                })
                .ToList();

            var viewModel = new TurnirDetailsViewModel
            {
                Turnir = turnir,
                PrijaveEkipe = prijaveEkipe,
                Utakmice = utakmice,
                UkupnoIgraca = prijaveEkipe.Sum(prijava => prijava.Igraci.Count())
            };

            return View(viewModel);
        }
    }
}
