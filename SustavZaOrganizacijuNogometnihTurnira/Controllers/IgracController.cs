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
    }
}
