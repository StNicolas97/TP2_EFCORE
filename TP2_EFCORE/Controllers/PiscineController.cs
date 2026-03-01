using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TP2_EFCORE.Data;
using TP2_EFCORE.Services;

namespace TP2_EFCORE.Controllers
{
    public class PiscineController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly PiscinesServices _piscinesServices;

        public PiscineController(ApplicationDbContext context, PiscinesServices piscinesServices)
        {
            _context = context;
            _piscinesServices = piscinesServices;
        }

        public async Task<IActionResult> Index() 
        { 
            var piscines = await _piscinesServices.GetAllAsync();
            return View(piscines);
        }
    }
}
