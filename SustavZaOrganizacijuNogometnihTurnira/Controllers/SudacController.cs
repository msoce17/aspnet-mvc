using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    public class SudacController : Controller
    {
        private readonly SudacMockRepository _sudacRepository;

        public SudacController(SudacMockRepository sudacRepository)
        {
            _sudacRepository = sudacRepository;
        }

        public IActionResult Index()
        {
            var sudci = _sudacRepository.GetAll();

            return View(sudci);
        }

        public IActionResult Details(int id)
        {
            var sudac = _sudacRepository.GetById(id);

            if (sudac == null)
            {
                return NotFound();
            }

            return View(sudac);
        }
    }
}
