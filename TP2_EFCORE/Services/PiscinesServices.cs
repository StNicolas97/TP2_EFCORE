using TP2_EFCORE.Data;
using TP2_EFCORE.Models;
using Microsoft.EntityFrameworkCore;

namespace TP2_EFCORE.Services
{
    public class PiscinesServices
    {
        private readonly ApplicationDbContext _context;

        public PiscinesServices(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Piscine>> GetAllAsync()
        { 
            return await _context.Piscines.ToListAsync();
        }
    }
}
