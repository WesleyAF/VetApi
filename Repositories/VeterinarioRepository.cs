
using Microsoft.EntityFrameworkCore;
using VetApi.Data;
using VetApi.Interfaces.Repositories;
using VetApi.Models;

namespace VetApi.Repositories
{
    public class VeterinarioRepository : Repository<VeterinarioModel>, IVeterinarioRepository
    {
        private readonly AppDbContext _context;
        public VeterinarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<VeterinarioModel> GetVeterinariosWithConsultas(int veterinarioId)
        {
            return await _context.Veterinarios.Include(v => v.Consultas).FirstOrDefaultAsync(v => v.Id == veterinarioId);
        }
    }
}
