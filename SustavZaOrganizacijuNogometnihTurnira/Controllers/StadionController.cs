using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    public class StadionController : Controller
    {
        private readonly StadionMockRepository _stadionRepository;

        public StadionController(StadionMockRepository stadionRepository)
        {
            _stadionRepository = stadionRepository;
        }

        public IActionResult Index()
        {
            var stadioni = _stadionRepository.GetAll();

            return View(stadioni);
        }

        public IActionResult Details(int id)
        {
            var stadion = _stadionRepository.GetById(id);

            if (stadion == null)
            {
                return NotFound();
            }

            return View(stadion);
        }
    }
}
