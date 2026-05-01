using Microsoft.AspNetCore.Mvc;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;
using SustavZaOrganizacijuNogometnihTurnira.Models;

namespace SustavZaOrganizacijuNogometnihTurnira.Controllers
{
    public class StadionController : Controller
    {
        private readonly StadionRepository _stadionRepository;

        public StadionController(StadionRepository stadionRepository)
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
                Response.StatusCode = StatusCodes.Status404NotFound;
                return View("~/Views/Shared/NotFound.cshtml", new NotFoundViewModel
                {
                    Title = "Stadion nije pronađen",
                    Message = $"Stadion s ID-em {id} ne postoji.",
                    BackLinkText = "Nazad na stadione",
                    BackController = "Stadion",
                    BackAction = "Index"
                });
            }

            return View(stadion);
        }
    }
}
