using Microsoft.EntityFrameworkCore;
using TP2_EFCORE.Data;
using TP2_EFCORE.Models;

namespace TP2_EFCORE.Services
{
    public class UtilisateurService
    {
        private readonly ApplicationDbContext _context;

        public UtilisateurService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Utilisateur>> GetAllAsync()
        {
            return await _context.Utilisateurs.ToListAsync();
        }
    }
}
