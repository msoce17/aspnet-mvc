using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;
using SustavZaOrganizacijuNogometnihTurnira.Models;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    [Route("igraci")]
    public class IgracController : Controller
    {
        private readonly IgracRepository _igracRepository;
        private readonly EkipaRepository _ekipaRepository;

        public IgracController(IgracRepository igracRepository, EkipaRepository ekipaRepository)
        {
            _igracRepository = igracRepository;
            _ekipaRepository = ekipaRepository;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var igraci = _igracRepository.GetAll()
                .Select(igrac => new IgracDetailsViewModel
                {
                    Igrac = igrac,
                    Ekipa = _ekipaRepository.GetById(igrac.EkipaId)
                });

            return View(igraci);
        }

        [HttpGet("novo")]
        public IActionResult Create()
        {
            return View(CreateFormViewModel());
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IgracFormViewModel model)
        {
            if (!_ekipaRepository.Exists(model.EkipaId))
            {
                ModelState.AddModelError(nameof(model.EkipaId), "Odabrana ekipa ne postoji.");
            }

            if (!ModelState.IsValid)
            {
                model.Ekipe = _ekipaRepository.GetAll();
                return View(model);
            }

            var igrac = new Model.Igrac
            {
                Ime = model.Ime,
                Prezime = model.Prezime,
                BrojDresa = model.BrojDresa,
                Pozicija = model.Pozicija,
                DatumRodjenja = model.DatumRodjenja,
                Drzava = model.Drzava,
                Visina = model.Visina,
                EkipaId = model.EkipaId
            };

            _igracRepository.Add(igrac);

            return RedirectToAction(nameof(Details), new { id = igrac.IgracId });
        }

        [HttpGet("{id:int}")]
        public IActionResult Details(int id)
        {
            var igrac = _igracRepository.GetById(id);

            if (igrac == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return View("~/Views/Shared/NotFound.cshtml", new NotFoundViewModel
                {
                    Title = "Igrač nije pronađen",
                    Message = $"Igrač s ID-em {id} ne postoji.",
                    BackLinkText = "Nazad na igrače",
                    BackController = "Igrac",
                    BackAction = "Index"
                });
            }

            var viewModel = new IgracDetailsViewModel
            {
                Igrac = igrac,
                Ekipa = _ekipaRepository.GetById(igrac.EkipaId)
            };

            return View(viewModel);
        }

        [HttpGet("{id:int}/uredi")]
        public IActionResult Edit(int id)
        {
            var igrac = _igracRepository.GetById(id);

            if (igrac == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return View("~/Views/Shared/NotFound.cshtml", new NotFoundViewModel
                {
                    Title = "Igrač nije pronađen",
                    Message = $"Igrač s ID-em {id} ne postoji.",
                    BackLinkText = "Nazad na igrače",
                    BackController = "Igrac",
                    BackAction = "Index"
                });
            }

            return View(CreateFormViewModel(igrac));
        }

        [HttpPost("{id:int}/uredi")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IgracFormViewModel model)
        {
            if (id != model.IgracId)
            {
                return BadRequest();
            }

            if (!_igracRepository.Exists(id))
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return View("~/Views/Shared/NotFound.cshtml", new NotFoundViewModel
                {
                    Title = "Igrač nije pronađen",
                    Message = $"Igrač s ID-em {id} ne postoji.",
                    BackLinkText = "Nazad na igrače",
                    BackController = "Igrac",
                    BackAction = "Index"
                });
            }

            if (!_ekipaRepository.Exists(model.EkipaId))
            {
                ModelState.AddModelError(nameof(model.EkipaId), "Odabrana ekipa ne postoji.");
            }

            if (!ModelState.IsValid)
            {
                model.Ekipe = _ekipaRepository.GetAll();
                return View(model);
            }

            var igrac = new Model.Igrac
            {
                IgracId = id,
                Ime = model.Ime,
                Prezime = model.Prezime,
                BrojDresa = model.BrojDresa,
                Pozicija = model.Pozicija,
                DatumRodjenja = model.DatumRodjenja,
                Drzava = model.Drzava,
                Visina = model.Visina,
                EkipaId = model.EkipaId
            };

            _igracRepository.Update(igrac);

            return RedirectToAction(nameof(Details), new { id });
        }

        private IgracFormViewModel CreateFormViewModel(Model.Igrac? igrac = null)
        {
            return new IgracFormViewModel
            {
                IgracId = igrac?.IgracId,
                Ime = igrac?.Ime ?? string.Empty,
                Prezime = igrac?.Prezime ?? string.Empty,
                BrojDresa = igrac?.BrojDresa ?? 1,
                Pozicija = igrac?.Pozicija ?? string.Empty,
                DatumRodjenja = igrac?.DatumRodjenja ?? DateTime.Today,
                Drzava = igrac?.Drzava ?? string.Empty,
                Visina = igrac?.Visina ?? 1.80m,
                EkipaId = igrac?.EkipaId ?? 0,
                Ekipe = _ekipaRepository.GetAll()
            };
        }
    }
}
