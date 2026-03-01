using Microsoft.AspNetCore.Mvc;
using TP2_EFCORE.Data;
using TP2_EFCORE.Services;

namespace TP2_EFCORE.Controllers
{
    public class CoursController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CoursService _coursService;

        public CoursController(ApplicationDbContext context, CoursService coursService)
        {
            _context = context;
            _coursService = coursService;
        }

        public async Task<IActionResult> Index() 
        {
            var cours = await _coursService.GetAllAsync();
            return View(cours);
        }

    }
}
