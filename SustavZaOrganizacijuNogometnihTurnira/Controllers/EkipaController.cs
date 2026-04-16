using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;
using SustavZaOrganizacijuNogometnihTurnira.Models;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    public class EkipaController : Controller
    {
        private readonly EkipaMockRepository _ekipaRepository;
        private readonly IgracMockRepository _igracRepository;

        public EkipaController(EkipaMockRepository ekipaRepository, IgracMockRepository igracRepository)
        {
            _ekipaRepository = ekipaRepository;
            _igracRepository = igracRepository;
        }

        public IActionResult Index()
        {
            var ekipe = _ekipaRepository.GetAll();

            return View(ekipe);
        }

        public IActionResult Details(int id)
        {
            var ekipa = _ekipaRepository.GetById(id);

            if (ekipa == null)
            {
                return NotFound();
            }

            var viewModel = new EkipaDetailsViewModel
            {
                Ekipa = ekipa,
                Igraci = _igracRepository.GetAll().Where(igrac => igrac.EkipaId == id)
            };

            return View(viewModel);
        }
    }
}
