using Microsoft.EntityFrameworkCore;
using VetApi.Data;
using VetApi.Interfaces.Repositories;
using VetApi.Models;

namespace VetApi.Repositories
{
    public class DonoRepository : Repository<DonoModel>, IDonoRepository
    {
        private readonly AppDbContext _context;
        public DonoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<DonoModel?> ListAnimalsByOwner(int Id)
        {
            return await _context.Donos.Include(d => d.Animais).FirstOrDefaultAsync(dono => dono.Id == Id);
        }

     
    }
}
