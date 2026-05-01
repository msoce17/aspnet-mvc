using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;
using SustavZaOrganizacijuNogometnihTurnira.Models;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    public class PrijavaEkipeController : Controller
    {
        private readonly PrijavaEkipeRepository _prijavaEkipeRepository;
        private readonly TurnirRepository _turnirRepository;
        private readonly EkipaRepository _ekipaRepository;

        public PrijavaEkipeController(
            PrijavaEkipeRepository prijavaEkipeRepository,
            TurnirRepository turnirRepository,
            EkipaRepository ekipaRepository)
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
                Response.StatusCode = StatusCodes.Status404NotFound;
                return View("~/Views/Shared/NotFound.cshtml", new NotFoundViewModel
                {
                    Title = "Prijava nije pronađena",
                    Message = $"Prijava s ID-em {id} ne postoji.",
                    BackLinkText = "Nazad na prijave",
                    BackController = "PrijavaEkipe",
                    BackAction = "Index"
                });
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
