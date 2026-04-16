using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;
using SustavZaOrganizacijuNogometnihTurnira.Models;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    public class PrijavaEkipeController : Controller
    {
        private readonly PrijavaEkipeMockRepository _prijavaEkipeRepository;
        private readonly TurnirMockRepository _turnirRepository;
        private readonly EkipaMockRepository _ekipaRepository;

        public PrijavaEkipeController(
            PrijavaEkipeMockRepository prijavaEkipeRepository,
            TurnirMockRepository turnirRepository,
            EkipaMockRepository ekipaRepository)
        {
            _prijavaEkipeRepository = prijavaEkipeRepository;
            _turnirRepository = turnirRepository;
            _ekipaRepository = ekipaRepository;
        }

        public IActionResult Index()
        {
            var prijave = _prijavaEkipeRepository.GetAll()
                .Select(CreateViewModel);

            return View(prijave);
        }

        public IActionResult Details(int id)
        {
            var prijava = _prijavaEkipeRepository.GetById(id);

            if (prijava == null)
            {
                return NotFound();
            }

            return View(CreateViewModel(prijava));
        }

        private PrijavaEkipeViewModel CreateViewModel(Model.PrijavaEkipe prijava)
        {
            return new PrijavaEkipeViewModel
            {
                Prijava = prijava,
                Turnir = _turnirRepository.GetById(prijava.TurnirId),
                Ekipa = _ekipaRepository.GetById(prijava.EkipaId)
            };
        }
    }
}
