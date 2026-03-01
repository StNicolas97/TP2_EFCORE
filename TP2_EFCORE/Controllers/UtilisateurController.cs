using Microsoft.AspNetCore.Mvc;
using TP2_EFCORE.Data;
using TP2_EFCORE.Services;

namespace TP2_EFCORE.Controllers
{
    public class UtilisateurController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UtilisateurService _utilisateurService;

        public UtilisateurController(ApplicationDbContext context, UtilisateurService utilisateuService)
        {
            _context = context;
            _utilisateurService = utilisateuService;
        }

        public async Task<IActionResult> Index() 
        {
            var cours = await _utilisateurService.GetAllAsync();
            return View(cours);
        }

    }
}
