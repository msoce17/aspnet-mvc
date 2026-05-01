using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;
using SustavZaOrganizacijuNogometnihTurnira.Models;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    public class SudacController : Controller
    {
        private readonly SudacRepository _sudacRepository;

        public SudacController(SudacRepository sudacRepository)
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
                Response.StatusCode = StatusCodes.Status404NotFound;
                return View("~/Views/Shared/NotFound.cshtml", new NotFoundViewModel
                {
                    Title = "Sudac nije pronađen",
                    Message = $"Sudac s ID-em {id} ne postoji.",
                    BackLinkText = "Nazad na suce",
                    BackController = "Sudac",
                    BackAction = "Index"
                });
            }

            return View(sudac);
        }
    }
}
