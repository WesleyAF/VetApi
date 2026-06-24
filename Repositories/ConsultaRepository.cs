using Microsoft.EntityFrameworkCore;
using VetApi.Data;
using VetApi.Interfaces.Repositories;
using VetApi.Models;

namespace VetApi.Repositories
{
    public class ConsultaRepository : Repository<ConsultaModel>, IConsultaRepository
    {
        private readonly AppDbContext _context;
        public ConsultaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<ConsultaModel?> BuscarConsultaDonoVeterinario(int id)
        {
            return await _context.Consultas
                .Include(a => a.Animal)
                    .ThenInclude(a => a.Dono)
                .Include(v => v.Veterinario)
                .FirstOrDefaultAsync(consulta => consulta.Id == id);
        }
    }
}
