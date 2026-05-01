using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;
using SustavZaOrganizacijuNogometnihTurnira.Models;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    [Route("ekipe")]
    public class EkipaController : Controller
    {
        private readonly EkipaRepository _ekipaRepository;
        private readonly IgracRepository _igracRepository;

        public EkipaController(EkipaRepository ekipaRepository, IgracRepository igracRepository)
        {
            _ekipaRepository = ekipaRepository;
            _igracRepository = igracRepository;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var ekipe = _ekipaRepository.GetAll();

            return View(ekipe);
        }

        [HttpGet("novo")]
        public IActionResult Create()
        {
            return View(new EkipaFormViewModel());
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EkipaFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var ekipa = new Model.Ekipa
            {
                Naziv = model.Naziv,
                Grad = model.Grad,
                DatumOsnutka = model.DatumOsnutka,
                TrenerIme = model.TrenerIme,
                BrojIgraca = model.BrojIgraca,
                Kontakt = model.Kontakt
            };

            _ekipaRepository.Add(ekipa);

            return RedirectToAction(nameof(Details), new { id = ekipa.EkipaId });
        }

        [HttpGet("{id:int}")]
        public IActionResult Details(int id)
        {
            var ekipa = _ekipaRepository.GetById(id);

            if (ekipa == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return View("~/Views/Shared/NotFound.cshtml", new NotFoundViewModel
                {
                    Title = "Ekipa nije pronađena",
                    Message = $"Ekipa s ID-em {id} ne postoji.",
                    BackLinkText = "Nazad na ekipe",
                    BackController = "Ekipa",
                    BackAction = "Index"
                });
            }

            var viewModel = new EkipaDetailsViewModel
            {
                Ekipa = ekipa,
                Igraci = _igracRepository.GetAll().Where(igrac => igrac.EkipaId == id)
            };

            return View(viewModel);
        }

        [HttpGet("{id:int}/uredi")]
        public IActionResult Edit(int id)
        {
            var ekipa = _ekipaRepository.GetById(id);

            if (ekipa == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return View("~/Views/Shared/NotFound.cshtml", new NotFoundViewModel
                {
                    Title = "Ekipa nije pronađena",
                    Message = $"Ekipa s ID-em {id} ne postoji.",
                    BackLinkText = "Nazad na ekipe",
                    BackController = "Ekipa",
                    BackAction = "Index"
                });
            }

            return View(new EkipaFormViewModel
            {
                EkipaId = ekipa.EkipaId,
                Naziv = ekipa.Naziv,
                Grad = ekipa.Grad,
                DatumOsnutka = ekipa.DatumOsnutka,
                TrenerIme = ekipa.TrenerIme,
                BrojIgraca = ekipa.BrojIgraca,
                Kontakt = ekipa.Kontakt
            });
        }

        [HttpPost("{id:int}/uredi")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EkipaFormViewModel model)
        {
            if (id != model.EkipaId)
            {
                return BadRequest();
            }

            if (!_ekipaRepository.Exists(id))
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return View("~/Views/Shared/NotFound.cshtml", new NotFoundViewModel
                {
                    Title = "Ekipa nije pronađena",
                    Message = $"Ekipa s ID-em {id} ne postoji.",
                    BackLinkText = "Nazad na ekipe",
                    BackController = "Ekipa",
                    BackAction = "Index"
                });
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var ekipa = new Model.Ekipa
            {
                EkipaId = id,
                Naziv = model.Naziv,
                Grad = model.Grad,
                DatumOsnutka = model.DatumOsnutka,
                TrenerIme = model.TrenerIme,
                BrojIgraca = model.BrojIgraca,
                Kontakt = model.Kontakt
            };

            _ekipaRepository.Update(ekipa);

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
