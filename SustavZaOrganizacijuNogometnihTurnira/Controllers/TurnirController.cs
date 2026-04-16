using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;
using SustavZaOrganizacijuNogometnihTurnira.Models;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    public class TurnirController : Controller
    {
        private readonly TurnirMockRepository _turnirRepository;
        private readonly PrijavaEkipeMockRepository _prijavaEkipeRepository;
        private readonly UtakmicaMockRepository _utakmicaRepository;
        private readonly EkipaMockRepository _ekipaRepository;
        private readonly IgracMockRepository _igracRepository;
        private readonly StadionMockRepository _stadionRepository;
        private readonly SudacMockRepository _sudacRepository;

        public TurnirController(
            TurnirMockRepository turnirRepository,
            PrijavaEkipeMockRepository prijavaEkipeRepository,
            UtakmicaMockRepository utakmicaRepository,
            EkipaMockRepository ekipaRepository,
            IgracMockRepository igracRepository,
            StadionMockRepository stadionRepository,
            SudacMockRepository sudacRepository)
        {
            _turnirRepository = turnirRepository;
            _prijavaEkipeRepository = prijavaEkipeRepository;
            _utakmicaRepository = utakmicaRepository;
            _ekipaRepository = ekipaRepository;
            _igracRepository = igracRepository;
            _stadionRepository = stadionRepository;
            _sudacRepository = sudacRepository;
        }

        public IActionResult Index()
        {
            var turniri = _turnirRepository.GetAll();

            return View(turniri);
        }

        public IActionResult Details(int id)
        {
            var turnir = _turnirRepository.GetById(id);

            if (turnir == null)
            {
                return NotFound();
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
