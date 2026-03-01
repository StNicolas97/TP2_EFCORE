using Microsoft.EntityFrameworkCore;
using TP2_EFCORE.Data;
using TP2_EFCORE.Models;

namespace TP2_EFCORE.Services
{
    public class CoursService
    {
        private readonly ApplicationDbContext _context;

        public CoursService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cours>> GetAllAsync()
        {
            return await _context.Cours
                .Include(c => c.CoursPrealable)
                .ToListAsync();
        }
    }
}
