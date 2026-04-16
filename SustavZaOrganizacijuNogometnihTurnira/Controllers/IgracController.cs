using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;
using SustavZaOrganizacijuNogometnihTurnira.Models;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    public class IgracController : Controller
    {
        private readonly IgracMockRepository _igracRepository;
        private readonly EkipaMockRepository _ekipaRepository;

        public IgracController(IgracMockRepository igracRepository, EkipaMockRepository ekipaRepository)
        {
            _igracRepository = igracRepository;
            _ekipaRepository = ekipaRepository;
        }

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

        public IActionResult Details(int id)
        {
            var igrac = _igracRepository.GetById(id);

            if (igrac == null)
            {
                return NotFound();
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
