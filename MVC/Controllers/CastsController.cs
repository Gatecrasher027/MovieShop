using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class CastsController : Controller
    {
        private readonly ICastService _castService;

        public CastsController(ICastService castService)
        {
            _castService = castService;
        }

        public async Task<IActionResult> Index()
        {
            var casts = await _castService.GetAllCastsAsync();
            return View(casts);
        }
    }
}